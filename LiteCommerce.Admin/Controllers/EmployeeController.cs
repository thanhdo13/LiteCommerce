using LiteCommerce.BusinessLayers;
using LiteCommerce.DomainModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LiteCommerce.Admin.Controllers
{/// <summary>
/// 
/// </summary>
    public class EmployeeController : Controller
    {/// <summary>
     /// 
     /// </summary>
     /// <returns></returns>
        // GET: Employee
        [Authorize(Roles = WebUserRoles.AccountAdministrationStaff)]
        public ActionResult Index(int page = 1, string searchValue = "")
        {
            int pageSize = 3;
            int rowCount = 0;
            List<Employee> listOfEmployee = CataLogBLL.ListOfEmployee(page, pageSize, searchValue, out rowCount);
            var model = new Models.EmployeePaginationResult()
            {
                Page = page,
                PageSize = pageSize,
                RowCount = rowCount,
                Data = listOfEmployee,
                SearchValue = searchValue
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
            try
            {
                if (string.IsNullOrEmpty(id))
                {
                    ViewBag.Title = " Create new Employee";
                    Employee newEmployee = new Employee()
                    {
                        EmployeeID = 0
                    };
                    return View(newEmployee);
                }
                else
                {
                    ViewBag.Title = "Edit a Employee";
                    Employee editEmployee = CataLogBLL.GetEmployee(Convert.ToInt32(id));
                    if (editEmployee == null)
                    {
                        return RedirectToAction("Index");
                    }
                    return View(editEmployee);
                }
               // return View();
            }catch(Exception ex)
            {
                return Content(ex.Message + "" + ex.StackTrace);
            }
        }
        [HttpPost]
        public ActionResult Input(Employee model,HttpPostedFileBase uploadFile, string EmailNew)
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
                
                if (string.IsNullOrEmpty(model.FirstName))
                    ModelState.AddModelError("FirstName", "FirstName expected");
                if (string.IsNullOrEmpty(model.LastName))
                    ModelState.AddModelError("LastName", "LastName expected");
                if (string.IsNullOrEmpty(model.Title))
                    ModelState.AddModelError("Title", "Title expected");
                if (string.IsNullOrEmpty(EmailNew))
                    ModelState.AddModelError("Email", "Email expected!");
                if (string.IsNullOrEmpty(model.Address))
                    model.Address = "";
                if (string.IsNullOrEmpty(model.City))
                    model.City = "";
                if (string.IsNullOrEmpty(model.Country))
                    model.Country = "";
                if (string.IsNullOrEmpty(model.HomePhone))
                    model.HomePhone = "";
                if (string.IsNullOrEmpty(model.Notes))
                    model.Notes = "";
                if (string.IsNullOrEmpty(model.PhotoPath))
                    model.PhotoPath = "";
                if (string.IsNullOrEmpty(model.Password))
                    model.Password = "";
                if (CataLogBLL.CheckEmail(EmailNew) != 0 && EmailNew.Equals(model.Email)==false)
                {
                    ModelState.AddModelError("Email", "Email đã có người dùng!");
                    ViewBag.Title = model.EmployeeID == 0 ? "Create new Employee" : "Edit a Employee";
                    Employee editEmployee = CataLogBLL.GetEmployee(Convert.ToInt32(model.EmployeeID));
                    return View(editEmployee);
                }
                else
                {
                    model.Email = EmailNew;
                }
                if (!ModelState.IsValid)
                {
                    //ViewBag.Title = model.SupplierID = 0 ?
                    ViewBag.Title = model.EmployeeID == 0 ? "Create new Employee" : "Edit a Employee";
                    Employee editEmployee = CataLogBLL.GetEmployee(Convert.ToInt32(model.EmployeeID));
                    return View(editEmployee);
                }
                //TODO: Luu

                if (model.EmployeeID == 0)
                {
                    CataLogBLL.AddEmployee(model);
                }
                else
                {
                    CataLogBLL.UpdateEmployee(model);
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return Content(ex.Message + "" + ex.StackTrace);
               // return View(model);
            }

        }
        [HttpPost]
        public ActionResult Delete(int[] employeeIDs = null)
        {
            if (employeeIDs != null)
            {
                CataLogBLL.DeleteEmployee(employeeIDs);
            }
            return RedirectToAction("Index");
        }
       
    }
}