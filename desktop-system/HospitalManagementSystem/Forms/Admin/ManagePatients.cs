using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MaterialSkin.Controls;
using HospitalManagementSystem.Core;
using HospitalManagementSystem.Models;
using Newtonsoft.Json;
using HospitalManagementSystem.Helpers;
using PatientModel = HospitalManagementSystem.Models.Patient;

namespace HospitalManagementSystem.Forms.Admin
{
    public partial class ManagePatients : Form
    {
        public ManagePatients()
        {
            InitializeComponent();

            //Apply consistent styling to the DataGridView
            DataGridHelper.Apply(dgvPatients);

            // pid | fname | lname | gender | email | contact
            DataGridHelper.SetColumnWidths(dgvPatients,
                60,   // ID
                120,  // First Name
                120,  // Last Name
                80,   // Gender
                -1,   // Email — fills remaining space
                110   // Contact
            );

            LoadPatients();
        }

        // ── Load All Patients ───────────────────────────────────
        private async void LoadPatients()
        {
            try
            {
                var result = await ApiClient.GetAsync<ApiResponse<List<PatientModel>>>(
                    "patients");

                if (result.Success)
                {
                    dgvPatients.Rows.Clear();

                    foreach (var p in result.Data)
                    {
                        dgvPatients.Rows.Add(
                            p.Pid, p.Fname, p.Lname,
                            p.Gender, p.Email, p.Contact);
                    }

                    //  Auto-fit after data loads
                    DataGridHelper.AutoFitColumns(dgvPatients);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load patients:\n{ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        

        // ── Row Selected — Populate Fields ─────────────────────
        private void dgvPatients_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvPatients.SelectedRows.Count == 0) return;

            var row = dgvPatients.SelectedRows[0];
            txtPid.Text = row.Cells["colPid"].Value?.ToString();
            txtFname.Text = row.Cells["colFname"].Value?.ToString();
            txtLname.Text = row.Cells["colLname"].Value?.ToString();
            txtEmail.Text = row.Cells["colEmail"].Value?.ToString();
            txtContact.Text = row.Cells["colContact"].Value?.ToString();

            string gender = row.Cells["colGender"].Value?.ToString();
            cmbGender.SelectedItem = gender;
        }

        // ── Add Patient ─────────────────────────────────────────
        private async void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateFields()) return;

            try
            {
                var formData = BuildFormData();
                formData.Add("password", txtFname.Text.ToLower() + "123");
                formData.Add("cpassword", txtFname.Text.ToLower() + "123");

                var result = await ApiClient.PostAsync<ApiResponse>(
                    "patients", formData);

                MessageBox.Show(result.Message,
                    result.Success ? "Success" : "Error",
                    MessageBoxButtons.OK,
                    result.Success ? MessageBoxIcon.Information : MessageBoxIcon.Error);

                if (result.Success) { ClearFields(); LoadPatients(); }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── Update Patient ──────────────────────────────────────
        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtPid.Text))
            {
                MessageBox.Show("Please select a patient to update.",
                    "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ValidateFields()) return;

            try
            {
                var formData = BuildFormData();
                formData.Add("pid", txtPid.Text);

                var result = await ApiClient.PutAsync<ApiResponse>(
                    $"patients/{txtPid.Text}", formData);

                MessageBox.Show(result.Message,
                    result.Success ? "Success" : "Error",
                    MessageBoxButtons.OK,
                    result.Success ? MessageBoxIcon.Information : MessageBoxIcon.Error);

                if (result.Success) { ClearFields(); LoadPatients(); }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── Delete Patient ──────────────────────────────────────
        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtPid.Text))
            {
                MessageBox.Show("Please select a patient to delete.",
                    "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirm = MessageBox.Show(
                $"Delete patient {txtFname.Text} {txtLname.Text}?",
                "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirm != DialogResult.Yes) return;

            try
            {
                var formData = new Dictionary<string, string>
                {
                    { "pid", txtPid.Text }
                };

                var result = await ApiClient.DeleteAsync<ApiResponse>(
                    $"patients/{txtPid.Text}");

                MessageBox.Show(result.Message,
                    result.Success ? "Success" : "Error",
                    MessageBoxButtons.OK,
                    result.Success ? MessageBoxIcon.Information : MessageBoxIcon.Error);

                if (result.Success) { ClearFields(); LoadPatients(); }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── Refresh ─────────────────────────────────────────────
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ClearFields();
            LoadPatients();
        }

        // ── Helpers ─────────────────────────────────────────────
        private bool ValidateFields()
        {
            if (string.IsNullOrEmpty(txtFname.Text) ||
                string.IsNullOrEmpty(txtLname.Text) ||
                string.IsNullOrEmpty(txtEmail.Text) ||
                string.IsNullOrEmpty(txtContact.Text) ||
                cmbGender.SelectedItem == null)
            {
                MessageBox.Show("Please fill in all fields.",
                    "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private Dictionary<string, string> BuildFormData()
        {
            return new Dictionary<string, string>
            {
                { "fname",   txtFname.Text.Trim()   },
                { "lname",   txtLname.Text.Trim()   },
                { "gender",  cmbGender.SelectedItem.ToString() },
                { "email",   txtEmail.Text.Trim()   },
                { "contact", txtContact.Text.Trim() }
            };
        }

        private void ClearFields()
        {
            txtPid.Text = "";
            txtFname.Text = "";
            txtLname.Text = "";
            txtEmail.Text = "";
            txtContact.Text = "";
            cmbGender.SelectedIndex = -1;
            dgvPatients.ClearSelection();
        }
    }
}