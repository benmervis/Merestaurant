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
    public partial class FormOrder : Form
    {
        public FormOrder()
        {
            InitializeComponent();
        }

        //calculate for number of drinks or foods.
        void calculation(object sender, EventArgs e)
        {
            Button btn = sender as Button;

            switch (btn.Name)
            {
                case "btn1":
                    txtNumber.Text += (1).ToString();
                    break;
                case "btn2":
                    txtNumber.Text += (2).ToString();
                    break;
                case "btn3":
                    txtNumber.Text += (3).ToString();
                    break;
                case "btn4":
                    txtNumber.Text += (4).ToString();
                    break;
                case "btn5":
                    txtNumber.Text += (5).ToString();
                    break;
                case "btn6":
                    txtNumber.Text += (6).ToString();
                    break;
                case "btn7":
                    txtNumber.Text += (7).ToString();
                    break;
                case "btn8":
                    txtNumber.Text += (8).ToString();
                    break;
                case "btn9":
                    txtNumber.Text += (9).ToString();
                    break;
                case "btn0":
                    txtNumber.Text += (0).ToString();
                    break;
                default:
                    MessageBox.Show("Enter a number.");

                    break;


            }
        }

        int tableID;
        int billID;


        private void FormOrder_Load(object sender, EventArgs e)
        {
            lblTableNo.Text = cGeneral.ButtonName;

            cTables tables= new cTables();
            tableID = tables.TableGetByNumber(cGeneral.ButtonValue);
            if (tables.TableGetByState(tableID, 2) == true)
            {
                cBills bill = new cBills();

                billID = bill.GetByBills(tableID);
                cOrder orders = new cOrder();
                orders.GetByOrder(lvOrders, billID);
            }


            btn1.Click += new EventHandler(calculation);
            btn2.Click += new EventHandler(calculation);
            btn3.Click += new EventHandler(calculation);
            btn4.Click += new EventHandler(calculation);
            btn5.Click += new EventHandler(calculation);
            btn6.Click += new EventHandler(calculation);
            btn7.Click += new EventHandler(calculation);
            btn8.Click += new EventHandler(calculation);
            btn9.Click += new EventHandler(calculation);
            btn0.Click += new EventHandler(calculation);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            pt.GetByProductTypes(lvMenu, btnBreakfast2);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pt.GetByProductTypes(lvMenu, btnPastas3);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnMainDishes_Click(object sender, EventArgs e)
        {
            pt.GetByProductTypes(lvMenu, btnMainDishes4);
        }

        private void button22_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to exit?", "Warning!!!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void button21_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormTables table = new FormTables();
            table.Show();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        cProductTypes pt = new cProductTypes();
        private void btnBeginnings_Click(object sender, EventArgs e)
        {
            
            pt.GetByProductTypes(lvMenu, btnBeginnings1);
            
        }

        private void btnSnack5_Click(object sender, EventArgs e)
        {
            pt.GetByProductTypes(lvMenu, btnSnack5);
        }

        private void btnBurgers6_Click(object sender, EventArgs e)
        {
            pt.GetByProductTypes(lvMenu, btnBurgers6);
        }

        private void btnSalads7_Click(object sender, EventArgs e)
        {
            pt.GetByProductTypes(lvMenu, btnSalads7);
        }

        private void btnDesserts8_Click(object sender, EventArgs e)
        {
            pt.GetByProductTypes(lvMenu, btnDesserts8);
        }

        private void btnDrinks9_Click(object sender, EventArgs e)
        {
            pt.GetByProductTypes(lvMenu, btnDrinks9);
        }

        int counter = 0;
        //int counter2 = 0;
        private void lvMenu_DoubleClick(object sender, EventArgs e)
        {
            if(txtNumber.Text=="")
            {
                txtNumber.Text = "1";
            }


            if(lvMenu.Items.Count > 0)
            {
                counter = lvOrders.Items.Count;
                lvOrders.Items.Add(lvMenu.SelectedItems[0].Text);
                lvOrders.Items[counter].SubItems.Add(txtNumber.Text);
                lvOrders.Items[counter].SubItems.Add(lvMenu.SelectedItems[0].SubItems[2].Text);
                lvOrders.Items[counter].SubItems.Add((Convert.ToDecimal(lvMenu.SelectedItems[0].SubItems[1].Text)*Convert.ToDecimal(txtNumber.Text)).ToString());
                lvOrders.Items[counter].SubItems.Add("0");
                
                lvOrders.Items[counter].SubItems.Add(counter.ToString());
                
                txtNumber.Text = "";




            }
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            /*
             
            1-Empty Table
            2-Full Table
            3-Reservated Table
             
            */

            cTables table = new cTables();
            cBills NewBill = new cBills();
            cOrder saveOrder = new cOrder();
            FormTables Table = new FormTables();
            

            bool result = false;


            if(table.TableGetByState(tableID,1)==true)
            {
                NewBill.ServiceTypeID1 = 1;
                NewBill.PersonnelID1 = 1;
                NewBill.TableID1 = tableID;
                NewBill.Date1= DateTime.Now;

                result = NewBill.SetByBillNew(NewBill);

                table.SetChangeTableState(cGeneral.ButtonName, 2);

                if(lvOrders.Items.Count > 0)
                {
                    for(int i=0;i< lvOrders.Items.Count;i++)
                    {
                        saveOrder.TableID1 = tableID;
                        saveOrder.ProductID1 =Convert.ToInt32(lvOrders.Items[i].SubItems[2].Text);
                        saveOrder.BillID1 = NewBill.GetByBills(tableID);
                        saveOrder.Number= Convert.ToInt32(lvOrders.Items[i].SubItems[1].Text);
                        saveOrder.SetSaveOrder(saveOrder);

                    }

                    

                    this.Close();
                    Table.Show();
                    
                }

            }




        }

        private void btnPayment_Click(object sender, EventArgs e)
        {

            cGeneral.BillID = billID.ToString();
            FormBills bill = new FormBills();
            this.Close();
            bill.Show();

        }
    }
}
