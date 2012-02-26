using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using com.google.zxing;
using COMMON = com.google.zxing.common;
using System.Drawing.Imaging;

namespace WeddingLibrary.QRC
{
    public class Util
    {
        public static void Display(System.Web.HttpResponse response, string contents)
        {
            COMMON.ByteMatrix byteMatrix = new MultiFormatWriter().encode(contents, BarcodeFormat.QR_CODE, 350, 350);
            Display(response, byteMatrix, ImageFormat.Jpeg, false);
        }

        public static void Display(System.Web.HttpResponse response, COMMON.ByteMatrix matrix, System.Drawing.Imaging.ImageFormat format, bool isAppendImage)
        {
            response.ClearContent();
            response.ContentType = "image/Jpeg";
            response.BinaryWrite(GetBytes(matrix, format, isAppendImage));
            response.End();
        }

        public static byte[] GetBytes(COMMON.ByteMatrix matrix, System.Drawing.Imaging.ImageFormat format, bool isAppendImage)
        {
            Bitmap bmap = toBitmap(matrix);
            if (isAppendImage)
            {
                Graphics g = Graphics.FromImage(bmap);
                string f = string.Concat(System.Web.HttpContext.Current.Server.MapPath("."), "\\include\\append.png");
                Util.AddWatermarkImage(g, f, "CENTER", 300, 300);
            }
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            bmap.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            bmap.Dispose();
            return ms.ToArray();
        }

        public static void WriteToFile(COMMON.ByteMatrix matrix, System.Drawing.Imaging.ImageFormat format, string file, bool isAppendImage)
        {
            Bitmap bmap = toBitmap(matrix);
            if (isAppendImage)
            {
                Graphics g = Graphics.FromImage(bmap);
                string f = string.Concat(System.Web.HttpContext.Current.Server.MapPath("."), "\\include\\append.png");
                Util.AddWatermarkImage(g, f, "CENTER", 300, 300);
            }
            bmap.Save(file, format);
        }

        public static Bitmap toBitmap(COMMON.ByteMatrix matrix)
        {
            int width = matrix.Width;
            int height = matrix.Height;
            Bitmap bmap = new Bitmap(width, height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    bmap.SetPixel(x, y, matrix.get_Renamed(x, y) != -1 ? ColorTranslator.FromHtml("0xFF000000") : ColorTranslator.FromHtml("0xFFFFFFFF"));
                }
            }
            return bmap;
        }

        public static void AddWatermarkImage(Graphics picture, string WaterMarkPicPath, string _watermarkPosition, int _width, int _height)
        {
            System.Drawing.Image watermark = new Bitmap(WaterMarkPicPath);
            ImageAttributes imageAttributes = new ImageAttributes();
            ColorMap colorMap = new ColorMap();
            colorMap.OldColor = Color.FromArgb(255, 0, 255, 0);
            colorMap.NewColor = Color.FromArgb(0, 0, 0, 0);
            ColorMap[] remapTable = { colorMap };
            imageAttributes.SetRemapTable(remapTable, ColorAdjustType.Bitmap);
            float[][] colorMatrixElements = {

                                                new float[] {1.0f,  0.0f,  0.0f,  0.0f, 0.0f},

                                                new float[] {0.0f,  1.0f,  0.0f,  0.0f, 0.0f},

                                                new float[] {0.0f,  0.0f,  1.0f,  0.0f, 0.0f},

                                                new float[] {0.0f,  0.0f,  0.0f,  0.3f, 0.0f},

                                                new float[] {0.0f,  0.0f,  0.0f,  0.0f, 1.0f}

                                            };
            ColorMatrix colorMatrix = new ColorMatrix(colorMatrixElements);
            imageAttributes.SetColorMatrix(colorMatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
            int xpos = 0;
            int ypos = 0;
            int WatermarkWidth = 0;
            int WatermarkHeight = 0;

            double bl = 1d;
            if ((_width > watermark.Width * 4) && (_height > watermark.Height * 4))
            {
                bl = 1;
            }

            else if ((_width > watermark.Width * 4) && (_height < watermark.Height * 4))
            {
                bl = Convert.ToDouble(_height / 4) / Convert.ToDouble(watermark.Height);
            }
            else
                if ((_width < watermark.Width * 4) && (_height > watermark.Height * 4))
                {
                    bl = Convert.ToDouble(_width / 4) / Convert.ToDouble(watermark.Width);
                }
                else
                {
                    if ((_width * watermark.Height) > (_height * watermark.Width))
                    {
                        bl = Convert.ToDouble(_height / 4) / Convert.ToDouble(watermark.Height);
                    }
                    else
                    {
                        bl = Convert.ToDouble(_width / 4) / Convert.ToDouble(watermark.Width);
                    }
                }
            WatermarkWidth = Convert.ToInt32(watermark.Width * bl);
            WatermarkHeight = Convert.ToInt32(watermark.Height * bl);
            switch (_watermarkPosition)
            {
                case "WM_TOP_LEFT":
                    xpos = 10;
                    ypos = 10;
                    break;
                case "WM_TOP_RIGHT":
                    xpos = _width - WatermarkWidth - 10;
                    ypos = 10;
                    break;
                case "WM_BOTTOM_RIGHT":
                    xpos = _width - WatermarkWidth - 10;
                    ypos = _height - WatermarkHeight - 10;
                    break;
                case "WM_BOTTOM_LEFT":
                    xpos = 10;
                    ypos = _height - WatermarkHeight - 10;
                    break;
                case "CENTER":
                    xpos = Convert.ToInt32((picture.VisibleClipBounds.Width / 2) - (WatermarkWidth / 2));
                    ypos = Convert.ToInt32(picture.VisibleClipBounds.Height / 2 - WatermarkHeight / 2);
                    break;
            }
            picture.DrawImage(watermark, new Rectangle(xpos, ypos, WatermarkWidth, WatermarkHeight), 0, 0, watermark.Width, watermark.Height, GraphicsUnit.Pixel, null);
            watermark.Dispose();
            imageAttributes.Dispose();
        }
    }
}
