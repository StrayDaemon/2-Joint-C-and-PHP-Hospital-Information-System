using HospitalManagementSystem.Core;
using HospitalManagementSystem.Helpers;
using HospitalManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Xml.Linq;

namespace HospitalManagementSystem.Forms.Admin
{
    public partial class ViewContacts : Form
    {
        public ViewContacts()
        {
            InitializeComponent();
            DataGridHelper.Apply(dgvContacts);

            // name | email | contact | message
            DataGridHelper.SetColumnWidths(dgvContacts,
                120,  // Name
                180,  // Email
                110,  // Contact
                -1    // Message — fills remaining space
            );

            LoadContacts();
        }

        // ── Load All Contacts ───────────────────────────────────
        private async void LoadContacts()
        {
            try
            {
                var result = await ApiClient.GetAsync<ApiResponse<List<Contact>>>(
                    "contacts");

                if (result.Success)
                {
                    dgvContacts.Rows.Clear();

                    foreach (var c in result.Data)
                    {
                        dgvContacts.Rows.Add(
                            c.Name, c.Email,
                            c.ContactNo, c.Message);
                    }

                    lblCount.Text = $"Total Messages: {result.Data.Count}";
                    DataGridHelper.AutoFitColumns(dgvContacts,
                        minWidth: 100, maxWidth: 400);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load contacts:\n{ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── Row Selected — Show Message Preview ─────────────────
        private void dgvContacts_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvContacts.SelectedRows.Count == 0) return;

            var row = dgvContacts.SelectedRows[0];

            txtName.Text = row.Cells["colName"].Value?.ToString();
            txtEmail.Text = row.Cells["colEmail"].Value?.ToString();
            txtContact.Text = row.Cells["colContact"].Value?.ToString();
            txtMessage.Text = row.Cells["colMessage"].Value?.ToString();
        }

        // ── Refresh ─────────────────────────────────────────────
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ClearPreview();
            LoadContacts();
        }

        // ── Search by Name ──────────────────────────────────────
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim().ToLower();

            foreach (DataGridViewRow row in dgvContacts.Rows)
            {
                if (row.IsNewRow) continue;

                string name = row.Cells["colName"].Value?.ToString().ToLower() ?? "";
                string email = row.Cells["colEmail"].Value?.ToString().ToLower() ?? "";

                row.Visible = name.Contains(keyword) || email.Contains(keyword);
            }
        }

        // ── Helpers ─────────────────────────────────────────────
        private void ClearPreview()
        {
            txtName.Text = "";
            txtEmail.Text = "";
            txtContact.Text = "";
            txtMessage.Text = "";
            dgvContacts.ClearSelection();
        }
    }
}