using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.DynamicData;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DemoWebForms
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        string connectionString = "Data Source=DESKTOP-TF957R2\\SQLEXPRESS2019;Initial Catalog=WebForms;Integrated Security=True;";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Load_Table();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Create_Table();
        }

        void Create_Table()
        {
            string tName = tableName.Text;
            string cName = columnName.Text;
            string dtype = dataType.Text;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = $"CREATE TABLE {tName} ({cName} {dtype});";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        void Load_Table()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand query = new SqlCommand("Select * from UserTable", connection);
                SqlDataAdapter adapter = new SqlDataAdapter(query);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
        }

        public void Add_Record(object sender, EventArgs e)
        {
            string name = TextBox1.Text;
            string deptName = TextBox2.Text;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string cmd = $"Insert into UserTable values('{name}','{deptName}');";
                using (SqlCommand command = new SqlCommand(cmd, connection))
                {
                    command.ExecuteNonQuery();
                    connection.Close();
                    Load_Table();
                    TextBox1.Text = "";
                    TextBox2.Text = "";
                    TextBox3.Text = "";
                }

            }
        }


        protected void Update_Record(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = $"Update UserTable set Firstname ='{TextBox1.Text}',department ='{TextBox2.Text}' where Id ={int.Parse(TextBox3.Text)};";
                using (SqlCommand com = new SqlCommand(query, connection))
                {
                    com.ExecuteNonQuery();
                    connection.Close();
                    Load_Table();
                    TextBox1.Text = "";
                    TextBox2.Text = "";
                    TextBox3.Text = "";
                }
            }
        }

        protected void Delete_Record(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = $"Delete From UserTable where Id = {int.Parse(TextBox3.Text)};";
                using (SqlCommand com = new SqlCommand(query, connection))
                {
                    com.ExecuteNonQuery();
                    connection.Close();
                    Load_Table();
                    TextBox1.Text = "";
                    TextBox2.Text = "";
                    TextBox3.Text = "";
                }
            }
        }

        protected void Get_Record(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = $"Select * from UserTable where Id = {int.Parse(TextBox3.Text)};";
                    using (SqlCommand comm = new SqlCommand(query, connection))
                    {
                        SqlDataReader reader = comm.ExecuteReader();
                        while (reader.Read())
                        {

                            TextBox1.Text = reader.GetValue(1).ToString();
                            TextBox2.Text = reader.GetValue(2).ToString();
                            TextBox3.Text = reader.GetValue(0).ToString();
                        }
                    }
                }
            }

            catch(Exception ex)
            {
                Response.Write("Error"+ex);
            }
           
        }
    }
}