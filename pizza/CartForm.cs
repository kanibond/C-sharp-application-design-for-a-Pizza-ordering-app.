using System;
using System.Drawing;
using System.Windows.Forms;

namespace pizza
{
    /// <summary>
    /// Checkout Form. Displays complete order and pricing for checkout
    /// </summary>
    public partial class CartForm : Form
    {
        /* ************************************ Member Data ************************************ */

        private Cart cart;
        decimal totalPrice;

        /* ************************************ Constructors ************************************ */

        public CartForm()
        {
            InitializeComponent();
            cart = Cart.Instance;
            totalPrice = 0.0M;
            InitViews();
        }

        /* ************************************ Methods ************************************ */

        public void InitViews()
        {
            int x = 50, y = 50; // initial positions
            int offset = 50;    // x or y offest
            Size size = Constants.ImageSize;

            // loop through every pizza added to the cart
            foreach(Pizza pizza in cart.GetCart())
            {
                // add the pizza image
                Controls.Add(GetPictureBox(pizza, x, y, size));

                // add the name of the pizza
                Controls.Add(GetPizzaNameLabel(pizza, x, y, size, offset));

                // add the size of the pizza
                Controls.Add(GetLabel(pizza, x, y, size, offset, offset, "size"));

                // add the price of the pizza
                Controls.Add(GetLabel(pizza, x, y, size, offset, offset * 2, "price"));

                totalPrice += pizza.TotalPrice;
                y += size.Height + offset;  // update y-position
            }

            // calculate tax and totals and update labels
            itemsOrderedLabel.Text = cart.GetCart().Count.ToString();
            subtotalLabel.Text = $"${totalPrice.ToString("F2")}";
            decimal tax = totalPrice * 0.10M;
            taxLabel.Text = $"${tax.ToString("F2")}";
            totalPrice += tax;
            totalLabel.Text = $"${totalPrice.ToString("F2")}";
        }

        /// <summary>
        /// Get the pizza's image
        /// </summary>
        /// <param name="pizza">The pizza</param>
        /// <param name="x">the x position</param>
        /// <param name="y">the y position</param>
        /// <param name="size">the size of the image</param>
        /// <returns></returns>
        private PictureBox GetPictureBox(Pizza pizza, int x, int y, Size size)
        {
            return new PictureBox
            {
                Size = new Size(size.Width, size.Height),
                SizeMode = PictureBoxSizeMode.StretchImage,
                Location = new Point(x, y),
                Image = new Bitmap(pizza.GetImage()),
                BackColor = Color.Transparent
            };
        }

        /// <summary>
        /// Get the pizza's name
        /// </summary>
        /// <param name="pizza">the pizza</param>
        /// <param name="x">the x postion</param>
        /// <param name="y">the y positon</param>
        /// <param name="size">the size of the image</param>
        /// <param name="offset">the offset for the x-axis</param>
        /// <returns></returns>
        private Label GetPizzaNameLabel(Pizza pizza, int x, int y, Size size, int offset)
        {
            return new Label
            {
                Size = new Size(200, 45),
                Text = pizza.Name,
                Location = new Point(x + size.Width + offset, y),
                Font = new Font(Font.FontFamily, 16, FontStyle.Bold)
            };
        }

        /// <summary>
        /// Get various labels for the pizza
        /// </summary>
        /// <param name="pizza"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="size"></param>
        /// <param name="offset"></param>
        /// <param name="offsetY"></param>
        /// <param name="option"></param>
        /// <returns></returns>
        private Label GetLabel(Pizza pizza, int x, int y, Size size, int offset, int offsetY, string option)
        {
            Label label = new Label
            {
                Size = new Size(200, 45),
                Location = new Point(x + size.Width + offset, y + offsetY),
                Font = new Font(Font.FontFamily, 14)
            };

            // get price label
            if (option == "price")
                label.Text = $"${pizza.TotalPrice.ToString()}";
            
            // get size label 
            else if (option == "size")
            {
                switch (pizza.PizzaSize)
                {
                    case Pizza.Size.Personal:
                        label.Text = "Personal";
                        break;
                    case Pizza.Size.Small:
                        label.Text = "Small";
                        break;
                    case Pizza.Size.Medium:
                        label.Text = "Medium";
                        break;
                    default:
                        label.Text = "Large";
                        break;
                }
            }

            return label;
        }

        /// <summary>
        /// Purchase pizzas, show message box and return to main form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void purchaseButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Constants.PurchaseMessage +
                            $" You were charged ${totalPrice.ToString("F2")} for {cart.GetCart().Count} pizzas.",
                            Constants.SuccessMessage,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
            Close();
        }

        /// <summary>
        // Closes the form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void continueShoppingButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
