using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.WebRequestMethods;

namespace President_Copy
{
    public partial class Form1 : Form
    {

        RadioButton[] presidentButton;
        public Form1()
        {
            InitializeComponent();
            try
            {
                Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(
                    @"SOFTWARE\\WOW6432Node\\Microsoft\\Internet Explorer\\MAIN\\FeatureControl\\FEATURE_BROWSER_EMULATION",
                    true);
                key.SetValue(Application.ExecutablePath.Replace(Application.StartupPath + "\\", ""), 12001, Microsoft.Win32.RegistryValueKind.DWord);
                key.Close();
            }
            catch
            {

            }

            progressBar1.Value = progressBar1.Maximum;

            //add event handler for exit button
            this.exitButton.Click += new EventHandler(ExitButton__Click);

            //disable the exit button until the test  is done
            this.exitButton.Enabled = false;

            //navigates to wikipedia in the web browser
            this.webBrowser1.Navigate("https://en.m.wikipedia.org/wiki/Benjamin_Harrison");

            //titles the a default value
            this.webBrowserGroupBox.Text = "https://en.m.wikipedia.org/wiki/Benjamin_Harrison";

            //adds event handler for all the president buttons
            this.benjaminHarrisRadioButton.Click += new EventHandler(PresidentRadioButton__Click);
            this.franklinDRooseveltRadioButton.Click += new EventHandler(PresidentRadioButton__Click);
            this.williamJClintonRadioButton.Click += new EventHandler(PresidentRadioButton__Click);
            this.barackObamaRadioButton.Click += new EventHandler(PresidentRadioButton__Click);
            this.jamesBuchananRadioButton.Click += new EventHandler(PresidentRadioButton__Click);
            this.franklinPierceRadioButton.Click += new EventHandler(PresidentRadioButton__Click);
            this.georgeWBushRadioButton.Click += new EventHandler(PresidentRadioButton__Click);
            this.johnFKennedyRadioButton.Click += new EventHandler(PresidentRadioButton__Click);
            this.williamMcKinleyRadioButton.Click += new EventHandler(PresidentRadioButton__Click);
            this.ronaldReaganRadioButton.Click += new EventHandler(PresidentRadioButton__Click);
            this.dwightDEisenhowerRadioButton.Click += new EventHandler(PresidentRadioButton__Click);
            this.martinVanBurenRadioButton.Click += new EventHandler(PresidentRadioButton__Click);
            this.georgeWashingtonRadioButton.Click += new EventHandler(PresidentRadioButton__Click);
            this.johnAdamsRadioButton.Click += new EventHandler(PresidentRadioButton__Click);
            this.theodoreRooseveltRadioButton.Click += new EventHandler(PresidentRadioButton__Click);
            this.thomasJeffersonRadioButton.Click += new EventHandler(PresidentRadioButton__Click);

            //puts the president buttons in the president array
            presidentButton = new RadioButton[] {this.benjaminHarrisRadioButton,this.franklinDRooseveltRadioButton,this.williamJClintonRadioButton,
            this.barackObamaRadioButton,this.jamesBuchananRadioButton,this.franklinPierceRadioButton,this.georgeWBushRadioButton,this.johnFKennedyRadioButton,
            this.williamMcKinleyRadioButton,this.ronaldReaganRadioButton,this.dwightDEisenhowerRadioButton,this.martinVanBurenRadioButton,this.georgeWashingtonRadioButton,
            this.johnAdamsRadioButton,this.theodoreRooseveltRadioButton,this.thomasJeffersonRadioButton};

            //adds event handler for all the filter buttons
            this.democratFilterRadioButton.Click += new EventHandler(DemocratFilterRadioButton__Click);
            this.democraticRepublicanFilterRadioButton.Click += new EventHandler(DemocraticRepublicanFilterRadioButton__Click);
            this.republicanFilterRadioButton.Click += new EventHandler(RepublicanFilterRadioButton__Click);
            this.federalistFilterRadioButton.Click += new EventHandler(FederalistFilterRadioButton__Click);
            this.allFilterRadioButton.Click += new EventHandler(AllFilterRadioButton__Click);

            //sets default image
            this.pictureBox1.ImageLocation = @"BenjaminHarrison.jpeg";

            //makes picture fit into the picture box
            this.pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

            //loads the default image
            this.pictureBox1.Load();

            //add picture box event handlers to change the size
            this.pictureBox1.MouseEnter += new EventHandler(PictureBox1__MouseEnter);
            this.pictureBox1.MouseLeave += new EventHandler(PictureBox1__MouseLeave);

            //an event handler when the web browser finishes loading
            this.webBrowser1.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(WebBrowser1__DocumentCompleted);
        }

        private void AllFilterRadioButton__Click(object sender, EventArgs e)
        {

        }

        private void FederalistFilterRadioButton__Click(object sender, EventArgs e)
        {

        }

        private void RepublicanFilterRadioButton__Click(object sender, EventArgs e)
        {

        }

        private void DemocraticRepublicanFilterRadioButton__Click(object sender, EventArgs e)
        {

        }

        private void DemocratFilterRadioButton__Click(object sender, EventArgs e)
        {

        }

        //Changes all the anchor tags titles and  changes the groupbox title
        private void WebBrowser1__DocumentCompleted(object sender,  WebBrowserDocumentCompletedEventArgs e)
        {
            //changes the groupbox text to the current url in caes it is not one of the presidents
            string url = this.webBrowser1.Url.ToString();
            this.webBrowserGroupBox.Text = url;

            //gets all the anchor tags on the page
            HtmlElementCollection anchorCollection = this.webBrowser1.Document.GetElementsByTagName("a");

            //changes all the anchor's title's to something else
            foreach(HtmlElement anchor in anchorCollection)
            {
                anchor.SetAttribute("title", "Jaaron is bad at C#");
            }
            //anchorCollection;
        }

        //makes the picture bigger when the mouse hovers over it
        private void PictureBox1__MouseEnter(object sender, EventArgs e)
        {
            this.pictureBox1.Scale((float)1.5);
            Point anchorPoint = new Point(12, 220);
            this.pictureBox1.Location = anchorPoint;
        }

        //reverts the picture back to the original size
        private void PictureBox1__MouseLeave(object sender, EventArgs e)
        {
            Size size = new Size(167, 198);
            this.pictureBox1.Size = size;
            Point point = new Point(12, 220);
            this.pictureBox1.Location = point;
        }

        //exits the form when clicked
        private void ExitButton__Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //generalized click event handler for the radio buttons
        private void PresidentRadioButton__Click(object sender, EventArgs e)
        {
            //makes the url string based on the button clicked
            string url = $"https://en.m.wikipedia.org/wiki/{((RadioButton)sender).Text.Replace(" ", "_")}";

            //sets the group box text to the url and navigates the web browser to the url
            this.webBrowserGroupBox.Text = url;
            this.webBrowser1.Navigate(url);

            //exception for barack obama since it is a png and not a jpeg
            if(((RadioButton)sender).Text.Replace(" ", "") == "BarackObama")
            {
                this.pictureBox1.ImageLocation = $@"{((RadioButton)sender).Text.Replace(" ", "")}.png";
            }
            else
            {
                this.pictureBox1.ImageLocation = $@"{((RadioButton)sender).Text.Replace(" ", "")}.jpeg";
            }
            
            //this.Refresh();


            //titles the group box based on the url
            //this.webBrowserGroupBox.Text = this.webBrowser1.Url.ToString();
        }
    }
}
