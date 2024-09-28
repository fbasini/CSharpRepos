namespace PostmanCloneUI
{
    partial class Dashboard
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblFormHeader = new Label();
            lblApi = new Label();
            txtApi = new TextBox();
            btnCallApi = new Button();
            statusStrip = new StatusStrip();
            systemStaus = new ToolStripStatusLabel();
            lblResults = new Label();
            cbHttpVerbSelection = new ComboBox();
            tcCallData = new TabControl();
            bodyTab = new TabPage();
            txtBody = new TextBox();
            resultsTab = new TabPage();
            txtResults = new TextBox();
            statusStrip.SuspendLayout();
            tcCallData.SuspendLayout();
            bodyTab.SuspendLayout();
            resultsTab.SuspendLayout();
            SuspendLayout();
            // 
            // lblFormHeader
            // 
            lblFormHeader.AutoSize = true;
            lblFormHeader.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblFormHeader.Location = new Point(74, 42);
            lblFormHeader.Margin = new Padding(2, 0, 2, 0);
            lblFormHeader.Name = "lblFormHeader";
            lblFormHeader.Size = new Size(218, 41);
            lblFormHeader.TabIndex = 0;
            lblFormHeader.Text = "Postman Clone";
            // 
            // lblApi
            // 
            lblApi.AutoSize = true;
            lblApi.Location = new Point(74, 109);
            lblApi.Margin = new Padding(2, 0, 2, 0);
            lblApi.Name = "lblApi";
            lblApi.Size = new Size(45, 28);
            lblApi.TabIndex = 1;
            lblApi.Text = "API:";
            // 
            // txtApi
            // 
            txtApi.BorderStyle = BorderStyle.FixedSingle;
            txtApi.Location = new Point(243, 104);
            txtApi.Margin = new Padding(2);
            txtApi.Name = "txtApi";
            txtApi.Size = new Size(708, 34);
            txtApi.TabIndex = 2;
            // 
            // btnCallApi
            // 
            btnCallApi.Location = new Point(955, 106);
            btnCallApi.Margin = new Padding(2);
            btnCallApi.Name = "btnCallApi";
            btnCallApi.Size = new Size(61, 34);
            btnCallApi.TabIndex = 3;
            btnCallApi.Text = "Go";
            btnCallApi.UseVisualStyleBackColor = true;
            btnCallApi.Click += btnCallApi_Click;
            // 
            // statusStrip
            // 
            statusStrip.BackColor = Color.Transparent;
            statusStrip.ImageScalingSize = new Size(20, 20);
            statusStrip.Items.AddRange(new ToolStripItem[] { systemStaus });
            statusStrip.Location = new Point(0, 604);
            statusStrip.Name = "statusStrip";
            statusStrip.Padding = new Padding(1, 0, 9, 0);
            statusStrip.Size = new Size(1100, 26);
            statusStrip.TabIndex = 5;
            statusStrip.Text = "statusStrip1";
            // 
            // systemStaus
            // 
            systemStaus.BackColor = Color.White;
            systemStaus.Name = "systemStaus";
            systemStaus.Size = new Size(50, 20);
            systemStaus.Text = "Ready";
            // 
            // lblResults
            // 
            lblResults.AutoSize = true;
            lblResults.Location = new Point(74, 177);
            lblResults.Name = "lblResults";
            lblResults.Size = new Size(0, 28);
            lblResults.TabIndex = 6;
            // 
            // cbHttpVerbSelection
            // 
            cbHttpVerbSelection.BackColor = SystemColors.Window;
            cbHttpVerbSelection.DropDownStyle = ComboBoxStyle.DropDownList;
            cbHttpVerbSelection.FormattingEnabled = true;
            cbHttpVerbSelection.Items.AddRange(new object[] { "GET ", "POST", "PUT", "PATCH", "DELETE" });
            cbHttpVerbSelection.Location = new Point(124, 104);
            cbHttpVerbSelection.Name = "cbHttpVerbSelection";
            cbHttpVerbSelection.Size = new Size(114, 36);
            cbHttpVerbSelection.TabIndex = 7;
            // 
            // tcCallData
            // 
            tcCallData.Controls.Add(bodyTab);
            tcCallData.Controls.Add(resultsTab);
            tcCallData.Location = new Point(74, 159);
            tcCallData.Name = "tcCallData";
            tcCallData.SelectedIndex = 0;
            tcCallData.Size = new Size(942, 423);
            tcCallData.TabIndex = 8;
            // 
            // bodyTab
            // 
            bodyTab.Controls.Add(txtBody);
            bodyTab.Location = new Point(4, 37);
            bodyTab.Name = "bodyTab";
            bodyTab.Padding = new Padding(3);
            bodyTab.Size = new Size(934, 382);
            bodyTab.TabIndex = 0;
            bodyTab.Text = "Body";
            bodyTab.UseVisualStyleBackColor = true;
            // 
            // txtBody
            // 
            txtBody.BackColor = Color.White;
            txtBody.BorderStyle = BorderStyle.FixedSingle;
            txtBody.Dock = DockStyle.Fill;
            txtBody.Location = new Point(3, 3);
            txtBody.Margin = new Padding(2);
            txtBody.Multiline = true;
            txtBody.Name = "txtBody";
            txtBody.ScrollBars = ScrollBars.Both;
            txtBody.Size = new Size(928, 376);
            txtBody.TabIndex = 5;
            // 
            // resultsTab
            // 
            resultsTab.Controls.Add(txtResults);
            resultsTab.Location = new Point(4, 29);
            resultsTab.Name = "resultsTab";
            resultsTab.Padding = new Padding(3);
            resultsTab.Size = new Size(934, 390);
            resultsTab.TabIndex = 1;
            resultsTab.Text = "Results";
            resultsTab.UseVisualStyleBackColor = true;
            // 
            // txtResults
            // 
            txtResults.BackColor = Color.White;
            txtResults.BorderStyle = BorderStyle.FixedSingle;
            txtResults.Dock = DockStyle.Fill;
            txtResults.Location = new Point(3, 3);
            txtResults.Margin = new Padding(2);
            txtResults.Multiline = true;
            txtResults.Name = "txtResults";
            txtResults.ReadOnly = true;
            txtResults.ScrollBars = ScrollBars.Both;
            txtResults.Size = new Size(928, 384);
            txtResults.TabIndex = 5;
            // 
            // Dashboard
            // 
            AutoScaleDimensions = new SizeF(11F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Window;
            ClientSize = new Size(1100, 630);
            Controls.Add(tcCallData);
            Controls.Add(cbHttpVerbSelection);
            Controls.Add(lblResults);
            Controls.Add(statusStrip);
            Controls.Add(btnCallApi);
            Controls.Add(txtApi);
            Controls.Add(lblApi);
            Controls.Add(lblFormHeader);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4, 5, 4, 5);
            Name = "Dashboard";
            Text = "Postman Clone";
            statusStrip.ResumeLayout(false);
            statusStrip.PerformLayout();
            tcCallData.ResumeLayout(false);
            bodyTab.ResumeLayout(false);
            bodyTab.PerformLayout();
            resultsTab.ResumeLayout(false);
            resultsTab.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblFormHeader;
        private Label lblApi;
        private TextBox txtApi;
        private Button btnCallApi;
        private StatusStrip statusStrip;
        private Label lblResults;
        private ToolStripStatusLabel systemStaus;
        private ComboBox cbHttpVerbSelection;
        private TabControl tcCallData;
        private TabPage bodyTab;
        private TextBox txtBody;
        private TabPage resultsTab;
        private TextBox txtResults;
    }
}
