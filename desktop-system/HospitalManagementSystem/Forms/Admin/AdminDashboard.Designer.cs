namespace HospitalManagementSystem.Forms.Admin
{
    partial class AdminDashboard
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
            this.lblWelcome = new System.Windows.Forms.Label();
            this.lblAppTitle = new System.Windows.Forms.Label();
            this.btnPatients = new MaterialSkin.Controls.MaterialButton();
            this.btnDoctors = new MaterialSkin.Controls.MaterialButton();
            this.btnAppointments = new MaterialSkin.Controls.MaterialButton();
            this.btnContacts = new MaterialSkin.Controls.MaterialButton();
            this.btnLogout = new MaterialSkin.Controls.MaterialButton();
            this.panelMain = new System.Windows.Forms.Panel();
            this.SuspendLayout();

            // ── Form ─────────────────────────────────────────
            this.Text = "HMS — Admin Dashboard";
            this.ClientSize = new System.Drawing.Size(1100, 660);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Sizable = false;
            this.MaximizeBox = false;

            // ── Sidebar Panel ─────────────────────────────────
            this.panelSidebar.Location = new System.Drawing.Point(0, 64);
            this.panelSidebar.Size = new System.Drawing.Size(220, 596);
            this.panelSidebar.BackColor = System.Drawing.Color.FromArgb(25, 118, 210);

            // ── App Title ─────────────────────────────────────
            this.lblAppTitle.Text = "🏥 HMS";
            this.lblAppTitle.Font = new System.Drawing.Font("Roboto", 16F,
                                           System.Drawing.FontStyle.Bold);
            this.lblAppTitle.ForeColor = System.Drawing.Color.White;
            this.lblAppTitle.Size = new System.Drawing.Size(220, 50);
            this.lblAppTitle.Location = new System.Drawing.Point(0, 10);
            this.lblAppTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // ── Welcome Label ─────────────────────────────────
            this.lblWelcome.Text = "Welcome, ADMIN!";
            this.lblWelcome.Font = new System.Drawing.Font("Roboto", 10F);
            this.lblWelcome.ForeColor = System.Drawing.Color.White;
            this.lblWelcome.Size = new System.Drawing.Size(220, 30);
            this.lblWelcome.Location = new System.Drawing.Point(0, 60);
            this.lblWelcome.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // ── Sidebar Buttons ───────────────────────────────
            int btnX = 10;
            int btnW = 200;
            int btnH = 45;

            this.btnPatients.Text = "👤  Manage Patients";
            this.btnPatients.Size = new System.Drawing.Size(btnW, btnH);
            this.btnPatients.Location = new System.Drawing.Point(btnX, 110);
            this.btnPatients.Type = MaterialSkin.Controls.MaterialButton
                                          .MaterialButtonType.Text;
            this.btnPatients.UseAccentColor = true;
            this.btnPatients.Click += new System.EventHandler(this.btnPatients_Click);

            this.btnDoctors.Text = "🩺  Manage Doctors";
            this.btnDoctors.Size = new System.Drawing.Size(btnW, btnH);
            this.btnDoctors.Location = new System.Drawing.Point(btnX, 165);
            this.btnDoctors.Type = MaterialSkin.Controls.MaterialButton
                                         .MaterialButtonType.Text;
            this.btnDoctors.UseAccentColor = true;
            this.btnDoctors.Click += new System.EventHandler(this.btnDoctors_Click);

            this.btnAppointments.Text = "📅  Appointments";
            this.btnAppointments.Size = new System.Drawing.Size(btnW, btnH);
            this.btnAppointments.Location = new System.Drawing.Point(btnX, 220);
            this.btnAppointments.Type = MaterialSkin.Controls.MaterialButton
                                              .MaterialButtonType.Text;
            this.btnAppointments.UseAccentColor = true;
            this.btnAppointments.Click += new System.EventHandler(this.btnAppointments_Click);

            this.btnContacts.Text = "📨  View Contacts";
            this.btnContacts.Size = new System.Drawing.Size(btnW, btnH);
            this.btnContacts.Location = new System.Drawing.Point(btnX, 275);
            this.btnContacts.Type = MaterialSkin.Controls.MaterialButton
                                          .MaterialButtonType.Text;
            this.btnContacts.UseAccentColor = true;
            this.btnContacts.Click += new System.EventHandler(this.btnContacts_Click);

            this.btnLogout.Text = "🚪  Logout";
            this.btnLogout.Size = new System.Drawing.Size(btnW, btnH);
            this.btnLogout.Location = new System.Drawing.Point(btnX, 500);
            this.btnLogout.Type = MaterialSkin.Controls.MaterialButton
                                        .MaterialButtonType.Text;
            this.btnLogout.UseAccentColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);

            // ── Add to Sidebar ────────────────────────────────
            this.panelSidebar.Controls.Add(this.lblAppTitle);
            this.panelSidebar.Controls.Add(this.lblWelcome);
            this.panelSidebar.Controls.Add(this.btnPatients);
            this.panelSidebar.Controls.Add(this.btnDoctors);
            this.panelSidebar.Controls.Add(this.btnAppointments);
            this.panelSidebar.Controls.Add(this.btnContacts);
            this.panelSidebar.Controls.Add(this.btnLogout);

            // ── Main Content Panel ────────────────────────────
            this.panelMain.Location = new System.Drawing.Point(220, 64);
            this.panelMain.Size = new System.Drawing.Size(880, 596);
            this.panelMain.BackColor = System.Drawing.Color.FromArgb(245, 245, 245);

            // ── Add to Form ───────────────────────────────────
            this.Controls.Add(this.panelSidebar);
            this.Controls.Add(this.panelMain);

            this.ResumeLayout(false);
        }

        // ── Control Declarations ──────────────────────────────
        private System.Windows.Forms.Panel panelSidebar;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Label lblAppTitle;
        private System.Windows.Forms.Label lblWelcome;
        private MaterialSkin.Controls.MaterialButton btnPatients;
        private MaterialSkin.Controls.MaterialButton btnDoctors;
        private MaterialSkin.Controls.MaterialButton btnAppointments;
        private MaterialSkin.Controls.MaterialButton btnContacts;
        private MaterialSkin.Controls.MaterialButton btnLogout;
    }
}