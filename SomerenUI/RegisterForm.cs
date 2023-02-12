using SomerenLogic;
using SomerenModel;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SomerenDAL;
using System.Drawing;
using System.Security.Cryptography;
using System.Text;

namespace SomerenUI
{
    public partial class RegisterForm : Form
    {
        RegisterService registerService;

        public RegisterForm()
        {
            registerService = new RegisterService();
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                //checking if all fields are entered or not:
                if ((string.IsNullOrEmpty(txtRegisterName.Text)) ||
                    (string.IsNullOrEmpty(txtRegisterEmailAddress.Text)) ||
                    (string.IsNullOrEmpty(txtRegisterPassword.Text)) ||
                    (string.IsNullOrEmpty(txtRegisterLicenceKey1.Text)) ||
                    (string.IsNullOrEmpty(txtRegisterLicenceKey2.Text)) ||
                    (string.IsNullOrEmpty(txtRegisterLicenceKey3.Text)) ||
                    (string.IsNullOrEmpty(txtRegisterLicenceKey4.Text)) ||
                    (string.IsNullOrEmpty(txtRegisterSecretQuestion.Text)) ||
                    (string.IsNullOrEmpty(txtRegisterSecretAnswer.Text)))
                {
                    MessageBox.Show("Please make sure you have entered all the fields.", "ERROR");
                    return;
                }

                //checking email address
                string email = txtRegisterEmailAddress.Text;
                IsValidEmail(email);

                if (!IsValidEmail(email))
                {
                    MessageBox.Show("Please enter a valid e-mail address.", "ERROR");
                    return;
                }
                else if (registerService.GetUserNames().Contains(email)) //checking if the entered email is already in the system
                {
                    MessageBox.Show("This e-mail address already exists in our system. Please enter another valid e-mail.", "ERROR");
                    return;
                }

                if (txtRegisterPassword.Text != txtRegisterPasswordAgain.Text)
                {
                    MessageBox.Show("Entered passwords do not match each other.", "ERROR");
                    txtRegisterPassword.Text = "";
                    txtRegisterPasswordAgain.Text = "";
                    return;
                }

                //checking password 
                string password = txtRegisterPassword.Text;
                CheckPassword(password);

                if (!CheckPassword(password))
                {
                    MessageBox.Show("Your password does not meet the minimum security criterias. Please enter another password.", "ERROR");
                    return;
                }

                //checking licence key
                CheckLicenceKey();
                if (!CheckLicenceKey())
                {
                    MessageBox.Show("You entered a wrong licence key.", "ERROR");
                    return;
                }

                //if everything is valid:
                User newUser = new User();
                string newSalt = User.GenerateSalt();
                string hashedPassword = User.HashMethod(password, newSalt);

                newUser.Name = txtRegisterName.Text;
                newUser.UserName = txtRegisterEmailAddress.Text;
                newUser.Role = false;
                newUser.HashedPassword = hashedPassword;
                newUser.Salt = newSalt;
                newUser.SecretQuestion = txtRegisterSecretQuestion.Text;
                newUser.SecretAnswer = txtRegisterSecretAnswer.Text;

                registerService.AddUser(newUser);

                MessageBox.Show("You have successfully registered in our system!", "SUCCESS");
                this.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR");
                InitializeComponent();
            }
        }

        private bool CheckPassword(string enteredPassword)
        {
            //password rules 
            int minLength = 8;
            int minUpper = 1;
            int minLower = 1;
            int minNumber = 1;
            int minSpecial = 1;

            //get individual characters
            char[] characters = enteredPassword.ToCharArray();

            //checking variables
            int length = enteredPassword.Length;
            int upper = 0;
            int lower = 0;
            int number = 0;
            int character = 0;

            int invalidCharacters = 0;

            //check the entered password
            foreach (char c in characters)
            {
                if (char.IsUpper(c))
                {
                    upper++;
                }
                else if (char.IsLower(c))
                {
                    lower++;
                }
                else if (char.IsNumber(c))
                {
                    number++;
                }
                else if (!Char.IsLetterOrDigit(c))
                {
                    character++;
                }
                else
                {
                    invalidCharacters++;
                }
            }

            if (upper < minUpper || lower < minLower || length < minLength || invalidCharacters >= 1 || number < minNumber || character < minSpecial)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        static bool IsValidEmail(string email)
        {
            try
            {
                var address = new System.Net.Mail.MailAddress(email);
                return address.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private bool CheckLicenceKey()
        {
            string licenceKey1 = "XsZAb";
            string licenceKey2 = "tgz3PsD";
            string licenceKey3 = "qYh69un";
            string licenceKey4 = "WQCEx";

            if ((txtRegisterLicenceKey1.Text == licenceKey1) &&
                (txtRegisterLicenceKey2.Text == licenceKey2) &&
                (txtRegisterLicenceKey3.Text == licenceKey3) &&
                (txtRegisterLicenceKey4.Text == licenceKey4))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
