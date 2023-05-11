using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Merestaurant
{
    internal class cPersonnelMovements
    {
        cGeneral gnl = new cGeneral();

        #region Fields
        private int ID;
        private int PersonnelID;
        private string Operation;
        private DateTime Date;
        private bool Situation;

        #endregion
        #region Properties
        public int ID1 { get => ID; set => ID = value; }
        public int PersonnelID1 { get => PersonnelID; set => PersonnelID = value; }
        public string Operation1 { get => Operation; set => Operation = value; }
        public DateTime Date1 { get => Date; set => Date = value; }
        public bool Situation1 { get => Situation; set => Situation = value; }

        #endregion


        public bool PersonnelMovementSave(cPersonnelMovements pm)
        {

            bool result = false;

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Insert Into PersonnelMovements(PersonnelID,Operation,Date)Values(@PersonnelID,@Operation,@Date)", con);
            
            try
            {
                if(con.State==ConnectionState.Closed)
                {
                    con.Open();    
                }

                cmd.Parameters.Add("@PersonnelID",SqlDbType.Int).Value = pm.PersonnelID;
                cmd.Parameters.Add("@Operation",SqlDbType.VarChar).Value = pm.Operation;
                cmd.Parameters.Add("@Date",SqlDbType.DateTime).Value = pm.Date;

                result = Convert.ToBoolean(cmd.ExecuteNonQuery());

            
            }
            catch(SqlException ex)
            {
                string error = ex.Message;
                throw;
            }

            return result;

        }


    }

}
