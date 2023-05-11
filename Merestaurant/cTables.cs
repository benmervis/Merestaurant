using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merestaurant
{
    internal class cTables
    {
        #region Fields

        private int ID;
        private int Capacity;
        private int ServiceType;
        private int Situation;
        private int Confirmation;

        #endregion

        #region Properties
        public int ID1 { get => ID; set => ID = value; }
        public int Capacity1 { get => Capacity; set => Capacity = value; }
        public int ServiceType1 { get => ServiceType; set => ServiceType = value; }
        public int Situation1 { get => Situation; set => Situation = value; }
        public int Confirmation1 { get => Confirmation; set => Confirmation = value; }

        #endregion


        cGeneral gnl = new cGeneral();
        
        public string SessionInf(int state)
        {
            string date = "";

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select Date,TableID From Bills Right Join Tables on Bills.TableID=Tables.ID Where Tables.Situation=@Situation and Bills.Situation=0", con);
            SqlDataReader dr = null;
            cmd.Parameters.Add("@Situation",SqlDbType.Int).Value = state;
            //cmd.Parameters.Add("@TableID", SqlDbType.Int).Value = Convert.ToInt32(tableID);


            try
            {
                if(con.State==ConnectionState.Closed)
                {
                    con.Open();
                }
                dr = cmd.ExecuteReader();
                while(dr.Read())
                {
                    date = Convert.ToDateTime(dr["Date"]).ToString();
                }

            }
            catch (SqlException ex)
            {
                string error = ex.Message;

                throw;
            }
            finally
            {
                dr.Close();
                con.Dispose();
                con.Close();
            }

            return date;
        }

        public int TableGetByNumber(string TableValue)
        {
            string value = TableValue;
            int length = value.Length;

            return Convert.ToInt32(value.Substring(length - 1, 1));
        }

        public bool TableGetByState(int ButtonName,int state)
        {
            bool result = false;
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select Situation From Tables Where ID=@TableID and Situation=@state", con);

            cmd.Parameters.Add("@TableID",SqlDbType.Int).Value = ButtonName;
            cmd.Parameters.Add("@state",SqlDbType.Int).Value=state;

            try
            {
                if(con.State==ConnectionState.Closed)
                {
                    con.Open();
                }

                result = Convert.ToBoolean(cmd.ExecuteScalar());
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

            return result;
        }

        public void SetChangeTableState(string ButtonName,int State)
        {
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Update Tables Set Situation=@Situation where ID=@TableID", con);

            if(con.State==ConnectionState.Closed)
            {
                con.Open();
            }

            string aa=ButtonName;
            int length = aa.Length;

            cmd.Parameters.Add("@Situation", SqlDbType.Int).Value = State;
            cmd.Parameters.Add("@TableID", SqlDbType.Int).Value = aa.Substring(length - 1, 1);
            cmd.ExecuteNonQuery();

            con.Dispose();
            con.Close();
        }
    }
}
