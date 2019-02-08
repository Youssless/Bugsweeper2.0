namespace Bugsweeper {
    partial class GameWindow {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameWindow));
            this.gameBackground = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timerBox = new System.Windows.Forms.TextBox();
            this.flagCounter = new System.Windows.Forms.TextBox();
            this.extBtn = new System.Windows.Forms.Button();
            this.flagBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gameBackground)).BeginInit();
            this.SuspendLayout();
            // 
            // gameBackground
            // 
            this.gameBackground.ErrorImage = null;
            this.gameBackground.Image = ((System.Drawing.Image)(resources.GetObject("gameBackground.Image")));
            this.gameBackground.Location = new System.Drawing.Point(0, -1);
            this.gameBackground.Name = "gameBackground";
            this.gameBackground.Size = new System.Drawing.Size(961, 721);
            this.gameBackground.TabIndex = 0;
            this.gameBackground.TabStop = false;
            this.gameBackground.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // timerBox
            // 
            this.timerBox.Cursor = System.Windows.Forms.Cursors.No;
            this.timerBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timerBox.Location = new System.Drawing.Point(1003, 12);
            this.timerBox.Name = "timerBox";
            this.timerBox.ReadOnly = true;
            this.timerBox.Size = new System.Drawing.Size(228, 62);
            this.timerBox.TabIndex = 1;
            this.timerBox.Text = "00 : 00";
            this.timerBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.timerBox.TextChanged += new System.EventHandler(this.timerBox_TextChanged);
            // 
            // flagCounter
            // 
            this.flagCounter.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.flagCounter.Location = new System.Drawing.Point(1069, 252);
            this.flagCounter.Name = "flagCounter";
            this.flagCounter.Size = new System.Drawing.Size(100, 35);
            this.flagCounter.TabIndex = 3;
            this.flagCounter.Text = "0/20";
            this.flagCounter.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.flagCounter.TextChanged += new System.EventHandler(this.flagCounter_TextChanged);
            // 
            // extBtn
            // 
            this.extBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.extBtn.Location = new System.Drawing.Point(1109, 617);
            this.extBtn.Name = "extBtn";
            this.extBtn.Size = new System.Drawing.Size(143, 61);
            this.extBtn.TabIndex = 6;
            this.extBtn.Text = "Exit";
            this.extBtn.UseVisualStyleBackColor = true;
            // 
            // flagBtn
            // 
            this.flagBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("flagBtn.BackgroundImage")));
            this.flagBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.flagBtn.Location = new System.Drawing.Point(1069, 137);
            this.flagBtn.Name = "flagBtn";
            this.flagBtn.Size = new System.Drawing.Size(100, 93);
            this.flagBtn.TabIndex = 7;
            this.flagBtn.Text = "Flag";
            this.flagBtn.UseVisualStyleBackColor = true;
            this.flagBtn.Click += new System.EventHandler(this.flagBtn_Click);
            // 
            // GameWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 716);
            this.Controls.Add(this.flagBtn);
            this.Controls.Add(this.extBtn);
            this.Controls.Add(this.flagCounter);
            this.Controls.Add(this.timerBox);
            this.Controls.Add(this.gameBackground);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "GameWindow";
            this.Text = "Bugsweeper";
            this.Load += new System.EventHandler(this.GameWindow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gameBackground)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox gameBackground;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox timerBox;
        private System.Windows.Forms.TextBox flagCounter;
        private System.Windows.Forms.Button extBtn;
        private System.Windows.Forms.Button flagBtn;
    }
}

