using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QLRP
{
    public partial class frmQLPhim : Form
    {
        int maPhim = 0;

        public frmQLPhim()
        {
            InitializeComponent();
        }

        void LoadData()
        {
            SqlDataAdapter da = new SqlDataAdapter(
                "SELECT MaPhim, TenPhim FROM Phim",
                DBHelper.GetConnection());
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvPhim.DataSource = dt;
        }

        private void frmQLPhim_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void dgvPhim_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                maPhim = Convert.ToInt32(dgvPhim.Rows[e.RowIndex].Cells[0].Value);
                txtTenPhim.Text = dgvPhim.Rows[e.RowIndex].Cells[1].Value.ToString();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            SqlConnection conn = DBHelper.GetConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand(
                "INSERT INTO Phim(TenPhim) VALUES(@ten)", conn);
            cmd.Parameters.AddWithValue("@ten", txtTenPhim.Text);
            cmd.ExecuteNonQuery();
            conn.Close();
            LoadData();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            SqlConnection conn = DBHelper.GetConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand(
                "DELETE FROM Phim WHERE MaPhim=@id", conn);
            cmd.Parameters.AddWithValue("@id", maPhim);
            cmd.ExecuteNonQuery();
            conn.Close();
            LoadData();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            SqlConnection conn = DBHelper.GetConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand(
                "UPDATE Phim SET TenPhim=@ten WHERE MaPhim=@id", conn);
            cmd.Parameters.AddWithValue("@ten", txtTenPhim.Text);
            cmd.Parameters.AddWithValue("@id", maPhim);
            cmd.ExecuteNonQuery();
            conn.Close();
            LoadData();
        }
    }
}
