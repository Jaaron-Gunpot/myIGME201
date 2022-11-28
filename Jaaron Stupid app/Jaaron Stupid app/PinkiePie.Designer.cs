namespace Jaaron_Stupid_app
{
    partial class PinkiePie
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
            this.ponyPictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.ponyPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // ponyPictureBox
            // 
            this.ponyPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ponyPictureBox.Location = new System.Drawing.Point(0, 0);
            this.ponyPictureBox.Name = "ponyPictureBox";
            this.ponyPictureBox.Size = new System.Drawing.Size(800, 450);
            this.ponyPictureBox.TabIndex = 0;
            this.ponyPictureBox.TabStop = false;
            // 
            // PinkiePie
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ponyPictureBox);
            this.Name = "PinkiePie";
            this.Text = "PinkiePie";
            ((System.ComponentModel.ISupportInitialize)(this.ponyPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox ponyPictureBox;
    }
}