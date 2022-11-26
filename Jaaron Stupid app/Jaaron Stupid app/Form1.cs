using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using System.IO;

namespace Jaaron_Stupid_app
{
    public delegate void WonkBarDele(int value);
    public partial class mlp4Life : Form
    {
        AreYouOK youOK = new AreYouOK();
        public mlp4Life()
        {
            InitializeComponent();
            pinkiePieButton.MouseEnter += PinkiePieButton__MouseEnter;
            pinkiePieButton.MouseLeave += PinkiePieButton__MouseLeave;
            rarity.MouseEnter += new EventHandler(Rarity__MouseEnter);

            Thread thread;

            ThreadStart thread1 = new ThreadStart(mlp);

            thread = new Thread(thread1);

            thread.Start();
        }
        private void Rarity__MouseEnter(object sender, EventArgs e)
        {

        }
        public void wonkyBar(int value)
        {
            crazyBar.Value = value;
        }
        public void mlp()
        {
            WonkBarDele wonkBar;
            wonkBar = new WonkBarDele(wonkyBar);
            Random random;
            random= new Random();
            while(true)
            {
                int rand=random.Next(0,10);
                if (rand < 6)
                {
                    Invoke(wonkBar, rand);
                }

            }
        }

        private void PinkiePieButton__MouseLeave(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            pinkiePieButton.Visible = true;
        }

        private void PinkiePieButton__MouseEnter(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            pinkiePieButton.Visible= false;
            Random random;
            random = new Random();
            int randX = random.Next(100,500);
            int randY = random.Next(100,250);
            pinkiePieButton.Location = new Point(randX,randY);

            int randForm = random.Next(0,10);
            if (randForm <= 3)
            {
                //SoundPlayer sound = new SoundPlayer(@"C:\Windows\Media\Windows Error.wav");
                //sound.Play();
                Assembly assembly = Assembly.GetExecutingAssembly();
                Stream stream = assembly.GetManifestResourceStream("<Program.CS>.Windows Error.wav");
                SoundPlayer soundPlayer = new SoundPlayer(stream);
                soundPlayer.Play();
                youOK.ShowDialog();
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void trackBar1_Scroll_1(object sender, EventArgs e)
        {

        }
    }
}
