
namespace ABulletHellGame
{
    partial class Form1
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
            this._startBtn = new System.Windows.Forms.Button();
            this._gameOverLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // _startBtn
            // 
            this._startBtn.Location = new System.Drawing.Point(12, 12);
            this._startBtn.Name = "_startBtn";
            this._startBtn.Size = new System.Drawing.Size(177, 63);
            this._startBtn.TabIndex = 0;
            this._startBtn.UseVisualStyleBackColor = true;
            // 
            // _gameOverLabel
            // 
            this._gameOverLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._gameOverLabel.Location = new System.Drawing.Point(13, 82);
            this._gameOverLabel.Name = "_gameOverLabel";
            this._gameOverLabel.Size = new System.Drawing.Size(176, 37);
            this._gameOverLabel.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(201, 128);
            this.Controls.Add(this._gameOverLabel);
            this.Controls.Add(this._startBtn);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button _startBtn;
        private System.Windows.Forms.Label _gameOverLabel;
    }
}

