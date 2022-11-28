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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PinkiePie));
            this.ponyPictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.ponyPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // ponyPictureBox
            // 
            this.ponyPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ponyPictureBox.InitialImage = ((System.Drawing.Image)(resources.GetObject("ponyPictureBox.InitialImage")));
            this.ponyPictureBox.Location = new System.Drawing.Point(0, 0);
            this.ponyPictureBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ponyPictureBox.Name = "ponyPictureBox";
            this.ponyPictureBox.Size = new System.Drawing.Size(533, 292);
            this.ponyPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ponyPictureBox.TabIndex = 0;
            this.ponyPictureBox.TabStop = false;
            // 
            // PinkiePie
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(533, 292);
            this.Controls.Add(this.ponyPictureBox);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "PinkiePie";
            this.Text = "PinkiePie";
            ((System.ComponentModel.ISupportInitialize)(this.ponyPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox ponyPictureBox;
    }
}