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
    /// 
    [Authorize(Roles = WebUserRoles.SaleMan)]
    public class OrderController : Controller
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        // GET: List
        public ActionResult Index(int page = 1, string searchValue = "")
        {
            int pageSize = 3;
            int rowCount = 0;
            List<Order> listOfOrder = CataLogBLL.ListOfOrder(page, pageSize, searchValue, out rowCount);
            var model = new Models.OrderPaginationResult()
            {
                Page = page,
                PageSize = pageSize,
                RowCount = rowCount,
                Data = listOfOrder,
                SearchValue = searchValue
            };
            //  int pagesize = 3;
            // int rowcount = 0;
            // list<supplier> model = catalogbll.listofsupplier(page, pagesize, searchvalue, out rowcount);
            //  viewbag.rowcount = rowcount;
            return View(model);
        }
        public ActionResult Create(string id = "")
        {
            if (string.IsNullOrEmpty(id))
            {
                ViewBag.Title = " Create new Order";
            }
            else
            {
                ViewBag.Title = "Edit a Order";
            }
            return View();
        }
    }
}