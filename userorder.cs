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
        }
        private DataTable GetMenu()
        {
            DataSet ds = new DataSet();

            DataTable dtBurgs = new DataTable();
            SqlCommand com = new SqlCommand("SELECT * FROM burgers.burgerTypes", sqlcon);
            sqlcon.Open();
            using (sqlcon)
            {
                using (com)
                {
                    SqlDataAdapter dataadapter = new SqlDataAdapter("SELECT * FROM burgers.burgerTypes", sqlcon);
                    dataadapter.Fill(ds, "burgerName");
                    ordernewBurgerMenu.DataSource = ds;
                    ordernewBurgerMenu.DataMember = "burgerName";
                    this.ordernewBurgerMenu.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                    return dtBurgs;
                }
            }
        }
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
            for (int i = 0; i < priceList.Count; i++)
            {
                price += priceList[i] * numericUpDown1.Value;
            }
            MessageBox.Show("Cenata e: " + price.ToString());
            return price;
        }

        private void orderbtn_Click(object sender, EventArgs e)
        {
            CalculateOrderPrice();
        }
    }
}
