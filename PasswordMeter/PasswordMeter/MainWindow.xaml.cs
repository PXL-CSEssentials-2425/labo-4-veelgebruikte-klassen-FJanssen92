using System;
using System.Collections.Generic;
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

namespace PasswordMeter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Input velden: userNameTextBox en passwordTextBox
        /// Output veld: resultTextBlock
        /// </summary>

        public MainWindow()
        {
            InitializeComponent();
        }

        private void passwordMeterButton_Click(object sender, RoutedEventArgs e)
        {
            
            string username = userNameTextBox.Text;
            string password = passwordTextBox.Text;

            if (username.Length == 0)
            {
                resultTextBlock.Text = "Gelieve een gebruikersnaam in te geven.";
                return;
            }

            if (password.Length == 0)
            {
                resultTextBlock.Text = "Gelieve een wachtwoord in te geven.";
                return;
            }
            //if (string.IsNullorEmpty(username) || string.IsNullorEmpty(password)

            username = username.Trim();
            password = password.Trim();
            int passwordStrength = 0;

            if (!password.Contains(username))
            {
                passwordStrength++;
                
            }

            if (password.Length >= 10)
            {
                passwordStrength++;
            }

            bool isDigit = false;
            bool hasUpper = false;
            bool hasLower = false;

            foreach (char c in password.ToCharArray())
            {
                
                if (char.IsDigit(c))
                {
                    isDigit = true;

                }

                if (char.IsLower(c))
                {
                    hasLower = true;
                }

                if (char.IsUpper(c))
                {
                    hasUpper = true;
                }


            }

            if (isDigit)
            {
                passwordStrength++;
            }
            if (hasUpper)
            {
                passwordStrength++;
            }
            if (hasLower)
            {
                passwordStrength++;
            }

            switch (passwordStrength)
            {
                case 5:
                    resultTextBlock.Foreground = Brushes.Green;
                    resultTextBlock.Text = ("Sterk wachtwoord!");
                    break;
                case 4:
                    resultTextBlock.Foreground = Brushes.Orange;
                    resultTextBlock.Text = ("OK wachtwoord.");
                    break;
                default:
                    resultTextBlock.Foreground = Brushes.Red;
                    resultTextBlock.Text = ("Slecht wachtwoord!");
                    break;
            }
        }
    }
}
