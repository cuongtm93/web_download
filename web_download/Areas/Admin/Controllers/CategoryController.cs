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
    public class CategoryController : Controller
    {
        private webdownload.Models.WebDownloadDbContext db = new webdownload.Models.WebDownloadDbContext();
        
        public IActionResult Index()
        {
            var model = new List<CategoryIndexViewmodel>();
            foreach (var item in db.TblCategory.ToList())
            {
                var _new = new CategoryIndexViewmodel()
                {
                    Icon = item.icon,
                    Id = item.ID,
                    Name = item.name,
                    Order = item.order,
                    Url = item.url,
                };
                if (item.ParentID.HasValue)
                {
                    _new.ParentCategory = db.TblCategory.Find(item.ParentID);
                }
                model.Add(_new);
            }
            return View(model.ToList());
        }
        public IActionResult Delete(int ID)
        {
            var item = db.TblCategory.Find(ID);
            db.Remove(item);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int ID)
        {
            var cat = db.TblCategory.Find(ID);
            var model = new CategoryIndexViewmodel()
            {
                Icon = cat.icon,
                Id = cat.ID,
                Name = cat.name,
                Order = cat.order,
                Url = cat.url,
                text = cat.text
            };
            if (cat.ParentID.HasValue)
            {
                model.ParentCategory = db.TblCategory.Find(cat.ParentID);
            }
            model.TopCategories = db.TblCategory.Where(r => r.ParentID.HasValue == false).ToList();

            return View(model);
        }
        public IActionResult Edit_Proc(TblCategory model)
        {
            db.Entry(model).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}