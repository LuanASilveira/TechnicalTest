using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WK.TechnicalTest.Model.Entities
{
    public class Product : Entity
    {
        public virtual Category Category { get; set; }
        public long CategoryId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
