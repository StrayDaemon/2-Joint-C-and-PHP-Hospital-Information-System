using HospitalManagementSystem.Helpers;
using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HospitalManagementSystem.Forms.Admin
{
    public partial class AdminDashboard : MaterialForm
    {
        public AdminDashboard()
        {
            InitializeComponent();
            MaterialSkinManager.Instance.AddFormToManage(this);

            // Show logged-in admin name
            lblWelcome.Text = $"Welcome, {SessionManager.Username.ToUpper()} !";
        }

        // ── Sidebar Navigation Buttons ──────────────────────────

        private void btnPatients_Click(object sender, EventArgs e)
        {
            OpenPanel(new ManagePatients());
        }

        private void btnDoctors_Click(object sender, EventArgs e)
        {
            OpenPanel(new ManageDoctors());
        }

        private void btnAppointments_Click(object sender, EventArgs e)
        {
            OpenPanel(new ManageAppointments());
        }

        private void btnContacts_Click(object sender, EventArgs e)
        {
            OpenPanel(new ViewContacts());
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show(
                "Are you sure you want to logout?",
                "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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
            // Close any existing child
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
