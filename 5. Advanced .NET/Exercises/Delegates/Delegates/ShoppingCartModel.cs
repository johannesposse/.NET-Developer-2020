using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{
    class ShoppingCartModel
    {
        public List<ProductModel> items { get; set; } = new List<ProductModel>();

        public delegate void MentionDiscount(decimal subTotal);

        public decimal GenerateTotal(MentionDiscount mentionDiscount)
        {
            decimal subTotal = items.Sum(x => x.Price);

            mentionDiscount(subTotal);

            if (subTotal > 100)
                return subTotal * 0.80M;
            else if (subTotal > 50)
                return subTotal * 0.85M;
            else if (subTotal > 10)
                return subTotal * 0.90M;
            else
                return subTotal;
        }

    }
}
