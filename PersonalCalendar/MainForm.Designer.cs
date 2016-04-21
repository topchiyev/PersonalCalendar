namespace PersonalCalendar
{
    partial class MainForm
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
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.eventListBox = new System.Windows.Forms.ListBox();
            this.deleteEventButton = new System.Windows.Forms.Button();
            this.editEventButton = new System.Windows.Forms.Button();
            this.addEventButton = new System.Windows.Forms.Button();
            this.viewEventButton = new System.Windows.Forms.Button();
            this.allEventsButton = new System.Windows.Forms.Button();
            this.eventsForDayLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Location = new System.Drawing.Point(194, 18);
            this.monthCalendar1.MaxSelectionCount = 1;
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 0;
            this.monthCalendar1.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar1_DateChanged);
            // 
            // eventListBox
            // 
            this.eventListBox.FormattingEnabled = true;
            this.eventListBox.Location = new System.Drawing.Point(12, 31);
            this.eventListBox.Name = "eventListBox";
            this.eventListBox.Size = new System.Drawing.Size(167, 303);
            this.eventListBox.TabIndex = 2;
            this.eventListBox.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // deleteEventButton
            // 
            this.deleteEventButton.Location = new System.Drawing.Point(224, 221);
            this.deleteEventButton.Name = "deleteEventButton";
            this.deleteEventButton.Size = new System.Drawing.Size(170, 23);
            this.deleteEventButton.TabIndex = 3;
            this.deleteEventButton.Text = "Delete Event";
            this.deleteEventButton.UseVisualStyleBackColor = true;
            this.deleteEventButton.Click += new System.EventHandler(this.deleteEventButton_Click);
            // 
            // editEventButton
            // 
            this.editEventButton.Location = new System.Drawing.Point(224, 250);
            this.editEventButton.Name = "editEventButton";
            this.editEventButton.Size = new System.Drawing.Size(170, 23);
            this.editEventButton.TabIndex = 4;
            this.editEventButton.Text = "Edit Event";
            this.editEventButton.UseVisualStyleBackColor = true;
            this.editEventButton.Click += new System.EventHandler(this.editEventButton_Click);
            // 
            // addEventButton
            // 
            this.addEventButton.Location = new System.Drawing.Point(224, 192);
            this.addEventButton.Name = "addEventButton";
            this.addEventButton.Size = new System.Drawing.Size(170, 23);
            this.addEventButton.TabIndex = 5;
            this.addEventButton.Text = "Add Event";
            this.addEventButton.UseVisualStyleBackColor = true;
            this.addEventButton.Click += new System.EventHandler(this.addEventButton_Click);
            // 
            // viewEventButton
            // 
            this.viewEventButton.Location = new System.Drawing.Point(224, 279);
            this.viewEventButton.Name = "viewEventButton";
            this.viewEventButton.Size = new System.Drawing.Size(170, 23);
            this.viewEventButton.TabIndex = 6;
            this.viewEventButton.Text = "View Event";
            this.viewEventButton.UseVisualStyleBackColor = true;
            this.viewEventButton.Click += new System.EventHandler(this.viewEventButton_Click);
            // 
            // allEventsButton
            // 
            this.allEventsButton.Location = new System.Drawing.Point(224, 308);
            this.allEventsButton.Name = "allEventsButton";
            this.allEventsButton.Size = new System.Drawing.Size(170, 23);
            this.allEventsButton.TabIndex = 8;
            this.allEventsButton.Text = "All Events For Selected Month";
            this.allEventsButton.UseVisualStyleBackColor = true;
            this.allEventsButton.Click += new System.EventHandler(this.allEventsButton_Click);
            // 
            // eventsForDayLabel
            // 
            this.eventsForDayLabel.AutoSize = true;
            this.eventsForDayLabel.Location = new System.Drawing.Point(9, 15);
            this.eventsForDayLabel.Name = "eventsForDayLabel";
            this.eventsForDayLabel.Size = new System.Drawing.Size(88, 13);
            this.eventsForDayLabel.TabIndex = 9;
            this.eventsForDayLabel.Text = "Events for Today";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(457, 353);
            this.Controls.Add(this.eventsForDayLabel);
            this.Controls.Add(this.allEventsButton);
            this.Controls.Add(this.viewEventButton);
            this.Controls.Add(this.addEventButton);
            this.Controls.Add(this.editEventButton);
            this.Controls.Add(this.deleteEventButton);
            this.Controls.Add(this.eventListBox);
            this.Controls.Add(this.monthCalendar1);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.ListBox eventListBox;
        private System.Windows.Forms.Button deleteEventButton;
        private System.Windows.Forms.Button editEventButton;
        private System.Windows.Forms.Button addEventButton;
        private System.Windows.Forms.Button viewEventButton;
        private System.Windows.Forms.Button allEventsButton;
        private System.Windows.Forms.Label eventsForDayLabel;
    }
}

