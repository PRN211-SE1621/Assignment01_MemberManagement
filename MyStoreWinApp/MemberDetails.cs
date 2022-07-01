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
        public MemberObject admin { get; set; }
        private void btnSave_Click(object sender, EventArgs e)
        {

            try
            {
                if (!admin.Role.Equals("ADMIN"))
                {
                    throw new Exception("Action is not accepted!");
                }
                var member = new MemberObject
                {
                    MemberID = int.Parse(txtMemberId.Text),
                    MemberName = txtMemberName.Text,
                    City = txtCity.Text,
                    Country = txtCountry.Text,
                    Email = txtEmail.Text,
                    Password = txtPassword.Text,
                    Role = "user"
                };
                if (InsertOrUpdate)
                {
                    MemberRepository.UpdateMember(member);
                }
                else
                {
                    MemberRepository.CreateMember(member);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, InsertOrUpdate == false ? "Add new:" : "Insert");
            }
        }
        private void MemberDetails_Load(object sender, EventArgs e)
        {
            if (!admin.Role.Equals("ADMIN"))
            {
                MessageBox.Show("Action is not accepted!");
            }
            else
            {
                txtMemberId.Enabled = !InsertOrUpdate;
                txtPassword.Enabled = !InsertOrUpdate;
                txtEmail.Enabled = !InsertOrUpdate;
                if (InsertOrUpdate == true)
                {
                    txtMemberId.Text = MemberInfo.MemberID.ToString();
                    txtEmail.Text = MemberInfo.Email.ToString();
                    txtMemberName.Text = MemberInfo.MemberName.ToString();
                    txtCountry.Text = MemberInfo.Country.ToString();
                    txtPassword.Text = MemberInfo.Password.ToString();
                    txtCity.Text = MemberInfo.City.ToString();
                }
            }
        }
    }
}
