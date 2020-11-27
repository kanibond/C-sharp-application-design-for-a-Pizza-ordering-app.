using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace pizza
{
    public class CustomPizza : Pizza
    {
        /* ************************************ Member Data ************************************ */

        Dictionary<string, Image> images;   // holds 1 image per topping type

        /* ************************************ Constructors ************************************ */

        public CustomPizza() : base()
        {
            images = new Dictionary<string, Image>();
            images[Constants.Crust] = Constants.DefaultImage;
            VeggiesSide = MeatSide = Side.Both;
        }

        /* ************************************ Properties ************************************ */

        public Sauce PizzaSauce { set; get; }
        public Cheese PizzaCheese { set; get; }
        public Meat PizzaMeat { set; get; }
        public Veggies PizzaVeggies { set; get; }
        public Side VeggiesSide { set; get; }
        public Side MeatSide { set; get; }

        override public decimal TotalPrice => GetSizePrice() + GetSaucePrice() + GetCheesePrice() + GetMeatPrice() + GetVeggiesPrice();
        override public string Name => "Custom Pizza";

        /* ************************************ Methods ************************************ */

        public decimal GetSaucePrice()
        {
            switch (PizzaSauce)
            {
                case Sauce.Alfredo:
                    return 1.99M;
                default:
                    return 0.99M;
            }
        }

        public decimal GetCheesePrice()
        {
            switch (PizzaCheese)
            {
                case Cheese.Mozzerella:
                    return 0.99M;
                case Cheese.Parmesan:
                    return 0.59M;
                default:
                    return 1.59M;
            }
        }

        public decimal GetMeatPrice()
        {
            switch (PizzaMeat)
            {
                case Meat.Chicken:
                    return 2.99M;
                case Meat.Beef:
                    return 1.99M;
                case Meat.Sausage:
                    return 1.59M;
                default:
                    return 0.99M;
            }
        }

        public decimal GetVeggiesPrice()
        {
            switch (PizzaVeggies)
            {
                case Veggies.Broccoli:
                    return 1.99M;
                case Veggies.Mushrooms:
                    return 2.59M;
                default:
                    return 1.59M;
            }
        }

        /// <summary>
        /// Adds Meat Topping Image to List of Images
        /// </summary>
        /// <param name="meat"></param>
        public void AddTopping(Meat meat)
        {
            switch (meat)
            {
                case Meat.Chicken:
                    if (MeatSide == Side.Left)
                        images[Constants.Meat] = Constants.ChickenLeft;

                    else if (MeatSide == Side.Right)
                        images[Constants.Meat] = Constants.ChickenRight;

                    else
                        images[Constants.Meat] = Constants.Chicken;
                    break;

                case Meat.Beef:
                    if (MeatSide == Side.Left)
                        images[Constants.Meat] = Constants.BeefLeft;

                    else if (MeatSide == Side.Right)
                        images[Constants.Meat] = Constants.BeefRight;

                    else
                        images[Constants.Meat] = Constants.BeefBoth;
                    break;

                case Meat.Sausage:
                    if (MeatSide == Side.Left)
                        images[Constants.Meat] = Constants.SausageLeft;

                    else if (MeatSide == Side.Right)
                        images[Constants.Meat] = Constants.SausageRight;

                    else
                        images[Constants.Meat] = Constants.Sausage;
                    break;

                default:
                    if (MeatSide == Side.Left)
                        images[Constants.Meat] = Constants.PepperoniLeft;

                    else if (MeatSide == Side.Right)
                        images[Constants.Meat] = Constants.PepperoniRight;

                    else
                        images[Constants.Meat] = Constants.Pepperoni;
                    break;
            }
        }

        /// <summary>
        /// Adds Veggies topping image to dictionary of images
        /// </summary>
        /// <param name="veggies"></param>
        public void AddTopping(Veggies veggies)
        {
            switch (veggies)
            {
                case Veggies.Mushrooms:
                    if (VeggiesSide == Side.Left)
                        images[Constants.Veggies] = Constants.MushroomsLeft;

                    else if (VeggiesSide == Side.Right)
                        images[Constants.Veggies] = Constants.MushroomsRight;

                    else
                        images[Constants.Veggies] = Constants.Mushrooms;
                    break;

                case Veggies.Broccoli:
                    if (VeggiesSide == Side.Left)
                        images[Constants.Veggies] = Constants.BrocolliLeft;

                    else if (VeggiesSide == Side.Right)
                        images[Constants.Veggies] = Constants.BrocolliRight;

                    else
                        images[Constants.Veggies] = Constants.Brocolli;
                    break;

                default:
                    if (VeggiesSide == Side.Left)
                        images[Constants.Veggies] = Constants.SpinachLeft;

                    else if (VeggiesSide == Side.Right)
                        images[Constants.Veggies] = Constants.SpinachRight;

                    else
                        images[Constants.Veggies] = Constants.Spinach;
                    break;
            }
        }

        /// <summary>
        /// Get the image for the pizza by drawing all images for the toppings in 1 image
        /// </summary>
        /// <returns></returns>
        public override Image GetImage()
        {
            int width = Constants.ImageSize.Width;
            int height = Constants.ImageSize.Height;

            Image image = new Bitmap(width, height);

            using (var graphics = Graphics.FromImage(image))
            {
                foreach (KeyValuePair<string, Image> i in images)
                {
                    graphics.DrawImage(i.Value, new Rectangle(0, 0, width, height));
                }
            }

            return image;
        }

        public void AddCheese()
        {
            images[Constants.Cheese] = Constants.CheeseImage;
        }
        /* ************************************ Enums ************************************ */

        public enum Sauce
        {
            Alfredo,
            Tomato
        }

        public enum Cheese
        {
            Mozzerella,
            Provolone,
            Parmesan
        }

        public enum Meat
        {
            Chicken,
            Sausage,
            Beef,
            Pepperoni
        }

        public enum Veggies
        {
            Mushrooms,
            Broccoli,
            Spinach
        }

        public enum Side
        {
            Left,
            Right,
            Both
        }
    }
}
