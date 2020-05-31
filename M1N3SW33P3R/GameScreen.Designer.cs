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
            this.themeButton = new System.Windows.Forms.Button();
            this.pauseButton = new System.Windows.Forms.Button();
            this.modeButton = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timerLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // themeButton
            // 
            this.themeButton.BackgroundImage = global::M1N3SW33P3R.Properties.Resources.night1;
            this.themeButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.themeButton.Location = new System.Drawing.Point(210, 47);
            this.themeButton.Name = "themeButton";
            this.themeButton.Size = new System.Drawing.Size(50, 50);
            this.themeButton.TabIndex = 0;
            this.themeButton.UseVisualStyleBackColor = true;
            this.themeButton.Click += new System.EventHandler(this.themeButton_Click);
            // 
            // pauseButton
            // 
            this.pauseButton.BackgroundImage = global::M1N3SW33P3R.Properties.Resources.smile;
            this.pauseButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pauseButton.Location = new System.Drawing.Point(286, 47);
            this.pauseButton.Name = "pauseButton";
            this.pauseButton.Size = new System.Drawing.Size(50, 50);
            this.pauseButton.TabIndex = 1;
            this.pauseButton.UseVisualStyleBackColor = true;
            this.pauseButton.Click += new System.EventHandler(this.pauseButton_Click);
            // 
            // modeButton
            // 
            this.modeButton.BackgroundImage = global::M1N3SW33P3R.Properties.Resources.flagBlock;
            this.modeButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.modeButton.Location = new System.Drawing.Point(364, 47);
            this.modeButton.Name = "modeButton";
            this.modeButton.Size = new System.Drawing.Size(50, 50);
            this.modeButton.TabIndex = 2;
            this.modeButton.UseVisualStyleBackColor = true;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timerLabel
            // 
            this.timerLabel.Location = new System.Drawing.Point(32, 60);
            this.timerLabel.Name = "timerLabel";
            this.timerLabel.Size = new System.Drawing.Size(158, 46);
            this.timerLabel.TabIndex = 3;
            this.timerLabel.Text = "ert";
            // 
            // GameScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
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
    }
}
