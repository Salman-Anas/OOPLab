using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace business
{
    class product
    {
        public product(string productName, int price)
        {
            this.productName = productName;
            this.price = price;
        }
        public string productName;
        public int price;
    }
}
