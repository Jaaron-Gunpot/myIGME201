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
    public delegate void MLPRepeat();
    public partial class mlp4Life : Form
    {
        public Thread thread;
        AreYouOK youOK = new AreYouOK();
        public mlp4Life()
        {
            InitializeComponent();
            pinkiePieButton.MouseEnter += PinkiePieButton__MouseEnter;
            pinkiePieButton.MouseLeave += PinkiePieButton__MouseLeave;
            this.pinkiePieButton.BringToFront();
            rarity.MouseEnter += new EventHandler(Rarity__MouseEnter);

            ThreadStart thread1 = new ThreadStart(Mlp);

            thread = new Thread(thread1);
            this.FormClosing += new FormClosingEventHandler(Mlp4Life__FormClosing);
            thread.Start();
        }

        private void Mlp4Life__FormClosing(object sender, FormClosingEventArgs e)
        {
            //throw new NotImplementedException();
            thread.Abort();
        }

        private void Rarity__MouseEnter(object sender, EventArgs e)
        {

        }
        public void AnnoyingMusic()
        {
            SoundPlayer MLP= new SoundPlayer(@"MLP.wav");
            MLP.Play();
        }
        public void Mlp()
        {
            MLPRepeat mlp;
            mlp = new MLPRepeat(AnnoyingMusic);
            Random random;
            random= new Random();

            while(true)
            {
                Invoke(mlp);
                Thread.Sleep(160000);
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

            int randMove = random.Next(0, 10);
            if (randMove <= 7)
            {
                pinkiePieButton.Location = new Point(randX, randY);
                pinkiePieButton.Visible= true;
            }

            int randForm = random.Next(0,10);
            if (randForm <= 3)
            {
                //SoundPlayer sound = new SoundPlayer(@"C:\Windows\Media\Windows Error.wav");
                //sound.Play();
                //Assembly assembly = Assembly.GetExecutingAssembly();
                //Stream stream = assembly.GetManifestResourceStream("<Program.CS>.Windows Error.wav");
                SoundPlayer soundPlayer = new SoundPlayer(@"Error.wav");
                soundPlayer.
                soundPlayer.Play();
                youOK.Show();
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

        private void trackBar2_Scroll(object sender, EventArgs e)
        {

        }
    }
}
