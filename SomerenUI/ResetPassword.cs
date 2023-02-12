using System;
using SomerenDAL;
using SomerenModel;
using SomerenLogic;
using System.Windows.Forms;

namespace SomerenUI
{
    public partial class ResetPassword : Form
    {
        ResetPasswordService resetPasswordService;
        User user;

        public ResetPassword()
        {
            user = new User();
            resetPasswordService = new ResetPasswordService();
            InitializeComponent();
            pnlCheckUsername.Show();
            pnlSecretQuestion.Hide();
            pnlReset.Hide();
        }

        private void btnCheckUsername_Click(object sender, EventArgs e)
        {
            try
            {
                string username = RemoveWhitespace(txtUsername.Text);
                user = resetPasswordService.ReadUser(username);
                if (user.UserName == null)
                {
                    throw new Exception("this username does not exist in the database");
                }
                pnlSecretQuestion.Show();
                pnlCheckUsername.Hide();
                lblSecretQuestionOut.Text = user.SecretQuestion;//Display Secret Question on the panel
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR");
                ErrorLogging(ex);
                InitializeComponent();
            }
        }
        private void btnSecretQuestion_Click(object sender, EventArgs e)
        {
            try
            {
                string rightAnswer = RemoveWhitespace(user.SecretAnswer.ToLower());
                string inputAnswer = RemoveWhitespace(txtSecretAnswer.Text.ToLower());
                if (rightAnswer == inputAnswer)
                {
                    pnlReset.Show();
                    pnlCheckUsername.Hide();
                    pnlSecretQuestion.Hide();
                }
                else
                {
                    MessageBox.Show("The answer is incorrect, try agian!","ERROR");
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR");
                ErrorLogging(ex);
                InitializeComponent();
            }
        }
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNewpassword.Text != txtRetypePassword.Text)//check if the password is match to the retyped one
                {
                    MessageBox.Show("The passwords don't match each other, please try again.", "ERROR");
                    txtNewpassword.Text = "";
                    txtRetypePassword.Text = "";
                    return;
                }

                string newPassword = txtNewpassword.Text;
                char[] PasswordInChar = newPassword.ToCharArray();//change the password into the char form.

                if (!IsContains8Char(PasswordInChar)||!IsContainsLowerletter(PasswordInChar)||!IsContainsUpperletter(PasswordInChar)
                    ||!IsContainsNumber(PasswordInChar)||!IsContainsSpecialChar(PasswordInChar))//validation of password
                {
                    MessageBox.Show("The password does not meet the all of requirements, please try again","ERROR");
                    return;
                }

                string inputPassword = txtNewpassword.Text;
                string newSalt = User.GenerateSalt();
                string hashedPassword = User.HashMethod(inputPassword, newSalt);

                if (cbSetNewSecret.Checked)
                {
                    string newSecretQuestion = txtNewSecretQuestion.Text;
                    string newSecretAnswer = txtNewSecretAnswer.Text;
                    user.SecretQuestion = newSecretQuestion;
                    user.SecretAnswer = newSecretAnswer;
                    if (string.IsNullOrEmpty(newSecretQuestion) || string.IsNullOrEmpty(newSecretAnswer))
                    {
                        MessageBox.Show("Secret Question and(or) Answer are not entered.", "ERROR");
                        return;
                    }
                }

                user.HashedPassword = hashedPassword;
                user.Salt = newSalt;
                resetPasswordService.UpdatePassword(user);
                MessageBox.Show("Your new password has been successfully implemented.","SUCCESS");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR");
                ErrorLogging(ex);
            }
        }

        //validation method for password setting
        bool IsContains8Char(char[] newPasswordInChar)
        {
            return (newPasswordInChar.Length >= 8);
        }
        bool IsContainsLowerletter(char[] newPasswordInChar)
        {
            foreach (char c in newPasswordInChar)
            {
                if (Char.IsLower(c))
                {
                    return true;
                }
            }
            return false;
        }
        bool IsContainsUpperletter(char[] newPasswordInChar)
        {
            foreach (char c in newPasswordInChar)
            {
                if (Char.IsUpper(c))
                {
                    return true;
                }
            }
            return false;
        }
        bool IsContainsSpecialChar(char[] newPasswordInChar)
        {
            foreach (char c in newPasswordInChar)
            {
                if (!Char.IsLetterOrDigit(c))
                {
                    return true;
                }
            }
            return false;
        }
        bool IsContainsNumber(char[] newPasswordInChar)
        {
            foreach (char c in newPasswordInChar)
            {
                if (Char.IsNumber(c))
                {
                    return true;
                }
            }
            return false;
        }

        //Textbox functions
        private void txtUsername_Click(object sender, EventArgs e)
        {
            txtUsername.Text = "";
            txtUsername.ForeColor = System.Drawing.Color.Black;
        }
        private void textBox1_Click(object sender, EventArgs e)
        {
            txtSecretAnswer.Text = "";
            txtSecretAnswer.ForeColor = System.Drawing.Color.Black;
        }
        private void txtNewpassword_Click(object sender, EventArgs e)
        {
            txtNewpassword.Text = "";
            txtNewpassword.ForeColor = System.Drawing.Color.Black;
            txtNewpassword.PasswordChar = '*';
        }
        private void txtRetypePassword_Click(object sender, EventArgs e)
        {
            txtRetypePassword.Text = "";
            txtRetypePassword.ForeColor = System.Drawing.Color.Black;
            txtRetypePassword.PasswordChar = '*';
        }
        private void txtNewSecretQuestion_Click(object sender, EventArgs e)
        {
            txtNewSecretQuestion.Text = "";
            txtNewSecretQuestion.ForeColor = System.Drawing.Color.Black;
        }
        private void txtNewSecretAnswer_Click(object sender, EventArgs e)
        {
            txtNewSecretAnswer.Text = "";
            txtNewSecretAnswer.ForeColor = System.Drawing.Color.Black;
        }

        //Other functions
        public string RemoveWhitespace(string text)
        {
            return text.Replace(" ", "");
        }
        public void ErrorLogging(Exception ex)
        {
            BaseDao.ErrorLogging(ex);
        }
        private void cbSetNewSecret_CheckedChanged(object sender, EventArgs e)
        {
            txtNewSecretQuestion.Enabled = true;
            txtNewSecretAnswer.Enabled = true;
            txtNewSecretAnswer.Text = "";
            txtNewSecretQuestion.Text = "";
            txtNewSecretQuestion.ForeColor = System.Drawing.Color.Black;
            txtNewSecretAnswer.ForeColor = System.Drawing.Color.Black;
        }
    }
}