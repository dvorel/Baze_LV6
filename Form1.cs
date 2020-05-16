using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Baze_LV6_predlozak
{
    public partial class Form1 : Form
    {
        public bool imeB = false, prezimeB = false;
        public string ime;
        public string prezime;
        public string request;
        public string spol = "M";
        public Form1()
        {
            InitializeComponent();
        }

        public void postaviZahtjev()
        {
            if (imeB && prezimeB)
            {
                request = "SELECT * FROM student WHERE ime = '" + ime + "' AND prezime = '" + prezime + "' AND spol = '" + spol + "'";
            }
            else if (imeB)
            {
                request = "SELECT * FROM student WHERE ime = '" + ime + "' AND spol = '" + spol + "'";
            }
            else if (prezimeB)
            {
                request = "SELECT * FROM student WHERE prezime = '" + prezime + "' AND spol = '" + spol + "'";
            }
            else
            {
                request = "SELECT * FROM student WHERE spol = '" + spol + "'";
            }
        }

        private void btnSve_Click(object sender, EventArgs e)
        {
            string statement = "SELECT * FROM student";
            SqlConnection conn = new SqlConnection("Server = 192.168.1.106; Initial Catalog = stuslu; User ID = user; Password = 1234");    //postavljeni username i password
            conn.Open();
            SqlDataAdapter dataAdapter = new SqlDataAdapter(statement, conn);
            DataTable dt = new DataTable();
            dataAdapter.Fill(dt);
            dgvPodaci.DataSource = dt;
            conn.Close();
        }

        private void btnTrazi_Click(object sender, EventArgs e)
        {
            postaviZahtjev();
            SqlConnection conn = new SqlConnection("Server = 192.168.1.106; Initial Catalog = stuslu; User ID = user; Password = 1234");    //postavljeni username i password
            conn.Open();
            SqlDataAdapter dataAdapter = new SqlDataAdapter(request, conn);
            DataTable dt = new DataTable();
            dataAdapter.Fill(dt);
            dgvPodaci.DataSource = dt;
            conn.Close();
        }

        private void txtIme_TextChanged(object sender, EventArgs e)
        {
            imeB = true;
            ime = txtIme.Text;
        }

        private void rbZ_CheckedChanged_1(object sender, EventArgs e)
        {
            spol = "F";
        }

        private void rbM_CheckedChanged_1(object sender, EventArgs e)
        {
            spol = "M";
        }

        private void txtPrezime_TextChanged_1(object sender, EventArgs e)
        {
            prezimeB = true;
            prezime = txtPrezime.Text;
        }

    }
}
