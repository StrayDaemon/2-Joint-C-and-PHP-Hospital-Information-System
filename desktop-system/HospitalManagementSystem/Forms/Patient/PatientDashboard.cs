using System;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;
using HospitalManagementSystem.Helpers;

namespace HospitalManagementSystem.Forms.Patient
{
    public partial class PatientDashboard : MaterialForm
    {
        public PatientDashboard()
        {
            InitializeComponent();
            MaterialSkinManager.Instance.AddFormToManage(this);

            lblWelcome.Text = $"Welcome, {SessionManager.Username.ToUpper()}";
            lblPid.Text = $"Patient ID: {SessionManager.PatientId}";
        }

        // ── Sidebar Navigation ──────────────────────────────────

        private void btnBookAppointment_Click(object sender, EventArgs e)
        {
            OpenPanel(new BookAppointment());
        }

        private void btnViewAppointments_Click(object sender, EventArgs e)
        {
            OpenPanel(new ViewAppointments());
        }

        private void btnViewPrescriptions_Click(object sender, EventArgs e)
        {
            OpenPanel(new ViewPrescriptions());
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show(
                "Are you sure you want to logout?",
                "Logout",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                SessionManager.Role = null;
                SessionManager.Username = null;
                SessionManager.PatientId = 0;

                this.Hide();
                new LoginForm().Show();
            }
        }

        // ── Load child form into panelMain ──────────────────────
        private void OpenPanel(Form childForm)
        {
            foreach (Control c in panelMain.Controls)
                if (c is Form f) f.Close();

            panelMain.Controls.Clear();

            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;

            panelMain.Controls.Add(childForm);
            panelMain.Tag = childForm;
            childForm.Show();
        }
    }
}