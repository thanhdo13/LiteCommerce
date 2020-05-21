﻿using LiteCommerce.BusinessLayers;
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
    [Authorize]
    public class SupplierController : Controller
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        // GET: Supplier
        
        public ActionResult Index()
        {
            int rowCount = 0;
            List<Supplier> model = CatalogBLL.ListOfSupplier(1, 10, "", out rowCount);
            ViewBag.RowCount = rowCount;
            return View(model);
        }
        public ActionResult Input(string id= "")
        {
            if (string.IsNullOrEmpty(id))
            {
                ViewBag.Title = " Create new Supplier";
            }
            else
            {
                ViewBag.Title = "Edit a Supplier";
            }
            return View();
        }
    }
}