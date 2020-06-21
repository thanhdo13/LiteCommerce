using LiteCommerce.BusinessLayers;
using LiteCommerce.DomainModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LiteCommerce.Admin.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Authorize(Roles = WebUserRoles.DataManagement)]
    public class ProductController : Controller
    {
        // GET: Product
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Index(int page = 1, string searchValue = "", int category = 1, int supplier = 1)
        {
            int pageSize = 3;
            int rowCount = 0;
            List<Product> listOfProduct = CataLogBLL.ListOfProduct(page, pageSize,searchValue, out rowCount,supplier,category);
            var model = new Models.ProductPaginationResult()
            {
                Page = page,
                PageSize = pageSize,
                RowCount = rowCount,
                Data = listOfProduct,
                SearchValue =searchValue,
                Supplier = CataLogBLL.GetSupplier(supplier),
                Category = CataLogBLL.GetCategory(category)
               // Attribute = CataLogBLL.GetAttribute()
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
            if (string.IsNullOrEmpty(id))
            {
                ViewBag.Title = " Create new Product";
                Product newProduct = new Product()
                {
                    ProductID = 0

                };
                 return View(newProduct);
        }
            else
            {
                ViewBag.Title = "Edit a Product";
                Product editProduct = CataLogBLL.GetProduct(Convert.ToInt32(id));
                if (editProduct == null)
                {
                    return RedirectToAction("Index");
                }
                return View(editProduct);
            }
           
        }
        [HttpPost]
        public ActionResult Input(Product model, HttpPostedFileBase uploadFile)
        {
            // Up anh
            if (uploadFile != null)
            {
                string fileName = $"{DateTime.Now.Ticks}{Path.GetExtension(uploadFile.FileName)}";
                // string _fileName = string.Format{"{0}{1}"} $"{DateTime.Now.Ticks}{Path.GetExtension(uploadFile.FileName)}";
                // string _FileName = Path.GetFileName(uploadFile.FileName);
                string filePath = Path.Combine(Server.MapPath("~/Images"), fileName);
                uploadFile.SaveAs(filePath);
                model.PhotoPath = fileName;
            }
            try
            {
                //TODO: kiem tra tinh hop le cua du lieu 
                if (string.IsNullOrEmpty(model.ProductName))
                    ModelState.AddModelError("ProductName", "ProductName expected");
                if (string.IsNullOrEmpty(model.QuantityPerUnit))
                    ModelState.AddModelError("QuantityPerUnit", "QuantityPerUnit expected");
                if (string.IsNullOrEmpty(model.Descriptions))
                    model.Descriptions = "";
                if (string.IsNullOrEmpty(model.PhotoPath))
                    model.PhotoPath = "";
                if (!ModelState.IsValid)
                {
                    ViewBag.Title = model.SupplierID == 0 ? "Create new Product" : "Edit a Product";
                    return View(model);
                }
                //TODO: Luu
                if (model.ProductID == 0)
                    {
                         CataLogBLL.AddProduct(model);
                    }
                else
                    {
                    CataLogBLL.UpdateProduct(model);
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
        /// <param name="productIDs"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Delete(int[] productIDs = null)
        {
            if (productIDs != null)
            {
                CataLogBLL.DeleteProduct(productIDs);
            }
            return RedirectToAction("Index");
        }
    }
}