namespace PersonalCalendar
{
    partial class ConfirmSaveForm
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
            this.confirmSaveMessageLabel = new System.Windows.Forms.Label();
            this.confirmButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // confirmSaveMessageLabel
            // 
            this.confirmSaveMessageLabel.AutoSize = true;
            this.confirmSaveMessageLabel.Location = new System.Drawing.Point(76, 9);
            this.confirmSaveMessageLabel.Name = "confirmSaveMessageLabel";
            this.confirmSaveMessageLabel.Size = new System.Drawing.Size(134, 13);
            this.confirmSaveMessageLabel.TabIndex = 0;
            this.confirmSaveMessageLabel.Text = "Event Saved Successfully!";
            // 
            // confirmButton
            // 
            this.confirmButton.Location = new System.Drawing.Point(101, 43);
            this.confirmButton.Name = "confirmButton";
            this.confirmButton.Size = new System.Drawing.Size(75, 23);
            this.confirmButton.TabIndex = 1;
            this.confirmButton.Text = "OK";
            this.confirmButton.UseVisualStyleBackColor = true;
            this.confirmButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // ConfirmSaveForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 88);
            this.Controls.Add(this.confirmButton);
            this.Controls.Add(this.confirmSaveMessageLabel);
            this.Name = "ConfirmSaveForm";
            this.Text = "ConfirmSaveForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label confirmSaveMessageLabel;
        private System.Windows.Forms.Button confirmButton;
    }
}