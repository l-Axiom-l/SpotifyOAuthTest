﻿namespace SpotifyOAuthTest
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.nameBox = new System.Windows.Forms.Label();
            this.searchBox = new System.Windows.Forms.TextBox();
            this.addButton = new System.Windows.Forms.Button();
            this.queueBox = new System.Windows.Forms.TextBox();
            this.nextButton = new System.Windows.Forms.Button();
            this.playStateButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(12, 12);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(168, 171);
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            // 
            // nameBox
            // 
            this.nameBox.Location = new System.Drawing.Point(12, 186);
            this.nameBox.Name = "nameBox";
            this.nameBox.Size = new System.Drawing.Size(168, 29);
            this.nameBox.TabIndex = 1;
            this.nameBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // searchBox
            // 
            this.searchBox.Location = new System.Drawing.Point(186, 12);
            this.searchBox.Name = "searchBox";
            this.searchBox.Size = new System.Drawing.Size(233, 23);
            this.searchBox.TabIndex = 2;
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(186, 41);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(105, 23);
            this.addButton.TabIndex = 3;
            this.addButton.Text = "AddToQueue";
            this.addButton.UseVisualStyleBackColor = true;
            // 
            // queueBox
            // 
            this.queueBox.Location = new System.Drawing.Point(186, 70);
            this.queueBox.Multiline = true;
            this.queueBox.Name = "queueBox";
            this.queueBox.Size = new System.Drawing.Size(233, 145);
            this.queueBox.TabIndex = 4;
            // 
            // nextButton
            // 
            this.nextButton.Location = new System.Drawing.Point(375, 41);
            this.nextButton.Name = "nextButton";
            this.nextButton.Size = new System.Drawing.Size(44, 23);
            this.nextButton.TabIndex = 5;
            this.nextButton.Text = "Next";
            this.nextButton.UseVisualStyleBackColor = true;
            // 
            // playStateButton
            // 
            this.playStateButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.playStateButton.Location = new System.Drawing.Point(297, 41);
            this.playStateButton.Name = "playStateButton";
            this.playStateButton.Size = new System.Drawing.Size(72, 23);
            this.playStateButton.TabIndex = 6;
            this.playStateButton.Text = "Start\\Stop";
            this.playStateButton.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(431, 229);
            this.Controls.Add(this.playStateButton);
            this.Controls.Add(this.nextButton);
            this.Controls.Add(this.queueBox);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.searchBox);
            this.Controls.Add(this.nameBox);
            this.Controls.Add(this.pictureBox);
            this.Name = "Form1";
            this.Text = "AxiomsSpotifyApp";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PictureBox pictureBox;
        private Label nameBox;
        private TextBox searchBox;
        private Button addButton;
        private TextBox queueBox;
        private Button nextButton;
        private Button playStateButton;
    }
}