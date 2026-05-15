namespace HospitalManagementSystem.Forms.Admin
{
    partial class ManageAppointments
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
            this.txtDoctor = new MaterialSkin.Controls.MaterialTextBox();
            this.txtFees = new MaterialSkin.Controls.MaterialTextBox();
            this.txtDate = new MaterialSkin.Controls.MaterialTextBox();
            this.txtTime = new MaterialSkin.Controls.MaterialTextBox();
            this.cmbUserStatus = new MaterialSkin.Controls.MaterialComboBox();
            this.cmbDoctorStatus = new MaterialSkin.Controls.MaterialComboBox();
            this.cmbFilter = new MaterialSkin.Controls.MaterialComboBox();
            this.btnUpdateStatus = new MaterialSkin.Controls.MaterialButton();
            this.btnDelete = new MaterialSkin.Controls.MaterialButton();
            this.btnFilter = new MaterialSkin.Controls.MaterialButton();
            this.btnRefresh = new MaterialSkin.Controls.MaterialButton();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblFilter = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAppointments)).BeginInit();
            this.SuspendLayout();

            // ── Form ──────────────────────────────────────────
            this.ClientSize = new System.Drawing.Size(880, 596);
            this.BackColor = System.Drawing.Color.FromArgb(245, 245, 245);

            // ── Title ─────────────────────────────────────────
            this.lblTitle.Text = "Manage Appointments";
            this.lblTitle.Font = new System.Drawing.Font("Roboto", 16F,
                                        System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(25, 118, 210);
            this.lblTitle.Location = new System.Drawing.Point(20, 15);
            this.lblTitle.Size = new System.Drawing.Size(320, 35);

            // ── Filter Label ───────────────────────────────────
            this.lblFilter.Text = "Filter:";
            this.lblFilter.Font = new System.Drawing.Font("Roboto", 9F);
            this.lblFilter.ForeColor = System.Drawing.Color.Gray;
            this.lblFilter.Location = new System.Drawing.Point(580, 20);
            this.lblFilter.Size = new System.Drawing.Size(50, 25);

            // ── Filter ComboBox ───────────────────────────────
            this.cmbFilter.Hint = "Filter by status";
            this.cmbFilter.Location = new System.Drawing.Point(630, 15);
            this.cmbFilter.Size = new System.Drawing.Size(150, 48);
            this.cmbFilter.Items.AddRange(new object[]
            {
                "All",
                "Pending",
                "Confirmed"
            });

            // ── Filter Button ─────────────────────────────────
            this.btnFilter.Text = "FILTER";
            this.btnFilter.Location = new System.Drawing.Point(790, 20);
            this.btnFilter.Size = new System.Drawing.Size(80, 36);
            this.btnFilter.Type = MaterialSkin.Controls.MaterialButton
                                        .MaterialButtonType.Outlined;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);

            // ── DataGridView ──────────────────────────────────
            this.dgvAppointments.Location = new System.Drawing.Point(20, 60);
            this.dgvAppointments.Size = new System.Drawing.Size(840, 250);
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
            { Name = "colDoctor", HeaderText = "Doctor" });
            this.dgvAppointments.Columns.Add(new System.Windows.Forms.DataGridViewTextBoxColumn
            { Name = "colFees", HeaderText = "Fees" });
            this.dgvAppointments.Columns.Add(new System.Windows.Forms.DataGridViewTextBoxColumn
            { Name = "colDate", HeaderText = "Date" });
            this.dgvAppointments.Columns.Add(new System.Windows.Forms.DataGridViewTextBoxColumn
            { Name = "colTime", HeaderText = "Time" });
            this.dgvAppointments.Columns.Add(new System.Windows.Forms.DataGridViewTextBoxColumn
            { Name = "colUserStatus", HeaderText = "Patient Status" });
            this.dgvAppointments.Columns.Add(new System.Windows.Forms.DataGridViewTextBoxColumn
            { Name = "colDoctorStatus", HeaderText = "Doctor Status" });

            // ── Input Fields Row 1 ────────────────────────────
            int row1Y = 325;
            int row2Y = 385;

            this.txtAppID.Hint = "App ID (auto)";
            this.txtAppID.Location = new System.Drawing.Point(20, row1Y);
            this.txtAppID.Size = new System.Drawing.Size(120, 48);
            this.txtAppID.Enabled = false;

            this.txtPid.Hint = "Patient ID";
            this.txtPid.Location = new System.Drawing.Point(150, row1Y);
            this.txtPid.Size = new System.Drawing.Size(120, 48);
            this.txtPid.Enabled = false;

            this.txtPatient.Hint = "Patient Name";
            this.txtPatient.Location = new System.Drawing.Point(280, row1Y);
            this.txtPatient.Size = new System.Drawing.Size(200, 48);
            this.txtPatient.Enabled = false;

            this.txtDoctor.Hint = "Doctor";
            this.txtDoctor.Location = new System.Drawing.Point(490, row1Y);
            this.txtDoctor.Size = new System.Drawing.Size(160, 48);
            this.txtDoctor.Enabled = false;

            this.txtFees.Hint = "Fees";
            this.txtFees.Location = new System.Drawing.Point(660, row1Y);
            this.txtFees.Size = new System.Drawing.Size(120, 48);
            this.txtFees.Enabled = false;

            // ── Input Fields Row 2 ────────────────────────────
            this.txtDate.Hint = "Date";
            this.txtDate.Location = new System.Drawing.Point(20, row2Y);
            this.txtDate.Size = new System.Drawing.Size(160, 48);
            this.txtDate.Enabled = false;

            this.txtTime.Hint = "Time";
            this.txtTime.Location = new System.Drawing.Point(190, row2Y);
            this.txtTime.Size = new System.Drawing.Size(130, 48);
            this.txtTime.Enabled = false;

            this.cmbUserStatus.Hint = "Patient Status";
            this.cmbUserStatus.Location = new System.Drawing.Point(330, row2Y);
            this.cmbUserStatus.Size = new System.Drawing.Size(180, 48);
            this.cmbUserStatus.Items.AddRange(new object[] { "⏳ Pending", "✅ Confirmed" });

            this.cmbDoctorStatus.Hint = "Doctor Status";
            this.cmbDoctorStatus.Location = new System.Drawing.Point(520, row2Y);
            this.cmbDoctorStatus.Size = new System.Drawing.Size(180, 48);
            this.cmbDoctorStatus.Items.AddRange(new object[] { "⏳ Pending", "✅ Confirmed" });

            // ── Action Buttons ────────────────────────────────
            int btnY = 460;

            this.btnUpdateStatus.Text = "UPDATE STATUS";
            this.btnUpdateStatus.Location = new System.Drawing.Point(20, btnY);
            this.btnUpdateStatus.Size = new System.Drawing.Size(160, 40);
            this.btnUpdateStatus.Type = MaterialSkin.Controls.MaterialButton
                                              .MaterialButtonType.Contained;
            this.btnUpdateStatus.Click += new System.EventHandler(this.btnUpdateStatus_Click);

            this.btnDelete.Text = "DELETE";
            this.btnDelete.Location = new System.Drawing.Point(190, btnY);
            this.btnDelete.Size = new System.Drawing.Size(120, 40);
            this.btnDelete.Type = MaterialSkin.Controls.MaterialButton
                                        .MaterialButtonType.Outlined;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);

            this.btnRefresh.Text = "REFRESH";
            this.btnRefresh.Location = new System.Drawing.Point(320, btnY);
            this.btnRefresh.Size = new System.Drawing.Size(120, 40);
            this.btnRefresh.Type = MaterialSkin.Controls.MaterialButton
                                         .MaterialButtonType.Text;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);

            // ── Add Controls ──────────────────────────────────
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblFilter);
            this.Controls.Add(this.cmbFilter);
            this.Controls.Add(this.btnFilter);
            this.Controls.Add(this.dgvAppointments);
            this.Controls.Add(this.txtAppID);
            this.Controls.Add(this.txtPid);
            this.Controls.Add(this.txtPatient);
            this.Controls.Add(this.txtDoctor);
            this.Controls.Add(this.txtFees);
            this.Controls.Add(this.txtDate);
            this.Controls.Add(this.txtTime);
            this.Controls.Add(this.cmbUserStatus);
            this.Controls.Add(this.cmbDoctorStatus);
            this.Controls.Add(this.btnUpdateStatus);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnRefresh);

            ((System.ComponentModel.ISupportInitialize)(this.dgvAppointments)).EndInit();
            this.ResumeLayout(false);
        }

        // ── Control Declarations ──────────────────────────────
        private System.Windows.Forms.DataGridView dgvAppointments;
        private MaterialSkin.Controls.MaterialTextBox txtAppID;
        private MaterialSkin.Controls.MaterialTextBox txtPid;
        private MaterialSkin.Controls.MaterialTextBox txtPatient;
        private MaterialSkin.Controls.MaterialTextBox txtDoctor;
        private MaterialSkin.Controls.MaterialTextBox txtFees;
        private MaterialSkin.Controls.MaterialTextBox txtDate;
        private MaterialSkin.Controls.MaterialTextBox txtTime;
        private MaterialSkin.Controls.MaterialComboBox cmbUserStatus;
        private MaterialSkin.Controls.MaterialComboBox cmbDoctorStatus;
        private MaterialSkin.Controls.MaterialComboBox cmbFilter;
        private MaterialSkin.Controls.MaterialButton btnUpdateStatus;
        private MaterialSkin.Controls.MaterialButton btnDelete;
        private MaterialSkin.Controls.MaterialButton btnFilter;
        private MaterialSkin.Controls.MaterialButton btnRefresh;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblFilter;
    }
}