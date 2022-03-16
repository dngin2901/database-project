using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using UI;
using System.Threading;

namespace UI
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }

        // function for displaying inventory and creating the update button column
        public void LoadDataGridView()
        {
            dataGridView1.DataSource = null;
            dataGridView1.Columns.Clear();
            Cars c = new Cars();
            dataGridView1.DataSource = c.getAllCars();

            // creates the 'Update" column as a button.
            DataGridViewButtonColumn ButtonCol = new DataGridViewButtonColumn();
            ButtonCol.HeaderText = "Update";
            ButtonCol.Text = "Update";
            ButtonCol.Name = "Update";
            ButtonCol.UseColumnTextForButtonValue = true;
            ButtonCol.Width = 50;
            dataGridView1.Columns.Add(ButtonCol);

        }

        //show inventory button function
        private void Show_Database_Click(object sender, EventArgs e)
        {
            LoadDataGridView();
        }

        //search database for make or model
        private void Search_Database_Click(object sender, EventArgs e)
        {
            Cars c = new Cars();
            dataGridView1.DataSource = c.getCarByModel(SearchBox1.Text.Trim());
            dataGridView1.DataSource = c.getCarByMake(SearchBox1.Text.Trim());
        }

        //add button function
        private void Add_ToDatabase_Click(object sender, EventArgs e)
        {
            Add vehicle = new Add();
            vehicle.Show();
        }
       
        //delete button function
        private void delete_button_Click(object sender, EventArgs e)
        {
            int id = int.Parse(SearchBox1.Text.Trim());
            Cars c = new Cars();
            var result = c.Delete(id);
            if (result > 0)
            {
                MessageBox.Show("Deleted");
            }
            else
            {
                MessageBox.Show("Not Deleted");
            }
        }

        //update button function
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // once update cell is clicked parse car id into string
            if (e.ColumnIndex == 4 && e.RowIndex >= 0)
            {
                int carID = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                
                // open update form to size with car information
                UpdateForm update = new UpdateForm(carID, this);
                update.StartPosition = FormStartPosition.Manual;
                Rectangle pos = Screen.PrimaryScreen.Bounds;
                update.Location = new Point(pos.Width - update.Width);
                update.ShowDialog();
            }
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void openFile_button(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if(openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string strfilename = openFileDialog.FileName;
                DataAccess access = new DataAccess();

                access.openPath(strfilename);
                LoadDataGridView();
                
            }
            /*openFileDialog1.ShowDialog();
            string FileName = openFileDialog1.FileName;
            string readfile = File.ReadAllText(FileName);*/
            
        }
    }
}
