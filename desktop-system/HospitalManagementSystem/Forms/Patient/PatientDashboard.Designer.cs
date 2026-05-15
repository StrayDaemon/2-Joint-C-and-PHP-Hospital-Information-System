namespace HospitalManagementSystem.Forms.Patient
{
    partial class PatientDashboard
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
            this.lblPid = new System.Windows.Forms.Label();
            this.btnBookAppointment = new MaterialSkin.Controls.MaterialButton();
            this.btnViewAppointments = new MaterialSkin.Controls.MaterialButton();
            this.btnViewPrescriptions = new MaterialSkin.Controls.MaterialButton();
            this.btnLogout = new MaterialSkin.Controls.MaterialButton();
            this.panelMain = new System.Windows.Forms.Panel();
            this.lblHome = new System.Windows.Forms.Label();
            this.lblHomeSub = new System.Windows.Forms.Label();
            this.panelInfoCards = new System.Windows.Forms.Panel();
            this.lblCard1Title = new System.Windows.Forms.Label();
            this.lblCard1Sub = new System.Windows.Forms.Label();
            this.lblCard2Title = new System.Windows.Forms.Label();
            this.lblCard2Sub = new System.Windows.Forms.Label();
            this.lblCard3Title = new System.Windows.Forms.Label();
            this.lblCard3Sub = new System.Windows.Forms.Label();
            this.SuspendLayout();

            // ── Form ──────────────────────────────────────────
            this.Text = "HMS — Patient Portal";
            this.ClientSize = new System.Drawing.Size(1100, 660);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Sizable = false;
            this.MaximizeBox = false;

            // ── Sidebar Panel ─────────────────────────────────
            this.panelSidebar.Location = new System.Drawing.Point(0, 64);
            this.panelSidebar.Size = new System.Drawing.Size(220, 596);
            this.panelSidebar.BackColor = System.Drawing.Color.FromArgb(13, 71, 161);

            // ── App Title ─────────────────────────────────────
            this.lblAppTitle.Text = "🏥 HMS";
            this.lblAppTitle.Font = new System.Drawing.Font("Roboto", 16F,
                                           System.Drawing.FontStyle.Bold);
            this.lblAppTitle.ForeColor = System.Drawing.Color.White;
            this.lblAppTitle.Size = new System.Drawing.Size(220, 45);
            this.lblAppTitle.Location = new System.Drawing.Point(0, 10);
            this.lblAppTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // ── Role Label ────────────────────────────────────
            this.lblRole.Text = "PATIENT PORTAL";
            this.lblRole.Font = new System.Drawing.Font("Roboto", 8F,
                                       System.Drawing.FontStyle.Bold);
            this.lblRole.ForeColor = System.Drawing.Color.FromArgb(144, 202, 249);
            this.lblRole.Size = new System.Drawing.Size(220, 20);
            this.lblRole.Location = new System.Drawing.Point(0, 55);
            this.lblRole.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // ── Welcome Label ─────────────────────────────────
            this.lblWelcome.Text = "Welcome, PATIENT";
            this.lblWelcome.Font = new System.Drawing.Font("Roboto", 10F,
                                          System.Drawing.FontStyle.Bold);
            this.lblWelcome.ForeColor = System.Drawing.Color.White;
            this.lblWelcome.Size = new System.Drawing.Size(220, 28);
            this.lblWelcome.Location = new System.Drawing.Point(0, 80);
            this.lblWelcome.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // ── Patient ID Label ──────────────────────────────
            this.lblPid.Text = "Patient ID: 0";
            this.lblPid.Font = new System.Drawing.Font("Roboto", 8F);
            this.lblPid.ForeColor = System.Drawing.Color.FromArgb(144, 202, 249);
            this.lblPid.Size = new System.Drawing.Size(220, 20);
            this.lblPid.Location = new System.Drawing.Point(0, 108);
            this.lblPid.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // ── Divider ───────────────────────────────────────
            var divider = new System.Windows.Forms.Panel();
            divider.BackColor = System.Drawing.Color.FromArgb(66, 165, 245);
            divider.Location = new System.Drawing.Point(15, 135);
            divider.Size = new System.Drawing.Size(190, 1);

            // ── Sidebar Buttons ───────────────────────────────
            int btnX = 10;
            int btnW = 200;
            int btnH = 45;

            this.btnBookAppointment.Text = "📅  Book Appointment";
            this.btnBookAppointment.Size = new System.Drawing.Size(btnW, btnH);
            this.btnBookAppointment.Location = new System.Drawing.Point(btnX, 150);
            this.btnBookAppointment.Type = MaterialSkin.Controls.MaterialButton
                                                .MaterialButtonType.Text;
            this.btnBookAppointment.UseAccentColor = true;
            this.btnBookAppointment.Click += new System.EventHandler(
                                                this.btnBookAppointment_Click);

            this.btnViewAppointments.Text = "📋  My Appointments";
            this.btnViewAppointments.Size = new System.Drawing.Size(btnW, btnH);
            this.btnViewAppointments.Location = new System.Drawing.Point(btnX, 205);
            this.btnViewAppointments.Type = MaterialSkin.Controls.MaterialButton
                                                 .MaterialButtonType.Text;
            this.btnViewAppointments.UseAccentColor = true;
            this.btnViewAppointments.Click += new System.EventHandler(
                                                 this.btnViewAppointments_Click);

            this.btnViewPrescriptions.Text = "💊  My Prescriptions";
            this.btnViewPrescriptions.Size = new System.Drawing.Size(btnW, btnH);
            this.btnViewPrescriptions.Location = new System.Drawing.Point(btnX, 260);
            this.btnViewPrescriptions.Type = MaterialSkin.Controls.MaterialButton
                                                  .MaterialButtonType.Text;
            this.btnViewPrescriptions.UseAccentColor = true;
            this.btnViewPrescriptions.Click += new System.EventHandler(
                                                  this.btnViewPrescriptions_Click);

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
            this.panelSidebar.Controls.Add(this.lblPid);
            this.panelSidebar.Controls.Add(divider);
            this.panelSidebar.Controls.Add(this.btnBookAppointment);
            this.panelSidebar.Controls.Add(this.btnViewAppointments);
            this.panelSidebar.Controls.Add(this.btnViewPrescriptions);
            this.panelSidebar.Controls.Add(this.btnLogout);

            // ── Main Content Panel ────────────────────────────
            this.panelMain.Location = new System.Drawing.Point(220, 64);
            this.panelMain.Size = new System.Drawing.Size(880, 596);
            this.panelMain.BackColor = System.Drawing.Color.FromArgb(245, 245, 245);

            // ── Home Welcome Text ─────────────────────────────
            this.lblHome.Text = "Welcome to Patient Portal";
            this.lblHome.Font = new System.Drawing.Font("Roboto", 20F,
                                       System.Drawing.FontStyle.Bold);
            this.lblHome.ForeColor = System.Drawing.Color.FromArgb(13, 71, 161);
            this.lblHome.Size = new System.Drawing.Size(840, 50);
            this.lblHome.Location = new System.Drawing.Point(20, 40);
            this.lblHome.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this.lblHomeSub.Text = "Book appointments, track their status,\n" +
                                        "and view prescriptions from your doctors.";
            this.lblHomeSub.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblHomeSub.ForeColor = System.Drawing.Color.Gray;
            this.lblHomeSub.Size = new System.Drawing.Size(840, 55);
            this.lblHomeSub.Location = new System.Drawing.Point(20, 95);
            this.lblHomeSub.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // ── Info Cards Panel ──────────────────────────────
            this.panelInfoCards.Location = new System.Drawing.Point(20, 180);
            this.panelInfoCards.Size = new System.Drawing.Size(840, 160);
            this.panelInfoCards.BackColor = System.Drawing.Color.Transparent;

            // Card 1 — Book
            var card1 = new System.Windows.Forms.Panel();
            card1.Location = new System.Drawing.Point(0, 0);
            card1.Size = new System.Drawing.Size(260, 140);
            card1.BackColor = System.Drawing.Color.White;

            this.lblCard1Title.Text = "📅";
            this.lblCard1Title.Font = new System.Drawing.Font("Segoe UI Emoji", 28F);
            this.lblCard1Title.Location = new System.Drawing.Point(90, 10);
            this.lblCard1Title.Size = new System.Drawing.Size(80, 60);

            this.lblCard1Sub.Text = "Book Appointment";
            this.lblCard1Sub.Font = new System.Drawing.Font("Roboto", 10F,
                                           System.Drawing.FontStyle.Bold);
            this.lblCard1Sub.ForeColor = System.Drawing.Color.FromArgb(13, 71, 161);
            this.lblCard1Sub.Location = new System.Drawing.Point(20, 80);
            this.lblCard1Sub.Size = new System.Drawing.Size(220, 30);
            this.lblCard1Sub.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            card1.Controls.Add(this.lblCard1Title);
            card1.Controls.Add(this.lblCard1Sub);

            // Card 2 — Appointments
            var card2 = new System.Windows.Forms.Panel();
            card2.Location = new System.Drawing.Point(290, 0);
            card2.Size = new System.Drawing.Size(260, 140);
            card2.BackColor = System.Drawing.Color.White;

            this.lblCard2Title.Text = "📋";
            this.lblCard2Title.Font = new System.Drawing.Font("Segoe UI Emoji", 28F);
            this.lblCard2Title.Location = new System.Drawing.Point(90, 10);
            this.lblCard2Title.Size = new System.Drawing.Size(80, 60);

            this.lblCard2Sub.Text = "My Appointments";
            this.lblCard2Sub.Font = new System.Drawing.Font("Roboto", 10F,
                                           System.Drawing.FontStyle.Bold);
            this.lblCard2Sub.ForeColor = System.Drawing.Color.FromArgb(13, 71, 161);
            this.lblCard2Sub.Location = new System.Drawing.Point(20, 80);
            this.lblCard2Sub.Size = new System.Drawing.Size(220, 30);
            this.lblCard2Sub.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            card2.Controls.Add(this.lblCard2Title);
            card2.Controls.Add(this.lblCard2Sub);

            // Card 3 — Prescriptions
            var card3 = new System.Windows.Forms.Panel();
            card3.Location = new System.Drawing.Point(580, 0);
            card3.Size = new System.Drawing.Size(260, 140);
            card3.BackColor = System.Drawing.Color.White;

            this.lblCard3Title.Text = "💊";
            this.lblCard3Title.Font = new System.Drawing.Font("Segoe UI Emoji", 28F);
            this.lblCard3Title.Location = new System.Drawing.Point(90, 10);
            this.lblCard3Title.Size = new System.Drawing.Size(80, 60);

            this.lblCard3Sub.Text = "My Prescriptions";
            this.lblCard3Sub.Font = new System.Drawing.Font("Roboto", 10F,
                                           System.Drawing.FontStyle.Bold);
            this.lblCard3Sub.ForeColor = System.Drawing.Color.FromArgb(13, 71, 161);
            this.lblCard3Sub.Location = new System.Drawing.Point(20, 80);
            this.lblCard3Sub.Size = new System.Drawing.Size(220, 30);
            this.lblCard3Sub.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            card3.Controls.Add(this.lblCard3Title);
            card3.Controls.Add(this.lblCard3Sub);

            this.panelInfoCards.Controls.Add(card1);
            this.panelInfoCards.Controls.Add(card2);
            this.panelInfoCards.Controls.Add(card3);

            this.panelMain.Controls.Add(this.lblHome);
            this.panelMain.Controls.Add(this.lblHomeSub);
            this.panelMain.Controls.Add(this.panelInfoCards);

            // ── Add to Form ───────────────────────────────────
            this.Controls.Add(this.panelSidebar);
            this.Controls.Add(this.panelMain);

            this.ResumeLayout(false);
        }

        // ── Control Declarations ──────────────────────────────
        private System.Windows.Forms.Panel panelSidebar;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Panel panelInfoCards;
        private System.Windows.Forms.Label lblAppTitle;
        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Label lblPid;
        private System.Windows.Forms.Label lblHome;
        private System.Windows.Forms.Label lblHomeSub;
        private System.Windows.Forms.Label lblCard1Title;
        private System.Windows.Forms.Label lblCard1Sub;
        private System.Windows.Forms.Label lblCard2Title;
        private System.Windows.Forms.Label lblCard2Sub;
        private System.Windows.Forms.Label lblCard3Title;
        private System.Windows.Forms.Label lblCard3Sub;
        private MaterialSkin.Controls.MaterialButton btnBookAppointment;
        private MaterialSkin.Controls.MaterialButton btnViewAppointments;
        private MaterialSkin.Controls.MaterialButton btnViewPrescriptions;
        private MaterialSkin.Controls.MaterialButton btnLogout;
    }
}