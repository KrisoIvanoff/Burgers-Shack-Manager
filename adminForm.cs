using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BurgeriVisual
{
    public partial class adminForm : Form
    {
        public adminForm()
        {
            InitializeComponent();
        }

        private void adminForm_Load(object sender, EventArgs e)
        {
            SqlConnection pastordconn = new SqlConnection("server=DESKTOP-JKT9IB6;database=burgers;Integrated Security=true;");
            pastordconn.Open();
            DataSet ds = new DataSet();
            SqlDataAdapter burgName = new SqlDataAdapter("SELECT * FROM dbo.orders",pastordconn);
            burgName.Fill(ds, "orders");
            visualizeAllOrders.DataSource = ds;
            visualizeAllOrders.DataMember = "orders";
            pastordconn.Close();
        }
    }
}
