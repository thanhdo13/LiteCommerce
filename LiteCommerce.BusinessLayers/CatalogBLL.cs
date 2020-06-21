using LiteCommerce.DataLayers;
using LiteCommerce.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiteCommerce.BusinessLayers
{
    /// <summary>
    /// Các chứa năng xử lú nghiệp vụ liên quan đến
    /// quản lý dữ liêu chung của hệ thống như : nhà cung cấp,...
    /// </summary>
    public static class CataLogBLL
    {
        /// <summary>
        /// Hamf phai duoc goi de khoi tao chuc nang tac nhghiep
        /// </summary>
        /// <param name="connectionString"></param>
        public static void Initialize(string connectionString)
        {
            SupplierDB = new DataLayers.SqlServer.SupplierDAL(connectionString);
            CustomerDB = new DataLayers.SqlServer.CustomerDAL(connectionString);
            ShipperDB = new DataLayers.SqlServer.ShipperDAL(connectionString);
            CategoryDB = new DataLayers.SqlServer.CategoryDAL(connectionString);
            EmployeeDB = new DataLayers.SqlServer.EmployeeDAL(connectionString);
            OrderDB = new DataLayers.SqlServer.OrderDAL(connectionString);
            ProductDB = new DataLayers.SqlServer.ProductDAL(connectionString);
            AttributeDB = new DataLayers.SqlServer.AtrributeDAL(connectionString);
            HelperDB = new DataLayers.SqlServer.HelperDAL(connectionString);

        }
        #region Khai báo các thuộc tính giao tiếp với DAL
        private static  ISupplierDAL SupplierDB { get; set; }
        private static ICustomerDAL CustomerDB { get; set; }
        private static IShipperDAL ShipperDB { get; set; }
        private static ICategoryDAL CategoryDB { get; set; }
        private static IEmployeeDAL EmployeeDB { get; set; }
        private static IOrderDAL OrderDB { get; set; }
        private static IProduct ProductDB { get; set; }
        private static IAttributeDAL AttributeDB { get; set; }
        private static IUserAccountDAL UserAccountDB  { get; set; }
        private static IHelperDAL HelperDB { get; set; }
        #endregion
        #region Khai báo các chức năng xử ký nghiệp vụ
        /// <summary>
        /// Lay ra danh sach supplier co phan trang so trang va dem so dong
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <param name="searchValue"></param>
        /// <param name=""></param>
        /// <returns></returns>
        public static List<Supplier> ListOfSupplier(int page, int pageSize, string searchValue, out int rowCount)
        {
            if (page < 1)
                page = 1;
            if (pageSize < 0)
                pageSize = 20;
            rowCount = SupplierDB.Count(searchValue);
            return SupplierDB.List(page,pageSize,searchValue);
        }
        public static List<Supplier> ListOfSupplier()
        {
            return SupplierDB.List(1, -1, "");
        }
        /// <summary>
        /// Lay ra danh sach Customer co phan trang so trang va dem so dong
        /// </summary>
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <param name="searchValue"></param>
        /// <param name="rowCount"></param>
        /// <returns></returns>
        public static List<Customer> ListOfCustomer(int page, int pageSize, string searchValue,string country, out int rowCount)
        {
            if (page < 1)
                page = 1;
            if (pageSize < 0)
                pageSize = 20;
            rowCount = CustomerDB.Count(searchValue,country);
            return CustomerDB.List(page,pageSize,searchValue,country);
        }
        public static List<Product> ListOfProduct(int page, int pageSize, string searchValue, out int rowCount, int supplier, int category)
        {
            if (page < 1)
                page = 1;
            if (pageSize < 0)
                pageSize = 20;
            rowCount = ProductDB.Count(searchValue,supplier,category);
            return ProductDB.List(page, pageSize, searchValue, supplier,category);
        }
        public static List<Product> ListOfProduct()
        {
           return ProductDB.List(1, -1, "", 1, 1);
        }
        public static List<Country> ListOfCountries(int page, int pageSize, string searchValue, out int rowCount)
        {
            if (page < 1)
                page = 1;
            if (pageSize < 0)
                pageSize = 20;
            rowCount = HelperDB.Count(searchValue);
            return HelperDB.ListofCountry(page,pageSize,searchValue);
        }
        public static List<Country> ListOfCountries()
        {
            return HelperDB.ListofCountry(1, -1, "");
        }
        /// <summary>
        /// Lay thong tin cua supplier thong qua supplierID
        /// </summary>
        /// <param name="supplierID"></param>
        /// <returns></returns>
        public static Supplier GetSupplier(int supplierID)
        {
            return SupplierDB.Get(supplierID);
        }
        public static Customer GetCustomer(string customerID)
        {
            return CustomerDB.Get(customerID);
        }
        public static Category GetCategory(int categoryID)
        {
            return CategoryDB.Get(categoryID);
        }
        public static Shipper GetShipper(int shipperID)
        {
            return ShipperDB.Get(shipperID);
        }
        public static Employee GetEmployee(int employeeID)
        {
            return EmployeeDB.Get(employeeID);
        }
        public static Product GetProduct(int productID)
        {
            return ProductDB.Get(productID);
        }
        public static Country GetCountry(int countryID)
        {
            return HelperDB.Get(countryID);
        }
        public static List<Attributes> GetListAttribute(int productID)
        {
            return AttributeDB.GetListAttribute(productID);
        }
        /// <summary>
        /// them 1 supplier
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static int AddSupplier(Supplier data)
        {
            return SupplierDB.Add(data);
        }
        public static string AddCustomer(Customer data)
        {
            return CustomerDB.Add(data);
        }
        public static int AddCategory(Category data)
        {
            return CategoryDB.Add(data);
        }
        public static int AddShipper(Shipper data)
        {
            return ShipperDB.Add(data);
        }
        public static int AddEmployee(Employee data)
        {
            return EmployeeDB.Add(data);
        }
        public static int AddProduct(Product data)
        {
            return ProductDB.Add(data);
        }
        public static int AddAtrribute(Attributes data)
        {
            return AttributeDB.Add(data);
        }
        public static int AddCountry(Country data)
        {
            return HelperDB.Add(data);
        }
        /// <summary>
        ///  update 1 supplier
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static bool UpdateSupplier(Supplier data)
        {
            return SupplierDB.Update(data);
        }
        public static bool UpdateCustomer(Customer data)
        {
            return CustomerDB.Update(data);
        }
        public static bool UpdateCategory(Category data)
        {
            return CategoryDB.Update(data);
        }
        public static bool UpdateShipper(Shipper data)
        {
            return ShipperDB.Update(data);
        }
        public static bool UpdateEmployee(Employee data)
        {
            return EmployeeDB.Update(data);
        }
        public static bool UpdateProduct(Product data)
        {
            return ProductDB.Update(data);
        }
        public static bool UpdateAttribute(Attributes data)
        {
            return AttributeDB.Update(data);
        }
        public static bool UpdateCountry(Country data)
        {
            return HelperDB.Update(data);
        }
        /// <summary>
        ///  Xoa nhieu supplier
        /// </summary>
        /// <param name="supplierIDs"></param>
        /// <returns></returns>
        public static int DeleteSuppliers(int[] supplierIDs)
        {
            return SupplierDB.Delete(supplierIDs);
        }
        public static int DeleteCustomers(string[] customerIDs)
        {
            return CustomerDB.Delete(customerIDs);
        }
        public static int DeleteCategories(int[] categoryIDs)
        {
            return CategoryDB.Delete(categoryIDs);
        }
        public static int DeleteShippers(int[] shipperIDs)
        {
            return ShipperDB.Delete(shipperIDs);
        }
        public static int DeleteEmployee(int[] employeeIDs)
        {
            return EmployeeDB.Delete(employeeIDs);
        }
        public static int DeleteProduct(int[] productIDs)
        {
            return ProductDB.Delete(productIDs);
        }
        public static int DeleteCountries(int[] countryIDs)
        {
            return HelperDB.Delete(countryIDs);
        }
        public static List<Shipper> ListOfShipper(int page, int pageSize, string searchValue, out int rowCount)
        {
            if (page < 1)
                page = 1;
            if (pageSize < 0)
                pageSize = 20;
            rowCount = ShipperDB.Count(searchValue);
            return ShipperDB.List(page, pageSize, searchValue);
        }
        public static List<Shipper> ListOfShipper()
        {
            
            return ShipperDB.List(1, -1, "");
        }
        public static List<Category> ListOfCategory(int page, int pageSize, string searchValue, out int rowCount)
        {
            if (page < 1)
                page = 1;
            if (pageSize < 0)
                pageSize = 20;
            rowCount = CategoryDB.Count(searchValue);
            return CategoryDB.List(page, pageSize, searchValue);
        }
        public static List<Category> ListOfCategory()
        {
            return CategoryDB.List(1, -1, "");
        }
        public static List<Employee> ListOfEmployee(int page, int pageSize, string searchValue, out int rowCount)
        {
            if (page < 1)
                page = 1;
            if (pageSize < 0)
                pageSize = 20;
            rowCount = EmployeeDB.Count(searchValue);
            return EmployeeDB.List(page, pageSize, searchValue);
        }
        public static List<Order> ListOfOrder(int page, int pageSize, string searchValue, out int rowCount)
        {
            if (page < 1)
                page = 1;
            if (pageSize < 0)
                pageSize = 20;
            rowCount = OrderDB.Count(searchValue);
            return OrderDB.List(page, pageSize, searchValue);
        }
        public static int CheckEmail(string email)
        {
            return EmployeeDB.CheckEmail(email);
        }
        #endregion
    }
}
