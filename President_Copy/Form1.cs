using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Configuration;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.WebRequestMethods;

namespace President_Copy
{
    public partial class Form1 : Form
    {
        //makes a delegate signature
        public delegate void PresChecker();
           
        //initializes some useful arrays and a thread to check the text boxes
        RadioButton[] presidentButton;
        TextBox[] presidentTextBoxes;
        Thread thread;
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

            //fills the timer to max at the start
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

            //adds republicans as a property in accessible description to be read later
            this.benjaminHarrisRadioButton.AccessibleDescription = "Republican";
            this.georgeWBushRadioButton.AccessibleDescription = "Republican";
            this.williamMcKinleyRadioButton.AccessibleDescription = "Republican";
            this.ronaldReaganRadioButton.AccessibleDescription = "Republican";
            this.dwightDEisenhowerRadioButton.AccessibleDescription = "Republican";
            this.theodoreRooseveltRadioButton.AccessibleDescription = "Republican";

            //adds democrats as a property in accessible description to be read later
            this.franklinDRooseveltRadioButton.AccessibleDescription = "Democrat";
            this.jamesBuchananRadioButton.AccessibleDescription = "Democrat";
            this.williamJClintonRadioButton.AccessibleDescription = "Democrat";
            this.franklinPierceRadioButton.AccessibleDescription = "Democrat";
            this.barackObamaRadioButton.AccessibleDescription = "Democrat";
            this.johnFKennedyRadioButton.AccessibleDescription = "Democrat";
            this.martinVanBurenRadioButton.AccessibleDescription = "Democrat";

            //makes thomas jefferson the Democratic-Republican to be read later
            this.thomasJeffersonRadioButton.AccessibleDescription = "Democratic-Republican";

            //adds federalist to accessible description to be read later
            this.georgeWashingtonRadioButton.AccessibleDescription = "Federalist";
            this.johnAdamsRadioButton.AccessibleDescription = "Federalist";

            //adds numbers for the text boxes
            this.benjaminHarrisonTextBox.Tag = 23;
            this.franklinDRooseveltTextBox.Tag = 32;
            this.williamJClintonTextBox.Tag = 42;
            this.jamesBuchananTextBox.Tag = 15;
            this.franklinPierceTextBox.Tag = 14;
            this.georgeWBushTextBox.Tag = 43;
            this.barackObamaTextBox.Tag = 44;
            this.johnFKennedyTextBox.Tag = 35;
            this.williamMcKinleyTextBox.Tag = 25;
            this.ronaldReaganTextBox.Tag = 40;
            this.dwightDEisenhowerTextBox.Tag = 34;
            this.martinVanBurenTextBox.Tag = 8;
            this.georgeWashingtonTextBox.Tag = 1;
            this.johnAdamsTextBox.Tag = 2;
            this.theodoreRooseveltTextBox.Tag = 26;
            this.thomasJeffersonTextbox.Tag = 3;

            //puts the textboxes into an array to make later things easier
            presidentTextBoxes = new TextBox[] { this.benjaminHarrisonTextBox, this.franklinDRooseveltTextBox, this.williamJClintonTextBox,
            this.jamesBuchananTextBox, this.franklinPierceTextBox,this.georgeWBushTextBox,this.barackObamaTextBox, this.johnFKennedyTextBox,
            this.williamMcKinleyTextBox,this.ronaldReaganTextBox,this.dwightDEisenhowerTextBox,this.martinVanBurenTextBox,this.georgeWashingtonTextBox,
            this.johnAdamsTextBox,this.theodoreRooseveltTextBox,this.thomasJeffersonTextbox};

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

            //this.benjaminHarrisonTextBox.KeyPress += new KeyPressEventHandler(BenjaminHarrisonTextBox__KeyPress);

            //adds the error for wrong number for the text boxes and key press event handlers
            foreach (TextBox textBox in presidentTextBoxes)
            {
                textBox.Validating += new CancelEventHandler(TextBox__Validating);
                textBox.KeyPress += new KeyPressEventHandler(TextBox__KeyPress);
            }
            //this.benjaminHarrisonTextBox.Validating += new CancelEventHandler(BenjaminHarrisonTextBox__Validating);

            //adds tick event handler
            this.timer1.Tick += new EventHandler(Timer1__Tick);

            //sets up the checking thread
            ThreadStart threadStart = new ThreadStart(Checker);

            thread = new Thread(threadStart);

            //starts the checking thread
            thread.Start();
        }

        //plays firework video and stops timer and enables exit button
        public void Celebrate()
        {
            thread.Abort();
            this.timer1.Stop();
            this.exitButton.Enabled = true;
            try
            {
                this.webBrowser1.Navigate("https://www.youtube.com/embed/18212B4yfLg?autoplay=1");
            }
            catch
            {

            }
        }

        //a thread used to check if the text boxes are correct
        private void Checker()
        {
            //delegate method to invoke when they are correct
            PresChecker presChecker;

            presChecker = new PresChecker(Celebrate);

            while (true)
            {
                //the correct gets reset every loop
                int correct = 0;

                foreach (TextBox textBox in presidentTextBoxes)
                {
                    if(textBox.Text == textBox.Tag.ToString())
                    {
                        //if a text box is correct, increment the correct counter
                        correct++;
                    }
                    //if they are all correct, invoke the delegate method
                    if (correct == 16)
                    {
                        Invoke(presChecker);
                    }
                }
            }  
        }

        //prevent the user from leaving the text box if they put a wrong awnser
        private void TextBox__Validating(object sender, CancelEventArgs e)
        {
            //if they input the incorrect number and it is not 0, prevent them from using another control
            if(((TextBox)sender).Tag.ToString() != ((TextBox)sender).Text && ((TextBox)sender).Text != "0")
            {
                errorProvider1.SetError((TextBox)sender,"That is the wrong number");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.Dispose();
                e.Cancel = false;
            }
        }

        //The timer decreasing over time
        private void Timer1__Tick(object sender, EventArgs e)
        {
            //decrement the progress bar
            --this.progressBar1.Value;

            //happens when timer becomes ends
            if (this.progressBar1.Value == 0)
            {
                this.timer1.Stop();
                //resets the timer
                this.progressBar1.Value = this.progressBar1.Maximum;
                //resets the text boxes to 0
                foreach(TextBox textBox in presidentTextBoxes)
                {
                    textBox.Text = "0";
                }
            }
        }

        private void TextBox__KeyPress(object sender, KeyPressEventArgs e)
        {
            //filters to only allow digits and backspaces to be entered
            if (Char.IsDigit(e.KeyChar) || e.KeyChar == '\b')
            {
                //we do not handle it and .NET lets the key go through
                e.Handled = false;
                this.timer1.Interval = 1000;
                //start the timer
                this.timer1.Start();
            }
            else
            {
                //we do handle it and do nothing so it is ignored
                e.Handled = true;
            }
        }

        //returns the president buttons back to normal
        private void AllFilterRadioButton__Click(object sender, EventArgs e)
        {
            foreach(RadioButton radio in presidentButton)
            {
                radio.Enabled = true;
                radio.Visible = true;
                //radio.Text = radio.AccessibleName;
            }
        }

        //filters to have only the federalists
        private void FederalistFilterRadioButton__Click(object sender, EventArgs e)
        {
            foreach (RadioButton radio in presidentButton)
            {
                radio.Enabled = true;
                radio.Visible = true;
                //if they are not federalist, hide and disable the button
                if (radio.AccessibleDescription != "Federalist")
                {
                    radio.Enabled = false;
                    radio.Visible = false;
                }
            }
        }

        private void RepublicanFilterRadioButton__Click(object sender, EventArgs e)
        {
            foreach (RadioButton radio in presidentButton)
            {
                radio.Enabled = true;
                radio.Visible = true;
                //if they are not Republican, hide and disable the button
                if (radio.AccessibleDescription != "Republican")
                {
                    radio.Enabled = false;
                    radio.Visible = false;
                }
            }
        }

        private void DemocraticRepublicanFilterRadioButton__Click(object sender, EventArgs e)
        {
            foreach (RadioButton radio in presidentButton)
            {
                radio.Enabled = true;
                radio.Visible = true;
                //if they are not Democratic-Republican, hide and disable the button
                if (radio.AccessibleDescription != "Democratic-Republican")
                {
                    radio.Enabled = false;
                    radio.Visible = false;
                }
            }
        }

        private void DemocratFilterRadioButton__Click(object sender, EventArgs e)
        {
            foreach (RadioButton radio in presidentButton)
            {
                radio.Enabled = true;
                radio.Visible = true;
                //if they are not Democrat, hide and disable the button
                if (radio.AccessibleDescription != "Democrat")
                {
                    radio.Enabled = false;
                    radio.Visible = false;
                }
            }
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
