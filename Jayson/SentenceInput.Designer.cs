namespace Jayson
{
    partial class SentenceInput
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
            this.inputBox = new System.Windows.Forms.TextBox();
            this.welcomeBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // inputBox
            // 
            this.inputBox.Location = new System.Drawing.Point(3, 19);
            this.inputBox.Name = "inputBox";
            this.inputBox.Size = new System.Drawing.Size(703, 20);
            this.inputBox.TabIndex = 5;
            // 
            // welcomeBox
            // 
            this.welcomeBox.BackColor = System.Drawing.SystemColors.Control;
            this.welcomeBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.welcomeBox.Location = new System.Drawing.Point(3, 3);
            this.welcomeBox.MaxLength = 0;
            this.welcomeBox.Name = "welcomeBox";
            this.welcomeBox.ReadOnly = true;
            this.welcomeBox.Size = new System.Drawing.Size(400, 13);
            this.welcomeBox.TabIndex = 4;
            this.welcomeBox.TabStop = false;
            this.welcomeBox.Text = "Welcome to the Jayson Teacher. Input a sentence and press enter to begin.";
            this.welcomeBox.TextChanged += new System.EventHandler(this.welcomeBox_TextChanged);
            // 
            // sentenceInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.inputBox);
            this.Controls.Add(this.welcomeBox);
            this.Name = "sentenceInput";
            this.Size = new System.Drawing.Size(711, 42);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox inputBox;
        private System.Windows.Forms.TextBox welcomeBox;
    }
}
