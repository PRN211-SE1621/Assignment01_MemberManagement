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
        public MemberDetails(Form parentForm)
        {
            InitializeComponent();
            this.parentForm = parentForm;
        }
        public IMemberRepository MemberRepository { get; set; }
        public bool InsertOrUpdate { get; set; }
        public MemberObject MemberInfo { get; set; }
        public bool IsAdmin { get; set; }
        private Form parentForm;
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if(txtEmail.Text.Equals("") || txtPassword.Text.Equals(""))
                {
                    MessageBox.Show("Email or Password is empty");
                }
                else
                {
                    var member = new MemberObject
                    {
                        MemberID = int.Parse(txtMemberId.Text),
                        MemberName = txtMemberName.Text,
                        City = txtCity.Text,
                        Country = txtCountry.Text,
                        Email = txtEmail.Text,
                        Password = MemberInfo == null ? txtPassword.Text : MemberInfo.Password,
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
            }
            catch (Exception ex)
            {
                if(ex.Message.Contains("input"))
                {
                    MessageBox.Show("The id must be a number", InsertOrUpdate == false ? "Add a new member" : "Update a member");
                }
                else
                {
                    MessageBox.Show(ex.Message, InsertOrUpdate == false ? "Add a new member" : "Update a member");
                }
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
                Password = txtPassword.Text
            };
            FrmChangePassword changePassword = new FrmChangePassword(this, member);
            this.Hide();
            changePassword.ShowDialog();
        }
        private void MemberDetails_Load(object sender, EventArgs e)
        {
            txtMemberId.Enabled = !InsertOrUpdate;
            txtPassword.Enabled = !InsertOrUpdate;
            txtEmail.Enabled = !InsertOrUpdate;
            btnChangePassword.Enabled = InsertOrUpdate && !IsAdmin;
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
            if(!IsAdmin)
            {
                this.parentForm.Close();
            }    
        }

        private void MemberDetails_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(!IsAdmin)
            {
                if(parentForm != null)
                {
                    parentForm.Close();
                }    
            }
        }
    }
}
