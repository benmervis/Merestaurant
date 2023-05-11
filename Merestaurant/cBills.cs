using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merestaurant
{
    internal class cBills
    {
        cGeneral gnl = new cGeneral();

        #region Fields

        private int ID;
        private int ServiceTypeID;
        private int PersonnelID;
        private int TableID;
        private DateTime Date;
        private int Situation;
        private decimal Amount;

        #endregion

        #region Properties
        public int ID1 { get => ID; set => ID = value; }
        public int ServiceTypeID1 { get => ServiceTypeID; set => ServiceTypeID = value; }
        public int PersonnelID1 { get => PersonnelID; set => PersonnelID = value; }
        public int TableID1 { get => TableID; set => TableID = value; }
        public DateTime Date1 { get => Date; set => Date = value; }
        public int Situation1 { get => Situation; set => Situation = value; }
        public decimal Amount1 { get => Amount; set => Amount = value; }

        #endregion

        public int GetByBills(int TableID)
        {
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select top 1 ID From Bills Where TableID=@TableID Order by ID desc", con);

            cmd.Parameters.Add("@TableID", SqlDbType.Int).Value = TableID;

            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                TableID = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (SqlException ex)
            {
                string error = ex.Message;
            }
            finally
            {
                con.Close();
            }

            return TableID;
        }//Ticket number of the open table

        public bool SetByBillNew(cBills Informations)
        {
            bool result = false;

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Insert Into Bills(ServiceTypeID,Date,PersonnelID,TableID,Situation) values(@ServiceTypeID,@Date,@PersonnelID,@TableID,@Situation)", con);

            try
            {
                if(con.State== ConnectionState.Closed)
                {
                    con.Open();
                }

                cmd.Parameters.Add("@ServiceTypeID", SqlDbType.Int).Value = Informations.ServiceTypeID;

                cmd.Parameters.Add("@Date", SqlDbType.DateTime).Value = Informations.Date;
                cmd.Parameters.Add("@PersonnelID", SqlDbType.Int).Value = Informations.PersonnelID;
                cmd.Parameters.Add("@TableID", SqlDbType.Int).Value = Informations.TableID;
                cmd.Parameters.Add("@Situation", SqlDbType.Bit).Value = Informations.Situation;
                result = Convert.ToBoolean(cmd.ExecuteNonQuery());

            }
            catch(SqlException ex)
            {
                string error = ex.Message;
            }

            finally 
            {
                con.Dispose();
                con.Close(); 
            }

            return result;

        }

        public bool AccountClose(int BillID,int state)
        {
            bool result = false;


            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Update Bills set Situation = 0 where BillID=@BillID", con);

            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }



                cmd.Parameters.Add("BillID", SqlDbType.Int).Value = BillID;
                cmd.Parameters.Add("state",SqlDbType.Int).Value=state;
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
