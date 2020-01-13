using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using webdownload.Models;

namespace webdownload.Controllers
{
    public class HomeController : Controller
    {
        private WebDownloadDbContext db = new WebDownloadDbContext();
        public IActionResult Index()
        {
            var model = new HomeIndexViewmodel();
            model.News_Softwares = db.TblSoftware.OrderByDescending(r => r.DateAdd).Take(8).ToList();
            return View(model);
        }

        [Route("phan-mem/{url}")]
        public IActionResult Details(string url)
        {
            var download = db.TblSoftware.Single(r => r.short_url == url);
            return View(download);
        }

        [HttpPost]
        public IActionResult Search2(string name)
        {
            List<TblSoftware> model;
            if (string.IsNullOrWhiteSpace(name))
            {
                ViewBag.Count = 0;
                ViewBag.Total = db.TblSoftware.Count();
                model = new List<TblSoftware>();
                return View(model);
            }
            model = db.TblSoftware.Where(r => r.Name.ToLower().Contains(name.ToLower())).Take(8).ToList();
            if (model.Count() == 0) model = new List<TblSoftware>();
            ViewBag.Count = model.Count;
            ViewBag.Total = db.TblSoftware.Count();
            return View(model);
        }

        [HttpPost]
        public IActionResult Search2_autocomplete(string name)
        {
            List<TblSoftware> model;
            if (string.IsNullOrWhiteSpace(name))
            {
                ViewBag.Count = 0;
                ViewBag.Total = db.TblSoftware.Count();
                model = new List<TblSoftware>();
                return View("search2_partial",model);
            }
            model = db.TblSoftware.Where(r => r.Name.ToLower().Contains(name.ToLower())).Take(8).ToList();
            if (model.Count() == 0) model = new List<TblSoftware>();
            ViewBag.Count = model.Count;
            ViewBag.Total = db.TblSoftware.Count();
            return View("search2_partial", model);
        }
        [Route("Download/{url}")]
        public IActionResult Download(string url)
        {
            var download = db.TblSoftware.Single(r => r.short_url == url);
            return View(download);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
