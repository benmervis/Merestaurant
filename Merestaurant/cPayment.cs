using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Merestaurant
{
    internal class cPayment
    {

        cGeneral gnl = new cGeneral();
        #region Fields

        private int PaymentID;
        private int BillID;
        private decimal TotalAmount;
        private DateTime Date;
        private decimal CustomerID;
        private int Situation;
        #endregion

        #region Properties

        public int PaymentID1 { get => PaymentID; set => PaymentID = value; }
        public int BillID1 { get => BillID; set => BillID = value; }
        public decimal TotalAmount1 { get => TotalAmount; set => TotalAmount = value; }
        public DateTime Date1 { get => Date; set => Date = value; }
        public decimal CustomerID1 { get => CustomerID; set => CustomerID = value; }
        public int Situation1 { get => Situation; set => Situation = value; }

        #endregion

        //customer's table account closing function
        public bool BillClose(cPayment account)
        {

            bool result = false;


            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Insert Into AccountPayments(BillID, CostumerID,TotalAmount, Date,Situation) values (@BillID, @CostumerID,@TotalAmount, @Date,@Situation)", con);

            cmd.Parameters.Add("@BillID", SqlDbType.Int).Value = BillID;

            try
            {
                if(con.State==ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.Parameters.Add("@BillID", SqlDbType.Int).Value = BillID;
                cmd.Parameters.Add("@TotalAmount", SqlDbType.Money).Value = TotalAmount;
                cmd.Parameters.Add("@CostumerID", SqlDbType.Int).Value = CustomerID;
                cmd.Parameters.Add("@Situation", SqlDbType.Int).Value = Situation1;
                cmd.Parameters.Add("@Date", SqlDbType.DateTime).Value = Date;
                
                result = Convert.ToBoolean(cmd.ExecuteNonQuery());
            
            }
            catch(SqlException ex) 
            {
                string error = ex.Message;

                throw;
                
            }
            finally
            {
                con.Dispose();
                con.Close();
            }

            return result;

        }


        //we write down the customer's total spend
        public decimal totalForCustomer(int customerID)
        {
            decimal total = 0;

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select sum(TotalAmount) as total from AccountPayments Where CostumerID=@CustomerID",con);

            try
            {
                if(con.State==ConnectionState.Closed)
                {
                    con.Open();
                }



                cmd.Parameters.Add("@CostumerID", SqlDbType.Int).Value = CustomerID;
                total = Convert.ToDecimal(cmd.ExecuteScalar());
            }
            catch(SqlException ex) 
            { 
                string error = ex.Message;
                throw;
            
            }
            finally 
            
            { 
                con.Dispose();
                con.Close(); 
            }





            

            return total;
        }

    }
}
