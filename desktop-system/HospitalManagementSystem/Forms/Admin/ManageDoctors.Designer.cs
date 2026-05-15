namespace HospitalManagementSystem.Forms.Admin
{
    partial class ManageDoctors
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dgvDoctors = new System.Windows.Forms.DataGridView();
            this.txtUsername = new MaterialSkin.Controls.MaterialTextBox();
            this.txtPassword = new MaterialSkin.Controls.MaterialTextBox();
            this.txtEmail = new MaterialSkin.Controls.MaterialTextBox();
            this.txtFees = new MaterialSkin.Controls.MaterialTextBox();
            this.cmbSpec = new MaterialSkin.Controls.MaterialComboBox();
            this.btnAdd = new MaterialSkin.Controls.MaterialButton();
            this.btnUpdate = new MaterialSkin.Controls.MaterialButton();
            this.btnDelete = new MaterialSkin.Controls.MaterialButton();
            this.btnRefresh = new MaterialSkin.Controls.MaterialButton();
            this.lblTitle = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDoctors)).BeginInit();
            this.SuspendLayout();

            // ── Form ──────────────────────────────────────────
            this.ClientSize = new System.Drawing.Size(880, 596);
            this.BackColor = System.Drawing.Color.FromArgb(245, 245, 245);

            // ── Title ─────────────────────────────────────────
            this.lblTitle.Text = "Manage Doctors";
            this.lblTitle.Font = new System.Drawing.Font("Roboto", 16F,
                                        System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(25, 118, 210);
            this.lblTitle.Location = new System.Drawing.Point(20, 15);
            this.lblTitle.Size = new System.Drawing.Size(300, 35);

            // ── DataGridView ──────────────────────────────────
            this.dgvDoctors.Location = new System.Drawing.Point(20, 60);
            this.dgvDoctors.Size = new System.Drawing.Size(840, 270);
            this.dgvDoctors.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDoctors.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDoctors.MultiSelect = false;
            this.dgvDoctors.ReadOnly = true;
            this.dgvDoctors.AllowUserToAddRows = false;
            this.dgvDoctors.BackgroundColor = System.Drawing.Color.White;
            this.dgvDoctors.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvDoctors.RowHeadersVisible = false;
            this.dgvDoctors.Font = new System.Drawing.Font("Roboto", 9F);
            this.dgvDoctors.SelectionChanged += new System.EventHandler(
                                                    this.dgvDoctors_SelectionChanged);

            // ── Columns ───────────────────────────────────────
            // doctb: username | email | spec | docFees
            this.dgvDoctors.Columns.Add(new System.Windows.Forms.DataGridViewTextBoxColumn
            { Name = "colUsername", HeaderText = "Username" });
            this.dgvDoctors.Columns.Add(new System.Windows.Forms.DataGridViewTextBoxColumn
            { Name = "colEmail", HeaderText = "Email" });
            this.dgvDoctors.Columns.Add(new System.Windows.Forms.DataGridViewTextBoxColumn
            { Name = "colSpec", HeaderText = "Specialization" });
            this.dgvDoctors.Columns.Add(new System.Windows.Forms.DataGridViewTextBoxColumn
            { Name = "colFees", HeaderText = "Fees (₹)" });

            // ── Input Fields ──────────────────────────────────
            int row1Y = 350;
            int row2Y = 410;

            this.txtUsername.Hint = "Username";
            this.txtUsername.Location = new System.Drawing.Point(20, row1Y);
            this.txtUsername.Size = new System.Drawing.Size(200, 48);

            this.txtPassword.Hint = "Password";
            this.txtPassword.Location = new System.Drawing.Point(230, row1Y);
            this.txtPassword.Size = new System.Drawing.Size(200, 48);
            this.txtPassword.Password = true;

            this.txtEmail.Hint = "Email";
            this.txtEmail.Location = new System.Drawing.Point(440, row1Y);
            this.txtEmail.Size = new System.Drawing.Size(250, 48);

            // Specializations from doctb data
            this.cmbSpec.Hint = "Specialization";
            this.cmbSpec.Location = new System.Drawing.Point(20, row2Y);
            this.cmbSpec.Size = new System.Drawing.Size(220, 48);
            this.cmbSpec.Items.AddRange(new object[]
            {
                "General",
                "Cardiologist",
                "Pediatrician",
                "Neurologist",
                "Dermatologist",
                "Orthopedic",
                "ENT Specialist",
                "Ophthalmologist"
            });

            this.txtFees.Hint = "Doctor Fees";
            this.txtFees.Location = new System.Drawing.Point(250, row2Y);
            this.txtFees.Size = new System.Drawing.Size(200, 48);

            // ── Action Buttons ────────────────────────────────
            int btnY = 490;

            this.btnAdd.Text = "ADD";
            this.btnAdd.Location = new System.Drawing.Point(20, btnY);
            this.btnAdd.Size = new System.Drawing.Size(120, 40);
            this.btnAdd.Type = MaterialSkin.Controls.MaterialButton
                                     .MaterialButtonType.Contained;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);

            this.btnUpdate.Text = "UPDATE";
            this.btnUpdate.Location = new System.Drawing.Point(150, btnY);
            this.btnUpdate.Size = new System.Drawing.Size(120, 40);
            this.btnUpdate.Type = MaterialSkin.Controls.MaterialButton
                                        .MaterialButtonType.Contained;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);

            this.btnDelete.Text = "DELETE";
            this.btnDelete.Location = new System.Drawing.Point(280, btnY);
            this.btnDelete.Size = new System.Drawing.Size(120, 40);
            this.btnDelete.Type = MaterialSkin.Controls.MaterialButton
                                        .MaterialButtonType.Outlined;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);

            this.btnRefresh.Text = "REFRESH";
            this.btnRefresh.Location = new System.Drawing.Point(410, btnY);
            this.btnRefresh.Size = new System.Drawing.Size(120, 40);
            this.btnRefresh.Type = MaterialSkin.Controls.MaterialButton
                                         .MaterialButtonType.Text;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);

            // ── Add Controls ──────────────────────────────────
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.dgvDoctors);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.cmbSpec);
            this.Controls.Add(this.txtFees);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnRefresh);

            ((System.ComponentModel.ISupportInitialize)(this.dgvDoctors)).EndInit();
            this.ResumeLayout(false);
        }

        // ── Control Declarations ──────────────────────────────
        private System.Windows.Forms.DataGridView dgvDoctors;
        private MaterialSkin.Controls.MaterialTextBox txtUsername;
        private MaterialSkin.Controls.MaterialTextBox txtPassword;
        private MaterialSkin.Controls.MaterialTextBox txtEmail;
        private MaterialSkin.Controls.MaterialTextBox txtFees;
        private MaterialSkin.Controls.MaterialComboBox cmbSpec;
        private MaterialSkin.Controls.MaterialButton btnAdd;
        private MaterialSkin.Controls.MaterialButton btnUpdate;
        private MaterialSkin.Controls.MaterialButton btnDelete;
        private MaterialSkin.Controls.MaterialButton btnRefresh;
        private System.Windows.Forms.Label lblTitle;
    }
}