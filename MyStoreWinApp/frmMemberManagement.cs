using BussinessObject;
using DataAccess.Repository;
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
        private IMemberRepository memberRepo;
        private BindingSource bindingSource;
        public frmMemberManagement()
        {
            InitializeComponent();
        }
        public frmMemberManagement(FrmLogin loginForm, MemberObject member)
        {
            InitializeComponent();
            this.loginForm = loginForm;
            this.member = member;
            memberRepo = new MemberRepository();
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
            LoadMembersToGridView(memberRepo.GetAllMembers());
        }
        private void LoadMembersToGridView(IEnumerable<MemberObject> members)
        {
            try
            {
                bindingSource = new BindingSource();
                bindingSource.DataSource = members;

                txtMemberId.DataBindings.Clear();
                txtMemberName.DataBindings.Clear();
                txtEmail.DataBindings.Clear();
                txtCity.DataBindings.Clear();
                txtCountry.DataBindings.Clear();
                txtPassword.DataBindings.Clear();

                txtMemberId.DataBindings.Add("Text", bindingSource, "MemberId");
                txtMemberName.DataBindings.Add("Text", bindingSource, "MemberName");
                txtEmail.DataBindings.Add("Text", bindingSource, "Email");
                txtCity.DataBindings.Add("Text", bindingSource, "City");
                txtCountry.DataBindings.Add("Text", bindingSource, "Country");
                txtPassword.DataBindings.Add("Text", bindingSource, "Password");

                dgvMemberList.DataSource = null;
                dgvMemberList.DataSource = bindingSource;
                if (members.Count() == 0)
                {
                    ClearText();
                    btnDelete.Enabled = false;
                }
                else
                {
                    btnDelete.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ClearText()
        {
            txtMemberId.Text = "";
            txtMemberName.Text = "";
            txtEmail.Text = "";
            txtCity.Text = "";
            txtCountry.Text = "";
            txtPassword.Text = "******";
        }

        private void btnCLose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cboCountry_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            string country = txtCountryFilter.Text;
            string city = txtCityFilter.Text;
            IEnumerable<MemberObject> members = memberRepo.GetMembersFilterByCountryAndCity(country, city);
            LoadMembersToGridView(members);
        }

        private void dgvMemberList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void frmMemberManagement_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(loginForm != null) loginForm.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

        }

        private void btnSort_Click(object sender, EventArgs e)
        {

        }
    }
}
