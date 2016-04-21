namespace PersonalCalendar
{
    partial class ConfirmDeleteForm
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
            this.deleteEventSuccessLabel = new System.Windows.Forms.Label();
            this.confirmButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // deleteEventSuccessLabel
            // 
            this.deleteEventSuccessLabel.AutoSize = true;
            this.deleteEventSuccessLabel.Location = new System.Drawing.Point(72, 18);
            this.deleteEventSuccessLabel.Name = "deleteEventSuccessLabel";
            this.deleteEventSuccessLabel.Size = new System.Drawing.Size(136, 13);
            this.deleteEventSuccessLabel.TabIndex = 0;
            this.deleteEventSuccessLabel.Text = "Event deleted successfully!";
            // 
            // confirmButton
            // 
            this.confirmButton.Location = new System.Drawing.Point(103, 46);
            this.confirmButton.Name = "confirmButton";
            this.confirmButton.Size = new System.Drawing.Size(75, 23);
            this.confirmButton.TabIndex = 1;
            this.confirmButton.Text = "OK";
            this.confirmButton.UseVisualStyleBackColor = true;
            this.confirmButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // ConfirmDeleteForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 81);
            this.Controls.Add(this.confirmButton);
            this.Controls.Add(this.deleteEventSuccessLabel);
            this.Name = "ConfirmDeleteForm";
            this.Text = "ConfirmDeleteForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label deleteEventSuccessLabel;
        private System.Windows.Forms.Button confirmButton;
    }
}