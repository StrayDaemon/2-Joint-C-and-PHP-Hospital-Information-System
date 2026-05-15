using System;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;
using HospitalManagementSystem.Helpers;

namespace HospitalManagementSystem.Forms.Doctor
{
    public partial class DoctorDashboard : MaterialForm
    {
        public DoctorDashboard()
        {
            InitializeComponent();
            MaterialSkinManager.Instance.AddFormToManage(this);

            // Show logged-in doctor name
            lblWelcome.Text = $"Dr. {SessionManager.Username.ToUpper()}";
        }

        // ── Sidebar Navigation ──────────────────────────────────

        private void btnAppointments_Click(object sender, EventArgs e)
        {
            OpenPanel(new DoctorAppointments());
        }

        private void btnPrescription_Click(object sender, EventArgs e)
        {
            OpenPanel(new WritePrescription());
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