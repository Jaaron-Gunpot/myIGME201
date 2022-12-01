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
        Thread checkThread;
        SoundPlayer player=new SoundPlayer(@"MLP.wav");
        AreYouOK youOK;
        Random random = new Random();
        bool[] finished = { false, false, false, false, false, false };
        public mlp4Life()
        {
            InitializeComponent();
            //adds event handlers to move the pinke pie button around sometimes
            pinkiePieButton.MouseEnter += new EventHandler(PinkiePieButton__MouseEnter);
            pinkiePieButton.MouseLeave += new EventHandler(PinkiePieButton__MouseLeave);
            this.pinkiePieButton.BringToFront();
            rarity.MouseEnter += new EventHandler(Rarity__MouseEnter);
            this.rarity.Click += new EventHandler(Rarity__Click);
            this.rainbowDashButton.Click += new EventHandler(RainbowDashButton__Click);
            this.twilightTrackBar.ValueChanged += new EventHandler(TwilightTrackBar__ValueChanged);
            this.pinkiePieTrackBar.ValueChanged += new EventHandler(PinkiePieTrackBar__ValueChanged);
            this.applejackTrackBar.ValueChanged += new EventHandler(ApplejackTrackBar__ValueChanged);
            this.rarityTrackBar.ValueChanged += new EventHandler(RarityTrackBar__ValueChanged);//5
            this.fluttershyTrackBar.ValueChanged += new EventHandler(FluttershyTrackBar__ValueChanged);//6


            ThreadStart thread1 = new ThreadStart(Mlp);
            ThreadStart threadStart = new ThreadStart(Checker);
            checkThread = new Thread(threadStart);
            checkThread.Start();

            player.PlayLooping();

            thread = new Thread(thread1);
            this.FormClosing += new FormClosingEventHandler(Mlp4Life__FormClosing);
            thread.Start();

            this.timerBar.Visible = false;
            this.timerBar.Value = this.timerBar.Maximum;
           
            this.deathTimer.Interval = 1000;
            this.deathTimer.Tick += new EventHandler(DeathTimer__Tick);
            this.deathTimer.Start();

            this.webBrowser1.SendToBack();
            this.webBrowser1.Visible = false;
            //this.webBrowser1.IsWebBrowserContextMenuEnabled = false;
        }

        public void FluttershyTrackBar__ValueChanged(object sender, EventArgs e)
        {
            if (this.fluttershyTrackBar.Value == 6)
            {
                finished[5] = true;
            }
        }

        public void RarityTrackBar__ValueChanged(object sender, EventArgs e)
        {
            if(this.rarityTrackBar.Value == 5)
            {
                finished[4] = true;
            }
        }

        public void ApplejackTrackBar__ValueChanged(object sender, EventArgs e)
        {
            if (applejackTrackBar.Value == 3)
            {
                finished[2] = true;
            }
            else
            {
                PinkiePieButton__MouseEnter(sender, e);
            }
        }

        public void sonicRainBoom()
        {
            this.rainbowDashTrackBar.Value = 4;
            this.rainbowDashTrackBar.Enabled = false;
            finished[3] = true;
        }

        public void Finish()
        {
            thread.Abort();
            checkThread.Abort();
            this.webBrowser1.BringToFront();
            this.webBrowser1.Visible = true;
            this.webBrowser1.Navigate("https://www.youtube.com/watch?v=DOmdB7D-pUU");
            //this.webBrowser1.IsWebBrowserContextMenuEnabled = false;
        }

        private void Checker()
        {
            MLPRepeat finish;

            finish = new MLPRepeat(Finish);

            while (true)
            {
                int corrected = 0;
                foreach(bool correct in finished)
                {
                    if (correct)
                    {
                        corrected++;
                    }
                    if(corrected == 6)
                    {
                        Invoke(finish);
                    }
                }
            }
        }

        private void PinkiePieTrackBar__ValueChanged(object sender, EventArgs e)
        {
            if(this.pinkiePieTrackBar.Value == 2)
            {
                finished[this.pinkiePieTrackBar.Value - 1] = true;
                this.pinkiePieTrackBar.Visible = false;
            }
        }

        private void TwilightTrackBar__ValueChanged(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if(this.twilightTrackBar.Value == 1)
            {
                finished[this.twilightTrackBar.Value - 1] = true;
                this.timerBar.Enabled = false;
            }
            if (random.Next(1, 10) >= 6)
            {
                this.twilightTrackBar.Value=random.Next(2, 6);
            }
        }

        private void DeathTimer__Tick(object sender, EventArgs e)
        {
            --this.timerBar.Value;
            if (this.timerBar.Value==0)
            {
                this.deathTimer.Stop();
               
                if (random.Next(10) >= 2)
                {
                    this.Close();
                }
                else
                {
                    this.timerBar.Value = this.timerBar.Maximum;
                    this.deathTimer.Start();
                }
            }
        }

        private void Rarity__Click(object sender, EventArgs e)
        {
            Rarity rarity = new Rarity();
            
            rarity.Show();
        }

        private void Mlp4Life__FormClosing(object sender, FormClosingEventArgs e)
        {
            //throw new NotImplementedException();
            thread.Abort();
            checkThread.Abort();
            player.Stop();
        }

        private void Rarity__MouseEnter(object sender, EventArgs e)
        {
            SoundPlayer laugh = new SoundPlayer(@"Rarity.wav");
            laugh.Play();
            Thread.Sleep(3000);
            player.PlayLooping();
        }

        private void RainbowDashButton__Click(object sender, EventArgs e)
        {
            RainbowDash rainbowDash = new RainbowDash();
            sonicRainBoom();
            rainbowDash.Show();
        }

        public void Annoying()
        {
            if (random.Next(1, 10) >= 7)
            {
                player.Play();
            }

            this.BackColor = Color.FromArgb(random.Next(1, 255), random.Next(1, 255), random.Next(1, 255));
        }

        public void PinkBar()
        {
            this.pinkiePieTrackBar.Value = random.Next(1, 6);
        }
        
        public void Mlp()
        {
            MLPRepeat mLPRepeat;

            MLPRepeat pinkBar;

            pinkBar = new MLPRepeat(PinkBar);

            mLPRepeat = new MLPRepeat(Annoying);

            while(true)
            {
                try
                {
                    Invoke(pinkBar);
                }
                catch
                {

                }
                try
                {
                    Invoke(mLPRepeat);
                    Thread.Sleep(25000);
                }
                catch
                {
                    Thread.Sleep(10);
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
                //soundPlayer.
                youOK = new AreYouOK(this, random.Next(1, 10));
                if(randForm == 1)
                {
                    PinkiePie pinkie = new PinkiePie(this,random.Next(1,10));
                    pinkie.Show();
                }
                soundPlayer.Play();
                try
                {
                    youOK.Show();
                }
                catch
                {
                    AreYouOK youOK2= new AreYouOK(this, random.Next(1, 10));
                    youOK2.Show();
                }
            }
        }
    }
}
