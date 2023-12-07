using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Xml.Linq;

namespace פרויקט
{
    /// <summary>
    /// Interaction logic for SecondWindow.xaml
    /// </summary>
    public partial class SecondWindow : Window
    {
        Random random = new Random();
        private int questionCounter = 0;
        private int points =0;
        private DispatcherTimer timer;
        private int timeLeft = 15;


        public SecondWindow(string name2)
        {
            InitializeComponent();
            
            Title.Text = "Player Name: " +name2;
            getRandom();
            getOperator();
            Rank.Text = "Points: " + points.ToString();
            InitializeTimer();

        }
        private void InitializeTimer()
        {
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer_Tick;
            timer.Start();
            UpdateTimerText();
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            timeLeft--;
            UpdateTimerText();

            if (timeLeft <= 0)
            {
                timer.Stop();
                MessageBox.Show("Time's up! Moving to the next question.");
                NextQuestion();
                this.timeLeft += 15;
                ResetTimer();
            }
        }
        private void UpdateTimerText()
        {
            TimerText.Text = $"Time Left: {timeLeft} seconds";
        }
        private void ResetTimer()
        {
            if (timer != null)
            {
                timer.Stop();
                timer.Tick -= Timer_Tick;
            }

            timeLeft = 15; // או כל זמן שתבחר
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        public void getRandom()
        {
            
            int num1 = random.Next(1,11);
            number1.Text = num1.ToString();
            int num2 = random.Next(1,11);
            number2.Text = num2.ToString();

            //--------------------------------------------------
           

           
        }

        private void NextQuestion()
        {
            if (questionCounter < 5)
            {
                getRandom();
                getOperator();
                questionCounter++;
            }
            else
            {
                timer.Stop();
                MessageBox.Show("You've completed all 5 questions!");
                MessageBox.Show("Thank You For Playing!");
                MainWindow ret = new MainWindow();
                this.Close();
                ret.Show();
                // כאן נוכל להוסיף לוגיקה נוספת לסיום המשחק
            }
        }
        public void getOperator()
        {
            string x = random.Next(2) == 0 ? "+" : "-";
            operator1.Text = x;
            operator1.FontSize = 50;
        }


        private void check_Click(object sender, RoutedEventArgs e)
        {
            
            

            try
            {
                int user_ans = int.Parse(Resault.Text);
                
                if (operator1.Text == "+")
                {
                    int correct_ans01 = int.Parse(number1.Text);
                    int correct_ans02 = int.Parse(number2.Text);
                    int correct_ans = correct_ans01+ correct_ans02;

                    if (correct_ans == int.Parse(Resault.Text))
                    {
                        this.points = this.points + 20;
                        Rank.Text = "Points: " + points.ToString();
                        MessageBox.Show("Correct");
                        Resault.Text = "";
                        NextQuestion();
                        this.timeLeft= 0;
                        timeLeft += 15;
                    }
                    else
                    {
                        if (this.points != 0)
                        {
                            this.points = this.points - 20;
                            Rank.Text = "Points: " + points.ToString();
                        }
                        MessageBox.Show("Try Again" + " -20 Points :(");
                    }
                }
                else
                {
                    
                    
                        int correct_ans1 = int.Parse(number1.Text);
                        int correct_ans2 = int.Parse(number2.Text);
                        int finalans = correct_ans1- correct_ans2;
                        if (finalans == int.Parse(Resault.Text))
                        {
                            MessageBox.Show("Correct!");
                            Resault.Text = "";
                            NextQuestion();
                            this.points = this.points + 20;
                            Rank.Text = "Points: " + points.ToString();
                            this.timeLeft = 0;
                            timeLeft += 15;

                        }
                        else
                        {
                            
                            MessageBox.Show("Try Again" + " -20 Points :(");
                            if (this.points != 0)
                            {
                                this.points = this.points -20;
                                Rank.Text = "Points: " + points.ToString();
                            }
                        }

                }
                
            }
          
            catch 
            {
                MessageBox.Show("Please Enter A Vaild Number");
            }
        
        }

        private void Quit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
