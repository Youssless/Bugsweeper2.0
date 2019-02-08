namespace Bugsweeper
{
    partial class ExtPopup
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
            this.msgBox = new System.Windows.Forms.TextBox();
            this.pRetryBtn = new System.Windows.Forms.Button();
            this.pExtBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // msgBox
            // 
            this.msgBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.msgBox.Font = new System.Drawing.Font("Computer 7", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.msgBox.Location = new System.Drawing.Point(31, 12);
            this.msgBox.Multiline = true;
            this.msgBox.Name = "msgBox";
            this.msgBox.Size = new System.Drawing.Size(314, 70);
            this.msgBox.TabIndex = 0;
            this.msgBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.msgBox.TextChanged += new System.EventHandler(this.msgBox_TextChanged);
            // 
            // pRetryBtn
            // 
            this.pRetryBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.pRetryBtn.Location = new System.Drawing.Point(31, 103);
            this.pRetryBtn.Name = "pRetryBtn";
            this.pRetryBtn.Size = new System.Drawing.Size(152, 146);
            this.pRetryBtn.TabIndex = 1;
            this.pRetryBtn.Text = "Retry";
            this.pRetryBtn.UseVisualStyleBackColor = true;
            this.pRetryBtn.Click += new System.EventHandler(this.BtnPlayAgain);
            // 
            // pExtBtn
            // 
            this.pExtBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.pExtBtn.Location = new System.Drawing.Point(193, 103);
            this.pExtBtn.Name = "pExtBtn";
            this.pExtBtn.Size = new System.Drawing.Size(152, 146);
            this.pExtBtn.TabIndex = 2;
            this.pExtBtn.Text = "Exit";
            this.pExtBtn.UseVisualStyleBackColor = true;
            this.pExtBtn.Click += new System.EventHandler(this.BtnMainMenu);
            // 
            // ExtPopup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 261);
            this.Controls.Add(this.pExtBtn);
            this.Controls.Add(this.pRetryBtn);
            this.Controls.Add(this.msgBox);
            this.Name = "ExtPopup";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Popup_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox msgBox;
        private System.Windows.Forms.Button pRetryBtn;
        private System.Windows.Forms.Button pExtBtn;
    }
}