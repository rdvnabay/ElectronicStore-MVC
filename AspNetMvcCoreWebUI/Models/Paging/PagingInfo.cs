using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetMvcCoreWebUI.Models.Paging
{
    public class PagingInfo
    {
        public int TotalItems { get; set; }
        public int ItemsPerPage { get; set; }
        public int CurrentPage { get; set; }
        public string CurrentCategoryName { get; set; }

        public int TotalPages()
        {
            return (int)Math.Ceiling((decimal)(TotalItems / ItemsPerPage))+1;
        }
    }
}
