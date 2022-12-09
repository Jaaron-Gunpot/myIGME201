using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Math_Quiz_Form
{
    //Prompt for name, maybe use message box
    //if no name entered asks again, maybe use error provider here
    //Prompt for questions, maybe another message box or both in  the same box no apperant maximum
    //Only accepts digits, use error provider here
    //ask for difficulty of questions (easy Meduim hard) maybe a radio button works here
    //if wrong displays "I'm Sorry {name}, the awnser is {awnser} and goes to next question
    //if right displays "Well done {name}!!!
    //both correct and incorrect are in red
    //correct has a blue background
    //asks if want to play again, no closes the app, yes starts from the begininng, only cares about first letter
    //displays score at end in terms of correct out of given and a percent
    public partial class Form1 : Form
    {
        string name;
        int numOfQuestions = 0;
        //default difficulty is easy
        string difficulty = "Easy";
        int timeSeconds = 0;
        Thread thread;

        public delegate void Enable();
        public Form1()
        {
            InitializeComponent();

            //disables start button until everything has been filled
            this.startButton.Enabled = false;

            //thread to only enable button when all required fields are filled
            ThreadStart start = new ThreadStart(DataChecker);

            thread = new Thread(start);

            thread.Start();


            //adding event handlers
            this.startButton.Click += new EventHandler(StartButton__Click);

            this.FormClosed += new FormClosedEventHandler(Form1__FormClosed);

            this.nameTextBox.Validated += new EventHandler(NameTextBox__Validated);

            this.nameTextBox.KeyPress += new KeyPressEventHandler(NameTextBox__KeyPress);

            this.questionsTextBox.Validated += new EventHandler(QuestionsTextBox__Validated);

            this.questionsTextBox.KeyPress += new KeyPressEventHandler(QuestionsTextBox__KeyPress);

            this.timerTextBox.KeyPress += TimerTextBox_KeyPress;

            this.timerTextBox.Validated += TimerTextBox_Validated;

            //since they all do the same thing, the same logic can be applied to all of them
            this.easyRadioButton.Click += new EventHandler(RadioButton__Clicked);

            this.mediumRadioButton.Click += new EventHandler(RadioButton__Clicked);

            this.hardRadioButton.Click += new EventHandler(RadioButton__Clicked);
        }

        //makes the difficulty the same as the text on the button that was clicked
        private void RadioButton__Clicked(object sender, EventArgs e)
        {
            this.difficulty = ((RadioButton)sender).Text;
        }

        //once validated, save the amount of seconds wanted
        private void TimerTextBox_Validated(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            this.timeSeconds = int.Parse(this.timerTextBox.Text);
        }

        //only allow digits or backspaces to be entered
        private void TimerTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            //throw new NotImplementedException();
            if (Char.IsDigit(e.KeyChar) || e.KeyChar == '\b')
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        //only allow digits or backspaces to be entered
        public void QuestionsTextBox__KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) || e.KeyChar == '\b')
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        //once the number validates, saves the number
        public void QuestionsTextBox__Validated(object sender, EventArgs e)
        {
            this.numOfQuestions = int.Parse(this.questionsTextBox.Text);
        }
        //not allow them to enter anything but a digit and backspace
        public void NameTextBox__KeyPress(object sender, KeyPressEventArgs e)
        {
            //only allows letters and backspaces to be visible in the textbox
            if (Char.IsLetter(e.KeyChar)|| e.KeyChar == '\b')
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        //once they leave the text bos the name is saved
        public void NameTextBox__Validated(object sender, EventArgs e)
        {
            this.name = this.nameTextBox.Text;
        }
        //to stop the thread in case the user closes just the first box
        public void Form1__FormClosed(object sender, FormClosedEventArgs e)
        {
            thread.Abort();
        }
        //opens the actual quiz form with all the entered information and hides the prompt form
        public void StartButton__Click(object sender, EventArgs e)
        {
            QuizForm quiz = new QuizForm(this, this.name,this.numOfQuestions,this.difficulty,this.timeSeconds);
            quiz.Show();
            this.Visible = false;
        }

        private void EnableButton()
        {
            thread.Abort();
            this.startButton.Enabled = true;
        }

        //Runs and checks that the required questions have been answered to call a delagate enable the button and turn off the thread
        public void DataChecker()
        {
            Enable enable = new Enable(EnableButton);
            while (true)
            {
                if(this.name!=null && this.name.Length > 0)
                {
                    if(this.numOfQuestions != 0)
                    {
                        if (this.timeSeconds != 0)
                        {
                            Invoke(enable);
                        }   
                    }
                }
            }
        }
    }
}
