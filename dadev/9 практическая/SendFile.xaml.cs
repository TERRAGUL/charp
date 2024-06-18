using System.Net;
using System.Net.Mail;
using System.Windows;
using System.Windows.Controls;

namespace _9_практическая
{
    public partial class SendFile : Window
    {
        public SendFile()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string smtp = ((ComboBoxItem)MailCMBX.SelectedItem).Content.ToString();

            switch (smtp)
            {
                case "Mail":
                    smtp = "smtp.mail.ru";
                    break;
                case "Google":
                    smtp = "smtp.google.com";
                    break;
                case "Yandex":
                    smtp = "smtp.yandex.ru";
                    break;
                case "Rambler":
                    smtp = "smtp.rambler.ru";
                    break;
            }
            MailMessage message = new MailMessage(From.Text, To.Text, Subject.Text, "отправлен файлик из приложения!");
            message.Attachments.Add(new Attachment(Path.path));
            SmtpClient client = new SmtpClient(smtp);
            client.Credentials = new NetworkCredential(From.Text, Pass.Password);
            client.EnableSsl = true;
            client.Send(message);
        }
    }
}
