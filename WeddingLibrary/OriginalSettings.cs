using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace WeddingLibrary
{
    public class OriginalSettings : CommonLibrary.ObjectBase.ConfigBase<OriginalSettings>
    {
        #region Attributes

        private bool _IsDebugMode;

        public bool IsDebugMode
        {
            get { return _IsDebugMode; }
            set { _IsDebugMode = value; }
        }

        private string _LogConfig;

        public string LogConfig
        {
            get { return _LogConfig; }
            set { _LogConfig = value; }
        }

        private string _FilesVersion;

        public string FilesVersion
        {
            get { return _FilesVersion; }
            set { _FilesVersion = value; }
        }

        private string _Version;

        public string Version
        {
            get { return _Version; }
            set { _Version = value; }
        }

        private bool _LogDebug;

        public bool LogDebug
        {
            get { return _LogDebug; }
            set { _LogDebug = value; }
        }

        private bool _EnableErrorReport;

        public bool EnableErrorReport
        {
            get { return _EnableErrorReport; }
            set { _EnableErrorReport = value; }
        }

        private string _ReporterEmail;
        public string ReporterEmail
        {
            get { return _ReporterEmail; }
            set { _ReporterEmail = value; }
        }

        private string _RecipientEmails;
        public string RecipientEmails
        {
            get { return _RecipientEmails; }
            set { _RecipientEmails = value; }
        }

        private bool _LogInfo;
        public bool LogInfo
        {
            get { return _LogInfo; }
            set { _LogInfo = value; }
        }

        private bool _EnableWarningReport;
        public bool EnableWarningReport
        {
            get { return _EnableWarningReport; }
            set { _EnableWarningReport = value; }
        }

        private string _EncrKey;
        public string EncrKey
        {
            get { return _EncrKey; }
            set { _EncrKey = value; }
        }

        private string _CredentialHost;
        public string CredentialHost
        {
            get { return _CredentialHost; }
            set { _CredentialHost = value; }
        }

        private string _CredentialUserName;
        public string CredentialUserName
        {
            get { return _CredentialUserName; }
            set { _CredentialUserName = value; }
        }

        private string _CredentialPassword;
        public string CredentialPassword
        {
            get { return _CredentialPassword; }
            set { _CredentialPassword = value; }
        }

        private bool _EnableCredential;
        public bool EnableCredential
        {
            get { return _EnableCredential; }
            set { _EnableCredential = value; }
        }

        private string _EmailServer;
        public string EmailServer
        {
            get { return _EmailServer; }
            set { _EmailServer = value; }
        }

        private string _LocalHost;
        public string LocalHost
        {
            get { return _LocalHost; }
            set { _LocalHost = value; }
        }

        private int _WebServiceTimeout;
        public int WebServiceTimeout
        {
            get { return _WebServiceTimeout; }
            set { _WebServiceTimeout = value; }
        }

        #endregion

        public OriginalSettings()
        {
        }

        public override void ReadSetting()
        {
            base.ReadSetting();
            CommonLibrary.WebObject.ConfigManager.InitConfig<OriginalSettings>(ref Config.Original, Config.Mode);
        }

        public override void InitSetting()
        {
            base.InitSetting();

           if (!string.IsNullOrEmpty(Config.Original.RecipientEmails))
                Config.RecipientEmails = Config.Original.RecipientEmails.Split(',');
        }

        public override void SaveSetting()
        {
            base.SaveSetting();
            CommonLibrary.WebObject.ConfigManager.WriteConfig<OriginalSettings>(Config.Original, Config.Mode);
        }
    }
}
