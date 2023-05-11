using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Merestaurant
{
    internal class cReservation
    {
        cGeneral gnl = new cGeneral();
        #region Fields
        private int ID;
        private int TableID;
        private int CustomerID;
        private DateTime Date;
        private int BillID;

        #endregion


        #region Properties 

        public int ID1 { get => ID; set => ID = value; }
        public int TableID1 { get => TableID; set => TableID = value; }
        public int CustomerID1 { get => CustomerID; set => CustomerID = value; }
        public DateTime Date1 { get => Date; set => Date = value; }
        public int BillID1 { get => BillID; set => BillID = value; }

        #endregion

       
        public int getByCustomerIdFromReservation(int tableID)
        {
            int custID=0 ;

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select top 1 CustomerID from Reservations where TableID=@tableID order by CustomerID Desc", con);

            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                cmd.Parameters.Add("tableID", SqlDbType.Int).Value = TableID;

                custID = Convert.ToInt32(cmd.ExecuteNonQuery());


            }
            catch (SqlException ex)
            {
                string error = ex.Message;
            }
            finally
            {
                con.Dispose();
                con.Close();
            }



            return tableID;

        }


        //close table with reservation when closing account
        public bool ReservationClose(int BillID)
        {
            bool result = false;


            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Update Reservations set Situation = 0 where BillID=@BillID", con);

            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }



                cmd.Parameters.Add("@BillID", SqlDbType.Int).Value = BillID;
                result = Convert.ToBoolean(cmd.ExecuteScalar());
            }
            catch (SqlException ex)
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

    }
}
