namespace HospitalManagementSystem.Forms.Patient
{
    partial class BookAppointment
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtPid = new MaterialSkin.Controls.MaterialTextBox();
            this.txtFname = new MaterialSkin.Controls.MaterialTextBox();
            this.txtLname = new MaterialSkin.Controls.MaterialTextBox();
            this.txtGender = new MaterialSkin.Controls.MaterialTextBox();
            this.txtEmail = new MaterialSkin.Controls.MaterialTextBox();
            this.txtContact = new MaterialSkin.Controls.MaterialTextBox();
            this.cmbDoctor = new MaterialSkin.Controls.MaterialComboBox();
            this.txtSpec = new MaterialSkin.Controls.MaterialTextBox();
            this.txtFees = new MaterialSkin.Controls.MaterialTextBox();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.dtpTime = new System.Windows.Forms.DateTimePicker();
            this.btnBook = new MaterialSkin.Controls.MaterialButton();
            this.btnReset = new MaterialSkin.Controls.MaterialButton();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblPatient = new System.Windows.Forms.Label();
            this.lblBooking = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.lblFeesNote = new System.Windows.Forms.Label();
            this.SuspendLayout();

            // ── Form ──────────────────────────────────────────
            this.ClientSize = new System.Drawing.Size(880, 596);
            this.BackColor = System.Drawing.Color.FromArgb(245, 245, 245);

            // ── Title ─────────────────────────────────────────
            this.lblTitle.Text = "Book Appointment";
            this.lblTitle.Font = new System.Drawing.Font("Roboto", 16F,
                                        System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(13, 71, 161);
            this.lblTitle.Location = new System.Drawing.Point(20, 15);
            this.lblTitle.Size = new System.Drawing.Size(300, 35);

            // ── Patient Info Section ──────────────────────────
            this.lblPatient.Text = "── Your Information ─────────────────────────";
            this.lblPatient.Font = new System.Drawing.Font("Roboto", 9F,
                                          System.Drawing.FontStyle.Bold);
            this.lblPatient.ForeColor = System.Drawing.Color.FromArgb(13, 71, 161);
            this.lblPatient.Location = new System.Drawing.Point(20, 58);
            this.lblPatient.Size = new System.Drawing.Size(840, 20);

            // ── Patient Info Fields (read-only) ───────────────
            int pRow1 = 85;
            int pRow2 = 140;

            this.txtPid.Hint = "Patient ID";
            this.txtPid.Location = new System.Drawing.Point(20, pRow1);
            this.txtPid.Size = new System.Drawing.Size(120, 48);
            this.txtPid.Enabled = false;

            this.txtFname.Hint = "First Name";
            this.txtFname.Location = new System.Drawing.Point(150, pRow1);
            this.txtFname.Size = new System.Drawing.Size(200, 48);
            this.txtFname.Enabled = false;

            this.txtLname.Hint = "Last Name";
            this.txtLname.Location = new System.Drawing.Point(360, pRow1);
            this.txtLname.Size = new System.Drawing.Size(200, 48);
            this.txtLname.Enabled = false;

            this.txtGender.Hint = "Gender";
            this.txtGender.Location = new System.Drawing.Point(570, pRow1);
            this.txtGender.Size = new System.Drawing.Size(130, 48);
            this.txtGender.Enabled = false;

            this.txtEmail.Hint = "Email";
            this.txtEmail.Location = new System.Drawing.Point(20, pRow2);
            this.txtEmail.Size = new System.Drawing.Size(300, 48);
            this.txtEmail.Enabled = false;

            this.txtContact.Hint = "Contact";
            this.txtContact.Location = new System.Drawing.Point(330, pRow2);
            this.txtContact.Size = new System.Drawing.Size(200, 48);
            this.txtContact.Enabled = false;

            // ── Booking Section ───────────────────────────────
            this.lblBooking.Text = "── Appointment Details ──────────────────────";
            this.lblBooking.Font = new System.Drawing.Font("Roboto", 9F,
                                          System.Drawing.FontStyle.Bold);
            this.lblBooking.ForeColor = System.Drawing.Color.FromArgb(13, 71, 161);
            this.lblBooking.Location = new System.Drawing.Point(20, 205);
            this.lblBooking.Size = new System.Drawing.Size(840, 20);

            // ── Doctor ComboBox ───────────────────────────────
            this.cmbDoctor.Hint = "Select Doctor";
            this.cmbDoctor.Location = new System.Drawing.Point(20, 235);
            this.cmbDoctor.Size = new System.Drawing.Size(420, 48);
            this.cmbDoctor.SelectedIndexChanged += new System.EventHandler(
                                                     this.cmbDoctor_SelectedIndexChanged);

            // ── Spec & Fees (auto-filled) ─────────────────────
            this.txtSpec.Hint = "Specialization";
            this.txtSpec.Location = new System.Drawing.Point(450, 235);
            this.txtSpec.Size = new System.Drawing.Size(220, 48);
            this.txtSpec.Enabled = false;

            this.txtFees.Hint = "Consultation Fees";
            this.txtFees.Location = new System.Drawing.Point(680, 235);
            this.txtFees.Size = new System.Drawing.Size(180, 48);
            this.txtFees.Enabled = false;

            // ── Fees Note ─────────────────────────────────────
            this.lblFeesNote.Text = "💡 Fees are auto-filled when you select a doctor.";
            this.lblFeesNote.Font = new System.Drawing.Font("Roboto", 8F,
                                           System.Drawing.FontStyle.Italic);
            this.lblFeesNote.ForeColor = System.Drawing.Color.Gray;
            this.lblFeesNote.Location = new System.Drawing.Point(20, 290);
            this.lblFeesNote.Size = new System.Drawing.Size(500, 20);

            // ── Date Picker ───────────────────────────────────
            this.lblDate.Text = "Appointment Date:";
            this.lblDate.Font = new System.Drawing.Font("Roboto", 9F);
            this.lblDate.ForeColor = System.Drawing.Color.FromArgb(80, 80, 80);
            this.lblDate.Location = new System.Drawing.Point(20, 325);
            this.lblDate.Size = new System.Drawing.Size(160, 25);

            this.dtpDate.Location = new System.Drawing.Point(20, 353);
            this.dtpDate.Size = new System.Drawing.Size(280, 36);
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDate.MinDate = System.DateTime.Today;
            this.dtpDate.Font = new System.Drawing.Font("Roboto", 11F);

            // ── Time Picker ───────────────────────────────────
            this.lblTime.Text = "Appointment Time:";
            this.lblTime.Font = new System.Drawing.Font("Roboto", 9F);
            this.lblTime.ForeColor = System.Drawing.Color.FromArgb(80, 80, 80);
            this.lblTime.Location = new System.Drawing.Point(320, 325);
            this.lblTime.Size = new System.Drawing.Size(160, 25);

            this.dtpTime.Location = new System.Drawing.Point(320, 353);
            this.dtpTime.Size = new System.Drawing.Size(280, 36);
            this.dtpTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpTime.ShowUpDown = true;
            this.dtpTime.Font = new System.Drawing.Font("Roboto", 11F);

            // ── Action Buttons ────────────────────────────────
            int btnY = 430;

            this.btnBook.Text = "BOOK APPOINTMENT";
            this.btnBook.Location = new System.Drawing.Point(20, btnY);
            this.btnBook.Size = new System.Drawing.Size(220, 48);
            this.btnBook.Type = MaterialSkin.Controls.MaterialButton
                                      .MaterialButtonType.Contained;
            this.btnBook.Click += new System.EventHandler(this.btnBook_Click);

            this.btnReset.Text = "RESET";
            this.btnReset.Location = new System.Drawing.Point(250, btnY);
            this.btnReset.Size = new System.Drawing.Size(120, 48);
            this.btnReset.Type = MaterialSkin.Controls.MaterialButton
                                       .MaterialButtonType.Outlined;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);

            // ── Add Controls ──────────────────────────────────
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblPatient);
            this.Controls.Add(this.txtPid);
            this.Controls.Add(this.txtFname);
            this.Controls.Add(this.txtLname);
            this.Controls.Add(this.txtGender);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtContact);
            this.Controls.Add(this.lblBooking);
            this.Controls.Add(this.cmbDoctor);
            this.Controls.Add(this.txtSpec);
            this.Controls.Add(this.txtFees);
            this.Controls.Add(this.lblFeesNote);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.dtpTime);
            this.Controls.Add(this.btnBook);
            this.Controls.Add(this.btnReset);

            this.ResumeLayout(false);
        }

        // ── Control Declarations ──────────────────────────────
        private MaterialSkin.Controls.MaterialTextBox txtPid;
        private MaterialSkin.Controls.MaterialTextBox txtFname;
        private MaterialSkin.Controls.MaterialTextBox txtLname;
        private MaterialSkin.Controls.MaterialTextBox txtGender;
        private MaterialSkin.Controls.MaterialTextBox txtEmail;
        private MaterialSkin.Controls.MaterialTextBox txtContact;
        private MaterialSkin.Controls.MaterialComboBox cmbDoctor;
        private MaterialSkin.Controls.MaterialTextBox txtSpec;
        private MaterialSkin.Controls.MaterialTextBox txtFees;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.DateTimePicker dtpTime;
        private MaterialSkin.Controls.MaterialButton btnBook;
        private MaterialSkin.Controls.MaterialButton btnReset;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblPatient;
        private System.Windows.Forms.Label lblBooking;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Label lblFeesNote;
    }
}