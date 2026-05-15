namespace HospitalManagementSystem.Forms
{
    partial class LoginForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtUsername = new MaterialSkin.Controls.MaterialTextBox();
            this.txtPassword = new MaterialSkin.Controls.MaterialTextBox();
            this.cmbRole = new MaterialSkin.Controls.MaterialComboBox();
            this.btnLogin = new MaterialSkin.Controls.MaterialButton();
            this.lblTitle = new System.Windows.Forms.Label();
            this.SuspendLayout();

            this.Text = "Hospital Management System";
            this.ClientSize = new System.Drawing.Size(420, 500);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Sizable = false;
            this.MaximizeBox = false;

            this.lblTitle.Text = "HMS LOGIN";
            this.lblTitle.Font = new System.Drawing.Font("Roboto", 18F,
                                        System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(33, 150, 243);
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTitle.Size = new System.Drawing.Size(380, 50);
            this.lblTitle.Location = new System.Drawing.Point(20, 80);

            this.cmbRole.Location = new System.Drawing.Point(30, 150);
            this.cmbRole.Size = new System.Drawing.Size(360, 50);
            this.cmbRole.Hint = "Select Role";
            this.cmbRole.Items.AddRange(new object[] { "Admin", "Doctor", "Patient" });

            this.txtUsername.Location = new System.Drawing.Point(30, 220);
            this.txtUsername.Size = new System.Drawing.Size(360, 50);
            this.txtUsername.Hint = "Username";

            this.txtPassword.Location = new System.Drawing.Point(30, 290);
            this.txtPassword.Size = new System.Drawing.Size(360, 50);
            this.txtPassword.Hint = "Password";
            this.txtPassword.Password = true;

            this.btnLogin.Location = new System.Drawing.Point(30, 370);
            this.btnLogin.Size = new System.Drawing.Size(360, 50);
            this.btnLogin.Text = "LOGIN";
            this.btnLogin.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);

            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.cmbRole);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.btnLogin);

            this.ResumeLayout(false);
        }

        private MaterialSkin.Controls.MaterialTextBox txtUsername;
        private MaterialSkin.Controls.MaterialTextBox txtPassword;
        private MaterialSkin.Controls.MaterialComboBox cmbRole;
        private MaterialSkin.Controls.MaterialButton btnLogin;
        private System.Windows.Forms.Label lblTitle;
    }
}