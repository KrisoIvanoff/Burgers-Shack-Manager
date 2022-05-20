using System;
using System.Data;
using System.Data.SqlClient;
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

        SqlConnection pastordconn = new SqlConnection("server=DESKTOP-JKT9IB6;database=burgers;Integrated Security=true;");

        //da se dobavi username na poruchkata, a ne ID
        int rowCol = 0;
        private void adminForm_Load(object sender, EventArgs e)
        {
            pastordconn.Open();
            burgName = new SqlDataAdapter("SELECT  orders.orderid,orders.ordererUsername,orders.isDelivered, orders.burgertype, orders.quantity,orders.commentary,orders.deliveryAddr,orders.price FROM dbo.orders", pastordconn);
            burgName.Fill(ds, "allOrders");
            visualizeAllOrders.DataSource = ds;
            visualizeAllOrders.DataMember = "allOrders";
            this.visualizeAllOrders.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            rowCol = visualizeAllOrders.Rows.Count;
            pastordconn.Close();
            CheckIfShopIsOpen();
            RefreshGrid();
        }

        private void updatebtn_Click(object sender, EventArgs e)
        {
            SqlCommandBuilder cmdbdl = new SqlCommandBuilder(burgName);
            burgName.Update(ds, "allOrders");
            MessageBox.Show("Data updated");
        }
        bool isOpen = false;
        private void CheckIfShopIsOpen()
        {
            SqlCommand checkShopStatus = new SqlCommand("SELECT isOpen from dbo.shopstatus", pastordconn);
            pastordconn.Open();

            //1-opened,2-closed
            byte isOpenVar = Convert.ToByte(checkShopStatus.ExecuteScalar());
            switch (isOpenVar)
            {
                case 1: isOpen = true; openCloseShop.Text = "Close shop"; break;
                case 0: isOpen = false; openCloseShop.Text = "Open shop"; break;
                default: break;
            }
            pastordconn.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //ne znam dali teksta ima greshki,toq kod e pisan v ponedelnik (19.12.21g) v 1:30 sutrinta i 
            //nadali shte go gledam sled tova (ako raboti)
            if (isOpen == true)
            {
                isOpen = false;
                openCloseShop.Text = "Open shop";
                MessageBox.Show("Shop closed. Buyers won't be able to log in or place new orders!");
                SqlCommand closeShop = new SqlCommand("UPDATE dbo.ShopStatus SET isOpen = 0", pastordconn);
                pastordconn.Open(); closeShop.ExecuteNonQuery(); pastordconn.Close();
            }
            else
            {
                isOpen = true;
                openCloseShop.Text = "Close shop";
                MessageBox.Show("Shop opened. Buyers will now be able to place orders!");
                SqlCommand openShop = new SqlCommand("UPDATE dbo.ShopStatus SET isOpen = 1", pastordconn);
                pastordconn.Open(); openShop.ExecuteNonQuery(); pastordconn.Close();

            }
        }
        private void RefreshGrid()
        {
            refreshOrders.Interval = 10000;
            refreshOrders.Tick += new EventHandler(UpdateAllOrders);
            refreshOrders.Start();

        }
        private void UpdateAllOrders(object sender, EventArgs e)
        {
            pastordconn.Open();
            string select = "SELECT orders.orderid,orders.ordererUsername,orders.isDelivered, orders.burgertype, orders.quantity,orders.commentary,orders.deliveryAddr,orders.price FROM dbo.orders";
            SqlDataAdapter da = new SqlDataAdapter(select, pastordconn);
            DataSet ds = new DataSet();
            da.Fill(ds, "allOrders");
            visualizeAllOrders.DataSource = ds;
            visualizeAllOrders.DataMember = "allOrders";
            pastordconn.Close();
        }

        private void visualizeAllOrders_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
