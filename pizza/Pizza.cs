using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace pizza
{
    public class Pizza
    {
        public Pizza()
        {
            PizzaSize = Size.Medium;
        }

        /* ************************************ Properties ************************************ */

        public Size PizzaSize { set; get; }

        virtual public string Name { set; get; }
        virtual public decimal TotalPrice => GetSizePrice() + GetSpecialtyPrice();

        public Specialty SpecialtyType { get; set; }
        public Image DefaultImage => Constants.DefaultImage;

        /* ************************************ Methods ************************************ */

        public decimal GetSizePrice()
        {
            switch (PizzaSize)
            {
                case Size.Personal:
                    return 1.99M;
                case Size.Small:
                    return 2.99M;
                case Size.Medium:
                    return 3.99M;
                default:
                    return 4.59M;
            }
        }

        /// <summary>
        /// Get the Image of the specialty pizza
        /// </summary>
        /// <returns></returns>
        virtual public Image GetImage()
        {
            switch (SpecialtyType)
            {
                case Specialty.MeatLovers:
                    Name = "Meat Lovers";
                    return Constants.MeatLoversImage;

                case Specialty.CheeseLovers:
                    Name = "Cheese Lovers";
                    return Constants.CheeseLoversImage;

                case Specialty.VeggieLovers:
                    Name = "Veggie Lovers";
                    return Constants.VeggieLoversImage;

                default:
                    Name = "Italiano";
                    return Constants.ItalianoImage;
            }
        }


        private decimal GetSpecialtyPrice()
        {
            switch (SpecialtyType)
            {
                case Specialty.MeatLovers:
                    return 5.99M;
                case Specialty.CheeseLovers:
                    return 3.99M;
                case Specialty.VeggieLovers:
                    return 4.99M;
                default:
                    return 6.99M;
            }
        }

        /* ************************************ Enums ************************************ */

        public enum Size
        {
            Personal,
            Small,
            Medium,
            Large
        }

        public enum Specialty
        {
            MeatLovers,
            CheeseLovers,
            VeggieLovers,
            Italiano
        }
    }
}
