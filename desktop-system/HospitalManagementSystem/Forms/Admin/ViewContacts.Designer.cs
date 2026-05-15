namespace HospitalManagementSystem.Forms.Admin
{
    partial class ViewContacts
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dgvContacts = new System.Windows.Forms.DataGridView();
            this.txtSearch = new MaterialSkin.Controls.MaterialTextBox();
            this.txtName = new MaterialSkin.Controls.MaterialTextBox();
            this.txtEmail = new MaterialSkin.Controls.MaterialTextBox();
            this.txtContact = new MaterialSkin.Controls.MaterialTextBox();
            this.txtMessage = new MaterialSkin.Controls.MaterialTextBox();
            this.btnRefresh = new MaterialSkin.Controls.MaterialButton();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblCount = new System.Windows.Forms.Label();
            this.lblPreview = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvContacts)).BeginInit();
            this.SuspendLayout();

            // ── Form ──────────────────────────────────────────
            this.ClientSize = new System.Drawing.Size(880, 596);
            this.BackColor = System.Drawing.Color.FromArgb(245, 245, 245);

            // ── Title ─────────────────────────────────────────
            this.lblTitle.Text = "Contact Messages";
            this.lblTitle.Font = new System.Drawing.Font("Roboto", 16F,
                                        System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(25, 118, 210);
            this.lblTitle.Location = new System.Drawing.Point(20, 15);
            this.lblTitle.Size = new System.Drawing.Size(280, 35);

            // ── Count Label ───────────────────────────────────
            this.lblCount.Text = "Total Messages: 0";
            this.lblCount.Font = new System.Drawing.Font("Roboto", 9F);
            this.lblCount.ForeColor = System.Drawing.Color.Gray;
            this.lblCount.Location = new System.Drawing.Point(20, 52);
            this.lblCount.Size = new System.Drawing.Size(200, 20);

            // ── Search Box ────────────────────────────────────
            this.txtSearch.Hint = "🔍 Search by name or email...";
            this.txtSearch.Location = new System.Drawing.Point(580, 15);
            this.txtSearch.Size = new System.Drawing.Size(280, 48);
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);

            // ── Refresh Button ────────────────────────────────
            this.btnRefresh.Text = "REFRESH";
            this.btnRefresh.Location = new System.Drawing.Point(750, 55);
            this.btnRefresh.Size = new System.Drawing.Size(110, 36);
            this.btnRefresh.Type = MaterialSkin.Controls.MaterialButton
                                         .MaterialButtonType.Text;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);

            // ── DataGridView ──────────────────────────────────
            this.dgvContacts.Location = new System.Drawing.Point(20, 80);
            this.dgvContacts.Size = new System.Drawing.Size(840, 270);
            this.dgvContacts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvContacts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvContacts.MultiSelect = false;
            this.dgvContacts.ReadOnly = true;
            this.dgvContacts.AllowUserToAddRows = false;
            this.dgvContacts.BackgroundColor = System.Drawing.Color.White;
            this.dgvContacts.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvContacts.RowHeadersVisible = false;
            this.dgvContacts.Font = new System.Drawing.Font("Roboto", 9F);
            this.dgvContacts.SelectionChanged += new System.EventHandler(
                                                     this.dgvContacts_SelectionChanged);

            // ── Columns ───────────────────────────────────────
            // contact: name | email | contact | message
            this.dgvContacts.Columns.Add(new System.Windows.Forms.DataGridViewTextBoxColumn
            { Name = "colName", HeaderText = "Name", FillWeight = 15 });
            this.dgvContacts.Columns.Add(new System.Windows.Forms.DataGridViewTextBoxColumn
            { Name = "colEmail", HeaderText = "Email", FillWeight = 25 });
            this.dgvContacts.Columns.Add(new System.Windows.Forms.DataGridViewTextBoxColumn
            { Name = "colContact", HeaderText = "Contact", FillWeight = 15 });
            this.dgvContacts.Columns.Add(new System.Windows.Forms.DataGridViewTextBoxColumn
            { Name = "colMessage", HeaderText = "Message", FillWeight = 45 });

            // ── Preview Section Label ─────────────────────────
            this.lblPreview.Text = "── Message Preview ──────────────────────────";
            this.lblPreview.Font = new System.Drawing.Font("Roboto", 9F,
                                          System.Drawing.FontStyle.Bold);
            this.lblPreview.ForeColor = System.Drawing.Color.FromArgb(25, 118, 210);
            this.lblPreview.Location = new System.Drawing.Point(20, 362);
            this.lblPreview.Size = new System.Drawing.Size(840, 20);

            // ── Preview Fields ────────────────────────────────
            int previewY1 = 390;
            int previewY2 = 450;

            this.txtName.Hint = "Name";
            this.txtName.Location = new System.Drawing.Point(20, previewY1);
            this.txtName.Size = new System.Drawing.Size(200, 48);
            this.txtName.Enabled = false;

            this.txtEmail.Hint = "Email";
            this.txtEmail.Location = new System.Drawing.Point(230, previewY1);
            this.txtEmail.Size = new System.Drawing.Size(260, 48);
            this.txtEmail.Enabled = false;

            this.txtContact.Hint = "Contact No.";
            this.txtContact.Location = new System.Drawing.Point(500, previewY1);
            this.txtContact.Size = new System.Drawing.Size(200, 48);
            this.txtContact.Enabled = false;

            this.txtMessage.Hint = "Message";
            this.txtMessage.Location = new System.Drawing.Point(20, previewY2);
            this.txtMessage.Size = new System.Drawing.Size(840, 48);
            this.txtMessage.Enabled = false;
            this.txtMessage.Multiline = true;

            // ── Add Controls ──────────────────────────────────
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblCount);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.dgvContacts);
            this.Controls.Add(this.lblPreview);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtContact);
            this.Controls.Add(this.txtMessage);

            ((System.ComponentModel.ISupportInitialize)(this.dgvContacts)).EndInit();
            this.ResumeLayout(false);
        }

        // ── Control Declarations ──────────────────────────────
        private System.Windows.Forms.DataGridView dgvContacts;
        private MaterialSkin.Controls.MaterialTextBox txtSearch;
        private MaterialSkin.Controls.MaterialTextBox txtName;
        private MaterialSkin.Controls.MaterialTextBox txtEmail;
        private MaterialSkin.Controls.MaterialTextBox txtContact;
        private MaterialSkin.Controls.MaterialTextBox txtMessage;
        private MaterialSkin.Controls.MaterialButton btnRefresh;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.Label lblPreview;
    }
}