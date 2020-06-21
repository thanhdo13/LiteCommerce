using LiteCommerce.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LiteCommerce.DataLayers
{
    public interface IAtrributeDAL
    {
        /// <summary>
        /// Lay Attribute can lay
        /// </summary>
        /// <param name="AttributeID"></param>
        /// <returns></returns>
        Attribute Get(int AttributeID);
        /// <summary>
        /// Them du lieu cho Atrribute
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        int Add(Attribute data);
        /// <summary>
        /// Update Attribute
        /// </summary>
        /// <param name="AttributeID"></param>
        /// <returns></returns>
        bool Update(Attribute AttributeID);
    }
}
