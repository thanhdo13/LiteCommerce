using LiteCommerce.BusinessLayers;
using LiteCommerce.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace LiteCommerce.Admin.Controllers
{
    [Authorize(Roles = WebUserRoles.DataManagement)]
    public class AttributeController : Controller
    {
        // GET: Attribute
        public ActionResult Index(string id="")
        {
            int productID = Convert.ToInt32(id);
            List<Attributes> model = CataLogBLL.GetListAttribute(productID);
            return View(model);
        }
        [HttpPost]
        public ActionResult Update(Attributes model)
        {
            if (string.IsNullOrEmpty(model.AttributeName))
                ModelState.AddModelError("AttributeName", "AttributeName expected");
            if (string.IsNullOrEmpty(model.Color))
                ModelState.AddModelError("QuantityPerUnit", "QuantityPerUnit expected");
            if (string.IsNullOrEmpty(model.Size))
                ModelState.AddModelError("Size", "Size expected");
            if (!ModelState.IsValid)
            {
                ViewBag.Title = "Edit Attribute";
                //return View(model);
            }
            CataLogBLL.UpdateAttribute(model);
            return RedirectToAction("Index", new{ id = model.ProductID});
        }
        public ActionResult Delete(string attributeID)
        {

            return RedirectToAction("Index", new { id = 86});
        }

        }
}