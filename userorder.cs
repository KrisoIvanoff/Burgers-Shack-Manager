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
        public userorder()
        {
            InitializeComponent();
        }
        SqlConnection sqlcon = new SqlConnection("server=DESKTOP-JKT9IB6;database=burgers;Integrated Security=true;");

        private void userorder_Load(object sender, EventArgs e)
        {
            GetMenu();
            GetUserQuantity();

        }
        private void GetMenu()
        {
            DataSet ds = new DataSet();
            sqlcon.Open();
            using (sqlcon)
            {

                    SqlDataAdapter dataadapter = new SqlDataAdapter("SELECT * FROM burgers.burgerTypes", sqlcon);
                    dataadapter.Fill(ds, "burgerName");
                    ordernewBurgerMenu.DataSource = ds;
                    ordernewBurgerMenu.DataMember = "burgerName";
                    this.ordernewBurgerMenu.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }
        List<decimal> burgQuantity = new List<decimal>();
        private void GetUserQuantity()
        {
            SqlConnection sconn = new SqlConnection("server=DESKTOP-JKT9IB6;database=burgers;Integrated Security=true;");
            sconn.Open();
            DataSet ds = new DataSet();
            SqlDataAdapter dataadapter = new SqlDataAdapter("SELECT * FROM burgers.burgerTypes", sconn);
            dataadapter.Fill(ds, "burgerTypes");
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "burgerTypes";
            int index = 0;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {

                decimal cellValue = Convert.ToDecimal(dataGridView1.Rows[index].Cells[0].Value);
                burgQuantity.Add(cellValue);
                index++;
            }


            sconn.Close();
        }

        //I NEED HELP
        private decimal CalculateOrderPrice()
        {
            SqlConnection sqlcon2 = new SqlConnection("server=DESKTOP-JKT9IB6;database=burgers;Integrated Security=true;");
            sqlcon2.Open();
            decimal price = 0;
            List<decimal> priceList = new List<decimal>();
            using (sqlcon2)
            {
                SqlCommand com = new SqlCommand("SELECT price FROM burgers.burgertypes",sqlcon2);
                SqlDataReader reader = com.ExecuteReader();
                while(reader.Read())
                {
                    priceList.Add(Convert.ToDecimal(reader["price"]));
                }
            }
            for (int i = 0; i < burgQuantity.Count; i++)
            {
                price += priceList[i] * burgQuantity[i];

            }
            MessageBox.Show("Cenata e: " + price.ToString());
            return price;
        }
        private void orderbtn_Click(object sender, EventArgs e)
        {
            CalculateOrderPrice();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
