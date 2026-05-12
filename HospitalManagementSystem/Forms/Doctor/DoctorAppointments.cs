using System;
using System.Collections.Generic;
using System.Windows.Forms;
using HospitalManagementSystem.Core;
using HospitalManagementSystem.Models;
using HospitalManagementSystem.Helpers;

namespace HospitalManagementSystem.Forms.Doctor
{
    public partial class DoctorAppointments : Form
    {
        public DoctorAppointments()
        {
            InitializeComponent();
            LoadMyAppointments();
        }

        // ── Load Doctor's Own Appointments ──────────────────────
        private async void LoadMyAppointments()
        {
            try
            {
                // Pass logged-in doctor username as query param
                var result = await ApiClient.GetAsync<ApiResponse<List<Appointment>>>(
                    $"appointments?doctor={SessionManager.Username}");


                if (result.Success)
                {
                    dgvAppointments.Rows.Clear();

                    lblTotal.Text = $"Total Appointments: {result.Data.Count}";

                    foreach (var a in result.Data)
                    {
                        string uStatus = a.UserStatus == 1 ? "✅ Confirmed" : "⏳ Pending";
                        string dStatus = a.DoctorStatus == 1 ? "✅ Confirmed" : "⏳ Pending";

                        dgvAppointments.Rows.Add(
                            a.ID,
                            a.Pid,
                            a.FullName,
                            a.Gender,
                            a.Email,
                            a.Contact,
                            a.DocFees,
                            a.Appdate,
                            a.Apptime,
                            uStatus,
                            dStatus
                        );
                    }
                }
                else
                {
                    MessageBox.Show(result.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load appointments:\n{ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── Row Selected — Populate Detail Fields ───────────────
        private void dgvAppointments_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvAppointments.SelectedRows.Count == 0) return;

            var row = dgvAppointments.SelectedRows[0];

            txtAppID.Text = row.Cells["colID"].Value?.ToString();
            txtPid.Text = row.Cells["colPid"].Value?.ToString();
            txtPatient.Text = row.Cells["colPatient"].Value?.ToString();
            txtGender.Text = row.Cells["colGender"].Value?.ToString();
            txtEmail.Text = row.Cells["colEmail"].Value?.ToString();
            txtContact.Text = row.Cells["colContact"].Value?.ToString();
            txtFees.Text = row.Cells["colFees"].Value?.ToString();
            txtDate.Text = row.Cells["colDate"].Value?.ToString();
            txtTime.Text = row.Cells["colTime"].Value?.ToString();

            // Map status to combobox
            string dStat = row.Cells["colDoctorStatus"].Value?.ToString();
            cmbDoctorStatus.SelectedIndex = dStat == "✅ Confirmed" ? 1 : 0;
        }

        // ── Update MY Doctor Status ─────────────────────────────
        // Doctor can only update their OWN doctorStatus column
        private async void btnConfirm_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtAppID.Text))
            {
                MessageBox.Show("Please select an appointment.",
                    "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbDoctorStatus.SelectedIndex < 0)
            {
                MessageBox.Show("Please select a status.",
                    "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var formData = new Dictionary<string, string>
                {
                    { "id",           txtAppID.Text },
                    { "doctorStatus", cmbDoctorStatus.SelectedIndex.ToString() },
                    { "doctor",       SessionManager.Username }
                };

                var result = await ApiClient.PutAsync<ApiResponse>(
                    $"appointments/{txtAppID.Text}/status",
                    new Dictionary<string, string>
                    {
                        { "doctorStatus", cmbDoctorStatus.SelectedIndex.ToString() }
                    });

                MessageBox.Show(result.Message,
                    result.Success ? "Success" : "Error",
                    MessageBoxButtons.OK,
                    result.Success ? MessageBoxIcon.Information : MessageBoxIcon.Error);

                if (result.Success) { ClearFields(); LoadMyAppointments(); }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── Quick Confirm Button ────────────────────────────────
        private async void btnQuickConfirm_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtAppID.Text))
            {
                MessageBox.Show("Please select an appointment.",
                    "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirm = MessageBox.Show(
                $"Confirm appointment for {txtPatient.Text}\n" +
                $"Date: {txtDate.Text}  Time: {txtTime.Text}?",
                "Quick Confirm",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes) return;

            try
            {
                var formData = new Dictionary<string, string>
                {
                    { "id",           txtAppID.Text },
                    { "doctorStatus", "1"           }, // 1 = Confirmed
                    { "doctor",       SessionManager.Username }
                };

                var result = await ApiClient.PostAsync<ApiResponse>(
                    "doctor/update_status.php", formData);

                MessageBox.Show(result.Message,
                    result.Success ? "Appointment Confirmed!" : "Error",
                    MessageBoxButtons.OK,
                    result.Success ? MessageBoxIcon.Information : MessageBoxIcon.Error);

                if (result.Success) { ClearFields(); LoadMyAppointments(); }
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
            LoadMyAppointments();
        }

        // ── Write Prescription for Selected Patient ─────────────
        private void btnWriteRx_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtAppID.Text))
            {
                MessageBox.Show("Please select an appointment first.",
                    "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Pass selected appointment data to WritePrescription form
            var rxForm = new WritePrescription(
                appId: int.Parse(txtAppID.Text),
                pid: int.Parse(txtPid.Text),
                patient: txtPatient.Text,
                date: txtDate.Text,
                time: txtTime.Text
            );

            rxForm.ShowDialog();
        }

        // ── Helpers ─────────────────────────────────────────────
        private void ClearFields()
        {
            txtAppID.Text = "";
            txtPid.Text = "";
            txtPatient.Text = "";
            txtGender.Text = "";
            txtEmail.Text = "";
            txtContact.Text = "";
            txtFees.Text = "";
            txtDate.Text = "";
            txtTime.Text = "";
            cmbDoctorStatus.SelectedIndex = -1;
            dgvAppointments.ClearSelection();
        }
    }
}