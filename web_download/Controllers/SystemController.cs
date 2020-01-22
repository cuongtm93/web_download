using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace webdownload.Controllers
{
    public class SystemController : Controller
    {
        public Bitmap MakeSquarePhoto(Bitmap bmp, int size)
        {
            try
            {
                Bitmap res = new Bitmap(size, size);
                Graphics g = Graphics.FromImage(res);
                g.FillRectangle(new SolidBrush(Color.White), 0, 0, size, size);
                int t = 0, l = 0;
                if (bmp.Height > bmp.Width)
                    t = (bmp.Height - bmp.Width) / 2;
                else
                    l = (bmp.Width - bmp.Height) / 2;
                g.DrawImage(bmp, new Rectangle(0, 0, size, size), new Rectangle(l, t, bmp.Width - l * 2, bmp.Height - t * 2), GraphicsUnit.Pixel);
                return res;
            }
            catch
            {
                return null;
            }
        }
        public JsonResult MakeSquares()
        {
            string rootContentDir = AppDomain.CurrentDomain.GetData("DataDirectory").ToString();
            string image_dir = rootContentDir + "/wwwroot/assets/images";
            var files = System.IO.Directory.GetFiles(image_dir, "*.jpeg");
            var proc = new List<string>();
            foreach (var file in files)
            {
                var bitmap = (Bitmap)System.Drawing.Bitmap.FromFile(file);
                if (bitmap.Width >= 50)
                {
                    bitmap = MakeSquarePhoto(bitmap, 50);
                }
                bitmap.Save(file + "50_50.jpeg", System.Drawing.Imaging.ImageFormat.Jpeg);
                proc.Add(file);
                bitmap.Dispose();

            }
            return Json(proc);
        }
    }
}