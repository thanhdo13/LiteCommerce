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
    /// <summary>
    /// điều phối thuộc tính của thuộc tính của sản phẩm
    /// </summary>
    [Authorize(Roles = WebUserRoles.DataManagement)]
    public class AttributeController : Controller
    {
        /// <summary>
        /// trang chủ của các thuộc tính
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: Attribute
        public ActionResult Index(string id="")
        {
            int productID = Convert.ToInt32(id);
            List<Attributes> model = CataLogBLL.GetListAttribute(productID);
            return View(model);
        }
        /// <summary>
        /// hiển thị trang thêm , lấy ra và cập nhật luôn thông tin của 1 thuộc tính
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
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
            }
            CataLogBLL.UpdateAttribute(model);
            return RedirectToAction("Index", new{ id = model.ProductID});
        }
        /// <summary>
        /// Xóa nhiều thuộc tính
        /// </summary>
        /// <param name="attributeID"></param>
        /// <returns></returns>
        public ActionResult Delete(int[] attributeIDs, int ProductID)
        {
            if (attributeIDs != null)
            {
                CataLogBLL.DeleteCategories(attributeIDs);
            }
            return RedirectToAction("Index", new { id = ProductID });
        }
        /// <summary>
        /// lấy ra 1 thuộc tính
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Input(string id = "")
        {
            if (string.IsNullOrEmpty(id))
            {
                ViewBag.Title = " Create new Attribute";
                Attributes newAttrribute = new Attributes()
                {
                    AttributeID = 0

                };
                return View(newAttrribute);
            }
            else
            {
                ViewBag.Title = "Edit a Attribute";
                Attributes editAttrribute = CataLogBLL.GetAttribute(Convert.ToInt32(id));
                if (editAttrribute == null)
                {
                    return RedirectToAction("Index");
                }
                return View(editAttrribute);
            }
        }
        }
}