namespace Dyscord
{
    partial class SettingsForm
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
            this.startButton = new System.Windows.Forms.Button();
            this.ListenerTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(64, 59);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(125, 47);
            this.startButton.TabIndex = 0;
            this.startButton.Text = "Start Listener";
            this.startButton.UseVisualStyleBackColor = true;
            // 
            // ListenerTextBox
            // 
            this.ListenerTextBox.Location = new System.Drawing.Point(149, 27);
            this.ListenerTextBox.Name = "ListenerTextBox";
            this.ListenerTextBox.Size = new System.Drawing.Size(100, 26);
            this.ListenerTextBox.TabIndex = 1;
            this.ListenerTextBox.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(44, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "ListenerPort:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // SettingsForm
            // 
            this.AcceptButton = this.startButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(293, 152);
            this.ControlBox = false;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ListenerTextBox);
            this.Controls.Add(this.startButton);
            this.Name = "SettingsForm";
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.TextBox ListenerTextBox;
        private System.Windows.Forms.Label label1;
    }
}

