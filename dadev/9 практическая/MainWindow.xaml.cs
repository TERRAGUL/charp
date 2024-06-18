using Microsoft.Win32;
using System.Windows;

namespace _9_практическая
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Word word = new Word();
            word.Show();
            Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                Path.path = openFileDialog.FileName;
                Word word = new Word();
                word.Show();
                Close();
            }
        }
    }
}