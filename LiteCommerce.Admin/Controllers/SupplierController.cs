using LiteCommerce.BusinessLayers;
using LiteCommerce.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LiteCommerce.Admin.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Authorize(Roles =WebUserRoles.DataManagement)]
    public class SupplierController : Controller
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        // GET: Supplier

        public ActionResult Index(int page = 1, string searchValue = "")
        {
            int pageSize = 3;
            int rowCount = 0;
            List<Supplier> listOfSupplier = CataLogBLL.ListOfSupplier(page, pageSize, searchValue, out rowCount);
            var model = new Models.SupplierPaginationResult()
            {
                Page = page,
                PageSize = pageSize,
                RowCount = rowCount,
                Data = listOfSupplier,
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
                    ViewBag.Title = " Create new Supplier";
                    Supplier newSupplier = new Supplier()
                    {
                        SupplierID = 0
                    };
                    return View(newSupplier);
                }
                else
                {
                    ViewBag.Title = "Edit a Supplier";
                    Supplier editSupplier = CataLogBLL.GetSupplier(Convert.ToInt32(id));
                    if (editSupplier == null)
                    {
                        return RedirectToAction("Index");
                    }
                    return View(editSupplier);
                }
               // return View();

            }
            catch (Exception ex)
            {
                return Content(ex.Message + "" + ex.StackTrace);
            }
        }
        [HttpPost]
        public ActionResult Input(Supplier model)
        {
            try { 
            //TODO: kiem tra tinh hop le cua du lieu 
            if (string.IsNullOrEmpty(model.CompanyName))
                ModelState.AddModelError("CompanyName", "CompanyName expected");
            if (string.IsNullOrEmpty(model.ContactName))
                ModelState.AddModelError("ContactName", "ContactName expected");
            if (string.IsNullOrEmpty(model.ContactTitle))
                ModelState.AddModelError("ContactTitle", "ContactTitle expected");
            if (string.IsNullOrEmpty(model.Address))
                model.Address="";
            if (string.IsNullOrEmpty(model.City))
                model.City = "";
            if (string.IsNullOrEmpty(model.Country))
                model.Country = "";
            if (string.IsNullOrEmpty(model.Fax))
                model.Fax = "";
            if (string.IsNullOrEmpty(model.HomePage))
                model.HomePage = "";
            if (string.IsNullOrEmpty(model.Phone))
                model.Phone = "";
            if (!ModelState.IsValid)
            {
                    ViewBag.Title = model.SupplierID == 0 ? "Create new Supplier" : "Edit a Supplier";
                return View(model);
            }
            //TODO: Luu
            if (model.SupplierID == 0)
                {
                    CataLogBLL.AddSupplier(model);
                }
                else
                {
                    CataLogBLL.UpdateSupplier(model);
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Loi", ex.StackTrace);
                return View(model);
            }

        }
        /// <summary>
        /// Xoa nhieu supplier
        /// </summary>
        /// <param name="supplierIDs"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Delete(int[] supplierIDs= null)
        {
            if(supplierIDs != null)
            {
                CataLogBLL.DeleteSuppliers(supplierIDs);
            }
            return RedirectToAction("Index");
        }
    }
}