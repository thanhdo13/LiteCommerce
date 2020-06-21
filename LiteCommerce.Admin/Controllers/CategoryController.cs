using LiteCommerce.BusinessLayers;
using LiteCommerce.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LiteCommerce.Admin.Controllers
{/// <summary>
 /// 
 /// </summary>
 /// 
    [Authorize(Roles =WebUserRoles.DataManagement)]
    public class CategoryController : Controller
    {
        // GET: Category
        /// <summary>
        /// 
        /// </summary>
       

        public ActionResult Index(int page = 1, string searchValue = "")
        {
            int pageSize = 3;
            int rowCount = 0;
            List<Category> listOfCategory = CataLogBLL.ListOfCategory(page, pageSize, searchValue, out rowCount);
            var model = new Models.CategoryPaginationResult()
            {
                Page = page,
                PageSize = pageSize,
                RowCount = rowCount,
                Data = listOfCategory,
                SearchValue = searchValue
            };
            //  int pagesize = 3;
            // int rowcount = 0;
            // list<supplier> model = catalogbll.listofsupplier(page, pagesize, searchvalue, out rowcount);
            //  viewbag.rowcount = rowcount;
            return View(model);
        }
        [HttpGet]
        public ActionResult Input(string id = "")
        {
            try
            {
                if (string.IsNullOrEmpty(id))
                {
                    ViewBag.Title = "Create new Category";
                    Category newCategory = new Category()
                    {
                        CategoryID = 0
                    };
                    return View(newCategory);
                }
                else
                {
                    ViewBag.Title = "Edit a Category";
                    Category editCategory = CataLogBLL.GetCategory(Convert.ToInt32(id));
                    if (editCategory == null)
                    {
                        return RedirectToAction("Index");
                    }
                    return View(editCategory);
                }
            }
            catch (Exception ex)
            {
                return Content(ex.Message + "" + ex.StackTrace);
            }
        }
        [HttpPost]
        public ActionResult Input(Category model)
        {
            try
            {
                //TODO: kiem tra tinh hop le cua du lieu 
                if (string.IsNullOrEmpty(model.CategoryName))
                    ModelState.AddModelError("CategoryName", "CategoryName expected");
                if (string.IsNullOrEmpty(model.Description))
                    model.Description = "";
                if (!ModelState.IsValid)
                {
                    ViewBag.Title = model.CategoryID == 0 ? "Create new Category" : "Edit a Category";
                    return View(model);
                }
                //TODO: Luu
                if (model.CategoryID == 0)
                {
                    CataLogBLL.AddCategory(model);
                }
                else
                {
                    CataLogBLL.UpdateCategory(model);
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Loi", ex.StackTrace);
                return View(model);
            }
        }
        [HttpPost]
        public ActionResult Delete(int[] categoryIDs = null)
        {
            if (categoryIDs != null)
            {
                CataLogBLL.DeleteCategories(categoryIDs);
            }
            return RedirectToAction("Index");
        }
    }
}