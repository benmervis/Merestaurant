using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Merestaurant
{
    internal class cOrder
    {
        cGeneral gnl = new cGeneral();

        #region Fields

        private int ID;
        private int BillID;
        private int ProductID;
        private int number;
        private int TableID;

        #endregion

        #region Properties
        public int ID1 { get => ID; set => ID = value; }
        public int BillID1 { get => BillID; set => BillID = value; }
        public int ProductID1 { get => ProductID; set => ProductID = value; }
        public int Number { get => number; set => number = value; }
        public int TableID1 { get => TableID; set => TableID = value; }

        #endregion

        public void GetByOrder(ListView lv,int BillID)
        {
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select ProductName,Price,Sales.ID,Sales.ProductID,Sales.Number from Sales Inner Join Products on Sales.ProductID=Products.ID Where BillID=@BillID", con);

            SqlDataReader dr = null;

            cmd.Parameters.Add("@BillID", SqlDbType.Int).Value = BillID;
            try
            {
                if(con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                dr = cmd.ExecuteReader();

                int counter = 0;
                while(dr.Read())
                {
                    lv.Items.Add(dr["ProductName"].ToString());
                    lv.Items[counter].SubItems.Add(dr["Number"].ToString());    
                    lv.Items[counter].SubItems.Add(dr["ProductID"].ToString());
                    lv.Items[counter].SubItems.Add(Convert.ToString(Convert.ToDecimal(dr["Price"]) * Convert.ToDecimal(dr["Number"])));
                    lv.Items[counter].SubItems.Add(dr["ID"].ToString());

                    counter++;

                }
            }
            catch (SqlException ex)
            {
                string error = ex.Message;
            }

            finally
            {
                dr.Close();
                con.Close();
                con.Dispose();

            }
        }

        public bool SetSaveOrder(cOrder Informations)
        {
            bool result = false;

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Insert Into Sales(BillID,ProductID,Number,TableID) values(@BillID,@ProductID,@Number,@TableID)", con);

            try
            {
                if(con.State==ConnectionState.Closed)
                {
                    con.Open();
                }

                cmd.Parameters.Add("BillID", SqlDbType.Int).Value = Informations.BillID;
                cmd.Parameters.Add("ProductId", SqlDbType.Int).Value = Informations.ProductID;
                cmd.Parameters.Add("Number", SqlDbType.Int).Value = Informations.Number;
                cmd.Parameters.Add("TableID", SqlDbType.Int).Value = Informations.TableID;

                result=Convert.ToBoolean(cmd.ExecuteNonQuery());


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
    }
}
