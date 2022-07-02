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
        private Form parentForm;
        private IMemberRepository memberRepo;
        private BindingSource bindingSource;
        public frmMemberManagement()
        {
            InitializeComponent();
        }
        public frmMemberManagement(Form parentForm)
        {
            InitializeComponent();
            this.parentForm = parentForm;
            memberRepo = new MemberRepository();
        }
        private MemberObject GetMemberObject()
        {
            MemberObject mem = null;
            try
            {
                memberRepo = new MemberRepository();
                mem = memberRepo.GetMemberById(txtMemberId.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Get Member");
            }
            return mem;
        }

        private void frmMemberManagement_Load(object sender, EventArgs e)
        {
            btnDelete.Enabled = false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            MemberDetails memberDetails = new MemberDetails
            {
                Text = "Add Member",
                InsertOrUpdate = false,
                MemberRepository = memberRepo,
                IsAdmin = true
            };
            memberDetails.Show();
            LoadMembersToGridView(memberRepo.GetAllMembers());
            bindingSource.Position = bindingSource.Count - 1;
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadMembersToGridView(memberRepo.GetAllMembers());
            txtCountryFilter.Text = "";
            txtCityFilter.Text = "";
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

                txtMemberId.DataBindings.Add("Text", bindingSource, "MemberId");
                txtMemberName.DataBindings.Add("Text", bindingSource, "MemberName");
                txtEmail.DataBindings.Add("Text", bindingSource, "Email");
                txtCity.DataBindings.Add("Text", bindingSource, "City");
                txtCountry.DataBindings.Add("Text", bindingSource, "Country");

                dgvMemberList.DataSource = null;
                dgvMemberList.DataSource = bindingSource;
                dgvMemberList.Columns["Password"].Visible = false;
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
        }

        private void btnCLose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            string country = txtCountryFilter.Text;
            string city = txtCityFilter.Text;
            IEnumerable<MemberObject> currentMembers = GetListInGridView() == null ? memberRepo.GetAllMembers() : GetListInGridView();
            IEnumerable<MemberObject> members = memberRepo.GetMembersFilterByCountryAndCity(country, city, currentMembers);
            LoadMembersToGridView(members);
        }

        private void dgvMemberList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            MemberDetails memberDetails = new MemberDetails
            {
                Text = "Update Member",
                InsertOrUpdate = true,
                MemberRepository = memberRepo,
                MemberInfo = GetMemberObject(),
                IsAdmin = true
            };
            if(memberDetails.ShowDialog() == DialogResult.OK)
            {
                LoadMembersToGridView(memberRepo.GetAllMembers());
                bindingSource.Position = bindingSource.Count - 1;
            }
            LoadMembersToGridView(memberRepo.GetAllMembers());
        }

        private void frmMemberManagement_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(parentForm != null) parentForm.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadMembersToGridView(memberRepo.SearchMemberByIdAndName(txtMemberIDSearch.Text, txtMemberNameSearch.Text));
        }

        private void btnSort_Click(object sender, EventArgs e)
        {
            IEnumerable<MemberObject> currentMembers = GetListInGridView() == null ? memberRepo.GetAllMembers() : GetListInGridView();
            IEnumerable<MemberObject> membersAfterSorted = memberRepo.SortByMemberName(currentMembers);
            LoadMembersToGridView(membersAfterSorted);
        }
        private IEnumerable<MemberObject> GetListInGridView()
        {
            if(dgvMemberList.DataSource == null)
            {
                return null;
            }    
            return (IEnumerable<MemberObject>)((BindingSource)dgvMemberList.DataSource).DataSource;
        }
    }
}
