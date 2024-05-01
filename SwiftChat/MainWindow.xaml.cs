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
using System.Text.RegularExpressions;

namespace SwiftChat
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            btConfirm.Visibility = Visibility.Collapsed;
            tbConfirmPassword.Visibility = Visibility.Collapsed;
            btGoBack.Visibility = Visibility.Collapsed;
        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null && textBox.Text == textBox.Tag?.ToString())
            {
                textBox.Text = "";
            }
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null && string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Text = textBox.Tag?.ToString();
            }
        }

        private void btSignUp_Click(object sender, RoutedEventArgs e)
        {
            btSignIn.Visibility = Visibility.Collapsed;
            btSignUp.Visibility = Visibility.Collapsed;
            btConfirm.Visibility = Visibility.Visible;
            btGoBack.Visibility = Visibility.Visible;
            tbConfirmPassword.Visibility = Visibility.Visible;
            lbSignUp.Text = "Sign Up";
        }

        private void btGoBack_Click(object sender, RoutedEventArgs e)
        {
            lbSignUp.Text = "Sign In";
            tbConfirmPassword.Visibility = Visibility.Collapsed;
            btConfirm.Visibility = Visibility.Collapsed;
            btGoBack.Visibility = Visibility.Collapsed;
            btSignUp.Visibility = Visibility.Visible;
            btSignIn.Visibility = Visibility.Visible;
        }

        private void btConfirm_Click(object sender, RoutedEventArgs e)
        {
            lbSignUp.Text = "Sign In";
            tbConfirmPassword.Visibility = Visibility.Collapsed;
            btConfirm.Visibility = Visibility.Collapsed;
            btGoBack.Visibility = Visibility.Collapsed;
            btSignUp.Visibility = Visibility.Visible;
            btSignIn.Visibility = Visibility.Visible;

            // Email validation
            string email = tbEmail.Text;
            if (!IsValidEmail(email))
            {
                lbError.Visibility = Visibility.Visible;
                return;
            }

            // Reset error label visibility if email is valid
            lbError.Visibility = Visibility.Collapsed;
        }

        private void btSignIn_Click(object sender, RoutedEventArgs e)
        {
            // Email validation
            string email = tbEmail.Text;
            if (!IsValidEmail(email))
            {
                lbError.Visibility = Visibility.Visible;
                return;
            }

            // Reset error label visibility if email is valid
            lbError.Visibility = Visibility.Collapsed;

            // Create an instance of the ChatWindow
            ChatWindow chatWindow = new ChatWindow();

            // Show the ChatWindow and hide the current window
            chatWindow.Show();
            this.Hide();
        }

        private bool IsValidEmail(string email)
        {
            string pattern = @"^[a-zA-Z0-9._%+-]+@gmail\.com$";
            Regex regex = new Regex(pattern);
            return regex.IsMatch(email);
        }
    }
}
