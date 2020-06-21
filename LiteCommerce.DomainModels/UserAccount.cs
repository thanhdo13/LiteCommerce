using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiteCommerce.DomainModels
{
    /// <summary>
    /// Luwu thong tin lien quan den tai khoan dang nhap he thong
    /// </summary>
    public class UserAccount
    {
        /// <summary>
        /// ID cua tai khoan he thong
        /// </summary>
        public string UserID { get; set; }
        /// <summary>
        /// Luu ten day du cua User
        /// </summary>
        public string FullName { get; set; }
        /// <summary>
        ///  ten file anh cua User
        /// </summary>
        public string Photo { get; set; }
        /// <summary>
        /// Title
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// Danh sách quyền truy cập
        /// </summary>
        public string Roles { get; set; }

        /// <summary>
        /// Mat khau
        /// </summary>
    }
}
