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
    public partial class userorder : Form
    {
        public userorder(int localid,string username)
        {
            InitializeComponent();
            userid = localid;
            localusername = username;
        }
        SqlConnection sqlcon = new SqlConnection("server=DESKTOP-JKT9IB6;database=burgers;Integrated Security=true;");
        int userid = 0;
        string localusername = "";
        private void userorder_Load(object sender, EventArgs e)
        {
            GetMenu();
            GetUserOrder();

        }
        private void GetMenu()
        {
            DataSet ds = new DataSet();
            sqlcon.Open();
            SqlDataAdapter dataadapter = new SqlDataAdapter("SELECT * FROM burgers.burgerTypes", sqlcon);
            dataadapter.Fill(ds, "burgerName");
            ordernewBurgerMenu.DataSource = ds;
            ordernewBurgerMenu.DataMember = "burgerName";
            this.ordernewBurgerMenu.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            sqlcon.Close();
        }
        List<decimal> burgQuantity = new List<decimal>();
        DataSet dsguq = new DataSet();
        private void GetUserOrder()
        {
            SqlConnection sconn = new SqlConnection("server=DESKTOP-JKT9IB6;database=burgers;Integrated Security=true;");
            sconn.Open();
            SqlDataAdapter dataadapter = new SqlDataAdapter("SELECT * FROM burgers.burgerTypes", sconn);
            dataadapter.Fill(dsguq, "burgerTypes");
            sendOrder.DataSource = dsguq;
            sendOrder.DataMember = "burgerTypes";
            sendOrder.Columns[3].ReadOnly = true;
            sendOrder.Columns[4].ReadOnly = true;
            sendOrder.Columns[5].ReadOnly = true;
            sendOrder.Columns[6].ReadOnly = true;
            sconn.Close();
        }

        //I NEED HELP, PLEASE HELP ME,I'M GOING CRAZY
        private decimal CalculateOrderPrice()
        {
            int rowCount = dsguq.Tables.Count;
            sqlcon.Open();
            for (int i = 0; i <= rowCount + 1; i++)
            {
                decimal cellValue = Convert.ToDecimal(sendOrder.Rows[i].Cells[0].Value);
                burgQuantity.Add(cellValue);
            }
            decimal price = 0;
            decimal endprice = 0;
            List<decimal> priceList = new List<decimal>();
            SqlCommand com = new SqlCommand("SELECT price FROM burgers.burgertypes", sqlcon);
            SqlDataReader reader = com.ExecuteReader();
            while (reader.Read())
            {
                priceList.Add(Convert.ToDecimal(reader["price"]));
            }
            sqlcon.Close();
            sqlcon.Open();
            SqlCommand insOrder = new SqlCommand();
            for (int i = 0; i <= rowCount + 1; i++)
            {
                if (sendOrder.Rows[i].Cells[0].Value != null && sendOrder.Rows[i].Cells[1].Value != null&& sendOrder.Rows[i].Cells[2].Value != null)
                {
                    price = priceList[i] * burgQuantity[i];
                    endprice += price;

                    insOrder = new SqlCommand("INSERT INTO dbo.orders(burgertype,quantity,commentary,deliveryAddr,isDelivered,userid,price,ordererUsername) values ("
                                      + Convert.ToInt32(sendOrder.Rows[i].Cells[3].Value) + "," + Convert.ToInt32(sendOrder.Rows[i].Cells[0].Value) + ",N\'" + sendOrder.Rows[i].Cells[1].Value.ToString() + "\',"
                                      + "N\'" + sendOrder.Rows[i].Cells[2].Value.ToString() + "\'," + "0," + Convert.ToInt32(userid) + "," + price +",\'"  + localusername +  "\' )", sqlcon);
                    insOrder.ExecuteNonQuery();
                }

            }
            MessageBox.Show("Obshta cena: "+endprice.ToString()+"lv");
            MessageBox.Show("Order successful.Thank you for being our customer!");
            sendOrder = null;
            sqlcon.Close();
            return price;
        }
        private void orderbtn_Click(object sender, EventArgs e)
        {

            CalculateOrderPrice();

        }
    }
}