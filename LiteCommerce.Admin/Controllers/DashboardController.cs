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
    /// Trang Dashboard
    /// </summary>
    [Authorize]
    public class DashboardController : Controller
    {
        // GET: Dashboard
        /// <summary>
        /// thống kê theo năm
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            Dashboard dashboard = new Dashboard();
           
                dashboard = DashboardBLL.ThongKeTienTheoNam(2020);
                dashboard.Year = Convert.ToInt32(2020);
            return View(dashboard);
        }
        /// <summary>
        /// Load lại trang thống kê
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        [HttpGet]
        public JsonResult Input(string year = "")
        {
           
            Dashboard dashboard = DashboardBLL.ThongKeTienTheoNam(Convert.ToInt32(year));
            dashboard.Year = Convert.ToInt32(year);
            return  Json(new { result = dashboard}, JsonRequestBehavior.AllowGet);
        }
    }
}