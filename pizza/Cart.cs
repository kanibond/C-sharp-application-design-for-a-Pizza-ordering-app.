using System.Collections.Generic;

namespace pizza
{
    /// <summary>
    /// Holds an array of Pizza's representing a Cart
    /// Singleton Class
    /// </summary>
    public class Cart
    {
        /* ************************************ Member Data ************************************ */

        private List<Pizza> cart;
        private static Cart instance;
        public static Cart Instance => instance ?? (instance = new Cart()); // singleton instance

        /* ************************************ Properties ************************************ */

        public decimal Total => SubTotal + SubTotal * 0.10M;
        public bool IsEmpty => cart.Count > 0;

        /* ************************************ Constructors ************************************ */

        private Cart()
        {
            cart = new List<Pizza>();
        }

        /* ************************************ Methods ************************************ */

        public decimal SubTotal
        {
            get
            {
                decimal totalPrice = 0;
                foreach (Pizza pizza in cart)
                    totalPrice += pizza.TotalPrice;

                return totalPrice;
            }
        }

        public void AddToCart(Pizza pizza)
        {
            cart.Add(pizza);
        }

        public List<Pizza> GetCart()
        {
            return cart;
        }

        public void ClearCart()
        {
            cart.Clear();
        }

    }
}
