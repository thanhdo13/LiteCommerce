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
    /// cách phân trang điều phối của shipper
    /// </summary>
    [Authorize(Roles = WebUserRoles.DataManagement)]
    public class ShipperController : Controller
    {
        /// <summary>
        /// trang chủ shipper
        /// </summary>
        /// <returns></returns>
        // GET: Shipper
        public ActionResult Index(int page = 1, string searchValue = "")
        {
            int pageSize = 3;
            int rowCount = 0;
            List<Shipper> listOfShipper = CataLogBLL.ListOfShipper(page, pageSize, searchValue, out rowCount);
            var model = new Models.ShipperPaginationResult()
            {
                Page = page,
                PageSize = pageSize,
                RowCount = rowCount,
                Data = listOfShipper,
                SearchValue = searchValue
            };
            //  int pagesize = 3;
            // int rowcount = 0;
            // list<supplier> model = catalogbll.listofsupplier(page, pagesize, searchvalue, out rowcount);
            //  viewbag.rowcount = rowcount;
            return View(model);
        }
        /// <summary>
        /// hiển thị trang thêm hoặc lấy ra thông tin của 1 shipper
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Input(string id = "")
        {
            try { 
            
                if (string.IsNullOrEmpty(id))
            {
                ViewBag.Title = " Create new Shipper";
                    Shipper newShipper = new Shipper()
                    {
                        ShipperID = 0
                    };
                    return View(newShipper);
                }
            else
            {
                ViewBag.Title = "Edit a Shipper";
                    Shipper editShipper = CataLogBLL.GetShipper(Convert.ToInt32(id));
                    if (editShipper == null)
                    {
                        return RedirectToAction("Index");
                    }
                    return View(editShipper);
                }
            }catch(Exception ex)
            {
                return Content(ex.Message + "" + ex.StackTrace);
            }
        }
        /// <summary>
        /// cập nhật hoặc thêm 1 shipper
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Input(Shipper model)
        {
            try
            {
                if (string.IsNullOrEmpty(model.CompanyName))
                    ModelState.AddModelError("CompanyName", "CompanyName expected");
                if (string.IsNullOrEmpty(model.Phone))
                    model.Phone = "";
                if (!ModelState.IsValid)
                {
                    ViewBag.Title = model.ShipperID == 0 ? "Create new Shipper" : "Edit a Shipper";
                    return View(model);
                }
                if (model.ShipperID == 0)
                {
                    CataLogBLL.AddShipper(model);
                }
                else
                {
                    CataLogBLL.UpdateShipper(model);
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
        /// Xóa nhiều shipper
        /// </summary>
        /// <param name="shipperIDs"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Delete(int[] shipperIDs = null)
        {
            if (shipperIDs != null)
            {
                CataLogBLL.DeleteShippers(shipperIDs);
            }
            return RedirectToAction("Index");
        }
    }
}