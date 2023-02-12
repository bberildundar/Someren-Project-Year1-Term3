
namespace SomerenUI
{
    partial class ResetPassword
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlCheckUsername = new System.Windows.Forms.Panel();
            this.lblStep1 = new System.Windows.Forms.Label();
            this.btnCheckUsername = new System.Windows.Forms.Button();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.lblCheckUsername = new System.Windows.Forms.Label();
            this.pnlSecretQuestion = new System.Windows.Forms.Panel();
            this.lblStep2 = new System.Windows.Forms.Label();
            this.lblSecretQuestionOut = new System.Windows.Forms.Label();
            this.lblSecretAnswer = new System.Windows.Forms.Label();
            this.btnSecretQuestion = new System.Windows.Forms.Button();
            this.txtSecretAnswer = new System.Windows.Forms.TextBox();
            this.lblSecretQuestion = new System.Windows.Forms.Label();
            this.pnlReset = new System.Windows.Forms.Panel();
            this.rtxtRequirements = new System.Windows.Forms.RichTextBox();
            this.txtNewSecretAnswer = new System.Windows.Forms.TextBox();
            this.lblNewSecretAnswer = new System.Windows.Forms.Label();
            this.txtNewSecretQuestion = new System.Windows.Forms.TextBox();
            this.lblNewSecretQuestion = new System.Windows.Forms.Label();
            this.txtNewpassword = new System.Windows.Forms.TextBox();
            this.lblStep3 = new System.Windows.Forms.Label();
            this.lblRetype = new System.Windows.Forms.Label();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.txtRetypePassword = new System.Windows.Forms.TextBox();
            this.lblNewPassword = new System.Windows.Forms.Label();
            this.pnlBase = new System.Windows.Forms.Panel();
            this.cbSetNewSecret = new System.Windows.Forms.CheckBox();
            this.pnlCheckUsername.SuspendLayout();
            this.pnlSecretQuestion.SuspendLayout();
            this.pnlReset.SuspendLayout();
            this.pnlBase.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlCheckUsername
            // 
            this.pnlCheckUsername.Controls.Add(this.lblStep1);
            this.pnlCheckUsername.Controls.Add(this.btnCheckUsername);
            this.pnlCheckUsername.Controls.Add(this.txtUsername);
            this.pnlCheckUsername.Controls.Add(this.lblCheckUsername);
            this.pnlCheckUsername.Location = new System.Drawing.Point(30, 30);
            this.pnlCheckUsername.Name = "pnlCheckUsername";
            this.pnlCheckUsername.Size = new System.Drawing.Size(1143, 474);
            this.pnlCheckUsername.TabIndex = 1;
            // 
            // lblStep1
            // 
            this.lblStep1.AutoSize = true;
            this.lblStep1.Location = new System.Drawing.Point(45, 45);
            this.lblStep1.Name = "lblStep1";
            this.lblStep1.Size = new System.Drawing.Size(294, 25);
            this.lblStep1.TabIndex = 1;
            this.lblStep1.Text = "SETP 1. Type your username";
            // 
            // btnCheckUsername
            // 
            this.btnCheckUsername.Location = new System.Drawing.Point(778, 149);
            this.btnCheckUsername.Name = "btnCheckUsername";
            this.btnCheckUsername.Size = new System.Drawing.Size(237, 142);
            this.btnCheckUsername.TabIndex = 1;
            this.btnCheckUsername.Text = "NEXT";
            this.btnCheckUsername.UseVisualStyleBackColor = true;
            this.btnCheckUsername.Click += new System.EventHandler(this.btnCheckUsername_Click);
            // 
            // txtUsername
            // 
            this.txtUsername.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.txtUsername.Location = new System.Drawing.Point(299, 188);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(333, 31);
            this.txtUsername.TabIndex = 1;
            this.txtUsername.Text = "please enter your email";
            this.txtUsername.Click += new System.EventHandler(this.txtUsername_Click);
            // 
            // lblCheckUsername
            // 
            this.lblCheckUsername.AutoSize = true;
            this.lblCheckUsername.Location = new System.Drawing.Point(127, 194);
            this.lblCheckUsername.Name = "lblCheckUsername";
            this.lblCheckUsername.Size = new System.Drawing.Size(143, 25);
            this.lblCheckUsername.TabIndex = 1;
            this.lblCheckUsername.Text = "USERNAME :";
            // 
            // pnlSecretQuestion
            // 
            this.pnlSecretQuestion.Controls.Add(this.lblStep2);
            this.pnlSecretQuestion.Controls.Add(this.lblSecretQuestionOut);
            this.pnlSecretQuestion.Controls.Add(this.lblSecretAnswer);
            this.pnlSecretQuestion.Controls.Add(this.btnSecretQuestion);
            this.pnlSecretQuestion.Controls.Add(this.txtSecretAnswer);
            this.pnlSecretQuestion.Controls.Add(this.lblSecretQuestion);
            this.pnlSecretQuestion.Location = new System.Drawing.Point(30, 30);
            this.pnlSecretQuestion.Name = "pnlSecretQuestion";
            this.pnlSecretQuestion.Size = new System.Drawing.Size(1143, 474);
            this.pnlSecretQuestion.TabIndex = 2;
            // 
            // lblStep2
            // 
            this.lblStep2.AutoSize = true;
            this.lblStep2.Location = new System.Drawing.Point(45, 45);
            this.lblStep2.Name = "lblStep2";
            this.lblStep2.Size = new System.Drawing.Size(290, 25);
            this.lblStep2.TabIndex = 2;
            this.lblStep2.Text = "SETP 2. Type Secret Answer";
            // 
            // lblSecretQuestionOut
            // 
            this.lblSecretQuestionOut.AutoSize = true;
            this.lblSecretQuestionOut.Location = new System.Drawing.Point(342, 200);
            this.lblSecretQuestionOut.MinimumSize = new System.Drawing.Size(300, 0);
            this.lblSecretQuestionOut.Name = "lblSecretQuestionOut";
            this.lblSecretQuestionOut.Size = new System.Drawing.Size(300, 25);
            this.lblSecretQuestionOut.TabIndex = 2;
            this.lblSecretQuestionOut.Text = "...";
            // 
            // lblSecretAnswer
            // 
            this.lblSecretAnswer.AutoSize = true;
            this.lblSecretAnswer.Location = new System.Drawing.Point(82, 255);
            this.lblSecretAnswer.Name = "lblSecretAnswer";
            this.lblSecretAnswer.Size = new System.Drawing.Size(207, 25);
            this.lblSecretAnswer.TabIndex = 2;
            this.lblSecretAnswer.Text = "SECRET ANSWER :";
            // 
            // btnSecretQuestion
            // 
            this.btnSecretQuestion.Location = new System.Drawing.Point(784, 155);
            this.btnSecretQuestion.Name = "btnSecretQuestion";
            this.btnSecretQuestion.Size = new System.Drawing.Size(237, 142);
            this.btnSecretQuestion.TabIndex = 2;
            this.btnSecretQuestion.Text = "NEXT";
            this.btnSecretQuestion.UseVisualStyleBackColor = true;
            this.btnSecretQuestion.Click += new System.EventHandler(this.btnSecretQuestion_Click);
            // 
            // txtSecretAnswer
            // 
            this.txtSecretAnswer.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.txtSecretAnswer.Location = new System.Drawing.Point(334, 255);
            this.txtSecretAnswer.Name = "txtSecretAnswer";
            this.txtSecretAnswer.Size = new System.Drawing.Size(333, 31);
            this.txtSecretAnswer.TabIndex = 2;
            this.txtSecretAnswer.Text = "please enter the answer";
            this.txtSecretAnswer.Click += new System.EventHandler(this.textBox1_Click);
            // 
            // lblSecretQuestion
            // 
            this.lblSecretQuestion.AutoSize = true;
            this.lblSecretQuestion.Location = new System.Drawing.Point(82, 200);
            this.lblSecretQuestion.Name = "lblSecretQuestion";
            this.lblSecretQuestion.Size = new System.Drawing.Size(223, 25);
            this.lblSecretQuestion.TabIndex = 2;
            this.lblSecretQuestion.Text = "SECRET QUESTION :";
            // 
            // pnlReset
            // 
            this.pnlReset.Controls.Add(this.cbSetNewSecret);
            this.pnlReset.Controls.Add(this.rtxtRequirements);
            this.pnlReset.Controls.Add(this.txtNewSecretAnswer);
            this.pnlReset.Controls.Add(this.lblNewSecretAnswer);
            this.pnlReset.Controls.Add(this.txtNewSecretQuestion);
            this.pnlReset.Controls.Add(this.lblNewSecretQuestion);
            this.pnlReset.Controls.Add(this.txtNewpassword);
            this.pnlReset.Controls.Add(this.lblStep3);
            this.pnlReset.Controls.Add(this.lblRetype);
            this.pnlReset.Controls.Add(this.btnConfirm);
            this.pnlReset.Controls.Add(this.txtRetypePassword);
            this.pnlReset.Controls.Add(this.lblNewPassword);
            this.pnlReset.Location = new System.Drawing.Point(30, 30);
            this.pnlReset.Name = "pnlReset";
            this.pnlReset.Size = new System.Drawing.Size(1143, 513);
            this.pnlReset.TabIndex = 3;
            // 
            // rtxtRequirements
            // 
            this.rtxtRequirements.Location = new System.Drawing.Point(751, 128);
            this.rtxtRequirements.Name = "rtxtRequirements";
            this.rtxtRequirements.Size = new System.Drawing.Size(363, 343);
            this.rtxtRequirements.TabIndex = 8;
            this.rtxtRequirements.Text = "The new password requirements:\n• Minimum length 8 characters\n• Minimum of 1 lower" +
    "case letter\n• Minimum of 1 uppercase letter\n• Minimum of 1 number\n• Minimum of 1" +
    " special character";
            // 
            // txtNewSecretAnswer
            // 
            this.txtNewSecretAnswer.Enabled = false;
            this.txtNewSecretAnswer.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.txtNewSecretAnswer.Location = new System.Drawing.Point(331, 322);
            this.txtNewSecretAnswer.Name = "txtNewSecretAnswer";
            this.txtNewSecretAnswer.Size = new System.Drawing.Size(377, 31);
            this.txtNewSecretAnswer.TabIndex = 7;
            this.txtNewSecretAnswer.Text = "Check the checkbox to activate it";
            this.txtNewSecretAnswer.Click += new System.EventHandler(this.txtNewSecretAnswer_Click);
            // 
            // lblNewSecretAnswer
            // 
            this.lblNewSecretAnswer.AutoSize = true;
            this.lblNewSecretAnswer.Location = new System.Drawing.Point(47, 322);
            this.lblNewSecretAnswer.Name = "lblNewSecretAnswer";
            this.lblNewSecretAnswer.Size = new System.Drawing.Size(262, 50);
            this.lblNewSecretAnswer.TabIndex = 6;
            this.lblNewSecretAnswer.Text = "NEW SECRET ANSWER :\r\n(optional)\r\n";
            // 
            // txtNewSecretQuestion
            // 
            this.txtNewSecretQuestion.Enabled = false;
            this.txtNewSecretQuestion.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.txtNewSecretQuestion.Location = new System.Drawing.Point(331, 258);
            this.txtNewSecretQuestion.Name = "txtNewSecretQuestion";
            this.txtNewSecretQuestion.Size = new System.Drawing.Size(377, 31);
            this.txtNewSecretQuestion.TabIndex = 5;
            this.txtNewSecretQuestion.Text = "Check the checkbox to activate it";
            this.txtNewSecretQuestion.Click += new System.EventHandler(this.txtNewSecretQuestion_Click);
            // 
            // lblNewSecretQuestion
            // 
            this.lblNewSecretQuestion.AutoSize = true;
            this.lblNewSecretQuestion.Location = new System.Drawing.Point(47, 258);
            this.lblNewSecretQuestion.Name = "lblNewSecretQuestion";
            this.lblNewSecretQuestion.Size = new System.Drawing.Size(278, 75);
            this.lblNewSecretQuestion.TabIndex = 4;
            this.lblNewSecretQuestion.Text = "NEW SECRET QUESTION :\r\n(optional)\r\n\r\n";
            // 
            // txtNewpassword
            // 
            this.txtNewpassword.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.txtNewpassword.Location = new System.Drawing.Point(331, 137);
            this.txtNewpassword.Name = "txtNewpassword";
            this.txtNewpassword.Size = new System.Drawing.Size(377, 31);
            this.txtNewpassword.TabIndex = 3;
            this.txtNewpassword.Text = "please enter a new password";
            this.txtNewpassword.Click += new System.EventHandler(this.txtNewpassword_Click);
            // 
            // lblStep3
            // 
            this.lblStep3.AutoSize = true;
            this.lblStep3.Location = new System.Drawing.Point(45, 45);
            this.lblStep3.Name = "lblStep3";
            this.lblStep3.Size = new System.Drawing.Size(336, 25);
            this.lblStep3.TabIndex = 3;
            this.lblStep3.Text = "SETP 3. Type your new password";
            // 
            // lblRetype
            // 
            this.lblRetype.AutoSize = true;
            this.lblRetype.Location = new System.Drawing.Point(47, 197);
            this.lblRetype.Name = "lblRetype";
            this.lblRetype.Size = new System.Drawing.Size(237, 25);
            this.lblRetype.TabIndex = 3;
            this.lblRetype.Text = "RETYPE PASSWORD :";
            // 
            // btnConfirm
            // 
            this.btnConfirm.Location = new System.Drawing.Point(518, 397);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(190, 74);
            this.btnConfirm.TabIndex = 3;
            this.btnConfirm.Text = "CONFIRM";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // txtRetypePassword
            // 
            this.txtRetypePassword.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.txtRetypePassword.Location = new System.Drawing.Point(331, 197);
            this.txtRetypePassword.Name = "txtRetypePassword";
            this.txtRetypePassword.Size = new System.Drawing.Size(377, 31);
            this.txtRetypePassword.TabIndex = 3;
            this.txtRetypePassword.Text = "please enter the password again";
            this.txtRetypePassword.Click += new System.EventHandler(this.txtRetypePassword_Click);
            // 
            // lblNewPassword
            // 
            this.lblNewPassword.AutoSize = true;
            this.lblNewPassword.Location = new System.Drawing.Point(47, 137);
            this.lblNewPassword.Name = "lblNewPassword";
            this.lblNewPassword.Size = new System.Drawing.Size(201, 25);
            this.lblNewPassword.TabIndex = 3;
            this.lblNewPassword.Text = "NEW PASSWORD :";
            // 
            // pnlBase
            // 
            this.pnlBase.Controls.Add(this.pnlReset);
            this.pnlBase.Controls.Add(this.pnlCheckUsername);
            this.pnlBase.Controls.Add(this.pnlSecretQuestion);
            this.pnlBase.Location = new System.Drawing.Point(42, 23);
            this.pnlBase.Name = "pnlBase";
            this.pnlBase.Size = new System.Drawing.Size(1206, 577);
            this.pnlBase.TabIndex = 0;
            // 
            // cbSetNewSecret
            // 
            this.cbSetNewSecret.AutoSize = true;
            this.cbSetNewSecret.Location = new System.Drawing.Point(52, 421);
            this.cbSetNewSecret.Name = "cbSetNewSecret";
            this.cbSetNewSecret.Size = new System.Drawing.Size(400, 29);
            this.cbSetNewSecret.TabIndex = 10;
            this.cbSetNewSecret.Text = "SET new secret question and answer";
            this.cbSetNewSecret.UseVisualStyleBackColor = true;
            this.cbSetNewSecret.CheckedChanged += new System.EventHandler(this.cbSetNewSecret_CheckedChanged);
            // 
            // ResetPassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1290, 637);
            this.Controls.Add(this.pnlBase);
            this.Name = "ResetPassword";
            this.Text = "RenewPassword";
            this.pnlCheckUsername.ResumeLayout(false);
            this.pnlCheckUsername.PerformLayout();
            this.pnlSecretQuestion.ResumeLayout(false);
            this.pnlSecretQuestion.PerformLayout();
            this.pnlReset.ResumeLayout(false);
            this.pnlReset.PerformLayout();
            this.pnlBase.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlCheckUsername;
        private System.Windows.Forms.Button btnCheckUsername;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label lblCheckUsername;
        private System.Windows.Forms.Panel pnlSecretQuestion;
        private System.Windows.Forms.Button btnSecretQuestion;
        private System.Windows.Forms.TextBox txtSecretAnswer;
        private System.Windows.Forms.Label lblSecretQuestion;
        private System.Windows.Forms.Label lblSecretQuestionOut;
        private System.Windows.Forms.Label lblSecretAnswer;
        private System.Windows.Forms.Label lblStep2;
        private System.Windows.Forms.Label lblStep1;
        private System.Windows.Forms.Panel pnlReset;
        private System.Windows.Forms.TextBox txtNewpassword;
        private System.Windows.Forms.Label lblStep3;
        private System.Windows.Forms.Label lblRetype;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.TextBox txtRetypePassword;
        private System.Windows.Forms.Label lblNewPassword;
        private System.Windows.Forms.Panel pnlBase;
        private System.Windows.Forms.TextBox txtNewSecretAnswer;
        private System.Windows.Forms.Label lblNewSecretAnswer;
        private System.Windows.Forms.TextBox txtNewSecretQuestion;
        private System.Windows.Forms.Label lblNewSecretQuestion;
        private System.Windows.Forms.RichTextBox rtxtRequirements;
        private System.Windows.Forms.CheckBox cbSetNewSecret;
    }
}