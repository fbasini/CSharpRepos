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
            txtResults = new TextBox();
            statusStrip = new StatusStrip();
            systemStaus = new ToolStripStatusLabel();
            lblResults = new Label();
            statusStrip.SuspendLayout();
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
            txtApi.Location = new Point(123, 106);
            txtApi.Margin = new Padding(2);
            txtApi.Name = "txtApi";
            txtApi.Size = new Size(828, 34);
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
            // txtResults
            // 
            txtResults.BackColor = Color.White;
            txtResults.BorderStyle = BorderStyle.FixedSingle;
            txtResults.Location = new Point(74, 229);
            txtResults.Margin = new Padding(2);
            txtResults.Multiline = true;
            txtResults.Name = "txtResults";
            txtResults.ReadOnly = true;
            txtResults.ScrollBars = ScrollBars.Both;
            txtResults.Size = new Size(942, 330);
            txtResults.TabIndex = 4;
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
            lblResults.Size = new Size(72, 28);
            lblResults.TabIndex = 6;
            lblResults.Text = "Results";
            // 
            // Dashboard
            // 
            AutoScaleDimensions = new SizeF(11F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1100, 630);
            Controls.Add(lblResults);
            Controls.Add(statusStrip);
            Controls.Add(txtResults);
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
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblFormHeader;
        private Label lblApi;
        private TextBox txtApi;
        private Button btnCallApi;
        private TextBox txtResults;
        private StatusStrip statusStrip;
        private Label lblResults;
        private ToolStripStatusLabel systemStaus;
    }
}
