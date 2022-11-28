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
        public PinkiePie(Form owner)
        {
            InitializeComponent();
            this.Owner = owner;
            this.ponyPictureBox.ImageLocation = @"Pinkie_Pie.png";
            //makes picture fit into the picture box
            this.ponyPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
        }
    }
}
