using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace Merestaurant
{
    internal class cPersonnel
    {
        cGeneral gnl=new cGeneral();


        #region Fields

        private int PersonnelID;
        private int DutyID;
        private string Name;
        private string Surname;
        private string Password;
        private string NickName;
        private bool Situation;

        #endregion
        #region Properties

        public int ID1 { get => PersonnelID; set => PersonnelID = value; }
        public int DutyID1 { get => DutyID; set => DutyID = value; }
        public string Name1 { get => Name; set => Name = value; }
        public string Surname1 { get => Surname; set => Surname = value; }
        public string Password1 { get => Password; set => Password = value; }
        public string Nickname1 { get => NickName; set => NickName = value; }
        public bool Situation1 { get => Situation; set => Situation = value; }
        

        #endregion

        public bool PersonnelEntryControl(string password,int UserID)
        {
            bool result = false;


            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select * from Personnel where ID=@ID and Password=@Password", con);
            cmd.Parameters.Add("@ID",SqlDbType.VarChar).Value = UserID;
            cmd.Parameters.Add("@Password",SqlDbType.VarChar).Value = password;

            

            try
            {
                if(con.State==ConnectionState.Closed)
                {
                    con.Open();
                }

                result = Convert.ToBoolean(cmd.ExecuteScalar());
            }
            catch(SqlException ex)
            {
                string error = ex.Message;
                throw;
            }


            return result;
        }

        public void PersonnelGetByInformation(ComboBox cb)
        {

            cb.Items.Clear();


            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select * from Personnel", con);


            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                cPersonnel p = new cPersonnel();

                p.PersonnelID = Convert.ToInt32(dr["ID"]);
                p.DutyID= Convert.ToInt32(dr["DutyID"]);
                p.Name = Convert.ToString(dr["Name"]);
                p.Surname = Convert.ToString(dr["Surname"]);
                p.Password = Convert.ToString(dr["Password"]);
                p.NickName = Convert.ToString(dr["NickName"]);
                p.Situation = Convert.ToBoolean(dr["Situation"]);

                cb.Items.Add(p);

            }

            dr.Close();
            con.Close();

        }
    
        
        public override string ToString()
        {
            return NickName;
        }



    
    }
}
