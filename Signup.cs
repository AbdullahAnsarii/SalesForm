using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace loginAndInvoice
{
    public partial class Signup : Form
    {
        DBAccess dbObject = new DBAccess();

        public Signup()
        {
            InitializeComponent();
        }

        private void btnSignup_Click(object sender, EventArgs e)
        {
            //storing inputs in variables
            string userName = nameSignup.Text;
            string userEmail = emailSignup.Text;
            string userPassword = passwordSignup.Text;
            string userGender = genderBox.Text;
            //checking if any field is left empty
            if (userName.Equals(""))
            {
                MessageBox.Show("Name is a required field!!!", "Error");
            }
            else if (userEmail.Equals(""))
            {
                MessageBox.Show("Email is a required field!!!", "Error");
            }
            else if (userPassword.Equals(""))
            {
                MessageBox.Show("Password is a required field!!!", "Error");
            }
            else if (userGender.Equals(""))
            {
                MessageBox.Show("Gender is a required field!!!", "Error");
            }
            else
            {
                //saving in database
                SqlCommand insertCommand = new SqlCommand("insert into Users(Name,Email,Password,Gender) values(@userName, @userEmail, @userPassword, @userGender)");
                //making data secure
                insertCommand.Parameters.AddWithValue("@userName", userName);
                insertCommand.Parameters.AddWithValue("@userEmail", userEmail);
                insertCommand.Parameters.AddWithValue("@userPassword", userPassword);
                insertCommand.Parameters.AddWithValue("@userGender", userGender);
                
                //executing
                int row = dbObject.executeQuery(insertCommand);
                if (row == 1)
                {
                    MessageBox.Show("Account created successfully!!!");
                    this.Hide();
                    Login objLogin = new Login();
                    objLogin.Show();
                }
                else
                {
                    MessageBox.Show("Error Occured!!!");
                }
            }


        }

    }
}
