using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

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
    public partial class QuizForm : Form
    {
        string name;
        string difficulty;
        int timeSeconds;

        // constant for setting difficulty with 1 variable
        const int MAX_BASE = 10;

        // question and # correct counters
        int numOfQuestions = 0;
        int nCorrect = 0;

        // operator picker
        int nOp = 0;

        // operands and solution
        int val1 = 0;
        int val2 = 0;
        int nAnswer = 0;

        //a string to hold the awnser
        string awnser;

        //a number to base the difficulty off of
        int nMaxRange = 0;

        // seed the random number generator
        Random rand = new Random();

        public QuizForm(Form owner, string name, int numOfQuestions, string difficulty, int timeSeconds)
        {
            InitializeComponent();
            //keep the placement of the form
            this.Owner = owner;
            CenterToParent();
            //sets the variables based on what the user inputted in the previous form
            this.name = name;
            this.numOfQuestions = numOfQuestions;
            this.difficulty = difficulty;
            this.timeSeconds = timeSeconds;

            //sets the timer to the value that the user set
            this.progressBar1.Maximum = timeSeconds;
            this.progressBar1.Value = this.progressBar1.Maximum;
            this.timer1.Interval = 1000;
            this.timer1.Tick += Timer1_Tick;

            this.Load += QuizForm_Load;

            this.FormClosed += QuizForm_FormClosed;

            this.textBox1.KeyPress += TextBox1_KeyPress;

            //The text changes each time the awnser happens
            this.responseLabel.TextChanged += ResponseLabel_TextChanged;
        }

        private void ResponseLabel_TextChanged(object sender, EventArgs e)
        {
            Thread.Sleep(3000);
        }

        //only allow digits and backspaces in the textbox
        private void TextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) || e.KeyChar == '\b')
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
            //throw new NotImplementedException();
        }

        private void QuizForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            //throw new NotImplementedException();
            this.Owner.Close();
        }

        //sets up the difficulty right when the form loads
        private void QuizForm_Load(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            // if they choose easy, then set nMaxRange = MAX_BASE, unless myName == "David", then set difficulty to hard
            // if they choose medium, set nMaxRange = MAX_BASE * 2
            // if they choose hard, set nMaxRange = MAX_BASE * 3
            switch (this.difficulty.ToLower().Trim())
            {
                case "easy":
                    nMaxRange = MAX_BASE;
                    if (this.name.ToLower() == "david")
                    {
                        goto case "hard";
                    }
                    break;

                case "medium":
                    nMaxRange = MAX_BASE * 2;
                    break;

                case "hard":
                    nMaxRange = MAX_BASE * 3;
                    break;
            }

            // ask each question
            for (int nCntr = 0; nCntr < numOfQuestions; ++nCntr)
            {
                // generate a random number between 0 inclusive and 3 exclusive to get the operation
                nOp = rand.Next(0, 3);

                val1 = rand.Next(0, nMaxRange) + nMaxRange;
                val2 = rand.Next(0, nMaxRange);

                // if either argument is 0, pick new numbers
                if (val1 == 0 || val2 == 0)
                {
                    --nCntr;
                    continue;
                }

                // if nOp == 0, then addition
                if (nOp == 0)
                {
                    nAnswer = val1 + val2;
                    this.questionLabel.Text = $"Question #{nCntr + 1}: {val1} + {val2} => ";
                }
                // if nOp == 1, then subtraction
                else if (nOp == 1)
                {
                    nAnswer = val1 - val2;
                    this.questionLabel.Text = $"Question #{nCntr + 1}: {val1} - {val2} => ";
                }
                // else multiplication
                else
                {
                    nAnswer = val1 * val2;
                    this.questionLabel.Text = $"Question #{nCntr + 1}: {val1} * {val2} => ";
                }


            }
        }
        //decreases the progress bar every second and disables the text box and shows the awnser
        private void Timer1_Tick(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            --this.progressBar1.Value;
            if (this.progressBar1.Value == 0)
            {
                this.timer1.Stop();
                this.textBox1.Enabled = false;
                this.TimeUp();
            }
        }
        private void TimeUp()
        {
            this.awnser = $"the awnser is {this.nAnswer.ToString()}";
            this.responseLabel.Text = this.awnser;
        }
    }
}