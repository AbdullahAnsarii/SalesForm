using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace loginAndInvoice
{
    public partial class Login : Form
    {
        //declaring variables and creating object of classes
        public static string id, name, email, password, gender;
        DBAccess objDb = new DBAccess();
        DataTable objDt = new DataTable();
        Signup signupObj = new Signup();
        public Login()
        {
            InitializeComponent();
        }

        private void btnSignupLogin_Click(object sender, EventArgs e)
        {
            //redirecting to signup page
            signupObj.Show();
            this.Hide();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            //saving login credentials
            string loginEmail = emailLogin.Text;
            string loginPassword = passwordLogin.Text;
            //checking if user has left any field empty
            if (loginEmail.Equals("")){
                MessageBox.Show("Please Enter Email");
            }
            else if (loginPassword.Equals(""))
            {
                MessageBox.Show("Please Enter Password");
            }
            //checking if user has enter valid credentials
            else
            {
                string query = "Select * from Users where Email = '" + loginEmail + "' AND Password = '" + loginPassword + "'";
                //this command will read database line by line and check if email and pwd matches if it matches it will add it to objDt table

                objDb.readDatathroughAdapter(query, objDt);
                if (objDt.Rows.Count == 1)
                {
                    id = objDt.Rows[0]["ID"].ToString();
                    name = objDt.Rows[0]["Name"].ToString();
                    email = objDt.Rows[0]["Email"].ToString();
                    gender = objDt.Rows[0]["Gender"].ToString();
                    objDb.closeConn();
                    this.Hide();
                    Order objOrder = new Order();
                    objOrder.Show();
                }
                else
                {
                    MessageBox.Show("Invalid credentials");
                }
            }

        }
    }
}
