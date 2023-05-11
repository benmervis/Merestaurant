using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Merestaurant
{
    public partial class FormTables : Form
    {
        public FormTables()
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

        private void button1_Click(object sender, EventArgs e)
        {
           

            FormOrder form = new FormOrder();

            int length = Table1.Text.Length;


            cGeneral.ButtonValue = Table1.Text.Substring(length - 6, 6);
            cGeneral.ButtonName = Table1.Name;

            this.Close();
            form.ShowDialog();



        }

        private void button2_Click(object sender, EventArgs e)
        {

            FormOrder form = new FormOrder();

            int length = Table2.Text.Length;


            cGeneral.ButtonValue = Table2.Text.Substring(length - 6, 6);
            cGeneral.ButtonName = Table2.Name;

            this.Close();
            form.ShowDialog();


        }

        private void button3_Click(object sender, EventArgs e)
        {

            FormOrder form = new FormOrder();

            int length = Table3.Text.Length;


            cGeneral.ButtonValue = Table3.Text.Substring(length - 6, 6);
            cGeneral.ButtonName = Table3.Name;

            this.Close();
            form.ShowDialog();


        }

        private void button4_Click(object sender, EventArgs e)
        {
            

            FormOrder form = new FormOrder();

            int length = Table4.Text.Length;


            cGeneral.ButtonValue = Table4.Text.Substring(length - 6, 6);
            cGeneral.ButtonName = Table4.Name;

            this.Close();
            form.ShowDialog();



        }

        private void button16_Click(object sender, EventArgs e)
        {
            

            FormOrder form = new FormOrder();

            int length = Table5.Text.Length;


            cGeneral.ButtonValue = Table5.Text.Substring(length - 6, 6);
            cGeneral.ButtonName = Table5.Name;

            this.Close();
            form.ShowDialog();



        }

        private void button8_Click(object sender, EventArgs e)
        {
            FormOrder form = new FormOrder();

            int length = Table6.Text.Length;


            cGeneral.ButtonValue = Table6.Text.Substring(length - 6, 6);
            cGeneral.ButtonName = Table6.Name;

            this.Close();
            form.ShowDialog();



        }

        private void button6_Click(object sender, EventArgs e)
        {
            

            FormOrder form = new FormOrder();

            int length = Table7.Text.Length;


            cGeneral.ButtonValue = Table7.Text.Substring(length - 6, 6);
            cGeneral.ButtonName = Table7.Name;

            this.Close();
            form.ShowDialog();



        }

        private void button7_Click(object sender, EventArgs e)
        {
          


            FormOrder form = new FormOrder();

            int length = Table8.Text.Length;


            cGeneral.ButtonValue = Table8.Text.Substring(length - 6, 6);
            cGeneral.ButtonName = Table8.Name;

            this.Close();
            form.ShowDialog();


        }

        private void button9_Click(object sender, EventArgs e)
        {


            FormOrder form = new FormOrder();

            int length = Table9.Text.Length;


            cGeneral.ButtonValue = Table9.Text.Substring(length - 6, 6);
            cGeneral.ButtonName = Table9.Name;

            this.Close();
            form.ShowDialog();


        }

        private void button17_Click(object sender, EventArgs e)
        {
           

            FormOrder form = new FormOrder();

            int length = Table10.Text.Length;


            cGeneral.ButtonValue = Table10.Text.Substring(length - 6, 6);
            cGeneral.ButtonName = Table10.Name;

            this.Close();
            form.ShowDialog();



        }

        private void button12_Click(object sender, EventArgs e)
        {
           


            FormOrder form = new FormOrder();

            int length = Table11.Text.Length;


            cGeneral.ButtonValue = Table11.Text.Substring(length - 6, 6);
            cGeneral.ButtonName = Table11.Name;

            this.Close();
            form.ShowDialog();



        }

        private void button11_Click(object sender, EventArgs e)
        {

            FormOrder form = new FormOrder();

            int length = Table12.Text.Length;


            cGeneral.ButtonValue = Table12.Text.Substring(length - 6, 6);
            cGeneral.ButtonName = Table12.Name;

            this.Close();
            form.ShowDialog();



        }

        private void button13_Click(object sender, EventArgs e)
        {


            FormOrder form = new FormOrder();

            int length = Table13.Text.Length;


            cGeneral.ButtonValue = Table13.Text.Substring(length - 6, 6);
            cGeneral.ButtonName = Table13.Name;

            this.Close();
            form.ShowDialog();


        }

        private void button14_Click(object sender, EventArgs e)
        {

            FormOrder form = new FormOrder();

            int length = Table14.Text.Length;


            cGeneral.ButtonValue = Table14.Text.Substring(length - 6, 6);
            cGeneral.ButtonName = Table14.Name;

            this.Close();
            form.ShowDialog();



        }

        private void button18_Click(object sender, EventArgs e)
        {
            

            FormOrder form = new FormOrder();

            int length = Table15.Text.Length;


            cGeneral.ButtonValue = Table15.Text.Substring(length - 6, 6);
            cGeneral.ButtonName = Table15.Name;

            this.Close();
            form.ShowDialog();



        }

        private void button10_Click(object sender, EventArgs e)
        {
            

            FormOrder form = new FormOrder();

            int length = Table16.Text.Length;


            cGeneral.ButtonValue = Table16.Text.Substring(length - 6, 6);
            cGeneral.ButtonName = Table16.Name;

            this.Close();
            form.ShowDialog();



        }

        private void button5_Click(object sender, EventArgs e)
        {

            FormOrder form = new FormOrder();

            int length = Table17.Text.Length;


            cGeneral.ButtonValue = Table17.Text.Substring(length - 6, 6);
            cGeneral.ButtonName = Table17.Name;

            this.Close();
            form.ShowDialog();




        }

        private void button15_Click(object sender, EventArgs e)
        {
           

            FormOrder form = new FormOrder();

            int length = Table18.Text.Length;


            cGeneral.ButtonValue = Table18.Text.Substring(length - 6, 6);
            cGeneral.ButtonName = Table18.Name;

            this.Close();
            form.ShowDialog();



        }

        private void button19_Click(object sender, EventArgs e)
        {


            FormOrder form = new FormOrder();

            int length = Table19.Text.Length;


            cGeneral.ButtonValue = Table19.Text.Substring(length - 6, 6);
            cGeneral.ButtonName = Table19.Name;

            this.Close();
            form.ShowDialog();



        }

        private void button20_Click(object sender, EventArgs e)
        {

            FormOrder form = new FormOrder();

            int length = Table20.Text.Length;


            cGeneral.ButtonValue = Table20.Text.Substring(length - 6, 6);
            cGeneral.ButtonName = Table20.Name;

            this.Close();
            form.ShowDialog();



        }
        cGeneral gnl = new cGeneral();
        private void FormTables_Load_1(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select Situation,ID from Tables", con);
            SqlDataReader dr = null;

            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                foreach (Control item in this.Controls)
                {
                    if (item is Button)
                    {
                        if (item.Name == "Table" + dr["ID"].ToString() && dr["Situation"].ToString() == "1")
                        {
                            item.BackColor = Color.Green;

                        }
                        else if (item.Name == "Table" + dr["ID"].ToString() && dr["Situation"].ToString() == "2")
                        {
                            /*
                            cTables tbl = new cTables();
                            DateTime date1 = Convert.ToDateTime(tbl.SessionInf(2));
                            DateTime date2 = DateTime.Now;

                            string st1 = Convert.ToDateTime(tbl.SessionInf(2)).ToShortTimeString();
                            string st2 = DateTime.Now.ToShortTimeString();

                            DateTime time1 = date1.AddMinutes(DateTime.Parse(st1).TimeOfDay.TotalMinutes);
                            DateTime time2 = date2.AddMinutes(DateTime.Parse(st2).TimeOfDay.TotalMinutes);

                            var difference = time2 - time1;

                            item.Text = 
                                String.Format("{0}{1}{2}",
                                difference.Days > 0 ? string.Format("{0} Days\n", difference.Days) : "",
                                difference.Hours > 0 ? string.Format("{0} Hours\n", difference.Hours) : "",
                                difference.Minutes > 0 ? string.Format("{0} Minutes", difference.Minutes) : "").Trim() +"\n\n\nTable " + dr["ID"].ToString();
                            */
                            item.BackColor = Color.Red;
                        }
                        else if (item.Name == "Table" + dr["ID"].ToString() && dr["Situation"].ToString() == "3")
                        {
                            item.BackColor = Color.Yellow;
                        }
                    }
                }

            }

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
