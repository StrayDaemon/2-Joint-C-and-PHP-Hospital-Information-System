using HospitalManagementSystem.Core;
using HospitalManagementSystem.Helpers;
using HospitalManagementSystem.Models;
using MaterialSkin;
using MaterialSkin.Controls;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HospitalManagementSystem.Forms
{
    public partial class LoginForm : MaterialForm
    {
        public LoginForm()
        {
            InitializeComponent();
            var skinManager = MaterialSkinManager.Instance;
            skinManager.AddFormToManage(this);

            skinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            skinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
        }

        // ── Login Button Click ──────────────────────────────────
        private async void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();
            string role = cmbRole.Text;

            // ── Basic Validation ───────────────────────────────
            if (string.IsNullOrEmpty(username) ||
                string.IsNullOrEmpty(password) ||
                string.IsNullOrEmpty(role))
            {
                MessageBox.Show(
                    "Please fill in all fields and select a role.",
                    "Validation",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            btnLogin.Enabled = false;
            btnLogin.Text = "Logging in...";

            try
            {
                switch (role)
                {
                    case "Admin":
                        await LoginAsAdmin(username, password);
                        break;

                    case "Doctor":
                        await LoginAsDoctor(username, password);
                        break;

                    case "Patient":
                        await LoginAsPatient(username, password);
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Connection error: {ex.Message}\n\n" +
                    "Make sure Node.js API is running on port 3000.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                btnLogin.Enabled = true;
                btnLogin.Text = "LOGIN";
            }
        }

        // ── Admin Login ─────────────────────────────────────────
        private async Task LoginAsAdmin(string username, string password)
        {
            var result = await ApiClient.PostAsync<ApiResponse>(
                "auth/login",
                new Dictionary<string, string>
                {
                    { "username", username },
                    { "password", password },
                    { "role",     "admin"  }
                });

            if (result.Success)
            {
                // ✅ Store session
                SessionManager.Role = "admin";
                SessionManager.Username = username;

                // ✅ Navigate to Admin Dashboard
                this.Hide();
                new Admin.AdminDashboard().Show();
            }
            else
            {
                MessageBox.Show(
                    result.Message,
                    "Login Failed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // ── Doctor Login ────────────────────────────────────────
        private async Task LoginAsDoctor(string username, string password)
        {
            var result = await ApiClient.PostAsync<ApiResponse<DoctorPayload>>(
                "auth/login",
                new Dictionary<string, string>
                {
                    { "username", username },
                    { "password", password },
                    { "role",     "doctor" }
                });

            if (result.Success)
            {
                // ✅ Store session
                SessionManager.Role = "doctor";
                SessionManager.Username = result.Data?.Username ?? username;

                // ✅ Navigate to Doctor Dashboard
                this.Hide();
                new Doctor.DoctorDashboard().Show();
            }
            else
            {
                MessageBox.Show(
                    result.Message,
                    "Login Failed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // ── Patient Login ───────────────────────────────────────
        private async Task LoginAsPatient(string username, string password)
        {
            var result = await ApiClient.PostAsync<ApiResponse<PatientPayload>>(
                "auth/login",
                new Dictionary<string, string>
                {
                    { "username", username },
                    { "password", password },
                    { "role",     "patient"}
                });

            if (result.Success)
            {
                // ✅ Store session
                SessionManager.Role = "patient";
                SessionManager.Username = result.Data?.FullName ?? username;
                SessionManager.PatientId = result.Data?.Pid ?? 0;

                // ✅ Navigate to Patient Dashboard
                this.Hide();
                new Patient.PatientDashboard().Show();
            }
            else
            {
                MessageBox.Show(
                    result.Message,
                    "Login Failed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // ── Payload Classes ─────────────────────────────────────

        // Maps Node.js doctor login response data
        private class DoctorPayload
        {
            [Newtonsoft.Json.JsonProperty("username")]
            public string Username { get; set; }

            [Newtonsoft.Json.JsonProperty("email")]
            public string Email { get; set; }

            [Newtonsoft.Json.JsonProperty("spec")]
            public string Spec { get; set; }

            [Newtonsoft.Json.JsonProperty("docFees")]
            public int DocFees { get; set; }
        }

        // Maps Node.js patient login response data
        private class PatientPayload
        {
            [Newtonsoft.Json.JsonProperty("pid")]
            public int Pid { get; set; }

            [Newtonsoft.Json.JsonProperty("fullName")]
            public string FullName { get; set; }

            [Newtonsoft.Json.JsonProperty("email")]
            public string Email { get; set; }

            [Newtonsoft.Json.JsonProperty("fname")]
            public string Fname { get; set; }

            [Newtonsoft.Json.JsonProperty("lname")]
            public string Lname { get; set; }
        }
    }
}