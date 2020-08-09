//purchase,purchase detail,sales detail,sales


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
    
    public partial class Order : Form
    {
        SqlConnection objSqlconn = new SqlConnection();
        //objects for other classes
        Reciept objRec = new Reciept();
        DBAccess objDb = new DBAccess();
        //tables for item selection
        DataTable tableItem = new DataTable();
        DataTable tableSubitems = new DataTable();
        DataTable specific = new DataTable();

        private List<Label> lSubTotal;

        //declaration of vaariables
        public static int price = 0;
        public static int quantity = 0;
        public static int subtotal = 0;
        public static int total = 0;
        public static string formattedDate;
        public static string opener;
        public static string references;
        public static string totalAmt;
        public static string deliveryDate;
        public Order()
        {
            InitializeComponent();
        }

       

        private void Order_Load(object sender, EventArgs e)
        {
            //lSubTotal = new List<Label>(5)
            //{
            //    subtotal1,
            //    subtotal2,
            //    subtotal3,
            //    subtotal4,
            //    subtotal5
            //};
            //opener and opened box code
            DateTime myDate = DateTime.Now;
            formattedDate = string.Format("{0:dd/MM/yy HH:mm:ss:tt}", myDate);
            dateOpened.Text = formattedDate;
            nameOpener.Text = Login.name;
            //turning off editing mode
            txtItemName.Enabled = false;
            txtPrice2.Enabled = false;
            txtQuantity.Enabled = false;
            txtSubtotal.Enabled = false;
            //fetching data and storing in respective datatables
            string query2 = "Select * From Subitems";
            objDb.readDatathroughAdapter(query2, tableSubitems);
            string query = "Select * From Items";
            objDb.readDatathroughAdapter(query, tableItem);
            //displaying data for item combobox
            comboBoxItem.DataSource = tableItem;
            comboBoxItem.DisplayMember = "Items";
            
        }

        private void comboBoxItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            //selecting and displaying respective subitem combobox data for selected item
            specific = tableSubitems.Select("ItemID = " + tableItem.Rows[comboBoxItem.SelectedIndex]["ItemID"]).CopyToDataTable();
            comboBoxSubitem.DataSource = specific;
            comboBoxSubitem.DisplayMember = "Subitem";
        }

        private void comboBoxSubitem_SelectedIndexChanged(object sender, EventArgs e)
        {
            //displaying and turing off editing mode for QOH and price for the item selected
            txtPrice.Text = specific.Rows[comboBoxSubitem.SelectedIndex]["Price"].ToString();
            txtPrice.Enabled = false;
            txtQoh.Text = specific.Rows[comboBoxSubitem.SelectedIndex]["QOH"].ToString();
            txtQoh.Enabled = false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //adding data to the bill
            price = Int32.Parse(txtPrice.Text);
            if (txtQty.Text == "")
            {
                MessageBox.Show("Please enter quantity of item", "Error");
            }
            else
            {
                quantity = Int32.Parse(txtQty.Text);
                subtotal = price * quantity;
                if (name1.Text.Equals(" "))
                {
                    total = total + subtotal;
                    subtotal1.Text = subtotal.ToString();
                    name1.Text = specific.Rows[comboBoxSubitem.SelectedIndex]["Subitem"].ToString();
                    price1.Text = txtPrice.Text;
                    qty1.Text = txtQty.Text;
                    lblValueTotal.Text = total.ToString();
                    int qtyNow = Int32.Parse(txtQoh.Text) - Int32.Parse(qty1.Text);
                    specific.Rows[comboBoxSubitem.SelectedIndex]["QOH"] = qtyNow;
                }
                else if (name2.Text.Equals(" "))
                {
                    total = total + subtotal;
                    subtotal2.Text = subtotal.ToString();
                    name2.Text = specific.Rows[comboBoxSubitem.SelectedIndex]["Subitem"].ToString(); ;
                    price2.Text = txtPrice.Text;
                    qty2.Text = txtQty.Text;
                    lblValueTotal.Text = total.ToString();
                    int qtyNow = Int32.Parse(txtQoh.Text) - Int32.Parse(qty1.Text);
                    specific.Rows[comboBoxSubitem.SelectedIndex]["QOH"] = qtyNow;
                }
                else if (name3.Text.Equals(" "))
                {
                    total = total + subtotal;
                    subtotal3.Text = subtotal.ToString();
                    name3.Text = specific.Rows[comboBoxSubitem.SelectedIndex]["Subitem"].ToString(); ;
                    price3.Text = txtPrice.Text;
                    qty3.Text = txtQty.Text;
                    lblValueTotal.Text = total.ToString();
                    int qtyNow = Int32.Parse(txtQoh.Text) - Int32.Parse(qty1.Text);
                    specific.Rows[comboBoxSubitem.SelectedIndex]["QOH"] = qtyNow;
                }
                else if (name4.Text.Equals(" "))
                {
                    total = total + subtotal;
                    subtotal4.Text = subtotal.ToString();
                    name4.Text = specific.Rows[comboBoxSubitem.SelectedIndex]["Subitem"].ToString(); ;
                    price4.Text = txtPrice.Text;
                    qty4.Text = txtQty.Text;
                    lblValueTotal.Text = total.ToString();
                    int qtyNow = Int32.Parse(txtQoh.Text) - Int32.Parse(qty1.Text);
                    specific.Rows[comboBoxSubitem.SelectedIndex]["QOH"] = qtyNow;
                }
                else if (name5.Text.Equals(" "))
                {
                    total = total + subtotal;
                    subtotal5.Text = subtotal.ToString();
                    name5.Text = specific.Rows[comboBoxSubitem.SelectedIndex]["Subitem"].ToString(); ;
                    price5.Text = txtPrice.Text;
                    qty5.Text = txtQty.Text;
                    lblValueTotal.Text = total.ToString();
                    int qtyNow = Int32.Parse(txtQoh.Text) - Int32.Parse(qty1.Text);
                    specific.Rows[comboBoxSubitem.SelectedIndex]["QOH"] = qtyNow;

                }
                
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //clearing bill data
            name1.Text = name2.Text = name3.Text = name4.Text = name5.Text = " ";
            price1.Text = price2.Text = price3.Text = price4.Text = price5.Text = " ";
            qty1.Text = qty2.Text = qty3.Text = qty4.Text = qty5.Text = " ";
            subtotal1.Text = subtotal2.Text = subtotal3.Text = subtotal4.Text = subtotal5.Text = " ";
            lblValueTotal.Text = "0";
            total = 0;
        }

        private void btnGenerateReciept_Click(object sender, EventArgs e)
        {
            //creating variables to access them through other forms
            opener = nameOpener.Text;
            references = txtReference.Text;
            deliveryDate = deliveryDatePicker.Value.ToString("dd/MMMM/yyyy");
            totalAmt = total.ToString();
            this.Hide();
            objRec.Show();
        }

    }
}
