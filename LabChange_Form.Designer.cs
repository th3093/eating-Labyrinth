namespace eatingAtlabyrinth
{
    partial class LabChange_Form
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
            this.b_back = new System.Windows.Forms.Button();
            this.t_dateiName = new System.Windows.Forms.TextBox();
            this.b_openFileDialog = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.b_change = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // b_back
            // 
            this.b_back.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.b_back.Location = new System.Drawing.Point(12, 160);
            this.b_back.Name = "b_back";
            this.b_back.Size = new System.Drawing.Size(197, 42);
            this.b_back.TabIndex = 2;
            this.b_back.Text = "Zurück";
            this.b_back.UseVisualStyleBackColor = true;
            this.b_back.Click += new System.EventHandler(this.b_back_Click);
            // 
            // t_dateiName
            // 
            this.t_dateiName.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.t_dateiName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.t_dateiName.Location = new System.Drawing.Point(12, 55);
            this.t_dateiName.Name = "t_dateiName";
            this.t_dateiName.ReadOnly = true;
            this.t_dateiName.Size = new System.Drawing.Size(271, 29);
            this.t_dateiName.TabIndex = 3;
            this.t_dateiName.Text = "maze.dat";
            this.t_dateiName.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // b_openFileDialog
            // 
            this.b_openFileDialog.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.b_openFileDialog.Location = new System.Drawing.Point(304, 53);
            this.b_openFileDialog.Name = "b_openFileDialog";
            this.b_openFileDialog.Size = new System.Drawing.Size(137, 31);
            this.b_openFileDialog.TabIndex = 4;
            this.b_openFileDialog.Text = "Wähle Datei";
            this.b_openFileDialog.UseVisualStyleBackColor = true;
            this.b_openFileDialog.Click += new System.EventHandler(this.b_openFileDialog_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // b_change
            // 
            this.b_change.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.b_change.Location = new System.Drawing.Point(304, 160);
            this.b_change.Name = "b_change";
            this.b_change.Size = new System.Drawing.Size(197, 42);
            this.b_change.TabIndex = 5;
            this.b_change.Text = "Öffnen";
            this.b_change.UseVisualStyleBackColor = true;
            this.b_change.Click += new System.EventHandler(this.b_change_Click);
            // 
            // LabChange_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(513, 214);
            this.Controls.Add(this.b_change);
            this.Controls.Add(this.b_openFileDialog);
            this.Controls.Add(this.t_dateiName);
            this.Controls.Add(this.b_back);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "LabChange_Form";
            this.Text = "Eating @ Labyrinth";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button b_back;
        private System.Windows.Forms.TextBox t_dateiName;
        private System.Windows.Forms.Button b_openFileDialog;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button b_change;
    }
}