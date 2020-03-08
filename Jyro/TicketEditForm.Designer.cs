namespace Jyro
{
    partial class TicketEditForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblSummary = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblEstimation = new System.Windows.Forms.Label();
            this.lblPriority = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tbxSummary = new System.Windows.Forms.TextBox();
            this.tbxDescription = new System.Windows.Forms.TextBox();
            this.cbxPriority = new System.Windows.Forms.ComboBox();
            this.cbxStatus = new System.Windows.Forms.ComboBox();
            this.nudEstimation = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.nudEstimation)).BeginInit();
            this.SuspendLayout();
            // 
            // lblSummary
            // 
            this.lblSummary.AutoSize = true;
            this.lblSummary.Location = new System.Drawing.Point(76, 38);
            this.lblSummary.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSummary.Name = "lblSummary";
            this.lblSummary.Size = new System.Drawing.Size(67, 17);
            this.lblSummary.TabIndex = 0;
            this.lblSummary.Text = "Summary";
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(76, 85);
            this.lblDescription.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(79, 17);
            this.lblDescription.TabIndex = 2;
            this.lblDescription.Text = "Description";
            // 
            // lblEstimation
            // 
            this.lblEstimation.AutoSize = true;
            this.lblEstimation.Location = new System.Drawing.Point(76, 123);
            this.lblEstimation.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEstimation.Name = "lblEstimation";
            this.lblEstimation.Size = new System.Drawing.Size(73, 17);
            this.lblEstimation.TabIndex = 4;
            this.lblEstimation.Text = "Estimation";
            // 
            // lblPriority
            // 
            this.lblPriority.AutoSize = true;
            this.lblPriority.Location = new System.Drawing.Point(76, 164);
            this.lblPriority.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPriority.Name = "lblPriority";
            this.lblPriority.Size = new System.Drawing.Size(52, 17);
            this.lblPriority.TabIndex = 6;
            this.lblPriority.Text = "Priority";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(76, 208);
            this.lblStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(48, 17);
            this.lblStatus.TabIndex = 8;
            this.lblStatus.Text = "Status";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(79, 273);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 28);
            this.btnSave.TabIndex = 12;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(256, 273);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 28);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // tbxSummary
            // 
            this.tbxSummary.Location = new System.Drawing.Point(212, 35);
            this.tbxSummary.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbxSummary.Name = "tbxSummary";
            this.tbxSummary.Size = new System.Drawing.Size(160, 22);
            this.tbxSummary.TabIndex = 1;
            // 
            // tbxDescription
            // 
            this.tbxDescription.Location = new System.Drawing.Point(212, 77);
            this.tbxDescription.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbxDescription.Name = "tbxDescription";
            this.tbxDescription.Size = new System.Drawing.Size(160, 22);
            this.tbxDescription.TabIndex = 3;
            // 
            // cbxPriority
            // 
            this.cbxPriority.FormattingEnabled = true;
            this.cbxPriority.Items.AddRange(new object[] {
            "Showstopper",
            "High",
            "Normal",
            "Low"});
            this.cbxPriority.Location = new System.Drawing.Point(212, 155);
            this.cbxPriority.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbxPriority.Name = "cbxPriority";
            this.cbxPriority.Size = new System.Drawing.Size(160, 24);
            this.cbxPriority.TabIndex = 7;
            // 
            // cbxStatus
            // 
            this.cbxStatus.FormattingEnabled = true;
            this.cbxStatus.Items.AddRange(new object[] {
            "Backlog",
            "Planned",
            "Done"});
            this.cbxStatus.Location = new System.Drawing.Point(212, 199);
            this.cbxStatus.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbxStatus.Name = "cbxStatus";
            this.cbxStatus.Size = new System.Drawing.Size(160, 24);
            this.cbxStatus.TabIndex = 9;
            // 
            // nudEstimation
            // 
            this.nudEstimation.Location = new System.Drawing.Point(212, 115);
            this.nudEstimation.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.nudEstimation.Name = "nudEstimation";
            this.nudEstimation.Size = new System.Drawing.Size(160, 22);
            this.nudEstimation.TabIndex = 14;
            // 
            // TicketEditForm
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(411, 409);
            this.Controls.Add(this.nudEstimation);
            this.Controls.Add(this.cbxStatus);
            this.Controls.Add(this.cbxPriority);
            this.Controls.Add(this.tbxDescription);
            this.Controls.Add(this.tbxSummary);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.lblPriority);
            this.Controls.Add(this.lblEstimation);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.lblSummary);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "TicketEditForm";
            this.Text = "TicketEditForm";
            ((System.ComponentModel.ISupportInitialize)(this.nudEstimation)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSummary;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblEstimation;
        private System.Windows.Forms.Label lblPriority;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox tbxSummary;
        private System.Windows.Forms.TextBox tbxDescription;
        private System.Windows.Forms.ComboBox cbxPriority;
        private System.Windows.Forms.ComboBox cbxStatus;
        private System.Windows.Forms.NumericUpDown nudEstimation;
    }
}