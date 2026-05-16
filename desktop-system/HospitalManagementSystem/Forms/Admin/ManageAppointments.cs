using HospitalManagementSystem.Core;
using HospitalManagementSystem.Helpers;
using HospitalManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace HospitalManagementSystem.Forms.Admin
{
    public partial class ManageAppointments : Form
    {
        public ManageAppointments()
        {
            InitializeComponent();
            DataGridHelper.Apply(dgvAppointments);

            // ID | pid | patient | gender | doctor | fees
            // date | time | userStatus | doctorStatus
            DataGridHelper.SetColumnWidths(dgvAppointments,
                55,   // App ID
                55,   // Patient ID
                140,  // Patient Name
                70,   // Gender
                100,  // Doctor
                70,   // Fees
                100,  // Date
                80,   // Time
                120,  // Patient Status
                120   // Doctor Status
            );

            LoadAppointments();
        }

        // ── Load All Appointments ───────────────────────────────
        private async void LoadAppointments()
        {
            try
            {
                var result = await ApiClient.GetAsync<ApiResponse<List<Appointment>>>(
                    "appointments");

                if (result.Success)
                {
                    dgvAppointments.Rows.Clear();

                    foreach (var a in result.Data)
                    {
                        string uStatus = a.UserStatus == 1 ? "✅ Confirmed" : "⏳ Pending";
                        string dStatus = a.DoctorStatus == 1 ? "✅ Confirmed" : "⏳ Pending";

                        dgvAppointments.Rows.Add(
                            a.ID, a.Pid, a.FullName, a.Gender,
                            a.Doctor, a.DocFees, a.Appdate,
                            a.Apptime, uStatus, dStatus);
                    }

                    // ✅ Color rows by status
                    DataGridHelper.ColorRowsByStatus(
                        dgvAppointments, "colUserStatus");

                    DataGridHelper.AutoFitColumns(dgvAppointments,
                        minWidth: 55, maxWidth: 250);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load appointments:\n{ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── Row Selected — Populate Fields ──────────────────────
        private void dgvAppointments_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvAppointments.SelectedRows.Count == 0) return;

            var row = dgvAppointments.SelectedRows[0];

            txtAppID.Text = row.Cells["colID"].Value?.ToString();
            txtPid.Text = row.Cells["colPid"].Value?.ToString();
            txtPatient.Text = row.Cells["colPatient"].Value?.ToString();
            txtDoctor.Text = row.Cells["colDoctor"].Value?.ToString();
            txtFees.Text = row.Cells["colFees"].Value?.ToString();
            txtDate.Text = row.Cells["colDate"].Value?.ToString();
            txtTime.Text = row.Cells["colTime"].Value?.ToString();

            // Map status text back to combobox
            string uStat = row.Cells["colUserStatus"].Value?.ToString();
            cmbUserStatus.SelectedIndex = uStat == "✅ Confirmed" ? 1 : 0;

            string dStat = row.Cells["colDoctorStatus"].Value?.ToString();
            cmbDoctorStatus.SelectedIndex = dStat == "✅ Confirmed" ? 1 : 0;
        }

        // ── Update Status ───────────────────────────────────────
        private async void btnUpdateStatus_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtAppID.Text))
            {
                MessageBox.Show("Please select an appointment to update.",
                    "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbUserStatus.SelectedIndex < 0 || cmbDoctorStatus.SelectedIndex < 0)
            {
                MessageBox.Show("Please select both status values.",
                    "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var formData = new Dictionary<string, string>
                {
                    { "id",           txtAppID.Text },
                    { "userStatus",   cmbUserStatus.SelectedIndex.ToString()   },
                    { "doctorStatus", cmbDoctorStatus.SelectedIndex.ToString() }
                };

                var result = await ApiClient.PutAsync<ApiResponse>(
                     $"appointments/{txtAppID.Text}/status",
                     new Dictionary<string, string>
                     {
                        { "userStatus",   cmbUserStatus.SelectedIndex.ToString()   },
                        { "doctorStatus", cmbDoctorStatus.SelectedIndex.ToString() }
                     });

                MessageBox.Show(result.Message,
                    result.Success ? "Success" : "Error",
                    MessageBoxButtons.OK,
                    result.Success ? MessageBoxIcon.Information : MessageBoxIcon.Error);

                if (result.Success) { ClearFields(); LoadAppointments(); }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── Delete Appointment ──────────────────────────────────
        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtAppID.Text))
            {
                MessageBox.Show("Please select an appointment to delete.",
                    "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirm = MessageBox.Show(
                $"Delete appointment ID {txtAppID.Text} for {txtPatient.Text}?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm != DialogResult.Yes) return;

            try
            {
                var formData = new Dictionary<string, string>
                {
                    { "id", txtAppID.Text }
                };

                var result = await ApiClient.DeleteAsync<ApiResponse>(
                    $"appointments/{txtAppID.Text}");

                MessageBox.Show(result.Message,
                    result.Success ? "Success" : "Error",
                    MessageBoxButtons.OK,
                    result.Success ? MessageBoxIcon.Information : MessageBoxIcon.Error);

                if (result.Success) { ClearFields(); LoadAppointments(); }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── Filter by Status ────────────────────────────────────
        private async void btnFilter_Click(object sender, EventArgs e)
        {
            if (cmbFilter.SelectedIndex < 0)
            {
                LoadAppointments();
                return;
            }

            try
            {
                // 0 = All, 1 = Pending, 2 = Confirmed
                string filter = cmbFilter.SelectedIndex.ToString();

                var result = await ApiClient.GetAsync<ApiResponse<List<Appointment>>>(
                    $"appointments?filter={filter}");

                if (result.Success)
                {
                    dgvAppointments.Rows.Clear();

                    foreach (var a in result.Data)
                    {
                        string uStatus = a.UserStatus == 1 ? "✅ Confirmed" : "⏳ Pending";
                        string dStatus = a.DoctorStatus == 1 ? "✅ Confirmed" : "⏳ Pending";

                        dgvAppointments.Rows.Add(
                            a.ID,
                            a.Pid,
                            a.FullName,
                            a.Gender,
                            a.Doctor,
                            a.DocFees,
                            a.Appdate,
                            a.Apptime,
                            uStatus,
                            dStatus
                        );
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Filter error: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── Refresh ─────────────────────────────────────────────
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ClearFields();
            cmbFilter.SelectedIndex = -1;
            LoadAppointments();
        }

        // ── Helpers ─────────────────────────────────────────────
        private void ClearFields()
        {
            txtAppID.Text = "";
            txtPid.Text = "";
            txtPatient.Text = "";
            txtDoctor.Text = "";
            txtFees.Text = "";
            txtDate.Text = "";
            txtTime.Text = "";
            cmbUserStatus.SelectedIndex = -1;
            cmbDoctorStatus.SelectedIndex = -1;
            dgvAppointments.ClearSelection();
        }
    }
}