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
    public partial class FrmChangePassword : Form
    {

        private MemberDetails MemberDetails;
        private MemberObject member;
        private IMemberRepository memberRepo;

        private void FrmChangePassword_Load(object sender, EventArgs e)
        {

        }
        public FrmChangePassword(MemberDetails memberDetails, MemberObject member)
        {
            InitializeComponent();
            this.MemberDetails = memberDetails;
            this.member = member;
            memberRepo = new MemberRepository();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                memberRepo.ChangePassword(member.MemberID, txtOldPassword.Text, txtNewPassword.Text, txtConfirmPassword.Text);
                DialogResult result = MessageBox.Show("Update password success");
                if (result == DialogResult.OK)
                {
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtConfirmPassword.Text = "";
            txtNewPassword.Text = "";
            txtOldPassword.Text = "";
        }
    }
}
