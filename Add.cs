using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace UI
{// A class used to add to the database using the winform user interface.
    public partial class Add : Form
    {
       
        // initializer method used for designer support
        public Add()
        {
            InitializeComponent();
            
        }
        // Method that is generated to support the "Add" form blank window.
        private void Add_Load(object sender, EventArgs e)
        {
            

        }
        // Method that is generated for the use of a textbox in the "Add" form window.
        // the car id is what is supposed to typed into this text box
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        // Method that is generated for the use of a textbox in the "Add" form window.
        // the vehicle make is what is supposed to typed into this text box
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        // Method that is generated for the use of a textbox in the "Add" form window.
        // the vehicle model is what is supposed to typed into this text box
        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        
        }
        // Method that is generated for the use of a textbox in the "Add" form window.
        // the vehicle mileage is what is supposed to typed into this text box
        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        // Text label function that prints out to the "Add" form when used
        // by the "add_button" method if the adding was successful or not to
        // the database.
        private void label5_Click(object sender, EventArgs e)
        {

        }

        // Function that is activated when the "add" button is clicked from the "add" form,
        // this function takes the input from 1 to 4 text boxes and then
        // adds them to the database using the "addCar" function from the "Cars" class
        private void add_button(object sender, EventArgs e)
        {
            int CarId = int.Parse(textBox1.Text.Trim());
            string make = textBox2.Text.Trim();
            string model = textBox3.Text.Trim();
            int milage = int.Parse(textBox4.Text.Trim());
            Cars c = new Cars();
            var result = c.AddCar(CarId, make, model, milage);
            if (result > 0)
            {
                LblMsg.Text = "Succesfully added vehicle.";
                LblMsg.ForeColor = Color.Green;
            }
            else
            {
                LblMsg.Text = "Failed to add vehicle.";
                LblMsg.ForeColor = Color.Red;
            }
        }

        
   
    }
}
