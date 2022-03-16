using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace UI
{
    public partial class UpdateForm : Form
    {
        int CarId =-1;
        Form1 FormView = null;

        // added Form1 as a parameter inorder to display the updated database
        public UpdateForm(int id, Form1 c)
        {
            InitializeComponent();
            CarId = id;
            FormView = c;
        }

        // update button, call on update function from Cars.cs
        private void button1_Click(object sender, EventArgs e)
        {
            Cars c = new Cars();        
            int result = c.Update(CarId, textBox2.Text.Trim(), textBox3.Text.Trim(),
            int.Parse(textBox4.Text.Trim()));
            if (result > 0)
            {
                LblMsg.Text = "Updated successful.";
                LblMsg.ForeColor = Color.Green;
                
                // outputs new updated database
                if(FormView != null)
                {
                    FormView.LoadDataGridView();
                }
            }
            else
            {
                LblMsg.Text = "Failed to update vehicle.";
                LblMsg.ForeColor = Color.Red;
            }
        }

        // fills in car info into text boxes on UpdateForm
        // using a valid car id from "getCarId: function from Cars.cs
        private void UpdateForm_Load(object sender, EventArgs e)
        {
            Cars car = new Cars();
            DataTable dt = car.getCarId(CarId);
            if (dt.Rows.Count > 0)
            {
                textBox1.Text = dt.Rows[0]["CarID"].ToString();
                textBox2.Text = dt.Rows[0]["make"].ToString();
                textBox3.Text = dt.Rows[0]["model"].ToString();
                textBox4.Text = dt.Rows[0]["mileage"].ToString();
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
