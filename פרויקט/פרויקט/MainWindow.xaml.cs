using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace פרויקט
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window
    {
     




        public MainWindow()
        {
            InitializeComponent();
            BitmapImage bitmapImage = new BitmapImage(new Uri("https://i.guim.co.uk/img/media/ac25bfe26598c25c2d1d3f293c0b6f73cd1f50da/0_361_5100_3062/master/5100.jpg?width=700&quality=85&auto=format&fit=max&s=eec1e2dc491fcb10abce1d15bc297e61"));
            this.Background = new ImageBrush(bitmapImage);


        }









        private void txtYourName_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Get the text from the TextBox
            User.Text = "Name :" +txtYourName.Text;
           
        }

        private void btnContinue_Click(object sender, RoutedEventArgs e)
        {
            
            
            string name1 = txtYourName.Text;
            
            
          
            if (string.IsNullOrEmpty(name1) || string.IsNullOrWhiteSpace(name1))
            {
                
                MessageBox.Show("Please Enter Your Name.");

            }
            else
            {
                try
                {
                    string firstLetter = name1.Substring(0, 1);
                    string restOfTheString = name1.Substring(1);
                    firstLetter = firstLetter.ToUpper();
                    string name = firstLetter + restOfTheString;






                    SecondWindow name2= new SecondWindow(name);
                    name2.Show();

                    Application.Current.MainWindow.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }


            }
        }

        private void Quit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
