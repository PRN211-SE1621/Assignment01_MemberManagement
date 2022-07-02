using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BussinessObject;
using DataAccess.Repository;

namespace MyStoreWinApp
{
    public partial class MemberDetails : Form
    {
        public MemberDetails()
        {
            InitializeComponent();
        }

        public IMemberRepository MemberRepository { get; set; }
        public bool InsertOrUpdate { get; set; }
        public MemberObject Member { get; set; }

        private void btnCancel_Click(object sender, EventArgs e) => Close();

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                var member = new MemberObject
                {
                    MemberID = int.Parse(txtMemberId.Text),
                    MemberName = txtMemberName.Text,
                    Email = txtEmail.Text,
                    Country = txtCountry.Text,
                    City = txtCity.Text,
                    Password = txtPassword.Text,
                    Role = "USER"
                };
                if (InsertOrUpdate == false)
                {
                    btnChangePassword.Hide();
                    MemberRepository.CreateMember(member);
                    MessageBox.Show("Add successfully!");
                }
                else
                {
                    MemberRepository.UpdateMember(member);
                    MessageBox.Show("Update successfully!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, InsertOrUpdate == false ? "Add a new member" : "Update a member");
            }
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            var member = new MemberObject
            {
                MemberID = int.Parse(txtMemberId.Text),
                MemberName = txtMemberName.Text,
                Email = txtEmail.Text,
                Country = txtCountry.Text,
                City = txtCity.Text,
                Password = txtPassword.Text,
                Role = "USER"
            };
            FrmChangePassword changePassword = new FrmChangePassword(this, member);
            this.Hide();
            changePassword.ShowDialog();
        }

        private void MemberDetails_Load(object sender, EventArgs e)
        {
            txtMemberId.Enabled = !InsertOrUpdate;
            txtPassword.Enabled = !InsertOrUpdate;
            if (InsertOrUpdate == true)
            {
                txtMemberId.Text = Member.MemberID.ToString();
                txtMemberName.Text = Member.MemberName;
                txtEmail.Text = Member.Email;
                txtCountry.Text = Member.Country;
                txtCity.Text = Member.City;
                txtPassword.Text = Member.Password;
            }
            else
            {
                btnChangePassword.Hide();
            }
        }
    }
}
