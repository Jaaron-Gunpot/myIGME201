using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jaaron_Stupid_app
{
    public partial class PinkiePie : Form
    {
        
        public PinkiePie(Form owner, int amount)
        {
            InitializeComponent();
            for(int i = 0; i < amount; i++)
            {
                InitializeComponent();
            }
            this.Owner = owner;
            this.ponyPictureBox.ImageLocation = @"Pinkie_Pie.png";
            //makes picture fit into the picture box
            this.ponyPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            this.ponyPictureBox.MouseEnter += new EventHandler(PonyPictureBox__MouseEnter);
            this.ponyPictureBox.MouseLeave += new EventHandler(PonyPictureBox__MouseLeave);
        }
        private void PonyPictureBox__MouseEnter(object sender, EventArgs e)
        {
            ponyPictureBox.ImageLocation = @"SMILE.png";
        }
        private void PonyPictureBox__MouseLeave(object sender, EventArgs e)
        {
            this.ponyPictureBox.ImageLocation = @"Pinkie_Pie.png";
        }
    }
}
