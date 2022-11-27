using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dyscord
{
    public partial class SettingsForm : Form
    {
        public int myPort;

        public SettingsForm(Form owner, int nPort)
        {
            InitializeComponent();

            this.Owner= owner;
            this.CenterToParent();
            this.myPort= nPort;
            this.ListenerTextBox.Text=nPort.ToString();
            this.ListenerTextBox.KeyPress += new KeyPressEventHandler(listenerTextBox__KeyPress);
            this.startButton.Click += new EventHandler(startButton__Click);

        }

        private void startButton__Click(object sender, EventArgs e)
        {
            this.myPort = int.Parse(this.ListenerTextBox.Text);
            this.Close();
        }
        private void listenerTextBox__KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) || e.KeyChar == '\b')
            {
                //we do not handle it
                e.Handled = false;
            }
            else
            {
                //we do handle it
                e.Handled = true;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
