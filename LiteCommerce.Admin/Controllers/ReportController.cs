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
    public class ReportController : Controller
    {
        /// <summary>
        /// trang chủ 
        /// </summary>
        /// <returns></returns>
        // GET: Report
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }
    }
}