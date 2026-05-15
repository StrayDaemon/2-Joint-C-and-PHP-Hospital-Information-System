namespace HospitalManagementSystem.Forms.Patient
{
    partial class ViewAppointments
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
            this.txtDoctor = new MaterialSkin.Controls.MaterialTextBox();
            this.txtFees = new MaterialSkin.Controls.MaterialTextBox();
            this.txtDate = new MaterialSkin.Controls.MaterialTextBox();
            this.txtTime = new MaterialSkin.Controls.MaterialTextBox();
            this.btnCancel = new MaterialSkin.Controls.MaterialButton();
            this.btnRefresh = new MaterialSkin.Controls.MaterialButton();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblConfirmed = new System.Windows.Forms.Label();
            this.lblPending = new System.Windows.Forms.Label();
            this.lblDetail = new System.Windows.Forms.Label();
            this.lblDetailStatus = new System.Windows.Forms.Label();
            this.panelSummary = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAppointments)).BeginInit();
            this.SuspendLayout();

            // ── Form ──────────────────────────────────────────
            this.ClientSize = new System.Drawing.Size(880, 596);
            this.BackColor = System.Drawing.Color.FromArgb(245, 245, 245);

            // ── Title ─────────────────────────────────────────
            this.lblTitle.Text = "My Appointments";
            this.lblTitle.Font = new System.Drawing.Font("Roboto", 16F,
                                        System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(13, 71, 161);
            this.lblTitle.Location = new System.Drawing.Point(20, 15);
            this.lblTitle.Size = new System.Drawing.Size(280, 35);

            // ── Refresh Button ────────────────────────────────
            this.btnRefresh.Text = "REFRESH";
            this.btnRefresh.Location = new System.Drawing.Point(760, 20);
            this.btnRefresh.Size = new System.Drawing.Size(110, 36);
            this.btnRefresh.Type = MaterialSkin.Controls.MaterialButton
                                         .MaterialButtonType.Text;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);

            // ── Summary Panel ─────────────────────────────────
            this.panelSummary.Location = new System.Drawing.Point(20, 58);
            this.panelSummary.Size = new System.Drawing.Size(840, 40);
            this.panelSummary.BackColor = System.Drawing.Color.Transparent;

            this.lblTotal.Text = "Total: 0";
            this.lblTotal.Font = new System.Drawing.Font("Roboto", 9F,
                                        System.Drawing.FontStyle.Bold);
            this.lblTotal.ForeColor = System.Drawing.Color.FromArgb(13, 71, 161);
            this.lblTotal.Location = new System.Drawing.Point(0, 8);
            this.lblTotal.Size = new System.Drawing.Size(120, 25);

            this.lblConfirmed.Text = "✅ Confirmed: 0";
            this.lblConfirmed.Font = new System.Drawing.Font("Roboto", 9F);
            this.lblConfirmed.ForeColor = System.Drawing.Color.Green;
            this.lblConfirmed.Location = new System.Drawing.Point(130, 8);
            this.lblConfirmed.Size = new System.Drawing.Size(160, 25);

            this.lblPending.Text = "⏳ Pending: 0";
            this.lblPending.Font = new System.Drawing.Font("Roboto", 9F);
            this.lblPending.ForeColor = System.Drawing.Color.OrangeRed;
            this.lblPending.Location = new System.Drawing.Point(300, 8);
            this.lblPending.Size = new System.Drawing.Size(160, 25);

            this.panelSummary.Controls.Add(this.lblTotal);
            this.panelSummary.Controls.Add(this.lblConfirmed);
            this.panelSummary.Controls.Add(this.lblPending);

            // ── DataGridView ──────────────────────────────────
            this.dgvAppointments.Location = new System.Drawing.Point(20, 105);
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
            this.dgvAppointments.Columns.Add(
                new System.Windows.Forms.DataGridViewTextBoxColumn
                { Name = "colID", HeaderText = "App ID", FillWeight = 8 });
            this.dgvAppointments.Columns.Add(
                new System.Windows.Forms.DataGridViewTextBoxColumn
                { Name = "colDoctor", HeaderText = "Doctor", FillWeight = 15 });
            this.dgvAppointments.Columns.Add(
                new System.Windows.Forms.DataGridViewTextBoxColumn
                { Name = "colFees", HeaderText = "Fees", FillWeight = 10 });
            this.dgvAppointments.Columns.Add(
                new System.Windows.Forms.DataGridViewTextBoxColumn
                { Name = "colDate", HeaderText = "Date", FillWeight = 15 });
            this.dgvAppointments.Columns.Add(
                new System.Windows.Forms.DataGridViewTextBoxColumn
                { Name = "colTime", HeaderText = "Time", FillWeight = 12 });
            this.dgvAppointments.Columns.Add(
                new System.Windows.Forms.DataGridViewTextBoxColumn
                { Name = "colUserStatus", HeaderText = "Your Status", FillWeight = 20 });
            this.dgvAppointments.Columns.Add(
                new System.Windows.Forms.DataGridViewTextBoxColumn
                { Name = "colDoctorStatus", HeaderText = "Doctor Status", FillWeight = 20 });

            // ── Detail Section ────────────────────────────────
            this.lblDetail.Text = "── Selected Appointment ──────────────────────";
            this.lblDetail.Font = new System.Drawing.Font("Roboto", 9F,
                                         System.Drawing.FontStyle.Bold);
            this.lblDetail.ForeColor = System.Drawing.Color.FromArgb(13, 71, 161);
            this.lblDetail.Location = new System.Drawing.Point(20, 365);
            this.lblDetail.Size = new System.Drawing.Size(840, 20);

            // ── Detail Fields ─────────────────────────────────
            int detY = 393;

            this.txtAppID.Hint = "App ID";
            this.txtAppID.Location = new System.Drawing.Point(20, detY);
            this.txtAppID.Size = new System.Drawing.Size(110, 48);
            this.txtAppID.Enabled = false;

            this.txtDoctor.Hint = "Doctor";
            this.txtDoctor.Location = new System.Drawing.Point(140, detY);
            this.txtDoctor.Size = new System.Drawing.Size(200, 48);
            this.txtDoctor.Enabled = false;

            this.txtFees.Hint = "Fees";
            this.txtFees.Location = new System.Drawing.Point(350, detY);
            this.txtFees.Size = new System.Drawing.Size(130, 48);
            this.txtFees.Enabled = false;

            this.txtDate.Hint = "Date";
            this.txtDate.Location = new System.Drawing.Point(490, detY);
            this.txtDate.Size = new System.Drawing.Size(160, 48);
            this.txtDate.Enabled = false;

            this.txtTime.Hint = "Time";
            this.txtTime.Location = new System.Drawing.Point(660, detY);
            this.txtTime.Size = new System.Drawing.Size(160, 48);
            this.txtTime.Enabled = false;

            // ── Detail Status ─────────────────────────────────
            this.lblDetailStatus.Text = "";
            this.lblDetailStatus.Font = new System.Drawing.Font("Roboto", 9F,
                                               System.Drawing.FontStyle.Italic);
            this.lblDetailStatus.Location = new System.Drawing.Point(20, 450);
            this.lblDetailStatus.Size = new System.Drawing.Size(600, 25);

            // ── Cancel Button ─────────────────────────────────
            this.btnCancel.Text = "CANCEL APPOINTMENT";
            this.btnCancel.Location = new System.Drawing.Point(20, 485);
            this.btnCancel.Size = new System.Drawing.Size(200, 45);
            this.btnCancel.Type = MaterialSkin.Controls.MaterialButton
                                        .MaterialButtonType.Outlined;
            this.btnCancel.Enabled = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            // ── Add Controls ──────────────────────────────────
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.panelSummary);
            this.Controls.Add(this.dgvAppointments);
            this.Controls.Add(this.lblDetail);
            this.Controls.Add(this.txtAppID);
            this.Controls.Add(this.txtDoctor);
            this.Controls.Add(this.txtFees);
            this.Controls.Add(this.txtDate);
            this.Controls.Add(this.txtTime);
            this.Controls.Add(this.lblDetailStatus);
            this.Controls.Add(this.btnCancel);

            ((System.ComponentModel.ISupportInitialize)(this.dgvAppointments)).EndInit();
            this.ResumeLayout(false);
        }

        // ── Control Declarations ──────────────────────────────
        private System.Windows.Forms.DataGridView dgvAppointments;
        private MaterialSkin.Controls.MaterialTextBox txtAppID;
        private MaterialSkin.Controls.MaterialTextBox txtDoctor;
        private MaterialSkin.Controls.MaterialTextBox txtFees;
        private MaterialSkin.Controls.MaterialTextBox txtDate;
        private MaterialSkin.Controls.MaterialTextBox txtTime;
        private MaterialSkin.Controls.MaterialButton btnCancel;
        private MaterialSkin.Controls.MaterialButton btnRefresh;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblConfirmed;
        private System.Windows.Forms.Label lblPending;
        private System.Windows.Forms.Label lblDetail;
        private System.Windows.Forms.Label lblDetailStatus;
        private System.Windows.Forms.Panel panelSummary;
    }
}