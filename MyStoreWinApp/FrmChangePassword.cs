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

        private void lbPassword_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
