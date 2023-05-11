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
    public partial class FormBills : Form
    {
        public FormBills()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button21_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormOrder order = new FormOrder();
            order.Show();
        }

        private void button22_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to exit?", "Warning!!!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        cOrder order = new cOrder();
        private void FormBills_Load(object sender, EventArgs e)
        {
            if(cGeneral.serviceTypeID==1)
            {
                lblBillID.Text = cGeneral.BillID;
                order.GetByOrder(lvBill, Convert.ToInt32(lblBillID.Text));

                if(lvBill.Items.Count>0)
                {
                    decimal sum = 0;

                    for(int i=0;i<lvBill.Items.Count;i++)
                    {
                        sum += Convert.ToDecimal(lvBill.Items[i].SubItems[3].Text);
                    }

                    lbTotalAmount.Text = String.Format("{0:0.0000}",sum);
                
                
                }



            }
        }

        private void lbTotalAmount_Click(object sender, EventArgs e)
        {

        }

        cTables tables = new cTables();
        cReservation res = new cReservation();

        private void btnCloseAccount_Click(object sender, EventArgs e)
        {
            if(cGeneral.serviceTypeID==1)
            {
                int TableID = tables.TableGetByNumber(cGeneral.ButtonValue);
                int customerID = 0;

                if(tables.TableGetByState(TableID,3)==true)
                {
                    customerID = res.getByCustomerIdFromReservation(TableID);

                }
                else
                {
                    customerID = 1;
                }

                cPayment payment = new cPayment();

                payment.BillID1=Convert.ToInt32(lblBillID.Text);
                payment.CustomerID1= customerID;
                payment.TotalAmount1= Convert.ToInt32(lbTotalAmount.Text);

                bool result = payment.BillClose(payment);

                if(result)
                {
                    MessageBox.Show("Account Closed.");
                    tables.SetChangeTableState(Convert.ToString(TableID),1);
                    
                    cReservation r = new cReservation();
                    r.ReservationClose(Convert.ToInt32(lblBillID.Text));

                    cBills b = new cBills();
                    b.AccountClose(Convert.ToInt32(lblBillID.Text), 0);

                    this.Close();
                    FormTables frm = new FormTables();
                    frm.Show();

                }

                else
                {
                    MessageBox.Show("An error occurred while closing the account.");
                }

                
            }
        }

        private void lvBill_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
