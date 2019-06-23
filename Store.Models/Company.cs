using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Models
{
    class Company
    {
        public int Id { get; set; }
        public string PersianName { get; set; }
        public string EnglishName { get; set; }
        public int? CountryId { get; set; }
        public virtual Country Country { get; set; }
    }
}
