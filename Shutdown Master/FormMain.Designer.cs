namespace Shutdown_Master
{
    partial class FormMain
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.comboBoxModes = new System.Windows.Forms.ComboBox();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.buttonApply = new System.Windows.Forms.Button();
            this.labelDelay = new System.Windows.Forms.Label();
            this.domainUpDownMins = new System.Windows.Forms.DomainUpDown();
            this.domainUpDownSecs = new System.Windows.Forms.DomainUpDown();
            this.labelTimer = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // comboBoxModes
            // 
            this.comboBoxModes.FormattingEnabled = true;
            this.comboBoxModes.Location = new System.Drawing.Point(15, 44);
            this.comboBoxModes.Name = "comboBoxModes";
            this.comboBoxModes.Size = new System.Drawing.Size(357, 24);
            this.comboBoxModes.TabIndex = 0;
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(15, 94);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(494, 23);
            this.progressBar.TabIndex = 1;
            // 
            // buttonApply
            // 
            this.buttonApply.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonApply.Location = new System.Drawing.Point(378, 12);
            this.buttonApply.Name = "buttonApply";
            this.buttonApply.Size = new System.Drawing.Size(131, 56);
            this.buttonApply.TabIndex = 2;
            this.buttonApply.Text = "Применить";
            this.buttonApply.UseVisualStyleBackColor = true;
            // 
            // labelDelay
            // 
            this.labelDelay.AutoSize = true;
            this.labelDelay.Location = new System.Drawing.Point(12, 16);
            this.labelDelay.Name = "labelDelay";
            this.labelDelay.Size = new System.Drawing.Size(145, 16);
            this.labelDelay.TabIndex = 3;
            this.labelDelay.Text = "Задержка (мин., сек.):";
            // 
            // domainUpDownMins
            // 
            this.domainUpDownMins.Location = new System.Drawing.Point(163, 14);
            this.domainUpDownMins.Name = "domainUpDownMins";
            this.domainUpDownMins.Size = new System.Drawing.Size(99, 22);
            this.domainUpDownMins.TabIndex = 4;
            this.domainUpDownMins.Text = "domainUpDown1";
            // 
            // domainUpDownSecs
            // 
            this.domainUpDownSecs.Location = new System.Drawing.Point(268, 14);
            this.domainUpDownSecs.Name = "domainUpDownSecs";
            this.domainUpDownSecs.Size = new System.Drawing.Size(104, 22);
            this.domainUpDownSecs.TabIndex = 5;
            this.domainUpDownSecs.Text = "domainUpDown1";
            // 
            // labelTimer
            // 
            this.labelTimer.AutoSize = true;
            this.labelTimer.Location = new System.Drawing.Point(15, 124);
            this.labelTimer.Name = "labelTimer";
            this.labelTimer.Size = new System.Drawing.Size(42, 16);
            this.labelTimer.TabIndex = 6;
            this.labelTimer.Text = "Timer";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(521, 159);
            this.Controls.Add(this.labelTimer);
            this.Controls.Add(this.domainUpDownSecs);
            this.Controls.Add(this.domainUpDownMins);
            this.Controls.Add(this.labelDelay);
            this.Controls.Add(this.buttonApply);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.comboBoxModes);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Shutdown Master";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxModes;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Button buttonApply;
        private System.Windows.Forms.Label labelDelay;
        private System.Windows.Forms.DomainUpDown domainUpDownMins;
        private System.Windows.Forms.DomainUpDown domainUpDownSecs;
        private System.Windows.Forms.Label labelTimer;
    }
}

