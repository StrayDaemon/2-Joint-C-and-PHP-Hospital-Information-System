namespace HospitalManagementSystem.Forms.Doctor
{
    partial class WritePrescription
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtAppID = new MaterialSkin.Controls.MaterialTextBox();
            this.txtPid = new MaterialSkin.Controls.MaterialTextBox();
            this.txtPatient = new MaterialSkin.Controls.MaterialTextBox();
            this.txtDoctor = new MaterialSkin.Controls.MaterialTextBox();
            this.txtDate = new MaterialSkin.Controls.MaterialTextBox();
            this.txtTime = new MaterialSkin.Controls.MaterialTextBox();
            this.txtFname = new MaterialSkin.Controls.MaterialTextBox();
            this.txtLname = new MaterialSkin.Controls.MaterialTextBox();
            this.txtDisease = new MaterialSkin.Controls.MaterialTextBox();
            this.txtAllergy = new MaterialSkin.Controls.MaterialTextBox();
            this.txtPrescription = new MaterialSkin.Controls.MaterialTextBox();
            this.btnSave = new MaterialSkin.Controls.MaterialButton();
            this.btnClear = new MaterialSkin.Controls.MaterialButton();
            this.btnClose = new MaterialSkin.Controls.MaterialButton();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblHeader = new System.Windows.Forms.Label();
            this.lblRxSection = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.SuspendLayout();

            // ── Form ──────────────────────────────────────────
            this.Text = "Write Prescription";
            this.ClientSize = new System.Drawing.Size(780, 600);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.BackColor = System.Drawing.Color.FromArgb(245, 245, 245);
            this.MaximizeBox = false;

            // ── Title ─────────────────────────────────────────
            this.lblTitle.Text = "📝 Write Prescription";
            this.lblTitle.Font = new System.Drawing.Font("Roboto", 16F,
                                        System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(0, 121, 107);
            this.lblTitle.Location = new System.Drawing.Point(20, 15);
            this.lblTitle.Size = new System.Drawing.Size(400, 35);

            // ── Status Label ──────────────────────────────────
            this.lblStatus.Text = "";
            this.lblStatus.Font = new System.Drawing.Font("Roboto", 9F,
                                         System.Drawing.FontStyle.Italic);
            this.lblStatus.Location = new System.Drawing.Point(20, 52);
            this.lblStatus.Size = new System.Drawing.Size(740, 20);

            // ── Appointment Info Header ───────────────────────
            this.lblHeader.Text = "── Appointment Info ─────────────────────────";
            this.lblHeader.Font = new System.Drawing.Font("Roboto", 9F,
                                         System.Drawing.FontStyle.Bold);
            this.lblHeader.ForeColor = System.Drawing.Color.FromArgb(0, 121, 107);
            this.lblHeader.Location = new System.Drawing.Point(20, 78);
            this.lblHeader.Size = new System.Drawing.Size(740, 20);

            // ── Appointment Info Fields (read-only) ───────────
            int infoRow1 = 105;
            int infoRow2 = 158;

            this.txtAppID.Hint = "App ID";
            this.txtAppID.Location = new System.Drawing.Point(20, infoRow1);
            this.txtAppID.Size = new System.Drawing.Size(100, 48);
            this.txtAppID.Enabled = false;

            this.txtPid.Hint = "Patient ID";
            this.txtPid.Location = new System.Drawing.Point(130, infoRow1);
            this.txtPid.Size = new System.Drawing.Size(110, 48);
            this.txtPid.Enabled = false;

            this.txtPatient.Hint = "Full Name";
            this.txtPatient.Location = new System.Drawing.Point(250, infoRow1);
            this.txtPatient.Size = new System.Drawing.Size(220, 48);
            this.txtPatient.Enabled = false;

            this.txtDoctor.Hint = "Doctor";
            this.txtDoctor.Location = new System.Drawing.Point(480, infoRow1);
            this.txtDoctor.Size = new System.Drawing.Size(280, 48);
            this.txtDoctor.Enabled = false;

            this.txtFname.Hint = "First Name";
            this.txtFname.Location = new System.Drawing.Point(20, infoRow2);
            this.txtFname.Size = new System.Drawing.Size(180, 48);
            this.txtFname.Enabled = false;

            this.txtLname.Hint = "Last Name";
            this.txtLname.Location = new System.Drawing.Point(210, infoRow2);
            this.txtLname.Size = new System.Drawing.Size(180, 48);
            this.txtLname.Enabled = false;

            this.txtDate.Hint = "Date";
            this.txtDate.Location = new System.Drawing.Point(400, infoRow2);
            this.txtDate.Size = new System.Drawing.Size(160, 48);
            this.txtDate.Enabled = false;

            this.txtTime.Hint = "Time";
            this.txtTime.Location = new System.Drawing.Point(570, infoRow2);
            this.txtTime.Size = new System.Drawing.Size(190, 48);
            this.txtTime.Enabled = false;

            // ── Prescription Section ──────────────────────────
            this.lblRxSection.Text = "── Prescription Details ─────────────────────";
            this.lblRxSection.Font = new System.Drawing.Font("Roboto", 9F,
                                            System.Drawing.FontStyle.Bold);
            this.lblRxSection.ForeColor = System.Drawing.Color.FromArgb(0, 121, 107);
            this.lblRxSection.Location = new System.Drawing.Point(20, 218);
            this.lblRxSection.Size = new System.Drawing.Size(740, 20);

            // ── Disease ───────────────────────────────────────
            this.txtDisease.Hint = "Disease / Condition";
            this.txtDisease.Location = new System.Drawing.Point(20, 245);
            this.txtDisease.Size = new System.Drawing.Size(360, 48);

            // ── Allergy ───────────────────────────────────────
            this.txtAllergy.Hint = "Known Allergies (or 'None')";
            this.txtAllergy.Location = new System.Drawing.Point(390, 245);
            this.txtAllergy.Size = new System.Drawing.Size(370, 48);

            // ── Prescription (multiline) ──────────────────────
            this.txtPrescription.Hint = "Prescription details, medications, dosage...";
            this.txtPrescription.Location = new System.Drawing.Point(20, 305);
            this.txtPrescription.Size = new System.Drawing.Size(740, 180);
            this.txtPrescription.Multiline = true;

            // ── Action Buttons ────────────────────────────────
            int btnY = 505;

            this.btnSave.Text = "SAVE PRESCRIPTION";
            this.btnSave.Location = new System.Drawing.Point(20, btnY);
            this.btnSave.Size = new System.Drawing.Size(200, 45);
            this.btnSave.Type = MaterialSkin.Controls.MaterialButton
                                      .MaterialButtonType.Contained;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            this.btnClear.Text = "CLEAR";
            this.btnClear.Location = new System.Drawing.Point(230, btnY);
            this.btnClear.Size = new System.Drawing.Size(120, 45);
            this.btnClear.Type = MaterialSkin.Controls.MaterialButton
                                       .MaterialButtonType.Outlined;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);

            this.btnClose.Text = "CLOSE";
            this.btnClose.Location = new System.Drawing.Point(360, btnY);
            this.btnClose.Size = new System.Drawing.Size(120, 45);
            this.btnClose.Type = MaterialSkin.Controls.MaterialButton
                                       .MaterialButtonType.Text;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);

            // ── Add Controls ──────────────────────────────────
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.lblHeader);
            this.Controls.Add(this.txtAppID);
            this.Controls.Add(this.txtPid);
            this.Controls.Add(this.txtPatient);
            this.Controls.Add(this.txtDoctor);
            this.Controls.Add(this.txtFname);
            this.Controls.Add(this.txtLname);
            this.Controls.Add(this.txtDate);
            this.Controls.Add(this.txtTime);
            this.Controls.Add(this.lblRxSection);
            this.Controls.Add(this.txtDisease);
            this.Controls.Add(this.txtAllergy);
            this.Controls.Add(this.txtPrescription);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnClose);

            this.ResumeLayout(false);
        }

        // ── Control Declarations ──────────────────────────────
        private MaterialSkin.Controls.MaterialTextBox txtAppID;
        private MaterialSkin.Controls.MaterialTextBox txtPid;
        private MaterialSkin.Controls.MaterialTextBox txtPatient;
        private MaterialSkin.Controls.MaterialTextBox txtDoctor;
        private MaterialSkin.Controls.MaterialTextBox txtDate;
        private MaterialSkin.Controls.MaterialTextBox txtTime;
        private MaterialSkin.Controls.MaterialTextBox txtFname;
        private MaterialSkin.Controls.MaterialTextBox txtLname;
        private MaterialSkin.Controls.MaterialTextBox txtDisease;
        private MaterialSkin.Controls.MaterialTextBox txtAllergy;
        private MaterialSkin.Controls.MaterialTextBox txtPrescription;
        private MaterialSkin.Controls.MaterialButton btnSave;
        private MaterialSkin.Controls.MaterialButton btnClear;
        private MaterialSkin.Controls.MaterialButton btnClose;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Label lblRxSection;
        private System.Windows.Forms.Label lblStatus;
    }
}