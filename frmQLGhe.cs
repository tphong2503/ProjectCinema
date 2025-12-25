using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QLRP
{
    public partial class frmQLGhe : Form
    {
        bool isAdding = false;

        public frmQLGhe()
        {
            InitializeComponent();
        }

        private void frmQLGhe_Load(object sender, EventArgs e)
        {
            LoadData();
            SetControl(false);
        }

        void LoadData()
        {
            using (SqlConnection conn = DBHelper.GetConnection())
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM GHE", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvGhe.DataSource = dt;
            }
        }

        void SetControl(bool edit)
        {
            txtMaGhe.Enabled = edit;
            txtTenGhe.Enabled = edit;
            txtLoaiGhe.Enabled = edit;
            txtTrangThai.Enabled = edit;

            btnLuu.Enabled = edit;
            btnHuy.Enabled = edit;

            btnThem.Enabled = !edit;
            btnSua.Enabled = !edit;
            btnXoa.Enabled = !edit;
        }

        private void dgvGhe_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtMaGhe.Text = dgvGhe.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtTenGhe.Text = dgvGhe.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtLoaiGhe.Text = dgvGhe.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtTrangThai.Text = dgvGhe.Rows[e.RowIndex].Cells[3].Value.ToString();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            isAdding = true;
            txtMaGhe.Clear();
            txtTenGhe.Clear();
            txtLoaiGhe.Clear();
            txtTrangThai.Clear();
            SetControl(true);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            isAdding = false;
            SetControl(true);
            txtMaGhe.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = DBHelper.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(
                    "DELETE FROM GHE WHERE MaGhe=@MaGhe", conn);
                cmd.Parameters.AddWithValue("@MaGhe", txtMaGhe.Text);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            LoadData();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = DBHelper.GetConnection())
            {
                SqlCommand cmd;
                if (isAdding)
                {
                    cmd = new SqlCommand(
                        "INSERT INTO GHE VALUES (@Ma,@Ten,@Loai,@TT)", conn);
                }
                else
                {
                    cmd = new SqlCommand(
                        "UPDATE GHE SET TenGhe=@Ten,LoaiGhe=@Loai,TrangThai=@TT WHERE MaGhe=@Ma", conn);
                }

                cmd.Parameters.AddWithValue("@Ma", txtMaGhe.Text);
                cmd.Parameters.AddWithValue("@Ten", txtTenGhe.Text);
                cmd.Parameters.AddWithValue("@Loai", txtLoaiGhe.Text);
                cmd.Parameters.AddWithValue("@TT", txtTrangThai.Text);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
            LoadData();
            SetControl(false);
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            SetControl(false);
        }
    }
}
