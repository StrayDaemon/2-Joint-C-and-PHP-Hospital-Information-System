namespace HospitalManagementSystem.Forms.Admin
{
    partial class ManagePatients
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dgvPatients = new System.Windows.Forms.DataGridView();
            this.txtPid = new MaterialSkin.Controls.MaterialTextBox();
            this.txtFname = new MaterialSkin.Controls.MaterialTextBox();
            this.txtLname = new MaterialSkin.Controls.MaterialTextBox();
            this.txtEmail = new MaterialSkin.Controls.MaterialTextBox();
            this.txtContact = new MaterialSkin.Controls.MaterialTextBox();
            this.cmbGender = new MaterialSkin.Controls.MaterialComboBox();
            this.btnAdd = new MaterialSkin.Controls.MaterialButton();
            this.btnUpdate = new MaterialSkin.Controls.MaterialButton();
            this.btnDelete = new MaterialSkin.Controls.MaterialButton();
            this.btnRefresh = new MaterialSkin.Controls.MaterialButton();
            this.lblTitle = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPatients)).BeginInit();
            this.SuspendLayout();

            // ── Form ──────────────────────────────────────────
            this.ClientSize = new System.Drawing.Size(880, 596);
            this.BackColor = System.Drawing.Color.FromArgb(245, 245, 245);

            // ── Title ─────────────────────────────────────────
            this.lblTitle.Text = "Manage Patients";
            this.lblTitle.Font = new System.Drawing.Font("Roboto", 16F,
                                        System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(25, 118, 210);
            this.lblTitle.Location = new System.Drawing.Point(20, 15);
            this.lblTitle.Size = new System.Drawing.Size(300, 35);

            // ── DataGridView ──────────────────────────────────
            this.dgvPatients.Location = new System.Drawing.Point(20, 60);
            this.dgvPatients.Size = new System.Drawing.Size(840, 280);
            this.dgvPatients.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPatients.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPatients.MultiSelect = false;
            this.dgvPatients.ReadOnly = true;
            this.dgvPatients.AllowUserToAddRows = false;
            this.dgvPatients.BackgroundColor = System.Drawing.Color.White;
            this.dgvPatients.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvPatients.RowHeadersVisible = false;
            this.dgvPatients.Font = new System.Drawing.Font("Roboto", 9F);
            this.dgvPatients.SelectionChanged += new System.EventHandler(
                                                       this.dgvPatients_SelectionChanged);

            // ── Columns ───────────────────────────────────────
            this.dgvPatients.Columns.Add(new System.Windows.Forms.DataGridViewTextBoxColumn
            { Name = "colPid", HeaderText = "ID", ReadOnly = true });
            this.dgvPatients.Columns.Add(new System.Windows.Forms.DataGridViewTextBoxColumn
            { Name = "colFname", HeaderText = "First Name" });
            this.dgvPatients.Columns.Add(new System.Windows.Forms.DataGridViewTextBoxColumn
            { Name = "colLname", HeaderText = "Last Name" });
            this.dgvPatients.Columns.Add(new System.Windows.Forms.DataGridViewTextBoxColumn
            { Name = "colGender", HeaderText = "Gender" });
            this.dgvPatients.Columns.Add(new System.Windows.Forms.DataGridViewTextBoxColumn
            { Name = "colEmail", HeaderText = "Email" });
            this.dgvPatients.Columns.Add(new System.Windows.Forms.DataGridViewTextBoxColumn
            { Name = "colContact", HeaderText = "Contact" });

            // ── Input Fields (Form Section) ───────────────────
            int row1Y = 360;
            int row2Y = 420;

            this.txtPid.Hint = "Patient ID (auto)";
            this.txtPid.Location = new System.Drawing.Point(20, row1Y);
            this.txtPid.Size = new System.Drawing.Size(150, 48);
            this.txtPid.Enabled = false;

            this.txtFname.Hint = "First Name";
            this.txtFname.Location = new System.Drawing.Point(180, row1Y);
            this.txtFname.Size = new System.Drawing.Size(200, 48);

            this.txtLname.Hint = "Last Name";
            this.txtLname.Location = new System.Drawing.Point(390, row1Y);
            this.txtLname.Size = new System.Drawing.Size(200, 48);

            this.cmbGender.Hint = "Gender";
            this.cmbGender.Location = new System.Drawing.Point(600, row1Y);
            this.cmbGender.Size = new System.Drawing.Size(150, 48);
            this.cmbGender.Items.AddRange(new object[] { "Male", "Female", "Other" });

            this.txtEmail.Hint = "Email";
            this.txtEmail.Location = new System.Drawing.Point(20, row2Y);
            this.txtEmail.Size = new System.Drawing.Size(300, 48);

            this.txtContact.Hint = "Contact";
            this.txtContact.Location = new System.Drawing.Point(330, row2Y);
            this.txtContact.Size = new System.Drawing.Size(200, 48);

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
            this.Controls.Add(this.dgvPatients);
            this.Controls.Add(this.txtPid);
            this.Controls.Add(this.txtFname);
            this.Controls.Add(this.txtLname);
            this.Controls.Add(this.cmbGender);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtContact);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnRefresh);

            ((System.ComponentModel.ISupportInitialize)(this.dgvPatients)).EndInit();
            this.ResumeLayout(false);
        }

        // ── Control Declarations ──────────────────────────────
        private System.Windows.Forms.DataGridView dgvPatients;
        private MaterialSkin.Controls.MaterialTextBox txtPid;
        private MaterialSkin.Controls.MaterialTextBox txtFname;
        private MaterialSkin.Controls.MaterialTextBox txtLname;
        private MaterialSkin.Controls.MaterialTextBox txtEmail;
        private MaterialSkin.Controls.MaterialTextBox txtContact;
        private MaterialSkin.Controls.MaterialComboBox cmbGender;
        private MaterialSkin.Controls.MaterialButton btnAdd;
        private MaterialSkin.Controls.MaterialButton btnUpdate;
        private MaterialSkin.Controls.MaterialButton btnDelete;
        private MaterialSkin.Controls.MaterialButton btnRefresh;
        private System.Windows.Forms.Label lblTitle;
    }
}