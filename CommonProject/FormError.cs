using CommonProject;
using CommonProject.Business;
using System;
using System.Windows.Forms;
namespace CommonProject
{
    public partial class frmLockSystem : Form
    {
        string boardNo = null;
        private string module;
        public frmLockSystem(string module, string title = "")
        {
            InitializeComponent();
            this.module = module;
            lblTitle.Text = title;
            REGEDIT.LOCK = module;
            RegeditHelper.WriteRegistry(REGEDIT.CommonRegeditConfig, REGEDIT.LOCK, "1");
            txtId.Select();
            txtId.Focus();
        }
        public frmLockSystem(string message, string ope, string board)
        {
            InitializeComponent();
            boardNo = board;
        }

        private void FormError_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
        }

        private void btnUnlock_Click(object sender, EventArgs e)
        {
            string id = txtId.Text;
            string password = txtPassword.Text;
            if (string.IsNullOrEmpty(id) || string.IsNullOrEmpty(password))
            {
                return;
            }
            if (UmesHelper.Unlock(id, password, module))
            {
                this.Dispose();
                this.Close();
                RegeditHelper.WriteRegistry(REGEDIT.CommonRegeditConfig, REGEDIT.LOCK, "0");
            }
            else
            {
                this.lblErr.Text = "Tài khoản không hợp lệ!";
            }
        }

        private void FormError_Load(object sender, EventArgs e)
        {
            txtId.Focus();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
        }

        private void txtPassword_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnUnlock_Click(null, null);
            }
        }
    }
}
