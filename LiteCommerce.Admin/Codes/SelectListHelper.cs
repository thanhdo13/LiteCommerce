using LiteCommerce.BusinessLayers;
using LiteCommerce.DataLayers.SqlServer;
using LiteCommerce.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LiteCommerce.Admin
{
    public static class SelectListHelper
    {
        /// <summary>
        /// SelectList cac quoc gia
        /// </summary>
        /// <returns></returns>
        public static List<SelectListItem> Countries(bool allowSelectAll = true)
        {
            List<SelectListItem> list = new List<SelectListItem>();
            list.Add(new SelectListItem() { Value = "", Text = "---- All Country -----" });
            if (allowSelectAll)
            {
                foreach (Country country in CataLogBLL.ListOfCountries())
                {
                    list.Add(new SelectListItem() { Value = country.CountryName, Text = country.CountryName });
                }
            }
            return list;
        }
        public static List<SelectListItem> Years(bool allowSelectAll = true)
        {
            List<SelectListItem> list = new List<SelectListItem>();
            if (allowSelectAll)
            {
                foreach (int year in DashboardBLL.Year())
                {
                    list.Add(new SelectListItem() { Value = year.ToString(), Text = year.ToString() });
                }
            }
            return list;
        }
        /// <summary>
        /// danh sách các product
        /// </summary>
        /// <param name="allowSelectAll"></param>
        /// <returns></returns>
        public static List<SelectListItem> ProductID(bool allowSelectAll = true)
        {
            List<SelectListItem> list = new List<SelectListItem>();
            if (allowSelectAll)
            {
                foreach (Product product in CataLogBLL.ListOfProduct())
                {
                    list.Add(new SelectListItem() { Value = product.ProductID.ToString(), Text = product.ProductName.ToString() });
                }
            }
            return list;
        }
        /// <summary>
        /// ds các nhà cung cấp
        /// </summary>
        /// <param name="allowSelectAll"></param>
        /// <returns></returns>
        public static List<SelectListItem> Suppliers(bool allowSelectAll = true)
        {
            List<SelectListItem> list = new List<SelectListItem>();
            if (allowSelectAll)
            {
                foreach(Supplier supplier in CataLogBLL.ListOfSupplier()) { 
                list.Add(new SelectListItem() { Value = supplier.SupplierID.ToString(), Text = supplier.CompanyName.ToString() });
                }
            }
            return list;
        }
        /// <summary>
        /// ds các thể loại
        /// </summary>
        /// <param name="allowSelectAll"></param>
        /// <returns></returns>
        public static List<SelectListItem> Categories(bool allowSelectAll = true)
        {
            List<SelectListItem> list = new List<SelectListItem>();
            if (allowSelectAll)
            {
                foreach (Category category in CataLogBLL.ListOfCategory())
                {
                    list.Add(new SelectListItem() { Value = category.CategoryID.ToString(), Text = category.CategoryName.ToString() });
                }
            }
            return list;
        }
        /// <summary>
        /// ds các shipper
        /// </summary>
        /// <param name="allowSelectAll"></param>
        /// <returns></returns>
            public static List<SelectListItem> Shippers(bool allowSelectAll = true)
        {
            List<SelectListItem> list = new List<SelectListItem>();
            if (allowSelectAll)
            {
                foreach (Shipper shipper in CataLogBLL.ListOfShipper())
                {
                    list.Add(new SelectListItem() { Value = shipper.ShipperID.ToString(), Text = shipper.CompanyName.ToString() });
                }
            }
            return list;
        }
    }
}