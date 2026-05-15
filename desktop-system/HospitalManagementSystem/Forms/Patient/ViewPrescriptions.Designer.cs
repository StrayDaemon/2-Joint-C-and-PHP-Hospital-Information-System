namespace HospitalManagementSystem.Forms.Patient
{
    partial class ViewPrescriptions
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dgvPrescriptions = new System.Windows.Forms.DataGridView();
            this.txtAppID = new MaterialSkin.Controls.MaterialTextBox();
            this.txtDoctor = new MaterialSkin.Controls.MaterialTextBox();
            this.txtDate = new MaterialSkin.Controls.MaterialTextBox();
            this.txtTime = new MaterialSkin.Controls.MaterialTextBox();
            this.txtDisease = new MaterialSkin.Controls.MaterialTextBox();
            this.txtAllergy = new MaterialSkin.Controls.MaterialTextBox();
            this.txtPrescription = new MaterialSkin.Controls.MaterialTextBox();
            this.btnPrint = new MaterialSkin.Controls.MaterialButton();
            this.btnRefresh = new MaterialSkin.Controls.MaterialButton();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblCount = new System.Windows.Forms.Label();
            this.lblDetail = new System.Windows.Forms.Label();
            this.lblRx = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrescriptions)).BeginInit();
            this.SuspendLayout();

            // ── Form ──────────────────────────────────────────
            this.ClientSize = new System.Drawing.Size(880, 596);
            this.BackColor = System.Drawing.Color.FromArgb(245, 245, 245);

            // ── Title ─────────────────────────────────────────
            this.lblTitle.Text = "My Prescriptions";
            this.lblTitle.Font = new System.Drawing.Font("Roboto", 16F,
                                        System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(13, 71, 161);
            this.lblTitle.Location = new System.Drawing.Point(20, 15);
            this.lblTitle.Size = new System.Drawing.Size(280, 35);

            // ── Count Label ───────────────────────────────────
            this.lblCount.Text = "Total Prescriptions: 0";
            this.lblCount.Font = new System.Drawing.Font("Roboto", 9F);
            this.lblCount.ForeColor = System.Drawing.Color.Gray;
            this.lblCount.Location = new System.Drawing.Point(20, 52);
            this.lblCount.Size = new System.Drawing.Size(220, 20);

            // ── Refresh Button ────────────────────────────────
            this.btnRefresh.Text = "REFRESH";
            this.btnRefresh.Location = new System.Drawing.Point(760, 20);
            this.btnRefresh.Size = new System.Drawing.Size(110, 36);
            this.btnRefresh.Type = MaterialSkin.Controls.MaterialButton
                                         .MaterialButtonType.Text;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);

            // ── DataGridView ──────────────────────────────────
            this.dgvPrescriptions.Location = new System.Drawing.Point(20, 78);
            this.dgvPrescriptions.Size = new System.Drawing.Size(840, 210);
            this.dgvPrescriptions.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPrescriptions.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPrescriptions.MultiSelect = false;
            this.dgvPrescriptions.ReadOnly = true;
            this.dgvPrescriptions.AllowUserToAddRows = false;
            this.dgvPrescriptions.BackgroundColor = System.Drawing.Color.White;
            this.dgvPrescriptions.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvPrescriptions.RowHeadersVisible = false;
            this.dgvPrescriptions.Font = new System.Drawing.Font("Roboto", 9F);
            this.dgvPrescriptions.SelectionChanged += new System.EventHandler(
                                                          this.dgvPrescriptions_SelectionChanged);

            // ── Columns ───────────────────────────────────────
            // prestb: ID | doctor | appdate | apptime | disease | allergy
            this.dgvPrescriptions.Columns.Add(
                new System.Windows.Forms.DataGridViewTextBoxColumn
                { Name = "colID", HeaderText = "App ID", FillWeight = 10 });
            this.dgvPrescriptions.Columns.Add(
                new System.Windows.Forms.DataGridViewTextBoxColumn
                { Name = "colDoctor", HeaderText = "Doctor", FillWeight = 20 });
            this.dgvPrescriptions.Columns.Add(
                new System.Windows.Forms.DataGridViewTextBoxColumn
                { Name = "colDate", HeaderText = "Date", FillWeight = 18 });
            this.dgvPrescriptions.Columns.Add(
                new System.Windows.Forms.DataGridViewTextBoxColumn
                { Name = "colTime", HeaderText = "Time", FillWeight = 15 });
            this.dgvPrescriptions.Columns.Add(
                new System.Windows.Forms.DataGridViewTextBoxColumn
                { Name = "colDisease", HeaderText = "Disease", FillWeight = 20 });
            this.dgvPrescriptions.Columns.Add(
                new System.Windows.Forms.DataGridViewTextBoxColumn
                { Name = "colAllergy", HeaderText = "Allergies", FillWeight = 17 });

            // ── Detail Section ────────────────────────────────
            this.lblDetail.Text = "── Prescription Detail ──────────────────────";
            this.lblDetail.Font = new System.Drawing.Font("Roboto", 9F,
                                         System.Drawing.FontStyle.Bold);
            this.lblDetail.ForeColor = System.Drawing.Color.FromArgb(13, 71, 161);
            this.lblDetail.Location = new System.Drawing.Point(20, 298);
            this.lblDetail.Size = new System.Drawing.Size(840, 20);

            // ── Detail Fields Row ─────────────────────────────
            int detY = 325;

            this.txtAppID.Hint = "App ID";
            this.txtAppID.Location = new System.Drawing.Point(20, detY);
            this.txtAppID.Size = new System.Drawing.Size(100, 48);
            this.txtAppID.Enabled = false;

            this.txtDoctor.Hint = "Doctor";
            this.txtDoctor.Location = new System.Drawing.Point(130, detY);
            this.txtDoctor.Size = new System.Drawing.Size(180, 48);
            this.txtDoctor.Enabled = false;

            this.txtDate.Hint = "Date";
            this.txtDate.Location = new System.Drawing.Point(320, detY);
            this.txtDate.Size = new System.Drawing.Size(160, 48);
            this.txtDate.Enabled = false;

            this.txtTime.Hint = "Time";
            this.txtTime.Location = new System.Drawing.Point(490, detY);
            this.txtTime.Size = new System.Drawing.Size(130, 48);
            this.txtTime.Enabled = false;

            this.txtDisease.Hint = "Disease";
            this.txtDisease.Location = new System.Drawing.Point(630, detY);
            this.txtDisease.Size = new System.Drawing.Size(230, 48);
            this.txtDisease.Enabled = false;

            // ── Allergy Field ─────────────────────────────────
            this.txtAllergy.Hint = "Allergies";
            this.txtAllergy.Location = new System.Drawing.Point(20, 382);
            this.txtAllergy.Size = new System.Drawing.Size(840, 48);
            this.txtAllergy.Enabled = false;

            // ── Prescription Text ─────────────────────────────
            this.lblRx.Text = "Prescription:";
            this.lblRx.Font = new System.Drawing.Font("Roboto", 9F,
                                     System.Drawing.FontStyle.Bold);
            this.lblRx.ForeColor = System.Drawing.Color.FromArgb(13, 71, 161);
            this.lblRx.Location = new System.Drawing.Point(20, 438);
            this.lblRx.Size = new System.Drawing.Size(140, 20);

            this.txtPrescription.Hint = "Prescription details will appear here...";
            this.txtPrescription.Location = new System.Drawing.Point(20, 460);
            this.txtPrescription.Size = new System.Drawing.Size(840, 70);
            this.txtPrescription.Multiline = true;
            this.txtPrescription.Enabled = false;

            // ── Print Button ──────────────────────────────────
            this.btnPrint.Text = "🖨 PRINT PRESCRIPTION";
            this.btnPrint.Location = new System.Drawing.Point(20, 545);
            this.btnPrint.Size = new System.Drawing.Size(220, 40);
            this.btnPrint.Type = MaterialSkin.Controls.MaterialButton
                                       .MaterialButtonType.Contained;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);

            // ── Add Controls ──────────────────────────────────
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblCount);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.dgvPrescriptions);
            this.Controls.Add(this.lblDetail);
            this.Controls.Add(this.txtAppID);
            this.Controls.Add(this.txtDoctor);
            this.Controls.Add(this.txtDate);
            this.Controls.Add(this.txtTime);
            this.Controls.Add(this.txtDisease);
            this.Controls.Add(this.txtAllergy);
            this.Controls.Add(this.lblRx);
            this.Controls.Add(this.txtPrescription);
            this.Controls.Add(this.btnPrint);

            ((System.ComponentModel.ISupportInitialize)(this.dgvPrescriptions)).EndInit();
            this.ResumeLayout(false);
        }

        // ── Control Declarations ──────────────────────────────
        private System.Windows.Forms.DataGridView dgvPrescriptions;
        private MaterialSkin.Controls.MaterialTextBox txtAppID;
        private MaterialSkin.Controls.MaterialTextBox txtDoctor;
        private MaterialSkin.Controls.MaterialTextBox txtDate;
        private MaterialSkin.Controls.MaterialTextBox txtTime;
        private MaterialSkin.Controls.MaterialTextBox txtDisease;
        private MaterialSkin.Controls.MaterialTextBox txtAllergy;
        private MaterialSkin.Controls.MaterialTextBox txtPrescription;
        private MaterialSkin.Controls.MaterialButton btnPrint;
        private MaterialSkin.Controls.MaterialButton btnRefresh;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.Label lblDetail;
        private System.Windows.Forms.Label lblRx;
    }
}