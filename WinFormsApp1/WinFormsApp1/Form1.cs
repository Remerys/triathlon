using Microsoft.EntityFrameworkCore;
using WinFormsApp1.Models;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Bdrdugas6Context cnx = new Bdrdugas6Context();

            dataGridView1.DataSource = cnx.Clubs.ToList();
        }
    }
}