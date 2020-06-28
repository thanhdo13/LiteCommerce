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
    /// cách phân trang điều phối của khách hàng
    [Authorize(Roles = WebUserRoles.DataManagement)]
    public class CustomerController : Controller
    {
        // GET: Customer
        /// <summary>
        /// hiển thị trang chủ của khách hàng
        /// </summary>
        /// <returns></returns>
          
        public ActionResult Index(int page = 1, string searchValue = "",string country = "")
        {
            int pageSize = 3;
            int rowCount = 0;
            List<Customer> listOfCustomer = CataLogBLL.ListOfCustomer(page, pageSize, searchValue,country, out rowCount);
            var model = new Models.CustomerPaginationResult()
            {
                Page = page,
                PageSize = pageSize,
                RowCount = rowCount,
                Data = listOfCustomer,
                SearchValue = searchValue,
                Country=country
            
            };
            //  int pagesize = 3;
            // int rowcount = 0;
            // list<supplier> model = catalogbll.listofsupplier(page, pagesize, searchvalue, out rowcount);
            //  viewbag.rowcount = rowcount;
            return View(model);
        }
        /// <summary>
        /// hiển thị trang thêm hoặc lấy ra thông tin của 1 khách hàng
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Input(string id = "")
        {
            try
            {
                if (string.IsNullOrEmpty(id))
                {
                    ViewBag.Title = " Create new Customer";
                    Customer newCustomer = new Customer()
                    {
                        CustomerID = ""
                    };
                    return View(newCustomer);
                }
                else
                {
                    ViewBag.Title = "Edit a Customer";
                    Customer editCustomer = CataLogBLL.GetCustomer(id);
                    return View(editCustomer);
                }  
            }catch(Exception ex)
            {
                return Content(ex.Message + "" + ex.StackTrace);
            }
        }
        /// <summary>
        /// cập nhật hoặc thêm 1 khách hàng
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Input(Customer model)
        {
            try
            {
              
                if (string.IsNullOrEmpty(model.CustomerID))
                    ModelState.AddModelError("CustomerID", "CustomerID expected");
                if (string.IsNullOrEmpty(model.CompanyName))
                    ModelState.AddModelError("CompanyName", "CompanyName expected");
                if (string.IsNullOrEmpty(model.ContactName))
                    ModelState.AddModelError("ContactName", "ContactName expected");
                if (string.IsNullOrEmpty(model.ContactTitle))
                    ModelState.AddModelError("ContactTitle", "ContactTitle expected");
                if (string.IsNullOrEmpty(model.Address))
                    model.Address = "";
                if (string.IsNullOrEmpty(model.City))
                    model.City = "";
                if (string.IsNullOrEmpty(model.Country))
                    model.Country = "";
                if (string.IsNullOrEmpty(model.Fax))
                    model.Fax = "";
                if (string.IsNullOrEmpty(model.Phone))
                    model.Phone = "";
                 if (!ModelState.IsValid)
                {
                    ViewBag.Title = model.CustomerID == "" ? "Create new Customer" : "Edit a Customer";
                    return View(model);
                 }
             
                Customer getCustomer = CataLogBLL.GetCustomer(model.CustomerID);
                if (getCustomer == null)
                {
                   // model.CustomerID = method;
                    CataLogBLL.AddCustomer(model);
                }
                else
                {
                    CataLogBLL.UpdateCustomer(model);
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return Content(ex.Message + "" + ex.StackTrace);
                //ModelState.AddModelError("Loi", ex.StackTrace);
                //return View(model);
            }

        }
        /// <summary>
        /// Xóa nhiều khách hàng
        /// </summary>
        /// <param name="customerIDs"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Delete(string[] customerIDs = null)
        {
            if (customerIDs != null)
            {
                CataLogBLL.DeleteCustomers(customerIDs);
            }
            return RedirectToAction("Index");
        }
    }
}