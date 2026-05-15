using HospitalManagementSystem.Core;
using HospitalManagementSystem.Helpers;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using HospitalManagementSystem.Models;
using PatientModel = HospitalManagementSystem.Models.Patient;
using DoctorModel = HospitalManagementSystem.Models.Doctor;

namespace HospitalManagementSystem.Forms.Patient
{
    public partial class BookAppointment : Form
    {
        public BookAppointment()
        {
            InitializeComponent();
            LoadDoctors();
            PreFillPatientInfo();
        }

        // ── Pre-fill patient info from session ──────────────────
        private async void PreFillPatientInfo()
        {
            try
            {
                // Fetch patient details using pid from session
                var result = await ApiClient.GetAsync<ApiResponse<PatientModel>>(
                    $"patients/{SessionManager.PatientId}");


                if (result.Success && result.Data != null)
                {
                    txtPid.Text = result.Data.Pid.ToString();
                    txtFname.Text = result.Data.Fname;
                    txtLname.Text = result.Data.Lname;
                    txtGender.Text = result.Data.Gender;
                    txtEmail.Text = result.Data.Email;
                    txtContact.Text = result.Data.Contact;
                }
                else
                {
                    // Fallback to session data
                    txtPid.Text = SessionManager.PatientId.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Could not load patient info:\n{ex.Message}",
                    "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPid.Text = SessionManager.PatientId.ToString();
            }
        }

        // ── Load Doctors into ComboBox ───────────────────────────
        private async void LoadDoctors()
        {
            try
            {
                var result = await ApiClient.GetAsync<ApiResponse<List<DoctorModel>>>(
                    "doctors");


                if (result.Success)
                {
                    cmbDoctor.Items.Clear();

                    foreach (var d in result.Data)
                    {
                        // Store doctor object for fee lookup
                        cmbDoctor.Items.Add(new DoctorItem
                        {
                            Username = d.Username,
                            Spec = d.Spec,
                            DocFees = d.DocFees
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Could not load doctors:\n{ex.Message}",
                    "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // ── Doctor Selected — Auto-fill Spec & Fees ─────────────
        private void cmbDoctor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbDoctor.SelectedItem is DoctorItem doc)
            {
                txtSpec.Text = doc.Spec;
                txtFees.Text = doc.DocFees.ToString();
            }
        }

        // ── Book Appointment ────────────────────────────────────
        private async void btnBook_Click(object sender, EventArgs e)
        {
            if (!ValidateFields()) return;

            var confirm = MessageBox.Show(
                $"Confirm appointment with Dr. {cmbDoctor.SelectedItem}\n" +
                $"Date : {dtpDate.Value:yyyy-MM-dd}\n" +
                $"Time : {dtpTime.Value:HH:mm}\n" +
                $"Fees : {txtFees.Text}",
                "Confirm Booking",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes) return;

            btnBook.Enabled = false;
            btnBook.Text = "Booking...";

            try
            {
                var doc = cmbDoctor.SelectedItem as DoctorItem;

                var formData = new Dictionary<string, string>
                {
                    { "pid",          txtPid.Text                     },
                    { "fname",        txtFname.Text.Trim()            },
                    { "lname",        txtLname.Text.Trim()            },
                    { "gender",       txtGender.Text                  },
                    { "email",        txtEmail.Text.Trim()            },
                    { "contact",      txtContact.Text.Trim()          },
                    { "doctor",       doc.Username                    },
                    { "docFees",      doc.DocFees.ToString()          },
                    { "appdate",      dtpDate.Value.ToString("yyyy-MM-dd") },
                    { "apptime",      dtpTime.Value.ToString("HH:mm:ss")  },
                    { "userStatus",   "1"                             },
                    { "doctorStatus", "0"                             }
                };

                var result = await ApiClient.PostAsync<ApiResponse>(
                    "appointments", formData);

                MessageBox.Show(result.Message,
                    result.Success ? "Booking Confirmed!" : "Error",
                    MessageBoxButtons.OK,
                    result.Success ? MessageBoxIcon.Information : MessageBoxIcon.Error);

                if (result.Success) ClearBookingFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Booking error:\n{ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnBook.Enabled = true;
                btnBook.Text = "BOOK APPOINTMENT";
            }
        }

        // ── Reset Booking Fields ────────────────────────────────
        private void btnReset_Click(object sender, EventArgs e)
        {
            ClearBookingFields();
        }

        // ── Helpers ─────────────────────────────────────────────
        private bool ValidateFields()
        {
            if (string.IsNullOrEmpty(txtFname.Text) ||
                string.IsNullOrEmpty(txtLname.Text) ||
                string.IsNullOrEmpty(txtEmail.Text) ||
                string.IsNullOrEmpty(txtContact.Text))
            {
                MessageBox.Show("Patient info is incomplete. Please re-login.",
                    "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (cmbDoctor.SelectedItem == null)
            {
                MessageBox.Show("Please select a doctor.",
                    "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (dtpDate.Value.Date < DateTime.Today)
            {
                MessageBox.Show("Appointment date cannot be in the past.",
                    "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void ClearBookingFields()
        {
            cmbDoctor.SelectedIndex = -1;
            txtSpec.Text = "";
            txtFees.Text = "";
            dtpDate.Value = DateTime.Today;
            dtpTime.Value = DateTime.Today;
        }

        // ── Inner class to store doctor data in ComboBox ────────
        private class DoctorItem
        {
            public string Username { get; set; }
            public string Spec { get; set; }
            public int DocFees { get; set; }

            // Display in ComboBox
            public override string ToString() =>
                $"{Username}  ({Spec})  — Fees: {DocFees}";
        }
    }
}