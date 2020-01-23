using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
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
            model.Top_Softwares = db.TblSoftware.OrderByDescending(r => r.downloaded).Take(8).ToList();
            return View(model);
        }

        [Route("chuyen-muc/{url}/{page}")]
        public IActionResult category_details(string url, int page)
        {
            const int perpage = 2;
            var category = db.TblCategory.SingleOrDefault(r => r.url == url);
            var softwares = db.TblSoftware.Where(r => r.categoryID == category.ID)
                .OrderByDescending(r => r.downloaded)
                .ThenByDescending(r => r.viewed)
                .Skip((page - 1) * perpage)
                .Take(perpage).ToList();

            int CalcPagesCount()
            {
                var total_software = db.TblSoftware.Where(r => r.categoryID == category.ID).Count();
                int totalPage = total_software / perpage;

                // add the last page, ugly
                if (total_software % perpage != 0) totalPage++;
                return totalPage;
            }


            var model = new HomeCategoryDetailsViewmodel()
            {
                total_page = (int)CalcPagesCount(),
                page_index = page,
                Category = category,
                Softwares = softwares,
            };
            model.Top_Softwares = db.TblSoftware.OrderByDescending(r => r.downloaded).Take(8).ToList();
         return View(model);
        }

        public IActionResult category_dropdown(string url)
        {
            var category = db.TblCategory.Single(r => r.url == url);
            var model = db.TblCategory.Where(r => r.ParentID == category.ID).ToList();
            return View(model);
        }

        [Route("phan-mem/{url}")]
        public IActionResult Details(string url)
        {
            var download = db.TblSoftware.Single(r => r.short_url == url);
            download.viewed += 1;
            db.SaveChanges();
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
                return View("search2_partial", model);
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
            download.downloaded += 1;
            db.SaveChanges();
            return View(download);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
