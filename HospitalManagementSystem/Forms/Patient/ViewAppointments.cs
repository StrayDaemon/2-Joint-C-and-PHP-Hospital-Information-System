using System;
using System.Collections.Generic;
using System.Windows.Forms;
using HospitalManagementSystem.Core;
using HospitalManagementSystem.Helpers;
using HospitalManagementSystem.Models;

namespace HospitalManagementSystem.Forms.Patient
{
    public partial class ViewAppointments : Form
    {
        public ViewAppointments()
        {
            InitializeComponent();
            LoadMyAppointments();
        }

        // ── Load Patient's Own Appointments ─────────────────────
        private async void LoadMyAppointments()
        {
            try
            {
                var result = await ApiClient.GetAsync<ApiResponse<List<Appointment>>>(
                    $"appointments?pid={SessionManager.PatientId}");

                if (result.Success)
                {
                    dgvAppointments.Rows.Clear();

                    int total = result.Data.Count;
                    int confirmed = 0;
                    int pending = 0;

                    foreach (var a in result.Data)
                    {
                        string uStatus = a.UserStatus == 1 ? "✅ Confirmed" : "⏳ Pending";
                        string dStatus = a.DoctorStatus == 1 ? "✅ Confirmed" : "⏳ Pending";

                        if (a.UserStatus == 1 && a.DoctorStatus == 1)
                            confirmed++;
                        else
                            pending++;

                        dgvAppointments.Rows.Add(
                            a.ID,
                            a.Doctor,
                            a.DocFees,
                            a.Appdate,
                            a.Apptime,
                            uStatus,
                            dStatus
                        );
                    }

                    // Update summary labels
                    lblTotal.Text = $"Total: {total}";
                    lblConfirmed.Text = $"✅ Confirmed: {confirmed}";
                    lblPending.Text = $"⏳ Pending: {pending}";
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
            txtDoctor.Text = row.Cells["colDoctor"].Value?.ToString();
            txtFees.Text = row.Cells["colFees"].Value?.ToString();
            txtDate.Text = row.Cells["colDate"].Value?.ToString();
            txtTime.Text = row.Cells["colTime"].Value?.ToString();

            string uStat = row.Cells["colUserStatus"].Value?.ToString();
            string dStat = row.Cells["colDoctorStatus"].Value?.ToString();

            // Show combined status message
            if (uStat == "✅ Confirmed" && dStat == "✅ Confirmed")
            {
                lblDetailStatus.Text = "✅ Both you and the doctor have confirmed.";
                lblDetailStatus.ForeColor = System.Drawing.Color.Green;

                // Can't cancel a fully confirmed appointment
                btnCancel.Enabled = false;
            }
            else if (dStat == "✅ Confirmed")
            {
                lblDetailStatus.Text = "⏳ Waiting for your confirmation.";
                lblDetailStatus.ForeColor = System.Drawing.Color.OrangeRed;
                btnCancel.Enabled = true;
            }
            else
            {
                lblDetailStatus.Text = "⏳ Awaiting doctor confirmation.";
                lblDetailStatus.ForeColor = System.Drawing.Color.Orange;
                btnCancel.Enabled = true;
            }
        }

        // ── Cancel Appointment ──────────────────────────────────
        // Sets userStatus = 0 (patient cancels their side)
        private async void btnCancel_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtAppID.Text))
            {
                MessageBox.Show("Please select an appointment to cancel.",
                    "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirm = MessageBox.Show(
                $"Cancel appointment with Dr. {txtDoctor.Text}\n" +
                $"Date: {txtDate.Text}  Time: {txtTime.Text}?\n\n" +
                "This will set your status to Pending.",
                "Confirm Cancellation",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm != DialogResult.Yes) return;

            try
            {
                var formData = new Dictionary<string, string>
                {
                    { "id",         txtAppID.Text },
                    { "userStatus", "0"           },
                    { "pid",        SessionManager.PatientId.ToString() }
                };

                var result = await ApiClient.PutAsync<ApiResponse>(
                    $"appointments/{txtAppID.Text}/status",
                    new Dictionary<string, string>
                    {
                        { "userStatus", "0" }
                    });

                MessageBox.Show(result.Message,
                    result.Success ? "Cancelled" : "Error",
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

        // ── Helpers ─────────────────────────────────────────────
        private void ClearFields()
        {
            txtAppID.Text = "";
            txtDoctor.Text = "";
            txtFees.Text = "";
            txtDate.Text = "";
            txtTime.Text = "";
            lblDetailStatus.Text = "";
            btnCancel.Enabled = false;
            dgvAppointments.ClearSelection();
        }
    }
}