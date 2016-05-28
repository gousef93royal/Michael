using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Shop
{
    public class Snack : Product
    {

        public Snack(int productId, string name, double price)
            : base(productId, name, price)
        {

        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
