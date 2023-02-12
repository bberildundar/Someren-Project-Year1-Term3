using SomerenLogic;
using SomerenModel;
using System;
using SomerenDAL;
using System.Windows.Forms;

namespace SomerenUI
{
    public partial class LoginMenu : Form
    {
        LoginService loginService;
        User login;

        public LoginMenu()
        {
            InitializeComponent();
            loginService = new LoginService();
            login = new User();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                login = loginService.GetSalt(txtUserName.Text); // Got salt

                string hashedPassword = User.HashMethod(txtPassword.Text, login.Salt);

                login = loginService.CheckLogin(txtUserName.Text, hashedPassword);

                if (login.UserName != null && loginService.IsAdmin(txtUserName.Text)) // For the admins
                {
                    SomerenUI form = new SomerenUI();
                    form.ShowDialog();
                    this.Close();
                }
                else if (login.UserName != null && !loginService.IsAdmin(txtUserName.Text)) // For the users(normal)
                {
                    SomerenUI form = new SomerenUI(txtUserName.Text);
                    form.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Oops! The password you entered is incorrect!", "Error Occured");
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message, "Error occured");
                BaseDao.ErrorLogging(exp);
            }
        }

        private void btnForgot_Click(object sender, EventArgs e)
        {
            ResetPassword resetPasswordForm = new ResetPassword();
            resetPasswordForm.ShowDialog();
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            RegisterForm registerForm = new RegisterForm();
            registerForm.ShowDialog();
        }
    }
}
