using System.Windows.Forms;
using System.Drawing;
namespace Chronicle.Facilities.Buildings
{
    partial class BuildingHourForm
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
            openTime = new DateTimePicker();
            closeTime = new DateTimePicker();
            dayOfWeek = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            effDate = new DateTimePicker();
            label3 = new Label();
            button1 = new Button();
            button2 = new Button();
            SuspendLayout();
            // 
            // openTime
            // 
            openTime.CustomFormat = "hh:mm tt";
            openTime.Format = DateTimePickerFormat.Custom;
            openTime.ImeMode = ImeMode.NoControl;
            openTime.Location = new Point(115, 98);
            openTime.Name = "openTime";
            openTime.ShowUpDown = true;
            openTime.Size = new Size(73, 23);
            openTime.TabIndex = 0;
            // 
            // closeTime
            // 
            closeTime.CustomFormat = "hh:mm tt";
            closeTime.Format = DateTimePickerFormat.Custom;
            closeTime.ImeMode = ImeMode.NoControl;
            closeTime.Location = new Point(212, 98);
            closeTime.Name = "closeTime";
            closeTime.ShowUpDown = true;
            closeTime.Size = new Size(73, 23);
            closeTime.TabIndex = 1;
            // 
            // dayOfWeek
            // 
            dayOfWeek.FormattingEnabled = true;
            dayOfWeek.Items.AddRange(new object[] { "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday" });
            dayOfWeek.Location = new Point(115, 69);
            dayOfWeek.Name = "dayOfWeek";
            dayOfWeek.Size = new Size(170, 23);
            dayOfWeek.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(36, 72);
            label1.Name = "label1";
            label1.Size = new Size(73, 15);
            label1.TabIndex = 3;
            label1.Text = "Day of Week";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(23, 104);
            label2.Name = "label2";
            label2.Size = new Size(86, 15);
            label2.TabIndex = 4;
            label2.Text = "Building Hours";
            // 
            // effDate
            // 
            effDate.CustomFormat = "MMM dd, yyyy";
            effDate.Format = DateTimePickerFormat.Custom;
            effDate.Location = new Point(115, 40);
            effDate.Name = "effDate";
            effDate.Size = new Size(170, 23);
            effDate.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(30, 46);
            label3.Name = "label3";
            label3.Size = new Size(79, 15);
            label3.TabIndex = 6;
            label3.Text = "Effective Date";
            // 
            // button1
            // 
            button1.DialogResult = DialogResult.OK;
            button1.Location = new Point(210, 135);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 7;
            button1.Text = "OK";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.DialogResult = DialogResult.Cancel;
            button2.Location = new Point(23, 135);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 8;
            button2.Text = "Cancel";
            button2.UseVisualStyleBackColor = true;
            // 
            // BuildingHourForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(302, 170);
            ControlBox = false;
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label3);
            Controls.Add(effDate);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dayOfWeek);
            Controls.Add(closeTime);
            Controls.Add(openTime);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "BuildingHourForm";
            Text = "BuildingHourForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DateTimePicker openTime;
        private DateTimePicker closeTime;
        private ComboBox dayOfWeek;
        private Label label1;
        private Label label2;
        private DateTimePicker effDate;
        private Label label3;
        private Button button1;
        private Button button2;
    }
}