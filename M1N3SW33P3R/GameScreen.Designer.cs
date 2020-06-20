namespace M1N3SW33P3R
{
    partial class GameScreen
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameScreen));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timerLabel = new System.Windows.Forms.Label();
            this.modeButton = new System.Windows.Forms.Button();
            this.pauseButton = new System.Windows.Forms.Button();
            this.themeButton = new System.Windows.Forms.Button();
            this.endLabel = new System.Windows.Forms.Label();
            this.settingsButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 30;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timerLabel
            // 
            this.timerLabel.Location = new System.Drawing.Point(31, 32);
            this.timerLabel.Name = "timerLabel";
            this.timerLabel.Size = new System.Drawing.Size(158, 46);
            this.timerLabel.TabIndex = 3;
            this.timerLabel.Text = "ert";
            // 
            // modeButton
            // 
            this.modeButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("modeButton.BackgroundImage")));
            this.modeButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.modeButton.FlatAppearance.BorderColor = System.Drawing.Color.Yellow;
            this.modeButton.FlatAppearance.BorderSize = 10;
            this.modeButton.Location = new System.Drawing.Point(342, 3);
            this.modeButton.Name = "modeButton";
            this.modeButton.Size = new System.Drawing.Size(60, 60);
            this.modeButton.TabIndex = 2;
            this.modeButton.UseVisualStyleBackColor = true;
            this.modeButton.Click += new System.EventHandler(this.modeButton_Click);
            // 
            // pauseButton
            // 
            this.pauseButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pauseButton.BackgroundImage")));
            this.pauseButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pauseButton.Location = new System.Drawing.Point(276, 3);
            this.pauseButton.Name = "pauseButton";
            this.pauseButton.Size = new System.Drawing.Size(60, 60);
            this.pauseButton.TabIndex = 1;
            this.pauseButton.UseVisualStyleBackColor = true;
            this.pauseButton.Click += new System.EventHandler(this.pauseButton_Click);
            // 
            // themeButton
            // 
            this.themeButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("themeButton.BackgroundImage")));
            this.themeButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.themeButton.Location = new System.Drawing.Point(210, 3);
            this.themeButton.Name = "themeButton";
            this.themeButton.Size = new System.Drawing.Size(60, 60);
            this.themeButton.TabIndex = 0;
            this.themeButton.UseVisualStyleBackColor = true;
            this.themeButton.Click += new System.EventHandler(this.themeButton_Click);
            // 
            // endLabel
            // 
            this.endLabel.Location = new System.Drawing.Point(271, 327);
            this.endLabel.Name = "endLabel";
            this.endLabel.Size = new System.Drawing.Size(158, 46);
            this.endLabel.TabIndex = 4;
            this.endLabel.Visible = false;
            // 
            // settingsButton
            // 
            this.settingsButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("settingsButton.BackgroundImage")));
            this.settingsButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.settingsButton.FlatAppearance.BorderColor = System.Drawing.Color.Yellow;
            this.settingsButton.FlatAppearance.BorderSize = 10;
            this.settingsButton.Location = new System.Drawing.Point(408, 3);
            this.settingsButton.Name = "settingsButton";
            this.settingsButton.Size = new System.Drawing.Size(60, 60);
            this.settingsButton.TabIndex = 5;
            this.settingsButton.UseVisualStyleBackColor = true;
            // 
            // GameScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.settingsButton);
            this.Controls.Add(this.endLabel);
            this.Controls.Add(this.timerLabel);
            this.Controls.Add(this.modeButton);
            this.Controls.Add(this.pauseButton);
            this.Controls.Add(this.themeButton);
            this.Name = "GameScreen";
            this.Size = new System.Drawing.Size(700, 700);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button themeButton;
        private System.Windows.Forms.Button pauseButton;
        private System.Windows.Forms.Button modeButton;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label timerLabel;
        private System.Windows.Forms.Label endLabel;
        private System.Windows.Forms.Button settingsButton;
    }
}
