namespace HospitalManagementSystem.Forms.Doctor
{
    partial class DoctorAppointments
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dgvAppointments = new System.Windows.Forms.DataGridView();
            this.txtAppID = new MaterialSkin.Controls.MaterialTextBox();
            this.txtPid = new MaterialSkin.Controls.MaterialTextBox();
            this.txtPatient = new MaterialSkin.Controls.MaterialTextBox();
            this.txtGender = new MaterialSkin.Controls.MaterialTextBox();
            this.txtEmail = new MaterialSkin.Controls.MaterialTextBox();
            this.txtContact = new MaterialSkin.Controls.MaterialTextBox();
            this.txtFees = new MaterialSkin.Controls.MaterialTextBox();
            this.txtDate = new MaterialSkin.Controls.MaterialTextBox();
            this.txtTime = new MaterialSkin.Controls.MaterialTextBox();
            this.cmbDoctorStatus = new MaterialSkin.Controls.MaterialComboBox();
            this.btnConfirm = new MaterialSkin.Controls.MaterialButton();
            this.btnQuickConfirm = new MaterialSkin.Controls.MaterialButton();
            this.btnWriteRx = new MaterialSkin.Controls.MaterialButton();
            this.btnRefresh = new MaterialSkin.Controls.MaterialButton();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblDetail = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAppointments)).BeginInit();
            this.SuspendLayout();

            // ── Form ──────────────────────────────────────────
            this.ClientSize = new System.Drawing.Size(880, 596);
            this.BackColor = System.Drawing.Color.FromArgb(245, 245, 245);

            // ── Title ─────────────────────────────────────────
            this.lblTitle.Text = "My Appointments";
            this.lblTitle.Font = new System.Drawing.Font("Roboto", 16F,
                                        System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(0, 121, 107);
            this.lblTitle.Location = new System.Drawing.Point(20, 15);
            this.lblTitle.Size = new System.Drawing.Size(300, 35);

            // ── Total Label ───────────────────────────────────
            this.lblTotal.Text = "Total Appointments: 0";
            this.lblTotal.Font = new System.Drawing.Font("Roboto", 9F);
            this.lblTotal.ForeColor = System.Drawing.Color.Gray;
            this.lblTotal.Location = new System.Drawing.Point(20, 52);
            this.lblTotal.Size = new System.Drawing.Size(220, 20);

            // ── Refresh Button ────────────────────────────────
            this.btnRefresh.Text = "REFRESH";
            this.btnRefresh.Location = new System.Drawing.Point(760, 20);
            this.btnRefresh.Size = new System.Drawing.Size(110, 36);
            this.btnRefresh.Type = MaterialSkin.Controls.MaterialButton
                                         .MaterialButtonType.Text;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);

            // ── DataGridView ──────────────────────────────────
            this.dgvAppointments.Location = new System.Drawing.Point(20, 75);
            this.dgvAppointments.Size = new System.Drawing.Size(840, 230);
            this.dgvAppointments.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAppointments.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAppointments.MultiSelect = false;
            this.dgvAppointments.ReadOnly = true;
            this.dgvAppointments.AllowUserToAddRows = false;
            this.dgvAppointments.BackgroundColor = System.Drawing.Color.White;
            this.dgvAppointments.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvAppointments.RowHeadersVisible = false;
            this.dgvAppointments.Font = new System.Drawing.Font("Roboto", 9F);
            this.dgvAppointments.SelectionChanged += new System.EventHandler(
                                                         this.dgvAppointments_SelectionChanged);

            // ── Columns ───────────────────────────────────────
            this.dgvAppointments.Columns.Add(new System.Windows.Forms.DataGridViewTextBoxColumn
            { Name = "colID", HeaderText = "App ID" });
            this.dgvAppointments.Columns.Add(new System.Windows.Forms.DataGridViewTextBoxColumn
            { Name = "colPid", HeaderText = "Patient ID" });
            this.dgvAppointments.Columns.Add(new System.Windows.Forms.DataGridViewTextBoxColumn
            { Name = "colPatient", HeaderText = "Patient Name" });
            this.dgvAppointments.Columns.Add(new System.Windows.Forms.DataGridViewTextBoxColumn
            { Name = "colGender", HeaderText = "Gender" });
            this.dgvAppointments.Columns.Add(new System.Windows.Forms.DataGridViewTextBoxColumn
            { Name = "colEmail", HeaderText = "Email" });
            this.dgvAppointments.Columns.Add(new System.Windows.Forms.DataGridViewTextBoxColumn
            { Name = "colContact", HeaderText = "Contact" });
            this.dgvAppointments.Columns.Add(new System.Windows.Forms.DataGridViewTextBoxColumn
            { Name = "colFees", HeaderText = "Fees" });
            this.dgvAppointments.Columns.Add(new System.Windows.Forms.DataGridViewTextBoxColumn
            { Name = "colDate", HeaderText = "Date" });
            this.dgvAppointments.Columns.Add(new System.Windows.Forms.DataGridViewTextBoxColumn
            { Name = "colTime", HeaderText = "Time" });
            this.dgvAppointments.Columns.Add(new System.Windows.Forms.DataGridViewTextBoxColumn
            { Name = "colUserStatus", HeaderText = "Patient Status" });
            this.dgvAppointments.Columns.Add(new System.Windows.Forms.DataGridViewTextBoxColumn
            { Name = "colDoctorStatus", HeaderText = "My Status" });

            // ── Detail Section Label ──────────────────────────
            this.lblDetail.Text = "── Selected Appointment ──────────────────────";
            this.lblDetail.Font = new System.Drawing.Font("Roboto", 9F,
                                         System.Drawing.FontStyle.Bold);
            this.lblDetail.ForeColor = System.Drawing.Color.FromArgb(0, 121, 107);
            this.lblDetail.Location = new System.Drawing.Point(20, 315);
            this.lblDetail.Size = new System.Drawing.Size(840, 20);

            // ── Detail Fields Row 1 ───────────────────────────
            int row1Y = 343;
            int row2Y = 400;

            this.txtAppID.Hint = "App ID";
            this.txtAppID.Location = new System.Drawing.Point(20, row1Y);
            this.txtAppID.Size = new System.Drawing.Size(100, 48);
            this.txtAppID.Enabled = false;

            this.txtPid.Hint = "Patient ID";
            this.txtPid.Location = new System.Drawing.Point(130, row1Y);
            this.txtPid.Size = new System.Drawing.Size(100, 48);
            this.txtPid.Enabled = false;

            this.txtPatient.Hint = "Patient Name";
            this.txtPatient.Location = new System.Drawing.Point(240, row1Y);
            this.txtPatient.Size = new System.Drawing.Size(200, 48);
            this.txtPatient.Enabled = false;

            this.txtGender.Hint = "Gender";
            this.txtGender.Location = new System.Drawing.Point(450, row1Y);
            this.txtGender.Size = new System.Drawing.Size(100, 48);
            this.txtGender.Enabled = false;

            this.txtFees.Hint = "Fees";
            this.txtFees.Location = new System.Drawing.Point(560, row1Y);
            this.txtFees.Size = new System.Drawing.Size(120, 48);
            this.txtFees.Enabled = false;

            // ── Detail Fields Row 2 ───────────────────────────
            this.txtEmail.Hint = "Email";
            this.txtEmail.Location = new System.Drawing.Point(20, row2Y);
            this.txtEmail.Size = new System.Drawing.Size(230, 48);
            this.txtEmail.Enabled = false;

            this.txtContact.Hint = "Contact";
            this.txtContact.Location = new System.Drawing.Point(260, row2Y);
            this.txtContact.Size = new System.Drawing.Size(150, 48);
            this.txtContact.Enabled = false;

            this.txtDate.Hint = "Date";
            this.txtDate.Location = new System.Drawing.Point(420, row2Y);
            this.txtDate.Size = new System.Drawing.Size(140, 48);
            this.txtDate.Enabled = false;

            this.txtTime.Hint = "Time";
            this.txtTime.Location = new System.Drawing.Point(570, row2Y);
            this.txtTime.Size = new System.Drawing.Size(120, 48);
            this.txtTime.Enabled = false;

            this.cmbDoctorStatus.Hint = "My Status";
            this.cmbDoctorStatus.Location = new System.Drawing.Point(700, row2Y);
            this.cmbDoctorStatus.Size = new System.Drawing.Size(160, 48);
            this.cmbDoctorStatus.Items.AddRange(new object[]
                { "⏳ Pending", "✅ Confirmed" });

            // ── Action Buttons ────────────────────────────────
            int btnY = 465;

            this.btnConfirm.Text = "UPDATE STATUS";
            this.btnConfirm.Location = new System.Drawing.Point(20, btnY);
            this.btnConfirm.Size = new System.Drawing.Size(150, 40);
            this.btnConfirm.Type = MaterialSkin.Controls.MaterialButton
                                         .MaterialButtonType.Contained;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);

            this.btnQuickConfirm.Text = "✅ QUICK CONFIRM";
            this.btnQuickConfirm.Location = new System.Drawing.Point(180, btnY);
            this.btnQuickConfirm.Size = new System.Drawing.Size(160, 40);
            this.btnQuickConfirm.Type = MaterialSkin.Controls.MaterialButton
                                              .MaterialButtonType.Contained;
            this.btnQuickConfirm.Click += new System.EventHandler(
                                              this.btnQuickConfirm_Click);

            this.btnWriteRx.Text = "📝 WRITE PRESCRIPTION";
            this.btnWriteRx.Location = new System.Drawing.Point(350, btnY);
            this.btnWriteRx.Size = new System.Drawing.Size(200, 40);
            this.btnWriteRx.Type = MaterialSkin.Controls.MaterialButton
                                         .MaterialButtonType.Outlined;
            this.btnWriteRx.Click += new System.EventHandler(this.btnWriteRx_Click);

            // ── Add Controls ──────────────────────────────────
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.dgvAppointments);
            this.Controls.Add(this.lblDetail);
            this.Controls.Add(this.txtAppID);
            this.Controls.Add(this.txtPid);
            this.Controls.Add(this.txtPatient);
            this.Controls.Add(this.txtGender);
            this.Controls.Add(this.txtFees);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtContact);
            this.Controls.Add(this.txtDate);
            this.Controls.Add(this.txtTime);
            this.Controls.Add(this.cmbDoctorStatus);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.btnQuickConfirm);
            this.Controls.Add(this.btnWriteRx);

            ((System.ComponentModel.ISupportInitialize)(this.dgvAppointments)).EndInit();
            this.ResumeLayout(false);
        }

        // ── Control Declarations ──────────────────────────────
        private System.Windows.Forms.DataGridView dgvAppointments;
        private MaterialSkin.Controls.MaterialTextBox txtAppID;
        private MaterialSkin.Controls.MaterialTextBox txtPid;
        private MaterialSkin.Controls.MaterialTextBox txtPatient;
        private MaterialSkin.Controls.MaterialTextBox txtGender;
        private MaterialSkin.Controls.MaterialTextBox txtEmail;
        private MaterialSkin.Controls.MaterialTextBox txtContact;
        private MaterialSkin.Controls.MaterialTextBox txtFees;
        private MaterialSkin.Controls.MaterialTextBox txtDate;
        private MaterialSkin.Controls.MaterialTextBox txtTime;
        private MaterialSkin.Controls.MaterialComboBox cmbDoctorStatus;
        private MaterialSkin.Controls.MaterialButton btnConfirm;
        private MaterialSkin.Controls.MaterialButton btnQuickConfirm;
        private MaterialSkin.Controls.MaterialButton btnWriteRx;
        private MaterialSkin.Controls.MaterialButton btnRefresh;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblDetail;
    }
}