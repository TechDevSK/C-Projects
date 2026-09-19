using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;

namespace expenseTracker
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=.;Initial Catalog=ExpenseDB;Integrated Security=True;Encrypt=True;TrustServerCertificate=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into expenses values (@expenseid, @expensename, @amount, @category, @date, @paymentmethod)", con);
            cmd.Parameters.AddWithValue("@expenseid", int.Parse(txtID.Text));
            cmd.Parameters.AddWithValue("@expensename", txtName.Text);
            cmd.Parameters.AddWithValue("@amount", int.Parse(txtAmount.Text));
            cmd.Parameters.AddWithValue("@category", cmbCategory.GetItemText(cmbCategory.SelectedItem));
            cmd.Parameters.AddWithValue("@date", dateTimePicker1.Value.Date);
            cmd.Parameters.AddWithValue("@paymentmethod", cmbPayment.GetItemText(cmbPayment.SelectedItem));
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Expense Saved");
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=.;Initial Catalog=ExpenseDB;Integrated Security=True;TrustServerCertificate=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from expenses", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            da.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=.;Initial Catalog=ExpenseDB;Integrated Security=True;TrustServerCertificate=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("update expenses set expensename=@expensename, amount=@amount, category=@category, date=@date, paymentmethod=@paymentmethod where expenseid=@expenseid", con);
            cmd.Parameters.AddWithValue("@expenseid", int.Parse(txtID.Text));
            cmd.Parameters.AddWithValue("@expensename", txtName.Text);
            cmd.Parameters.AddWithValue("@amount", int.Parse(txtAmount.Text));
            cmd.Parameters.AddWithValue("@category", cmbCategory.GetItemText(cmbCategory.SelectedItem));
            cmd.Parameters.AddWithValue("@date", dateTimePicker1.Value.Date);
            cmd.Parameters.AddWithValue("@paymentmethod", cmbPayment.GetItemText(cmbPayment.SelectedItem));
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Expense Updated");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=.;Initial Catalog=ExpenseDB;Integrated Security=True;TrustServerCertificate=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("delete from expenses where expenseid=@expenseid", con);
            cmd.Parameters.AddWithValue("@expenseid", int.Parse(txtID.Text));
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Expense Deleted");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=.;Initial Catalog=ExpenseDB;Integrated Security=True;TrustServerCertificate=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from expenses", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            da.Fill(table);
            dataGridView1.DataSource = table;
        }
    }
}
