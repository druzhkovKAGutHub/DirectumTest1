using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace WindowsFormsProject
{
    class ClassSQL
    {
        public void SaleryByDepatment(DataGridView  dataGridView1, ToolStripStatusLabel statusStrip)
        {
            DataSet ds;
            SqlDataAdapter adapter;
            SqlCommandBuilder commandBuilder;

            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.AllowUserToAddRows = false;

            string connectionString = @"Data Source=COMPUTER;Initial Catalog=Test2;Integrated Security=True";
            // Создание подключения
            //SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                // Открываем подключение
                string sqlExpression = @"select d.name, e.salart_sum from (select e.department_id, sum([salary]) as salart_sum from employee e group by e.department_id) AS e
                left join department d on d.id = e.department_id";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    adapter = new SqlDataAdapter(sqlExpression, connection);

                    ds = new DataSet();
                    adapter.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0];
                    statusStrip.Text = "Данные получены";
                }
            }
            catch (SqlException ex)
            {
                //Console.WriteLine(ex.Message);
            }
            finally
            {
                // закрываем подключение
                //connection.Close();
//                Console.WriteLine("Подключение закрыто...");
            }

        }
        public void SaleryByDepatmentMax(DataGridView  dataGridView1, ToolStripStatusLabel statusStrip)
        {
            DataSet ds;
            SqlDataAdapter adapter;
            SqlCommandBuilder commandBuilder;

            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.AllowUserToAddRows = false;

            string connectionString = @"Data Source=COMPUTER1;Initial Catalog=Test2;Integrated Security=True";
            // Создание подключения
            //SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                // Открываем подключение
                string sqlExpression = @"select emp1.*, e.id from (select department_id, max([salary]) salary from employee
group by department_id) as emp1
left join employee e on e.department_id = emp1.department_id and e.salary = emp1.salary";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    adapter = new SqlDataAdapter(sqlExpression, connection);

                    ds = new DataSet();
                    adapter.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0];
                    statusStrip.Text = "Данные получены";
                }
            }
            catch (SqlException ex)
            {
                //Console.WriteLine(ex.Message);
                statusStrip.Text = ex.Message;
            }
            finally
            {
                // закрываем подключение
                //connection.Close();
//                Console.WriteLine("Подключение закрыто...");
            }

        }
        public void SaleryOrderBy(DataGridView  dataGridView1, ToolStripStatusLabel statusStrip)
        {
            DataSet ds;
            SqlDataAdapter adapter;
            SqlCommandBuilder commandBuilder;

            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.AllowUserToAddRows = false;

            string connectionString = @"Data Source=COMPUTER;Initial Catalog=Test2;Integrated Security=True";
            // Создание подключения
            //SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                // Открываем подключение
                string sqlExpression = @"select d.name, e.name, e.salary  from employee e
left join department d on e.department_id = d.id
order by department_id, salary desc";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    adapter = new SqlDataAdapter(sqlExpression, connection);

                    ds = new DataSet();
                    adapter.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0];
                    statusStrip.Text = "Данные получены";
                }
            }
            catch (SqlException ex)
            {
                //Console.WriteLine(ex.Message);
            }
            finally
            {
                // закрываем подключение
                //connection.Close();
//                Console.WriteLine("Подключение закрыто...");
            }

        }
    }
}
