using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Merestaurant
{
    public partial class FormProducts : Form
    {
        public FormProducts()
        {
            InitializeComponent();
        }
        SqlMoney Price;
        private void FormProducts_Load(object sender, EventArgs e)
        {
            cProductTypes pt= new cProductTypes();
            bool result = pt.GetByProducts(lvProducts, ProductName, Price);

        }
    }
}
