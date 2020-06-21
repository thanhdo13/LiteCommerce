using LiteCommerce.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiteCommerce.DataLayers
{
    public interface IHelperDAL
    {
        int Count(string searchValue);
        List<Country> ListofCountry(int page, int pageSize, string searchValue);
        Country Get(int countryID);
        int Add(Country data);
        bool Update(Country countryID);
        int Delete(int[] countryIDs);

    }
}
