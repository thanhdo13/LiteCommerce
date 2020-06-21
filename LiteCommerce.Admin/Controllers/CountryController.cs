using LiteCommerce.BusinessLayers;
using LiteCommerce.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LiteCommerce.Admin.Controllers
{
    [Authorize(Roles = WebUserRoles.DataManagement)]
    public class CountryController : Controller
    {
        // GET: Country
        public ActionResult Index(int page = 1, string searchValue = "")
        {
            int pageSize = 3;
            int rowCount = 0;
            List<Country> listOfCountry = CataLogBLL.ListOfCountries(page,pageSize, searchValue,out rowCount);
            var model = new Models.CountryPaginationResult()
            {
                Page = page,
                PageSize = pageSize,
                RowCount = rowCount,
                Data = listOfCountry,
                SearchValue = searchValue

            };
            return View(model);
        }
        [HttpGet]
        public ActionResult Input(string id = "")
        {
            try
            {
                if (string.IsNullOrEmpty(id))
                {
                    ViewBag.Title = "Create new Country";
                    Country newCountry = new Country()
                    {
                        CountryID = 0
                    };
                    return View(newCountry);
                }
                else
                {
                    ViewBag.Title = "Edit a Country";
                    Country editCountry = CataLogBLL.GetCountry(Convert.ToInt32(id));
                    if (editCountry == null)
                    {
                        return RedirectToAction("Index");
                    }
                    return View(editCountry);
                }
            }
            catch (Exception ex)
            {
                return Content(ex.Message + "" + ex.StackTrace);
            }
        }
        [HttpPost]
        public ActionResult Input(Country model)
        {
            try
            {
                //TODO: kiem tra tinh hop le cua du lieu 
                if (string.IsNullOrEmpty(model.CountryName))
                    ModelState.AddModelError("CountryName", "CountryName expected");
                
                if (!ModelState.IsValid)
                {
                    ViewBag.Title = model.CountryID == 0 ? "Create new Country" : "Edit a Country";
                    return View(model);
                }
                //TODO: Luu
                if (model.CountryID == 0)
                {
                    CataLogBLL.AddCountry(model);
                }
                else
                {
                    CataLogBLL.UpdateCountry(model);
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Loi", ex.StackTrace);
                return View(model);
            }
        }
        [HttpPost]
        public ActionResult Delete(int[] countryIDs = null)
        {
            if (countryIDs != null)
            {
                CataLogBLL.DeleteCountries(countryIDs);
            }
            return RedirectToAction("Index");
        }
    }
}