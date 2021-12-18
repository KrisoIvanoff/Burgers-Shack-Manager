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
        SqlDataAdapter burgName;
        DataSet ds = new DataSet();

        private void adminForm_Load(object sender, EventArgs e)
        {
            SqlConnection pastordconn = new SqlConnection("server=DESKTOP-JKT9IB6;database=burgers;Integrated Security=true;");
            pastordconn.Open();
            burgName = new SqlDataAdapter("SELECT * FROM dbo.orders", pastordconn);
            burgName.Fill(ds, "allOrders");
            visualizeAllOrders.DataSource = ds;
            visualizeAllOrders.DataMember = "allOrders";

            pastordconn.Close();
        }


        private void updatebtn_Click(object sender, EventArgs e)
        {
            SqlConnection pastordconn = new SqlConnection("server=DESKTOP-JKT9IB6;database=burgers;Integrated Security=true;");
            SqlCommandBuilder cmdbdl = new SqlCommandBuilder(burgName);
                burgName.Update(ds, "allOrders");
            MessageBox.Show("Data updated");
        }
    }
}
