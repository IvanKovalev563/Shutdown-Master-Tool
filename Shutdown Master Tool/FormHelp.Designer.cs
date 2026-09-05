namespace Shutdown_Master_Tool
{
    partial class FormHelp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormHelp));
            this.buttonOK = new System.Windows.Forms.Button();
            this.labelHelp1 = new System.Windows.Forms.Label();
            this.labelHelp2 = new System.Windows.Forms.Label();
            this.labelHelp3 = new System.Windows.Forms.Label();
            this.picturebBoxScreenshot = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picturebBoxScreenshot)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonOK
            // 
            this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOK.Location = new System.Drawing.Point(608, 525);
            this.buttonOK.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(144, 42);
            this.buttonOK.TabIndex = 0;
            this.buttonOK.Text = "Ок";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // labelHelp1
            // 
            this.labelHelp1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.labelHelp1.AutoSize = true;
            this.labelHelp1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelHelp1.Location = new System.Drawing.Point(18, 335);
            this.labelHelp1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelHelp1.Name = "labelHelp1";
            this.labelHelp1.Size = new System.Drawing.Size(400, 58);
            this.labelHelp1.TabIndex = 2;
            this.labelHelp1.Text = "1) Выберите режим выключения.\r\n\r\n";
            // 
            // labelHelp2
            // 
            this.labelHelp2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.labelHelp2.AutoSize = true;
            this.labelHelp2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelHelp2.Location = new System.Drawing.Point(18, 363);
            this.labelHelp2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelHelp2.Name = "labelHelp2";
            this.labelHelp2.Padding = new System.Windows.Forms.Padding(0, 12, 0, 0);
            this.labelHelp2.Size = new System.Drawing.Size(523, 41);
            this.labelHelp2.TabIndex = 4;
            this.labelHelp2.Text = "2) Установите таймер перед выключением.\r\n";
            // 
            // labelHelp3
            // 
            this.labelHelp3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelHelp3.AutoSize = true;
            this.labelHelp3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelHelp3.Location = new System.Drawing.Point(18, 392);
            this.labelHelp3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelHelp3.Name = "labelHelp3";
            this.labelHelp3.Padding = new System.Windows.Forms.Padding(0, 23, 0, 0);
            this.labelHelp3.Size = new System.Drawing.Size(740, 81);
            this.labelHelp3.TabIndex = 3;
            this.labelHelp3.Text = "3) Нажмите кнопку запуска выключения. \r\nПри нужде отменить выключение - нажмите н" +
    "а неё повторно.";
            // 
            // picturebBoxScreenshot
            // 
            this.picturebBoxScreenshot.Image = global::Shutdown_Master_Tool.Properties.Resources.screenshot_en;
            this.picturebBoxScreenshot.Location = new System.Drawing.Point(24, 23);
            this.picturebBoxScreenshot.Margin = new System.Windows.Forms.Padding(6);
            this.picturebBoxScreenshot.Name = "picturebBoxScreenshot";
            this.picturebBoxScreenshot.Size = new System.Drawing.Size(726, 292);
            this.picturebBoxScreenshot.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picturebBoxScreenshot.TabIndex = 1;
            this.picturebBoxScreenshot.TabStop = false;
            // 
            // FormHelp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 588);
            this.ControlBox = false;
            this.Controls.Add(this.labelHelp2);
            this.Controls.Add(this.labelHelp3);
            this.Controls.Add(this.labelHelp1);
            this.Controls.Add(this.picturebBoxScreenshot);
            this.Controls.Add(this.buttonOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormHelp";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Shutdown Master Tool - Help";
            ((System.ComponentModel.ISupportInitialize)(this.picturebBoxScreenshot)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.PictureBox picturebBoxScreenshot;
        private System.Windows.Forms.Label labelHelp1;
        private System.Windows.Forms.Label labelHelp2;
        private System.Windows.Forms.Label labelHelp3;
    }
}