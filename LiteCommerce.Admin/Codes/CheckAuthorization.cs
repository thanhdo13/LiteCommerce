using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LiteCommerce.Admin
{
    /// <summary>
    /// Xử lý role của nhân viên 
    /// </summary>
    public static class CheckAuthorization
    {
        /// <summary>
        /// Xử lý role của nhân viên về DataManagement
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string CheckAuthorizationDATA(string text)
        {
            try
            {
                string[] infos = text.Split('|');
                for(int i = 0; i < infos.Length; i++)
                {
                    if (infos[i].Equals(WebUserRoles.DataManagement))
                        return WebUserRoles.DataManagement;
                }
                return "";
            }
            catch
            {
                return "";
            }
        }
        /// <summary>
        /// Xử lý role của nhân viên về SaleMan
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string CheckAuthorizationSale(string text)
        {
            try
            {
                string[] infos = text.Split('|');
                for (int i = 0; i < infos.Length; i++)
                {
                    if (infos[i].Equals(WebUserRoles.SaleMan))
                        return WebUserRoles.SaleMan;
                }
                return "";
            }
            catch
            {
                return "";
            }
        }
        /// <summary>
        /// Xử lý role của nhân viên về AccountAdministrationStaff
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string CheckAuthorizationAcc(string text)
        {
            try
            {
                string[] infos = text.Split('|');
                for (int i = 0; i < infos.Length; i++)
                {
                    if (infos[i].Equals(WebUserRoles.AccountAdministrationStaff))
                        return WebUserRoles.AccountAdministrationStaff;
                }
                return "";
            }
            catch
            {
                return "";
            }
        }
    }
}