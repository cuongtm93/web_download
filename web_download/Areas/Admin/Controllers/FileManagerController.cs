using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace webdownload.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class FileManagerController : Controller
    {
        string Encode(string text)
        {
            // Create a SHA256   
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(text));

                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }

        }

        [HttpPost]
        public async Task<JsonResult> Upload_From_ClipboardAsync(string url)
        {
            try
            {
                string rootContentDir = AppDomain.CurrentDomain.GetData("DataDirectory").ToString();
                string image_dir = rootContentDir + "/wwwroot/images";
                WebClient wc = new WebClient();
                var data = wc.DownloadData(url);
                var fileName = Encode(url);
                if (!System.IO.Directory.Exists(image_dir))
                {
                    System.IO.Directory.CreateDirectory(image_dir);
                }
                await System.IO.File.WriteAllBytesAsync(image_dir + "/" + fileName + ".jpg", data);
                return Json(new
                {
                    message = "ok",
                    fullpath = Url.Content("/images/" + fileName + ".jpg")
                });
            }
            catch (Exception)
            {

                return Json(new
                {
                    message = "error",
                });
            }

        }
        [HttpPost]
        public async Task<JsonResult> UploadFile(IFormFile file)
        {
            string rootContentDir = AppDomain.CurrentDomain.GetData("DataDirectory").ToString();
            string image_dir = rootContentDir + "/wwwroot/images";

            if (file == null || file.Length == 0)
                return new JsonResult("file not selected");

            var path = Path.Combine(image_dir,file.FileName);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return Json(new
            {
                message = "ok",
                fullpath = Url.Content("/images/" + file.FileName)
            });
        }
    }
}