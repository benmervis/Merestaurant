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
    public partial class FormKitchen : Form
    {
        public FormKitchen()
        {
            InitializeComponent();
        }

        private void button21_Click(object sender, EventArgs e)
        {

            this.Hide();
            FormMenu menu = new FormMenu();
            menu.Show();
        }

        private void button22_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to exit?", "Warning!!!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void FormKitchen_Load(object sender, EventArgs e)
        {

        }
    }
}
