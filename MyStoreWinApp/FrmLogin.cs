using DataAccess.Repository;
using BussinessObject;

namespace MyStoreWinApp
{
    public partial class FrmLogin : Form
    {
        IMemberRepository memberRepo = new MemberRepository();
        const string ADMIN_ROLE = "ADMIN";
        const string USER_ROLE = "user";
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string email = txtGmail.Text;
            string password = txtPassword.Text;

            MemberObject member = memberRepo.CheckLogin(email, password);

            if(member == null)
            {
                MessageBox.Show("Incorrect user name or password");
            } else if(member.Role.Equals(ADMIN_ROLE))
            {
                frmMemberManagement frmMemberManagement = new frmMemberManagement(this, member);
                this.Hide();
                frmMemberManagement.ShowDialog();
            } else if(member.Role.Equals(USER_ROLE))
            {
                MessageBox.Show("User role");
            }    
        }
    }
}