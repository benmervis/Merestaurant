using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Diagnostics;
using System.Data.SqlTypes;

namespace Merestaurant
{
    internal class cProductTypes
    {
        cGeneral gnl = new cGeneral();


        #region Fields
        private int PruductTypeNo;
        private int Category;
        private int Explanation;
        #endregion

        #region Properties
        public int PruductTypeNo1 { get => PruductTypeNo; set => PruductTypeNo = value; }
        public int Category1 { get => Category; set => Category = value; }
        public int Explanation1 { get => Explanation; set => Explanation = value; }

        #endregion

        public void GetByProductTypes(ListView Types, Button btn)
        {
            Types.Items.Clear();

            SqlConnection conn=new SqlConnection(gnl.conString);
            SqlCommand comm = new SqlCommand("Select ProductName,Price,Products.ID From Categories Inner Join Products on Categories.ID=Products.CategoryID where Products.CategoryID=@CategoryID", conn);

            string aa = btn.Name;
            int length = aa.Length;

            comm.Parameters.Add("@CategoryID",SqlDbType.Int).Value = aa.Substring(length - 1, 1);

            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }

            SqlDataReader dr = comm.ExecuteReader();

            int i = 0;

            while (dr.Read())
            {
                Types.Items.Add(dr["ProductName"].ToString());
                Types.Items[i].SubItems.Add(dr["Price"].ToString());
                Types.Items[i].SubItems.Add(dr["ID"].ToString());
                i++;
            }
            dr.Close();
            conn.Dispose();
            conn.Close();


        }

        public bool GetByProducts(ListView lvProducts, string ProductName,SqlMoney Price)
        {
            bool result = false;

            cGeneral gnl = new cGeneral();

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select from Products  where ProductName=@ProductName ,Price=@Price", con);

            SqlDataReader dr = null; 

            cmd.Parameters.Add("@ProductName", SqlDbType.VarChar).Value = ProductName;
            cmd.Parameters.Add("@Price", SqlDbType.VarChar).Value = Price;

            dr = cmd.ExecuteReader();
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                

                int counter = 0;
                while (dr.Read())
                {
                    lvProducts.Items.Add(dr["ProductName"].ToString());
                    lvProducts.Items[counter].SubItems.Add(dr["Price"].ToString());

                    counter++;

                }
                result = Convert.ToBoolean(cmd.ExecuteScalar());
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


            return result;
        }
    }

    }

