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
            var sub_categories = db.TblCategory.Where(r => r.ParentID == cateogry.ID);
            return View(sub_categories);
        }

        public IActionResult sub_category_show_list(string friendly_url, int? page)
        {
            try
            {
                const int per_page = 3;
                var cateogry = db.TblCategory.First(r => r.url == friendly_url);
                ViewBag.Category = cateogry;
                var last_page = 0;
                if ((db.TblSoftware.Count() % per_page) > 0)
                {
                    last_page = db.TblSoftware.Count() / per_page + 1;
                }
                else
                {
                    last_page = db.TblSoftware.Count() / per_page;
                }

                if (page.HasValue == false) page = 1;
                var softwares = new List<TblSoftware>();
                if (page > 0)
                {
                    softwares = db.TblSoftware.Where(r => r.categoryID == cateogry.ID).Skip((page.Value - 1) * per_page).Take(per_page).ToList();
                }
                var parent = db.TblCategory.Single(r => r.ID == cateogry.ParentID);
                ViewBag.Parent = parent;
                cateogry.ParentID = parent.ID;
                var model = new subcategorylist_viewmodel()
                {
                    CategoryID = cateogry.ID,
                    page = page.Value,
                    page_count = last_page,
                    softwares = softwares.ToList()
                };
                return View(model);
            }
            catch (Exception e)
            {
                return Content(e.Message);
            }

        }

        [HttpPost]
        public JsonResult delete_softwares(string[] checkeds)
        {
            try
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
            catch (Exception e)
            {
                return Json(new
                {
                    message = e.InnerException.Message
                });
            }

        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public JsonResult AddNewSoftware_Proc(TblSoftware model)
        {
            try
            {
                int? related_downloadID = null;
                model.DateAdd = DateTime.Now;
                var category_id = int.Parse(Request.Form["categoryID"][0]);
                if (string.IsNullOrWhiteSpace(model.Name))
                {
                    return Json(new
                    {
                        message = "Vui lòng điền tên",
                    });
                }
                model.short_url = FriendlyUrlHelper.GetFriendlyTitle(model.Name);
                model.categoryID = category_id;
                if (Request.Form["related_downloadID"].Count > 0 && !String.IsNullOrWhiteSpace(Request.Form["related_downloadID"][0]))
                {
                    related_downloadID = int.Parse(Request.Form["related_downloadID"][0]);
                    model.related_downloadID = related_downloadID.Value;

                }
                var _new = db.TblSoftware.Add(model);
                db.SaveChanges();
                return Json(new
                {
                    message = "Tạo mới thành công!",
                });
            }
            catch (Exception e)
            {
                return Json(new
                {
                    message = e.Message
                });
            }


        }
        public IActionResult AddNewSoftware(string CategoryId)
        {
            ViewBag.CategoryId = CategoryId;
            return View();
        }

        public IActionResult EditSoftware(int Id)
        {
            var model = db.TblSoftware.Find(Id);
            ViewBag.related_download = db.TblSoftware.Find(model.related_downloadID);
            return View(model);
        }
        public JsonResult EditSoftware_Proc(TblSoftware model)
        {
            try
            {
                var c = db.TblSoftware.Find(model.ID);
                c.icon = model.icon;
                c.main_download = model.main_download;
                c.Name = model.Name;
                if (string.IsNullOrWhiteSpace(c.Name))
                {
                    return Json(new
                    {
                        message = "Vui lòng đặt tên",
                    });
                }
                c.operating_systems = model.operating_systems;
                c.provider = model.provider;
                c.related_downloadID = model.related_downloadID;
                c.text = model.text;
                c.version = model.version;
                c.Visible = model.Visible;
                c.size = model.size;
                c.lience = model.lience;
                db.SaveChanges();
                return Json(new
                {
                    message = "Cập nhật thành công",
                });

            }
            catch (Exception e)
            {
                return Json(new
                {
                    message = e.Message,
                });
                throw;
            }

        }
        [HttpGet]
        public JsonResult Autocomplete(string query)
        {
            var data = db.TblSoftware.Where(r => r.Name.Contains(query)).Select(r => new
            {
                data = r.ID,
                value = r.Name
            });
            return Json(new { query = query, suggestions = data });
        }
    }
}