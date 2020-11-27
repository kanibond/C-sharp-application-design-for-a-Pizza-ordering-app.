/* ********************************************************************
 * Shady Boukhary
 * CMPS 4143: Contemporary Programming Languages: C#
 * Dr. StringFellow
 * November 7th
 * Program 6
 * Caterina's Pizza Shop: Order Pizza online. Choose either from Specialty pizzas
 * or craft your own pizza
 * ****************************************************************** */

using System;
using System.Windows.Forms;

namespace pizza
{
    /// <summary>
    /// Main Application Form
    /// Lets user add pizzas to cart; either custom or specialty
    /// </summary>
    public partial class PizzaPickerForm : Form
    {
        /* ************************************ Member Data ************************************ */

bool isCustom;
        Cart cart;
        Pizza currentPizza;
        FormClosedEventHandler onCloseLambda;   // shows this form when other form is closed

        /* ************************************ Constructors ************************************ */

        public PizzaPickerForm()
        {
            InitializeComponent();
            isCustom = false;
            cart = Cart.Instance;
            onCloseLambda = (sender, args) => Show();
            currentPizza = new Pizza();
            InitViews();
        }
        /* ************************************ Methods ************************************ */

        /// <summary>
        /// Initializes all views 
        /// </summary>
        public void InitViews()
        {
            // Set default image of pizza
            orderPictureBox.Image = currentPizza.DefaultImage;

            // uncheck radio buttons
            personalSizeRadioButton.Checked = smallSizeRadioButton.Checked = largeSizeRadioButton.Checked = false;
            mediumSizeRadioButton.Checked = true;
            addToCartButton.Enabled = false;

            // set default side photos
            meatRightPicturebox.Image = veggiesRightPicturebox.Image = Constants.ButtonRight;
            meatLeftPictureBox.Image = veggiesLeftPicturebox.Image = Constants.ButtonLeft;
            meatMiddlePicturebox.Image = veggiesMiddlePictureBox.Image = Constants.ButtonWholeSelected;

            // set default states for custom radio buttons
            if (isCustom)
            {
                alfredoRadioButton.Checked = tomatoRadioButton.Checked = mozzerrellaRadioButton.Checked =
                    provoloneRadioButton.Checked = parmesanRadioButton.Checked = chickenRadioButton.Checked =
                    sausageRadioButton.Checked = beefRadioButton.Checked = pepperoniRadioButton.Checked =
                    mushroomsRadioButton.Checked = broccoliRadioButton.Checked = spinachRadioButton.Checked = false;
            }

            checkoutButton.Enabled = cart.IsEmpty;
        }

        /// <summary>
        /// Clear current options and start a new pizza
        /// </summary>
        private void ClearOrder()
        {
            currentPizza = isCustom ? new CustomPizza() : new Pizza();
            InitViews();
        }

        /* ************************************ Event Handlers ************************************ */

        /// <summary>
        /// Switches between Specialty and Custom Tabs and clears options
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TabControlButtons_Click(object sender, EventArgs e)
        {
            if (sender == specialsButton)
            {
                tabControl.SelectedIndex = 0;
                isCustom = false;
                currentPizza = new Pizza();
            }
            else
            {
                tabControl.SelectedIndex = 1;
                isCustom = true;
                currentPizza = new CustomPizza();
            }
            ClearOrder();
        }

        /// <summary>
        /// Select a specialty pizza
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SpecialtyPizzaButtons_Click(object sender, EventArgs e)
        {
            if (sender == meatButton)
                currentPizza.SpecialtyType = Pizza.Specialty.MeatLovers;

            else if (sender == cheeseButton)
                currentPizza.SpecialtyType = Pizza.Specialty.CheeseLovers;

            else if (sender == veggieButton)
                currentPizza.SpecialtyType = Pizza.Specialty.VeggieLovers;

            else
                currentPizza.SpecialtyType = Pizza.Specialty.Italiano;

            // update image
            orderPictureBox.Image = currentPizza.GetImage();
            addToCartButton.Enabled = true;
        }

        /// <summary>
        /// Select size of pizza
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SizeRadioButtons_Click(object sender, EventArgs e)
        {
            if (sender == personalSizeRadioButton)
                currentPizza.PizzaSize = Pizza.Size.Personal;

            else if (sender == smallSizeRadioButton)
                currentPizza.PizzaSize = Pizza.Size.Small;

            else if (sender == mediumSizeRadioButton)
                currentPizza.PizzaSize = Pizza.Size.Medium;

            else
                currentPizza.PizzaSize = Pizza.Size.Large;
        }

        /// <summary>
        /// Adds pizza to cart
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addToCartButton_Click(object sender, EventArgs e)
        {
            cart.AddToCart(currentPizza);
            MessageBox.Show(Constants.AddedToCartMessage, Constants.SuccessMessage, 
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
            ClearOrder();
        }

        private void restartButton_Click(object sender, EventArgs e)
        {
            ClearOrder();
        }

        /// <summary>
        /// Selects sauce type
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SauceRadioButtons_Click(object sender, EventArgs e)
        {
            CustomPizza pizza = (CustomPizza)currentPizza;
            pizza.PizzaSauce = sender == alfredoRadioButton ? CustomPizza.Sauce.Alfredo : CustomPizza.Sauce.Tomato;
        }

        /// <summary>
        /// Selects cheese type
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheeseRadioButtons_Click(object sender, EventArgs e)
        {
            CustomPizza pizza = (CustomPizza)currentPizza;

            if (sender == mozzerrellaRadioButton)
                pizza.PizzaCheese = CustomPizza.Cheese.Mozzerella;

            else if (sender == provoloneRadioButton)
                pizza.PizzaCheese = CustomPizza.Cheese.Provolone;

            else
                pizza.PizzaCheese = CustomPizza.Cheese.Parmesan;

            pizza.AddCheese();
            orderPictureBox.Image = pizza.GetImage();
        }

        /// <summary>
        /// Selects meat type and updates image
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MeatRadioButtons_Click(object sender, EventArgs e)
        {
            CustomPizza pizza = (CustomPizza)currentPizza;

            if (sender == chickenRadioButton)
                pizza.PizzaMeat = CustomPizza.Meat.Chicken;

            else if (sender == sausageRadioButton)
                pizza.PizzaMeat = CustomPizza.Meat.Sausage;

            else if (sender == beefRadioButton)
                pizza.PizzaMeat = CustomPizza.Meat.Beef;

            else
                pizza.PizzaMeat = CustomPizza.Meat.Pepperoni;

            // update image
            pizza.AddTopping(pizza.PizzaMeat);
            orderPictureBox.Image = pizza.GetImage();
        }

        /// <summary>
        /// Selects veggie type and updates image
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void VeggiesRadioButtons_Click(object sender, EventArgs e)
        {
            CustomPizza pizza = (CustomPizza)currentPizza;

            if (sender == mushroomsRadioButton)
                pizza.PizzaVeggies = CustomPizza.Veggies.Mushrooms;

            else if (sender == broccoliRadioButton)
                pizza.PizzaVeggies = CustomPizza.Veggies.Broccoli;

            else
                pizza.PizzaVeggies = CustomPizza.Veggies.Spinach;

            // update image
            pizza.AddTopping(pizza.PizzaVeggies);
            orderPictureBox.Image = pizza.GetImage();
        }

        /// <summary>
        /// Disable or Enable addToCart button according to the state of radio buttons
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CustomRadioButtons_CheckChanged(object sender, EventArgs e)
        {
            if ((alfredoRadioButton.Checked || tomatoRadioButton.Checked)
                && (mozzerrellaRadioButton.Checked || provoloneRadioButton.Checked || parmesanRadioButton.Checked)
                && (chickenRadioButton.Checked || sausageRadioButton.Checked || beefRadioButton.Checked ||
                pepperoniRadioButton.Checked)
                && (mushroomsRadioButton.Checked || broccoliRadioButton.Checked || spinachRadioButton.Checked))
            {
                addToCartButton.Enabled = true;
            }
        }

        /// <summary>
        /// Clear the cart from all pizzas ands start over
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void clearCartButton_Click(object sender, EventArgs e)
        {
            cart.ClearCart();
            MessageBox.Show(Constants.CartClearedMessage, 
                            Constants.SuccessMessage, 
                            MessageBoxButtons.OK, 
                            MessageBoxIcon.Information);
            ClearOrder();
        }

        /// <summary>
        /// Got to checkout page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkoutButton_Click(object sender, EventArgs e)
        {
            CartForm form = new CartForm();
            form.FormClosed += onCloseLambda;
            form.Show();
            Hide();
        }

        /// <summary>
        /// Selects which size of pizza to apply topping and updates image
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MeatSideImages_Click(object sender, EventArgs e)
        {
            CustomPizza pizza = (CustomPizza)currentPizza;

            if (sender == meatLeftPictureBox)
            {
                pizza.MeatSide = CustomPizza.Side.Left;

                // update side images
                meatLeftPictureBox.Image = Constants.ButtonLeftSelected;
                meatMiddlePicturebox.Image = Constants.ButtonWhole;
                meatRightPicturebox.Image = Constants.ButtonRight;
            }

            else if (sender == meatRightPicturebox)
            {
                pizza.MeatSide = CustomPizza.Side.Right;

                // update side images
                meatLeftPictureBox.Image = Constants.ButtonLeft;
                meatMiddlePicturebox.Image = Constants.ButtonWhole;
                meatRightPicturebox.Image = Constants.ButtonRightSelected;
            }

            else
            {
                pizza.MeatSide = CustomPizza.Side.Both;

                // update side images
                meatLeftPictureBox.Image = Constants.ButtonLeft;
                meatMiddlePicturebox.Image = Constants.ButtonWholeSelected;
                meatRightPicturebox.Image = Constants.ButtonRight;

            }

            pizza.AddTopping(pizza.PizzaMeat);

            orderPictureBox.Image = pizza.GetImage();
        }

        /// <summary>
        /// Selects which side of pizza to apply veggie topping and updates image
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void VeggiesSizeImages_Click(object sender, EventArgs e)
        {
            CustomPizza pizza = (CustomPizza)currentPizza;

            if (sender == veggiesLeftPicturebox)
            {
                pizza.VeggiesSide = CustomPizza.Side.Left;

                // update side images
                veggiesLeftPicturebox.Image = Constants.ButtonLeftSelected;
                veggiesMiddlePictureBox.Image = Constants.ButtonWhole;
                veggiesRightPicturebox.Image = Constants.ButtonRight;
            }

            else if (sender == veggiesRightPicturebox)
            {
                pizza.VeggiesSide = CustomPizza.Side.Right;

                // update side images
                veggiesLeftPicturebox.Image = Constants.ButtonLeft;
                veggiesMiddlePictureBox.Image = Constants.ButtonWhole;
                veggiesRightPicturebox.Image = Constants.ButtonRightSelected;
            }
                
            else
            {
                pizza.VeggiesSide = CustomPizza.Side.Both;

                // update side images
                veggiesLeftPicturebox.Image = Constants.ButtonLeft;
                veggiesMiddlePictureBox.Image = Constants.ButtonWholeSelected;
                veggiesRightPicturebox.Image = Constants.ButtonRight;
            }

            // update image
            pizza.AddTopping(pizza.PizzaVeggies);
            orderPictureBox.Image = pizza.GetImage();
        }

    }
}
