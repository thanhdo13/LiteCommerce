using LiteCommerce.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiteCommerce.DataLayers
{
    public interface IAttributeDAL
    {
        List<Attributes>  GetListAttribute(int productID);
        /// <summary>
        /// Them data Atrribute 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        int Add(Attributes data);
        /// <summary>
        /// update attribute 
        /// </summary>
        /// <param name="attributeID"></param>
        /// <returns></returns>
        bool Update(Attributes data);
    }
}
