using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ClassSQL sql = new ClassSQL();
            sql.SaleryByDepatment(this.dataGridView1, this.toolStripStatusLabel1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ClassSQL sql = new ClassSQL();
            sql.SaleryByDepatmentMax(this.dataGridView1, this.toolStripStatusLabel1);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            ClassSQL sql = new ClassSQL();
            sql.SaleryOrderBy(this.dataGridView1, this.toolStripStatusLabel1);
        }
    }
}
