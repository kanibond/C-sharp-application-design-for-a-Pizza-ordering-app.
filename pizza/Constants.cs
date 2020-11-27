using System.Drawing;
using pizza.Properties;

namespace pizza
{
    /// <summary>
    /// Static class containing app-wide constants
    /// </summary>
    static class Constants
    {
        /* ************************* Images for Specials ************************* */

        public static Image DefaultImage => Resources.crust_handtossed;
        public static Image MeatLoversImage => Resources.pepperoni_pizza;
        public static Image CheeseLoversImage => Resources.cheese_pizza;
        public static Image VeggieLoversImage => Resources.veggie;
        public static Image ItalianoImage => Resources.italian1;
        public static Image CheeseImage => Resources.cheese_mozz;

        /* ************************* Images for Customs ************************* */

        /* ***************** Meat ***************** */

        // Chicken
        public static Image ChickenLeft => Resources.topping_Bacon_extra_L;
        public static Image ChickenRight => Resources.topping_Bacon_extra_R;
        public static Image Chicken => Resources.topping_Bacon_extra;

        // Beef
        public static Image BeefLeft => Resources.topping_Ham_extra_L;
        public static Image BeefRight => Resources.topping_Ham_extra_R;
        public static Image BeefBoth => Resources.topping_Ham_extra;

        // Sausage
        public static Image SausageLeft => Resources.topping_ItalianSausage_extra_L;
        public static Image SausageRight => Resources.topping_ItalianSausage_extra_R;
        public static Image Sausage => Resources.topping_ItalianSausage_extra;

        // Pepperoni
        public static Image PepperoniLeft => Resources.topping_Pepperoni_extra_L;
        public static Image PepperoniRight => Resources.topping_Pepperoni_extra_R;
        public static Image Pepperoni => Resources.topping_Pepperoni_extra;

        /* ***************** Veggies ***************** */

        // Mushrooms
        public static Image MushroomsLeft => Resources.topping_Mushroom_extra_L;
        public static Image MushroomsRight => Resources.topping_Mushroom_extra_R;
        public static Image Mushrooms => Resources.topping_Mushroom_extra;

        // Brocolli
        public static Image BrocolliLeft => Resources.topping_Olives_extra_L;
        public static Image BrocolliRight => Resources.topping_Olives_extra_R;
        public static Image Brocolli => Resources.topping_Olives_extra;

        // Spinach
        public static Image SpinachLeft => Resources.topping_Onion_extra_L;
        public static Image SpinachRight => Resources.topping_Onion_extra_R;
        public static Image Spinach => Resources.topping_Onion_extra;

        /* ************************* Images for Sides ************************* */

        public static Image ButtonLeftSelected => Resources.button_left_selected;
        public static Image ButtonLeft => Resources.button_left;

        public static Image ButtonRightSelected => Resources.button_right_selected;
        public static Image ButtonRight => Resources.button_right;

        public static Image ButtonWholeSelected => Resources.button_whole_selected;
        public static Image ButtonWhole => Resources.button_whole;

        /* ************************* Messages ************************* */

        public static string SuccessMessage => "Success!";
        public static string AddedToCartMessage => "Your pizza has been added to the cart!";
        public static string CartClearedMessage => "The cart has been cleared!";
        public static string PurchaseMessage => "Thank you for your order! Enjoy your pizza.";

        /* ************************* Dictionary Keys ************************* */

        public static string Meat => "meat";
        public static string Veggies => "veggies";
        public static string Crust => "crust";
        public static string Cheese => "cheese";


        public static Size ImageSize => new Size(225, 208);
    }
}
