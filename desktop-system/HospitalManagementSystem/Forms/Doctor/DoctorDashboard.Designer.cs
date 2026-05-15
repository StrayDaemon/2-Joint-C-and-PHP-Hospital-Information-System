namespace HospitalManagementSystem.Forms.Doctor
{
    partial class DoctorDashboard
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.panelSidebar = new System.Windows.Forms.Panel();
            this.lblAppTitle = new System.Windows.Forms.Label();
            this.lblRole = new System.Windows.Forms.Label();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.btnAppointments = new MaterialSkin.Controls.MaterialButton();
            this.btnPrescription = new MaterialSkin.Controls.MaterialButton();
            this.btnLogout = new MaterialSkin.Controls.MaterialButton();
            this.panelMain = new System.Windows.Forms.Panel();
            this.lblHome = new System.Windows.Forms.Label();
            this.lblHomeSub = new System.Windows.Forms.Label();
            this.SuspendLayout();

            // ── Form ──────────────────────────────────────────
            this.Text = "HMS — Doctor Portal";
            this.ClientSize = new System.Drawing.Size(1100, 660);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Sizable = false;
            this.MaximizeBox = false;

            // ── Sidebar Panel ─────────────────────────────────
            this.panelSidebar.Location = new System.Drawing.Point(0, 64);
            this.panelSidebar.Size = new System.Drawing.Size(220, 596);
            this.panelSidebar.BackColor = System.Drawing.Color.FromArgb(0, 121, 107);

            // ── App Title ─────────────────────────────────────
            this.lblAppTitle.Text = "🏥 HMS";
            this.lblAppTitle.Font = new System.Drawing.Font("Roboto", 16F,
                                           System.Drawing.FontStyle.Bold);
            this.lblAppTitle.ForeColor = System.Drawing.Color.White;
            this.lblAppTitle.Size = new System.Drawing.Size(220, 45);
            this.lblAppTitle.Location = new System.Drawing.Point(0, 10);
            this.lblAppTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // ── Role Label ────────────────────────────────────
            this.lblRole.Text = "DOCTOR PORTAL";
            this.lblRole.Font = new System.Drawing.Font("Roboto", 8F,
                                       System.Drawing.FontStyle.Bold);
            this.lblRole.ForeColor = System.Drawing.Color.FromArgb(178, 223, 219);
            this.lblRole.Size = new System.Drawing.Size(220, 20);
            this.lblRole.Location = new System.Drawing.Point(0, 55);
            this.lblRole.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // ── Welcome Label ─────────────────────────────────
            this.lblWelcome.Text = "Dr. DOCTOR";
            this.lblWelcome.Font = new System.Drawing.Font("Roboto", 10F,
                                          System.Drawing.FontStyle.Bold);
            this.lblWelcome.ForeColor = System.Drawing.Color.White;
            this.lblWelcome.Size = new System.Drawing.Size(220, 30);
            this.lblWelcome.Location = new System.Drawing.Point(0, 80);
            this.lblWelcome.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // ── Divider ───────────────────────────────────────
            var divider = new System.Windows.Forms.Panel();
            divider.BackColor = System.Drawing.Color.FromArgb(77, 182, 172);
            divider.Location = new System.Drawing.Point(15, 118);
            divider.Size = new System.Drawing.Size(190, 1);

            // ── Sidebar Buttons ───────────────────────────────
            int btnX = 10;
            int btnW = 200;
            int btnH = 45;

            this.btnAppointments.Text = "📅  My Appointments";
            this.btnAppointments.Size = new System.Drawing.Size(btnW, btnH);
            this.btnAppointments.Location = new System.Drawing.Point(btnX, 135);
            this.btnAppointments.Type = MaterialSkin.Controls.MaterialButton
                                              .MaterialButtonType.Text;
            this.btnAppointments.UseAccentColor = true;
            this.btnAppointments.Click += new System.EventHandler(
                                              this.btnAppointments_Click);

            this.btnPrescription.Text = "📝  Write Prescription";
            this.btnPrescription.Size = new System.Drawing.Size(btnW, btnH);
            this.btnPrescription.Location = new System.Drawing.Point(btnX, 190);
            this.btnPrescription.Type = MaterialSkin.Controls.MaterialButton
                                              .MaterialButtonType.Text;
            this.btnPrescription.UseAccentColor = true;
            this.btnPrescription.Click += new System.EventHandler(
                                              this.btnPrescription_Click);

            this.btnLogout.Text = "🚪  Logout";
            this.btnLogout.Size = new System.Drawing.Size(btnW, btnH);
            this.btnLogout.Location = new System.Drawing.Point(btnX, 500);
            this.btnLogout.Type = MaterialSkin.Controls.MaterialButton
                                        .MaterialButtonType.Text;
            this.btnLogout.UseAccentColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);

            // ── Add to Sidebar ────────────────────────────────
            this.panelSidebar.Controls.Add(this.lblAppTitle);
            this.panelSidebar.Controls.Add(this.lblRole);
            this.panelSidebar.Controls.Add(this.lblWelcome);
            this.panelSidebar.Controls.Add(divider);
            this.panelSidebar.Controls.Add(this.btnAppointments);
            this.panelSidebar.Controls.Add(this.btnPrescription);
            this.panelSidebar.Controls.Add(this.btnLogout);

            // ── Main Content Panel ────────────────────────────
            this.panelMain.Location = new System.Drawing.Point(220, 64);
            this.panelMain.Size = new System.Drawing.Size(880, 596);
            this.panelMain.BackColor = System.Drawing.Color.FromArgb(245, 245, 245);

            // ── Home Screen Labels ────────────────────────────
            this.lblHome.Text = "Welcome to Doctor Portal";
            this.lblHome.Font = new System.Drawing.Font("Roboto", 20F,
                                       System.Drawing.FontStyle.Bold);
            this.lblHome.ForeColor = System.Drawing.Color.FromArgb(0, 121, 107);
            this.lblHome.Size = new System.Drawing.Size(600, 50);
            this.lblHome.Location = new System.Drawing.Point(140, 220);
            this.lblHome.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this.lblHomeSub.Text = "Use the sidebar to manage your appointments\n" +
                                        "and write prescriptions for your patients.";
            this.lblHomeSub.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblHomeSub.ForeColor = System.Drawing.Color.Gray;
            this.lblHomeSub.Size = new System.Drawing.Size(600, 60);
            this.lblHomeSub.Location = new System.Drawing.Point(140, 280);
            this.lblHomeSub.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this.panelMain.Controls.Add(this.lblHome);
            this.panelMain.Controls.Add(this.lblHomeSub);

            // ── Add to Form ───────────────────────────────────
            this.Controls.Add(this.panelSidebar);
            this.Controls.Add(this.panelMain);

            this.ResumeLayout(false);
        }

        // ── Control Declarations ──────────────────────────────
        private System.Windows.Forms.Panel panelSidebar;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Label lblAppTitle;
        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Label lblHome;
        private System.Windows.Forms.Label lblHomeSub;
        private MaterialSkin.Controls.MaterialButton btnAppointments;
        private MaterialSkin.Controls.MaterialButton btnPrescription;
        private MaterialSkin.Controls.MaterialButton btnLogout;
    }
}