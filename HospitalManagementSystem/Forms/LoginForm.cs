using HospitalManagementSystem.Core;
using HospitalManagementSystem.Helpers;
using HospitalManagementSystem.Models;
using MaterialSkin;
using MaterialSkin.Controls;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HospitalManagementSystem.Forms
{
    public partial class LoginForm : MaterialForm
    {
        public LoginForm()
        {
            InitializeComponent();

            // Attach MaterialSkin to this form
            var skinManager = MaterialSkinManager.Instance;
            skinManager.AddFormToManage(this);
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
                MessageBox.Show("Please fill in all fields and select a role.",
                    "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            btnLogin.Enabled = false;
            btnLogin.Text = "Logging in...";

            try
            {
                var formData = new Dictionary<string, string>
                {
                    { "username", username },
                    { "password", password }
                };

                switch (role)
                {
                    case "Admin":
                        await LoginAsAdmin(formData);
                        break;

                    case "Doctor":
                        await LoginAsDoctor(formData);
                        break;

                    case "Patient":
                        await LoginAsPatient(formData);
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Connection error: {ex.Message}\n\nMake sure XAMPP is running.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnLogin.Enabled = true;
                btnLogin.Text = "LOGIN";
            }
        }

        // ── Admin Login ─────────────────────────────────────────
        private async System.Threading.Tasks.Task LoginAsAdmin(Dictionary<string, string> formData)
        {
            var result = await ApiClient.PostAsync<ApiResponse>(
            "auth/login",
            new Dictionary<string, string>
    {
                { "username", formData["username"] },
                { "password", formData["password"] },
                { "role",     "admin"              }
            });
        }

        // ── Doctor Login ────────────────────────────────────────
        private async System.Threading.Tasks.Task LoginAsDoctor(Dictionary<string, string> formData)
        {
            var result = await ApiClient.PostAsync<ApiResponse>(
            "auth/login",
            new Dictionary<string, string>
                {
                    { "username", formData["username"] },
                    { "password", formData["password"] },
                    { "role",     "doctor"             }
            });

        }

        // ── Patient Login ───────────────────────────────────────
        private async Task LoginAsPatient(Dictionary<string, string> formData)
        {
            var result = await ApiClient.PostAsync<ApiResponse<PatientPayload>>(
                "auth/login",
                new Dictionary<string, string>
                {
            { "username", formData["username"] },
            { "password", formData["password"] },
            { "role",     "patient"            }
                });

            if (result.Success)
            {
                SessionManager.Role = "patient";
                SessionManager.Username = result.Data.FullName;
                SessionManager.PatientId = result.Data.Pid;

                this.Hide();
                new Patient.PatientDashboard().Show();
            }
            else
            {
                MessageBox.Show(result.Message, "Login Failed",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── Add this inner class to LoginForm.cs ─────────────────
        private class PatientPayload
        {
            [Newtonsoft.Json.JsonProperty("pid")]
            public int Pid { get; set; }

            [Newtonsoft.Json.JsonProperty("fullName")]
            public string FullName { get; set; }

            [Newtonsoft.Json.JsonProperty("email")]
            public string Email { get; set; }
        }
    }
}
