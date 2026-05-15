using System;
using System.Collections.Generic;
using System.Windows.Forms;
using HospitalManagementSystem.Core;
using HospitalManagementSystem.Helpers;

namespace HospitalManagementSystem.Forms.Doctor
{
    public partial class WritePrescription : Form
    {
        // ── Passed in from DoctorAppointments ──────────────────
        private readonly int _appId;
        private readonly int _pid;
        private readonly string _patientName;
        private readonly string _date;
        private readonly string _time;

        // ── Constructor receives appointment context ─────────────
        public WritePrescription(int appId, int pid, string patient,
                                 string date, string time)
        {
            InitializeComponent();

            _appId = appId;
            _pid = pid;
            _patientName = patient;
            _date = date;
            _time = time;

            // Pre-fill read-only fields
            PopulateHeader();

            // Check if prescription already exists for this appointment
            LoadExistingPrescription();
        }

        // ── Also allow opening standalone (from sidebar) ────────
        public WritePrescription()
        {
            InitializeComponent();
        }

        // ── Pre-fill appointment info ───────────────────────────
        private void PopulateHeader()
        {
            txtAppID.Text = _appId.ToString();
            txtPid.Text = _pid.ToString();
            txtPatient.Text = _patientName;
            txtDoctor.Text = SessionManager.Username;
            txtDate.Text = _date;
            txtTime.Text = _time;

            // Split name into fname/lname
            var parts = _patientName.Split(' ');
            txtFname.Text = parts.Length > 0 ? parts[0] : _patientName;
            txtLname.Text = parts.Length > 1 ? parts[1] : "";
        }

        // ── Check if Rx already exists for this appointment ─────
        private async void LoadExistingPrescription()
        {
            if (_appId == 0) return;

            try
            {
                var result = await ApiClient.GetAsync<ApiResponse<Models.Prescription>>(
                    $"prescriptions/{_appId}");

                if (result.Success && result.Data != null)
                {
                    // Pre-fill existing prescription
                    txtDisease.Text = result.Data.Disease;
                    txtAllergy.Text = result.Data.Allergy;
                    txtPrescription.Text = result.Data.PrescriptionText;

                    lblStatus.Text = "⚠ Prescription already exists. Saving will update it.";
                    lblStatus.ForeColor = System.Drawing.Color.OrangeRed;
                }
                else
                {
                    lblStatus.Text = "✏ New prescription for this appointment.";
                    lblStatus.ForeColor = System.Drawing.Color.FromArgb(0, 121, 107);
                }
            }
            catch
            {
                // No existing prescription — fresh form
                lblStatus.Text = "✏ New prescription for this appointment.";
                lblStatus.ForeColor = System.Drawing.Color.FromArgb(0, 121, 107);
            }
        }

        // ── Save Prescription ───────────────────────────────────
        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateFields()) return;

            btnSave.Enabled = false;
            btnSave.Text = "Saving...";

            try
            {
                var formData = new Dictionary<string, string>
                {
                    { "doctor",       SessionManager.Username    },
                    { "pid",          txtPid.Text                },
                    { "ID",           txtAppID.Text              },
                    { "fname",        txtFname.Text              },
                    { "lname",        txtLname.Text              },
                    { "appdate",      txtDate.Text               },
                    { "apptime",      txtTime.Text               },
                    { "disease",      txtDisease.Text.Trim()     },
                    { "allergy",      txtAllergy.Text.Trim()     },
                    { "prescription", txtPrescription.Text.Trim()}
                };

                var result = await ApiClient.PostAsync<ApiResponse>(
                    "prescriptions", formData);

                MessageBox.Show(result.Message,
                    result.Success ? "Success" : "Error",
                    MessageBoxButtons.OK,
                    result.Success ? MessageBoxIcon.Information : MessageBoxIcon.Error);

                if (result.Success)
                {
                    lblStatus.Text = "✅ Prescription saved successfully.";
                    lblStatus.ForeColor = System.Drawing.Color.Green;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnSave.Enabled = true;
                btnSave.Text = "SAVE PRESCRIPTION";
            }
        }

        // ── Clear Prescription Fields ───────────────────────────
        private void btnClear_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show(
                "Clear all prescription fields?",
                "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                txtDisease.Text = "";
                txtAllergy.Text = "";
                txtPrescription.Text = "";
            }
        }

        // ── Close ───────────────────────────────────────────────
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // ── Validation ──────────────────────────────────────────
        private bool ValidateFields()
        {
            if (string.IsNullOrEmpty(txtDisease.Text.Trim()))
            {
                MessageBox.Show("Please enter the disease/condition.",
                    "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrEmpty(txtAllergy.Text.Trim()))
            {
                MessageBox.Show("Please enter allergy info (use 'None' if none).",
                    "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrEmpty(txtPrescription.Text.Trim()))
            {
                MessageBox.Show("Please enter the prescription details.",
                    "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrEmpty(txtAppID.Text) || txtAppID.Text == "0")
            {
                MessageBox.Show("No appointment selected. Please open this form " +
                    "from an appointment.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }
    }
}