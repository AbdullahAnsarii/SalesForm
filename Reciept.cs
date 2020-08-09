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
    public partial class Reciept : Form
    {
        public Reciept()
        {
            InitializeComponent();
        }

        private void Reciept_Load(object sender, EventArgs e)
        {
            datetime.Text = DateTime.Now.ToString();
            opener.Text = Order.opener;
            date.Text = Order.deliveryDate;
            references.Text = Order.references;
            totalamt.Text = Order.totalAmt;
        }
    }
}
