using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using webdownload.Areas.Admin.Models;
using webdownload.Models;

namespace webdownload.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    public class DefaultController : Controller
    {
        private readonly WebDownloadDbContext db = new WebDownloadDbContext();
        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult sub_category(string friendly_url)
        {
            var cateogry = db.TblCategory.First(r => r.url == friendly_url);
            var sub_categories = db.TblCategory.Where(r => r.Parent == cateogry);
            return View(sub_categories);
        }

        public IActionResult sub_category_show_list(string friendly_url, int? page)
        {
            const int per_page = 3;
            var cateogry = db.TblCategory.First(r => r.url == friendly_url);
            var last_page = db.TblSoftware.Count() / per_page + 1;
            if (page.HasValue == false) page = last_page;

            var softwares = db.TblSoftware.Where(r => r.category.ID == cateogry.ID).Skip((page.Value - 1) * per_page).Take(per_page).ToList();
            var parentId = db.TblCategory.Where(r => r.ID == cateogry.ID).Select(r=>r.Parent.ID);
            cateogry.Parent = db.TblCategory.First(r => r.ID == parentId.First());
            var model = new subcategorylist_viewmodel()
            {
                Category = cateogry,
                page = page.Value,
                page_count = last_page,
                softwares = softwares.ToList()
            };
            return View(model);
        }

        [HttpPost]
        public JsonResult delete_softwares(string[] checkeds)
        {
            foreach (var id in checkeds)
            {
                var val = int.Parse(id);
                var item = db.TblSoftware.First(r => r.ID == val);
                db.TblSoftware.Remove(item);
                db.SaveChanges();
            }
            return Json(new
            {
                message = "ok"
            });
        }
    }
}