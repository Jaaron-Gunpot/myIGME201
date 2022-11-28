﻿using System;
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
        SoundPlayer player=new SoundPlayer(@"MLP.wav");
        AreYouOK youOK = new AreYouOK();
        public mlp4Life()
        {
            InitializeComponent();
            pinkiePieButton.MouseEnter += PinkiePieButton__MouseEnter;
            pinkiePieButton.MouseLeave += PinkiePieButton__MouseLeave;
            this.pinkiePieButton.BringToFront();
            rarity.MouseEnter += new EventHandler(Rarity__MouseEnter);
            this.rarity.Click += new EventHandler(Rarity__Click);
            this.rainbowDashButton.Click += new EventHandler(RainbowDashButton__Click);

            ThreadStart thread1 = new ThreadStart(Mlp);

            player.PlayLooping();

            thread = new Thread(thread1);
            this.FormClosing += new FormClosingEventHandler(Mlp4Life__FormClosing);
            thread.Start();

            this.timerBar.Visible = false;
            this.timerBar.Value = this.timerBar.Maximum;

            this.deathTimer.Interval = 1000;
            this.deathTimer.Tick += new EventHandler(DeathTimer__Tick);
            this.deathTimer.Start();
        }

        private void DeathTimer__Tick(object sender, EventArgs e)
        {
            --this.timerBar.Value;
            if (this.timerBar.Value==0)
            {
                this.deathTimer.Stop();
                Random random= new Random();
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
            rainbowDash.Show();
        }

        public void AnnoyingMusic()
        {
            
        }
        public void Mlp()
        {
            MLPRepeat mlp;
            mlp = new MLPRepeat(AnnoyingMusic);
            //Random random;
            //random= new Random();

            while(true)
            {
                //try
                //{
                //    Invoke(mlp);
                //    Thread.Sleep(160000);
                //}
                //catch
                //{
                //    Thread.Sleep(10);
                //}
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
                //soundPlayer.
                if(randForm == 1)
                {
                    PinkiePie pinkie = new PinkiePie(this);
                    pinkie.Show();
                }
                soundPlayer.Play();
                try
                {
                    youOK.Show();
                }
                catch
                {
                    AreYouOK youOK2= new AreYouOK();
                    youOK2.Show();
                }
            }
        }
    }
}
