using Microsoft.Extensions.Configuration;

using DataAccess.Repository;
using BussinessObject;

namespace MyStoreWinApp
{
    public partial class FrmLogin : Form
    {
        IMemberRepository memberRepo = new MemberRepository();
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string email = txtGmail.Text;
            string password = txtPassword.Text;

            MemberObject defaultAdmin = IsDefaultAdmin(email, password);

            if(defaultAdmin != null)
            {
                frmMemberManagement frmMemberManagement = new frmMemberManagement(this, defaultAdmin);
                this.Hide();
                frmMemberManagement.ShowDialog();
            }
            else
            {
                MemberObject member = memberRepo.CheckLogin(email, password);

                if (member == null)
                {
                    MessageBox.Show("Incorrect user name or password");
                }
                else if(member.Role.Equals(Roles.ADMIN))
                {
                    frmMemberManagement frmMemberManagement = new frmMemberManagement(this, member);
                    this.Hide();
                    frmMemberManagement.ShowDialog();
                }
                else if(member.Role.Equals(Roles.USER))
                {
                    MemberDetails memberDetails = new MemberDetails()
                    {
                        MemberInfo = member,
                        MemberRepository = memberRepo,
                        InsertOrUpdate = true,
                    };
                    this.Hide();
                    memberDetails.ShowDialog();
                }    
            }
        }
        private MemberObject IsDefaultAdmin(string email, string password)
        {
            IConfiguration config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true)
                .Build();
            if(email == config["AdminAccount:Email"] && password == config["AdminAccount:Password"])
            {
                return new DefaultAdmin();
            }
            return null;
        }
    }
}