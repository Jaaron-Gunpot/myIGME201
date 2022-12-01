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
    public partial class AreYouOK : Form
    {
        public AreYouOK(Form owner, int amount)
        {
            InitializeComponent();
            this.Owner = owner;
            for (int i = 0; i < amount; i++)
            {
                InitializeComponent();
            }
            //vAmount = amount;
            this.Owner = owner;
            CenterToParent();

            this.yes1Button.Click += Yes1Button__Click;
            this.yes2Button.Click += new EventHandler(Yes1Button__Click);
        }

        private void Yes1Button__Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            ((Button)sender).Text="OK";
            this.Close();
        }
    }
}
