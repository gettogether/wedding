using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using WeddingLibrary.Database.DataObject;
using WeddingLibrary.Database.BusinessObject;
using System.Web.SessionState;

namespace WeddingLibrary.App.ashx
{
    public class User : IHttpHandler, IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            //context.Response.ContentType = "text/plain";
            try
            {
                string operaType = context.Request["operation"];
                if (!string.IsNullOrEmpty(operaType))
                {
                    operaType = operaType.Trim().ToLower();
                    if (operaType == "login")
                    {
                        string email = context.Request["email"];
                        string pwd = context.Request["pwd"];
                        if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(pwd))
                        {
                            context.Response.Write(AppResult<string>.GetResult("錯誤的參數(郵箱/密碼為空)"));
                        }
                        else
                        {
                            email = email.Trim();
                            pwd = pwd.Trim();
                            
                            //DO_Login.UO_Login uoLogin = BO_Login.GetObjectByEamilAndPassword(email, pwd);
                            WeddingLibrary.Profiles.Entities.UO_User login = WeddingLibrary.Profiles.Imp.Login.GetLogin(email, pwd);
                            if (login != null)
                            {
                                WeddingLibrary.App.Login appLg = new WeddingLibrary.App.Login();
                                DataMapping.ObjectHelper.CopyAttributes<WeddingLibrary.Profiles.Entities.UO_User, WeddingLibrary.App.Login>(login, appLg);
                                AppResult<WeddingLibrary.App.Login> ar = new AppResult<WeddingLibrary.App.Login>(appLg, string.Empty);
                                string jsonStr = Newtonsoft.Json.JsonConvert.SerializeObject(ar);
                                WeddingLibrary.SessionObject sess = new WeddingLibrary.SessionObject();
                                sess.Profile = new WeddingLibrary.Profiles.LoginProfile();
                                sess.Profile.LoginUser = login;
                                WeddingLibrary.SessionHelper.SetSession(sess);
                                context.Response.Write(jsonStr);
                            }
                            else
                            {
                                context.Response.Write(AppResult<string>.GetResult("錯誤的郵箱/密碼"));
                            }
                        }
                    }
                    else if (operaType == "register")
                    {
                        DO_Login.UO_Login addLogin = new DO_Login.UO_Login();
                        CommonLibrary.WebObject.WebHelper.SetValues<DO_Login.UO_Login>(addLogin, "RG_");
                        string error = string.Empty;
                        if (!string.IsNullOrEmpty(addLogin.LoginEmail))
                        {
                            if (BO_Login.GetObject(addLogin.LoginEmail) == null)
                            {
                                if (!string.IsNullOrEmpty(addLogin.LoginPassword))
                                    addLogin.LoginPassword = WeddingLibrary.Functions.Common.DesEncrypt(addLogin.LoginPassword);
                                System.Data.IDbConnection conn = addLogin.GetConnection();
                                System.Data.IDbTransaction tran = conn.BeginTransaction();
                                bool success = false;
                                try
                                {
                                    addLogin.CreateBy = addLogin.LoginEmail;
                                    if (addLogin.Insert(conn, tran) > 0)
                                    {
                                        DO_BigDate.UO_BigDate bigDate = new DO_BigDate.UO_BigDate();
                                        CommonLibrary.WebObject.WebHelper.SetValues<DO_BigDate.UO_BigDate>(bigDate, "RG_");
                                        bigDate.CreateBy = addLogin.LoginEmail;
                                        int bigDateIndex = bigDate.GetRecordsCount() + 1;
                                        //bigDate.BigDateCode = string.Concat(DateTime.Now.ToString("yyyyMMddHHmmssfff"), bigDateIndex.ToString());
                                        bigDate.BigDateCode = bigDateIndex.ToString("00000");
                                        if (bigDate.Insert(conn, tran) > 0)
                                        {
                                            DO_BigDateDetail.UO_BigDateDetail bigDateDetail = new DO_BigDateDetail.UO_BigDateDetail();
                                            bigDateDetail.BigDateCode = bigDate.BigDateCode;
                                            bigDateDetail.Email = addLogin.LoginEmail;
                                            bigDateDetail.CreateBy = addLogin.LoginEmail;
                                            if (bigDateDetail.Insert(conn, tran) > 0)
                                            {
                                                success = true;
                                            }
                                        }
                                    }
                                    if (success)
                                    {
                                        tran.Commit();
                                    }
                                }
                                catch (Exception ex)
                                {
                                    tran.Rollback();
                                    error = ex.Message;
                                }
                                finally
                                {
                                    conn.Close();
                                }
                            }
                            else
                            {
                                error = "郵箱已經被使用";
                            }
                        }
                        else
                        {
                            error = "參數錯誤";
                        }
                        //error = Newtonsoft.Json.JsonConvert.SerializeObject(addLogin);
                        context.Response.Write(AppResult<string>.GetResult(error));
                    }
                    else
                    {
                        context.Response.Write(AppResult<string>.GetResult("參數錯誤(未知參數)"));
                    }
                }
                else
                {
                    context.Response.Write(AppResult<string>.GetResult("參數錯誤"));
                }
            }
            catch (Exception ex)
            {
                Logging.Files.Log.Error(ex);
                context.Response.Write(AppResult<string>.GetResult(ex.Message));
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

    }
}


