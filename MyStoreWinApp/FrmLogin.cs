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
                frmMemberManagement frmMemberManagement = new frmMemberManagement(this);
                this.Hide();
                frmMemberManagement.Show();
            }
            else
            {
                MemberObject member = memberRepo.CheckLogin(email, password);

                if (member == null)
                {
                    MessageBox.Show("Incorrect user name or password");
                }
                else
                {
                    MemberDetails memberDetails = new MemberDetails(this)
                    {
                        MemberInfo = member,
                        MemberRepository = memberRepo,
                        InsertOrUpdate = true,
                        IsAdmin = false
                    };
                    this.Hide();
                    memberDetails.Show();
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