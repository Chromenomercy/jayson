namespace Jayson
{
    partial class TeacherForm
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
            this.sentenceInput = new Jayson.SentenceInput();
            this.SuspendLayout();
            // 
            // sentenceInput
            // 
            this.sentenceInput.Location = new System.Drawing.Point(0, 1);
            this.sentenceInput.Name = "sentenceInput";
            this.sentenceInput.Size = new System.Drawing.Size(711, 42);
            this.sentenceInput.TabIndex = 0;
            // 
            // TeacherForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(710, 44);
            this.Controls.Add(this.sentenceInput);
            this.MaximizeBox = false;
            this.Name = "TeacherForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Jayson Teacher";
            this.Load += new System.EventHandler(this.TeacherForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private SentenceInput sentenceInput;


    }
}