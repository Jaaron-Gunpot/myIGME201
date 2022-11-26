using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Net;
using System.IO;
using static System.Net.WebRequestMethods;

namespace Dyscord
{
    public delegate void UpdateConversationDelegate(string text);
    public partial class DyscordForm : Form
    {
        string targetUser;
        string targetIP;
        int targetPort;
        string myIp;
        int myPort=2222;
        Thread thread;
        Socket listener; 

        public DyscordForm()
        {
            InitializeComponent();

            this.Show();

            SettingsForm settingsForm = new SettingsForm(this, myPort);

            settingsForm.ShowDialog();

            this.myPort = settingsForm.myPort;

            ThreadStart threadStart = new ThreadStart(Listen);

            thread = new Thread(threadStart);

            thread.Start();

            IPHostEntry iPHost = Dns.GetHostEntry(Dns.GetHostName());

            this.loginButton.Click += LoginButton__Click;
        }

        private void LoginButton__Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            //webBrowser1= new WebBrowser();
            //webBrowser1.Url = http://people.rit.edu/dxsigm/php/login.php?login= loginTextBox.Text&ip=myIp:myPort;
            loginButton.Enabled = false;
            userTextBox.Enabled = false;
            webBrowser1.Visible = false;
        }

        public void UpdateConversation(string text)
        {
            this.convRichTextBox.Text = text + "\n";
        }

        public void Listen()
        {
            UpdateConversationDelegate updateConversationDelegate;

            updateConversationDelegate = new UpdateConversationDelegate(UpdateConversation);

            IPEndPoint serverEndpoint = new IPEndPoint(IPAddress.Any, this.myPort);

            this.listener = new Socket(AddressFamily.InterNetwork,SocketType.Stream, ProtocolType.Tcp);

            this.listener.Bind(serverEndpoint);

            listener.Listen(300);

            while(true) { 
                Socket client = listener.Accept();
                Stream netStream = new NetworkStream(client);
                StreamReader reader= new StreamReader(netStream);
                string result = reader.ReadToEnd();
                Invoke(updateConversationDelegate, result);
                reader.Close();
                netStream.Close();
                client.Close();
            }
        }
        private void DyscordForm_Load(object sender, EventArgs e)
        {

        }
    }
}
