using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Jaaron_Stupid_app
{
    public partial class Rarity : Form
    {
        public Rarity()
        {
            InitializeComponent();
            this.spikeTextBox.Click += new EventHandler(SpikeTextBox__Click);
            this.pictureBox1.ImageLocation = @"Rarity1.gif";
            this.pictureBox2.ImageLocation = @"Rarity2.gif";
            this.pictureBox3.ImageLocation = @"Rarity3.gif";
            this.pictureBox4.ImageLocation = @"Rarity4.gif";
            this.pictureBox5.ImageLocation = @"Rarity5.gif";
            this.pictureBox6.ImageLocation = @"Rarity6.gif";
            this.pictureBox7.ImageLocation = @"Rarity7.gif";
            this.pictureBox8.ImageLocation = @"Rarity8.gif";
            this.pictureBox9.ImageLocation = @"Rarity9.gif";
            this.pictureBox10.ImageLocation = @"Rarity10.gif";
            this.pictureBox11.ImageLocation = @"Rarity11.gif";
            this.pictureBox12.ImageLocation = @"Rarity12.gif";
        }
        private void SpikeTextBox__Click(object sender, EventArgs e)
        {
            SoundPlayer spike = new SoundPlayer(@"Spike.wav");
            spike.Play();
            
        }
    }
}
