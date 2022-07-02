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
    public partial class MemberDetails : Form
    {
        public MemberDetails()
        {
            InitializeComponent();
        }
        public IMemberRepository MemberRepository { get; set; }
        public bool InsertOrUpdate { get; set; }
        public MemberObject MemberInfo { get; set; }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                var member = new MemberObject
                {
                    MemberID = int.Parse(txtMemberId.Text),
                    MemberName = txtMemberName.Text,
                    City = txtCity.Text,
                    Country = txtCountry.Text,
                    Email = txtEmail.Text,
                    Password = MemberInfo == null ?  txtPassword.Text: MemberInfo.Password,
                    Role = MemberInfo == null ? "USER" : MemberInfo.Role
                };
                if (InsertOrUpdate)
                {
                    MemberRepository.UpdateMember(member);
                    MessageBox.Show("Update successfully.");
                }
                else
                {
                    MemberRepository.CreateMember(member);
                    MessageBox.Show("Add successfully.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, InsertOrUpdate == false ? "Add new:" : "Insert");
            }
        }
        private void MemberDetails_Load(object sender, EventArgs e)
        {
            txtMemberId.Enabled = !InsertOrUpdate;
            txtPassword.Enabled = !InsertOrUpdate;
            txtEmail.Enabled = !InsertOrUpdate;
            btnChangePassword.Enabled = InsertOrUpdate;
            if (InsertOrUpdate == true)
            {
                txtMemberId.Text = MemberInfo.MemberID.ToString();
                txtEmail.Text = MemberInfo.Email.ToString();
                txtMemberName.Text = MemberInfo.MemberName.ToString();
                txtCountry.Text = MemberInfo.Country.ToString();
                txtPassword.Text = "******";
                txtCity.Text = MemberInfo.City.ToString();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)=>Close();
    }
}
