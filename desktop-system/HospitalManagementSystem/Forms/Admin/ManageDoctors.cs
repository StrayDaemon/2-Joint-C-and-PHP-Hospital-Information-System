using HospitalManagementSystem.Core;
using HospitalManagementSystem.Helpers;
using HospitalManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Windows.Forms;
using DoctorModel = HospitalManagementSystem.Models.Doctor;

namespace HospitalManagementSystem.Forms.Admin
{
    public partial class ManageDoctors : Form
    {
        public ManageDoctors()
        {
            InitializeComponent();

            // Apply dynamic grid styling
            DataGridHelper.Apply(dgvDoctors);

            // ✅Set column widths
            // username | email | spec | docFees
            DataGridHelper.SetColumnWidths(dgvDoctors,
                130,  // Username
                -1,   // Email — fills remaining space
                160,  // Specialization
                100   // Fees
            );

            LoadDoctors();
        }

        // ── Load All Doctors ────────────────────────────────────
        private async void LoadDoctors()
        {
            try
            {
                var result = await ApiClient.GetAsync<ApiResponse<List<DoctorModel>>>(
                    "doctors");

                if (result.Success)
                {
                    dgvDoctors.Rows.Clear();

                    foreach (var d in result.Data)
                    {
                        dgvDoctors.Rows.Add(
                            d.Username,
                            d.Email,
                            d.Spec,
                            d.DocFees
                        );
                    }

                    // ✅ Auto-fit after data loads
                    DataGridHelper.AutoFitColumns(dgvDoctors,
                        minWidth: 100, maxWidth: 300);
                }
                else
                {
                    MessageBox.Show(result.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load doctors:\n{ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── Row Selected — Populate Fields ──────────────────────
        private void dgvDoctors_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvDoctors.SelectedRows.Count == 0) return;

            var row = dgvDoctors.SelectedRows[0];

            txtUsername.Text = row.Cells["colUsername"].Value?.ToString();
            txtEmail.Text = row.Cells["colEmail"].Value?.ToString();
            txtFees.Text = row.Cells["colFees"].Value?.ToString();

            string spec = row.Cells["colSpec"].Value?.ToString();
            cmbSpec.SelectedItem = spec;

            // Clear password on select for security
            txtPassword.Text = "";
        }

        // ── Add Doctor ──────────────────────────────────────────
        private async void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateFields(requirePassword: true)) return;

            try
            {
                var formData = BuildFormData();

                var result = await ApiClient.PostAsync<ApiResponse>(
                    "doctors", formData);

                MessageBox.Show(result.Message,
                    result.Success ? "Success" : "Error",
                    MessageBoxButtons.OK,
                    result.Success
                        ? MessageBoxIcon.Information
                        : MessageBoxIcon.Error);

                if (result.Success) { ClearFields(); LoadDoctors(); }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── Update Doctor ───────────────────────────────────────
        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUsername.Text))
            {
                MessageBox.Show("Please select a doctor to update.",
                    "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ValidateFields(requirePassword: false)) return;

            try
            {
                var formData = BuildFormData();

                var result = await ApiClient.PutAsync<ApiResponse>(
                    $"doctors/{txtUsername.Text}", formData);

                MessageBox.Show(result.Message,
                    result.Success ? "Success" : "Error",
                    MessageBoxButtons.OK,
                    result.Success
                        ? MessageBoxIcon.Information
                        : MessageBoxIcon.Error);

                if (result.Success) { ClearFields(); LoadDoctors(); }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── Delete Doctor ───────────────────────────────────────
        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUsername.Text))
            {
                MessageBox.Show("Please select a doctor to delete.",
                    "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirm = MessageBox.Show(
                $"Delete doctor '{txtUsername.Text}'?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm != DialogResult.Yes) return;

            try
            {
                var result = await ApiClient.DeleteAsync<ApiResponse>(
                    $"doctors/{txtUsername.Text}");

                MessageBox.Show(result.Message,
                    result.Success ? "Success" : "Error",
                    MessageBoxButtons.OK,
                    result.Success
                        ? MessageBoxIcon.Information
                        : MessageBoxIcon.Error);

                if (result.Success) { ClearFields(); LoadDoctors(); }
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
            LoadDoctors();
        }

        // ── Helpers ─────────────────────────────────────────────
        private bool ValidateFields(bool requirePassword)
        {
            if (string.IsNullOrEmpty(txtUsername.Text) ||
                string.IsNullOrEmpty(txtEmail.Text) ||
                string.IsNullOrEmpty(txtFees.Text) ||
                cmbSpec.SelectedItem == null)
            {
                MessageBox.Show("Please fill in all fields.",
                    "Validation", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return false;
            }

            if (requirePassword && string.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBox.Show(
                    "Password is required when adding a doctor.",
                    "Validation", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return false;
            }

            if (!int.TryParse(txtFees.Text, out _))
            {
                MessageBox.Show("Doctor fees must be a valid number.",
                    "Validation", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private Dictionary<string, string> BuildFormData()
        {
            return new Dictionary<string, string>
            {
                { "username", txtUsername.Text.Trim()              },
                { "password", txtPassword.Text.Trim()              },
                { "email",    txtEmail.Text.Trim()                 },
                { "spec",     cmbSpec.SelectedItem.ToString()      },
                { "docFees",  txtFees.Text.Trim()                  }
            };
        }

        private void ClearFields()
        {
            txtUsername.Text = "";
            txtPassword.Text = "";
            txtEmail.Text = "";
            txtFees.Text = "";
            cmbSpec.SelectedIndex = -1;
            dgvDoctors.ClearSelection();
        }
    }
}