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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.comboBoxModes = new System.Windows.Forms.ComboBox();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.buttonApply = new System.Windows.Forms.Button();
            this.labelDelay = new System.Windows.Forms.Label();
            this.domainUpDown_Time = new System.Windows.Forms.DomainUpDown();
            this.labelTimer = new System.Windows.Forms.Label();
            this.labelVersion = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // comboBoxModes
            // 
            this.comboBoxModes.FormattingEnabled = true;
            this.comboBoxModes.Items.AddRange(new object[] {
            "Завершение работы",
            "Перезагрузка"});
            this.comboBoxModes.Location = new System.Drawing.Point(12, 35);
            this.comboBoxModes.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxModes.Name = "comboBoxModes";
            this.comboBoxModes.Size = new System.Drawing.Size(286, 21);
            this.comboBoxModes.TabIndex = 4;
            this.comboBoxModes.SelectedIndexChanged += new System.EventHandler(this.comboBoxModes_SelectedIndexChanged);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(12, 75);
            this.progressBar.Margin = new System.Windows.Forms.Padding(2);
            this.progressBar.MarqueeAnimationSpeed = 500;
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(395, 18);
            this.progressBar.Step = 1;
            this.progressBar.TabIndex = 1;
            // 
            // buttonApply
            // 
            this.buttonApply.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonApply.Location = new System.Drawing.Point(302, 11);
            this.buttonApply.Margin = new System.Windows.Forms.Padding(2);
            this.buttonApply.Name = "buttonApply";
            this.buttonApply.Size = new System.Drawing.Size(105, 47);
            this.buttonApply.TabIndex = 2;
            this.buttonApply.Text = "Применить";
            this.buttonApply.UseVisualStyleBackColor = true;
            this.buttonApply.Click += new System.EventHandler(this.buttonApply_Click);
            // 
            // labelDelay
            // 
            this.labelDelay.AutoSize = true;
            this.labelDelay.Location = new System.Drawing.Point(10, 13);
            this.labelDelay.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelDelay.Name = "labelDelay";
            this.labelDelay.Size = new System.Drawing.Size(120, 13);
            this.labelDelay.TabIndex = 3;
            this.labelDelay.Text = "Задержка (мин., сек.):";
            // 
            // domainUpDown_Time
            // 
            this.domainUpDown_Time.Location = new System.Drawing.Point(130, 11);
            this.domainUpDown_Time.Margin = new System.Windows.Forms.Padding(2);
            this.domainUpDown_Time.Name = "domainUpDown_Time";
            this.domainUpDown_Time.Size = new System.Drawing.Size(168, 20);
            this.domainUpDown_Time.TabIndex = 0;
            this.domainUpDown_Time.Text = "domainUpDown1";
            this.domainUpDown_Time.SelectedItemChanged += new System.EventHandler(this.domainUpDown_Time_SelectedItemChanged);
            // 
            // labelTimer
            // 
            this.labelTimer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelTimer.Location = new System.Drawing.Point(11, 99);
            this.labelTimer.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelTimer.Name = "labelTimer";
            this.labelTimer.Size = new System.Drawing.Size(339, 13);
            this.labelTimer.TabIndex = 6;
            this.labelTimer.Text = "Timer";
            // 
            // labelVersion
            // 
            this.labelVersion.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelVersion.Location = new System.Drawing.Point(245, 99);
            this.labelVersion.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelVersion.Name = "labelVersion";
            this.labelVersion.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.labelVersion.Size = new System.Drawing.Size(161, 13);
            this.labelVersion.TabIndex = 7;
            this.labelVersion.Text = "Ver";
            this.labelVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // timer
            // 
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(417, 127);
            this.Controls.Add(this.labelVersion);
            this.Controls.Add(this.labelTimer);
            this.Controls.Add(this.domainUpDown_Time);
            this.Controls.Add(this.labelDelay);
            this.Controls.Add(this.buttonApply);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.comboBoxModes);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
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
        private System.Windows.Forms.DomainUpDown domainUpDown_Time;
        private System.Windows.Forms.Label labelTimer;
        private System.Windows.Forms.Label labelVersion;
        private System.Windows.Forms.Timer timer;
    }
}

