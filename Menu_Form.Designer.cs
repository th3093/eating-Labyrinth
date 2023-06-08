namespace eatingAtlabyrinth
{
    partial class Menu_Form
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
            this.b_start = new System.Windows.Forms.Button();
            this.b_auto = new System.Windows.Forms.Button();
            this.b_exit = new System.Windows.Forms.Button();
            this.p_preview = new System.Windows.Forms.PictureBox();
            this.p_title = new System.Windows.Forms.PictureBox();
            this.b_labChange = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.p_preview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.p_title)).BeginInit();
            this.SuspendLayout();
            // 
            // b_start
            // 
            this.b_start.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.b_start.Location = new System.Drawing.Point(304, 12);
            this.b_start.Name = "b_start";
            this.b_start.Size = new System.Drawing.Size(197, 42);
            this.b_start.TabIndex = 0;
            this.b_start.Text = "New Game";
            this.b_start.UseVisualStyleBackColor = true;
            this.b_start.Click += new System.EventHandler(this.b_start_Click);
            // 
            // b_auto
            // 
            this.b_auto.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.b_auto.Location = new System.Drawing.Point(304, 75);
            this.b_auto.Name = "b_auto";
            this.b_auto.Size = new System.Drawing.Size(197, 42);
            this.b_auto.TabIndex = 1;
            this.b_auto.Text = "Bot Game";
            this.b_auto.UseVisualStyleBackColor = true;
            this.b_auto.Click += new System.EventHandler(this.b_auto_Click);
            // 
            // b_exit
            // 
            this.b_exit.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.b_exit.Location = new System.Drawing.Point(304, 296);
            this.b_exit.Name = "b_exit";
            this.b_exit.Size = new System.Drawing.Size(197, 42);
            this.b_exit.TabIndex = 3;
            this.b_exit.Text = "Exit";
            this.b_exit.UseVisualStyleBackColor = true;
            this.b_exit.Click += new System.EventHandler(this.b_exit_Click);
            // 
            // p_preview
            // 
            this.p_preview.BackgroundImage = global::eatingAtlabyrinth.Properties.Resources.preview;
            this.p_preview.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.p_preview.Location = new System.Drawing.Point(12, 107);
            this.p_preview.Name = "p_preview";
            this.p_preview.Size = new System.Drawing.Size(267, 230);
            this.p_preview.TabIndex = 5;
            this.p_preview.TabStop = false;
            // 
            // p_title
            // 
            this.p_title.BackgroundImage = global::eatingAtlabyrinth.Properties.Resources.Title;
            this.p_title.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.p_title.Location = new System.Drawing.Point(15, 12);
            this.p_title.Name = "p_title";
            this.p_title.Size = new System.Drawing.Size(265, 84);
            this.p_title.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.p_title.TabIndex = 4;
            this.p_title.TabStop = false;
            // 
            // b_labChange
            // 
            this.b_labChange.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.b_labChange.Location = new System.Drawing.Point(304, 221);
            this.b_labChange.Name = "b_labChange";
            this.b_labChange.Size = new System.Drawing.Size(197, 42);
            this.b_labChange.TabIndex = 6;
            this.b_labChange.Text = "Change Labyrinth";
            this.b_labChange.UseVisualStyleBackColor = true;
            this.b_labChange.Click += new System.EventHandler(this.b_labChange_Click);
            // 
            // Menu_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InfoText;
            this.ClientSize = new System.Drawing.Size(513, 350);
            this.Controls.Add(this.b_labChange);
            this.Controls.Add(this.p_preview);
            this.Controls.Add(this.p_title);
            this.Controls.Add(this.b_exit);
            this.Controls.Add(this.b_auto);
            this.Controls.Add(this.b_start);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Menu_Form";
            this.Text = "Eating @ Labyrinth";
            ((System.ComponentModel.ISupportInitialize)(this.p_preview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.p_title)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button b_start;
        private System.Windows.Forms.Button b_auto;
        private System.Windows.Forms.Button b_exit;
        private System.Windows.Forms.PictureBox p_title;
        private System.Windows.Forms.PictureBox p_preview;
        private System.Windows.Forms.Button b_labChange;
    }
}