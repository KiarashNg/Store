using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Models
{
    class Product
    {
        public int Id { get; set; }
        public int? CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public int? CompanyId { get; set; }
        public virtual Company Company { get; set; }
        public string ModelName { get; set; }
        public string Description { get; set; }
    }
}
