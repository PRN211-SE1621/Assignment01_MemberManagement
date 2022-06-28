using BussinessObject;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyStoreWinApp
{
    public partial class frmMemberManagement : Form
    {
        private FrmLogin loginForm;
        private MemberObject member;
        public frmMemberManagement()
        {
            InitializeComponent();
        }
        public frmMemberManagement(FrmLogin loginForm, MemberObject member)
        {
            InitializeComponent();
            this.loginForm = loginForm;
            this.member = member;
        }

        private void frmMemberManagement_Load(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void btnNew_Click(object sender, EventArgs e)
        {

        }

        private void btnLoad_Click(object sender, EventArgs e)
        {

        }

        private void btnCLose_Click(object sender, EventArgs e)
        {

        }

        private void cboCountry_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnFilter_Click(object sender, EventArgs e)
        {

        }

        private void dgvMemberList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void frmMemberManagement_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(loginForm != null) loginForm.Close();
        }
    }
}
