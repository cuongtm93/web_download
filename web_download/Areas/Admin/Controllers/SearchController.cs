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
    public class SearchController : Controller
    {
        private readonly WebDownloadDbContext db = new WebDownloadDbContext();
        public IActionResult Index(string keyword)
        {
            var model = new IndexSearchViewmodel();
            var list = db.TblSoftware.Where(r => r.Name.ToLower().Contains(keyword.ToLower())).Take(10);
            model.Keyword = keyword;
            model.Softwares = new List<TblSoftware>();
            model.Softwares = list.ToList();

            model.found = list.Count();
            model.total = db.TblSoftware.Count();
            return View(model);
        }
    }
}