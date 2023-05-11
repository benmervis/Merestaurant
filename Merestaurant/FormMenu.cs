using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Merestaurant
{
    public partial class FormMenu : Form
    {
        public FormMenu()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {

            this.Hide();
            FormLogin login = new FormLogin();
            login.Show();

        }

        private void button1_Click(object sender, EventArgs e)
        {

                this.Hide();
                FormTables tables= new FormTables();
                tables.Show();

          
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to exit?", "Warning!!!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void FormMenu_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormKitchen kitchen = new FormKitchen();
            kitchen.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormReports reports= new FormReports();
            reports.Show();
        }


        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormReservation reservation = new FormReservation();
            reservation.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormAmount amount= new FormAmount();
            amount.Show();
        }

        private void btnProducts_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormProducts products= new FormProducts();
            products.Show();
        }
    }
}
