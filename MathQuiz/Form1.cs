using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MathQuiz
{
    public partial class Form1 : Form
    {
        /// Create a Random object called randomizer
        /// to generate random numbers.
        Random randomizer = new Random();
        /// These integer variables will store the numbers
        /// for addition problem
        int addend1;
        int addend2;

        //These integers store values for the subtraction problem
        int minuend;
        int subtrahend;

        //fill for multiplication
        int multiplicand;
        int multiplier;

        //fill in for division problem
        int dividend;
        int divisor;

        //This interger variable keeps track of the remaining time
        int timeLeft;


public void StartTheQuiz()
        {
            //generate the twpo random numbers for add
            //store the values ina addend1& 2
            addend1 = randomizer.Next(51);
            addend2 = randomizer.Next(52);

            // Convert the two generated numbers to strings for label controls
            plusLeftLabel.Text = addend1.ToString();
            plusRighLabel.Text = addend2.ToString();
            // set sum control to zero
            sum.Value = 0;

            // fill for the subtraction end
            minuend = randomizer.Next(1, 101);
            subtrahend = randomizer.Next(1, minuend);
            minusLeftLabel.Text = minuend.ToString();
            minusRightLabel.Text = subtrahend.ToString();
            difference.Value = 0;

            //fill for the multiplication end
            multiplicand = randomizer.Next(2, 11);
            multiplier = randomizer.Next(2, 11);
            timesLeftLabel.Text = multiplicand.ToString();
            timesRightLabel.Text = multiplier.ToString();
            product.Value = 0;

            //fill for the multiplication end
            divisor = randomizer.Next(2, 11);
            int temporaryQuotient = randomizer.Next(2, 11);
            dividend = divisor * temporaryQuotient;
            divideLeftLabel.Text = dividend.ToString();
            divideRightLabel.Text = divisor.ToString();
            quotient.Value = 0;

            //Start the timer.
            timeLeft = 30;
            timeLabel.Text = " 30 seconds";
            timer1.Start();

        }

        public Form1()
        {
            InitializeComponent();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            StartTheQuiz();
            startButton.Enabled = false;
        }

        private bool CheckTheAnswer()
        {
            if ((addend1 + addend2 == sum.Value )
               && (minuend-subtrahend==difference.Value)
                && (multiplicand * multiplier==product.Value)
                && (dividend / divisor == quotient.Value))

                return true;
            else
                return false;

        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (CheckTheAnswer())
            {
                //if checktheAnswer() returns true, then the user got the answer
                //right, stop the timer and message box
                timer1.Stop();
                MessageBox.Show("You got all the answers right!", "Congratulations");
                startButton.Enabled = true;
            }  
            else if (timeLeft>0)
            {
                //if CheckTheAnswer return false, keep counting dopwn
                //display the new time left
                // by updating the time left label
                timeLeft--;
                timeLabel.Text = timeLeft + " seconds";
            }
            else {
                // if the user runs out of time, stop the timer, show a message box, and fill the answers.
                timer1.Stop();
                timeLabel.Text = "Time's Up!";
                MessageBox.Show("You didn't finish in time.", "Sorry");
                sum.Value = addend1 + addend2;
                difference.Value = minuend - subtrahend;
                product.Value = multiplicand * multiplier;
                quotient.Value = dividend / divisor;
                timeLabel.BackColor = BackColor;
                startButton.Enabled = true;
            }
            if (timeLeft <= 5)
            {
                timeLabel.BackColor = Color.Red;
            }
        }

        private void answer_Enter(object sender, EventArgs e)
        {
            //Select the whole answer in the NumericUpdown control
            NumericUpDown answerBox = sender as NumericUpDown;
            if (answerBox!= null)
            {
                int lengthOfAnswer = answerBox.Value.ToString().Length;
                answerBox.Select(0, lengthOfAnswer);
            }
        }

        private void checkIfRight1(object sender, EventArgs e)
        {
            if (startButton.Enabled == false)
            {
                if (sum.Value == addend1 + addend2)
                {
                    System.Media.SystemSounds.Exclamation.Play();
                }
                else if (sum.Value != 0)
                {
                    System.Media.SystemSounds.Beep.Play();
                }
            }
         }
    }

}
