namespace Jaaron_Stupid_app
{
    partial class AreYouOK
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
            this.yes1Button = new System.Windows.Forms.Button();
            this.yes2Button = new System.Windows.Forms.Button();
            this.questionTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // yes1Button
            // 
            this.yes1Button.Location = new System.Drawing.Point(28, 64);
            this.yes1Button.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.yes1Button.Name = "yes1Button";
            this.yes1Button.Size = new System.Drawing.Size(50, 30);
            this.yes1Button.TabIndex = 0;
            this.yes1Button.Text = "YES!";
            this.yes1Button.UseVisualStyleBackColor = true;
            // 
            // yes2Button
            // 
            this.yes2Button.Location = new System.Drawing.Point(119, 64);
            this.yes2Button.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.yes2Button.Name = "yes2Button";
            this.yes2Button.Size = new System.Drawing.Size(50, 31);
            this.yes2Button.TabIndex = 1;
            this.yes2Button.Text = "YES!!";
            this.yes2Button.UseVisualStyleBackColor = true;
            // 
            // questionTextBox
            // 
            this.questionTextBox.Location = new System.Drawing.Point(28, 20);
            this.questionTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.questionTextBox.Name = "questionTextBox";
            this.questionTextBox.ReadOnly = true;
            this.questionTextBox.Size = new System.Drawing.Size(142, 20);
            this.questionTextBox.TabIndex = 2;
            this.questionTextBox.Text = "ARE YOU HAVING FUN???";
            // 
            // AreYouOK
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(210, 131);
            this.Controls.Add(this.questionTextBox);
            this.Controls.Add(this.yes2Button);
            this.Controls.Add(this.yes1Button);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "AreYouOK";
            this.Text = "AreYouOK";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button yes1Button;
        private System.Windows.Forms.Button yes2Button;
        private System.Windows.Forms.TextBox questionTextBox;
    }
}