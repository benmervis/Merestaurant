using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Merestaurant
{
    public partial class FormLogin : Form
    {
       
        public FormLogin()
        {
            InitializeComponent();
        }

        
        
        
        private void Form1_Load(object sender, EventArgs e)
        {
            cPersonnel p = new cPersonnel();
            p.PersonnelGetByInformation(cbNickName);


        }
         private void btnLogIn_Click(object sender, EventArgs e)
        {
            //cGeneral gnl = new cGeneral();
            cPersonnel p = new cPersonnel();
            
            bool result = p.PersonnelEntryControl(textBox1.Text,cGeneral.PersonnelID);

            if(result)
            {
                cPersonnelMovements pem = new cPersonnelMovements();
                pem.PersonnelID1 = cGeneral.PersonnelID;
                pem.Operation1 = "Logged In";
                pem.Date1= DateTime.Now;
                pem.PersonnelMovementSave(pem);
                
                this.Hide();
                FormMenu menu = new FormMenu();
                menu.Show();
            }

            else
            {
                MessageBox.Show("Wrong user login.\r\nTry again!", "Warning!!!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }       
        
        private void btnExit_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are you sure you want to exit?","Warning!!!",MessageBoxButtons.YesNo,MessageBoxIcon.Warning)==DialogResult.Yes)
            {
                Application.Exit();
            }

        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }



        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            cPersonnel p = (cPersonnel)cbNickName.SelectedItem;
            cGeneral.PersonnelID = p.ID1;
            cGeneral.GorevID = p.DutyID1;

        }



        private void label1_Click(object sender, EventArgs e)
        {

        }


    }
}
