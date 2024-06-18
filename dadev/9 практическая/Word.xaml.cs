using System.IO;
using System.Windows;
using System.Windows.Documents;
using Microsoft.Win32;
using Spire.Doc;

namespace _9_практическая
{
    public partial class Word : Window
    {
        public Word()
        {
            InitializeComponent();
            if (Path.path != null)
            {
                Document doc = new Document();
                doc.LoadFromFile(Path.path);
                doc.SaveToFile("конвертировали.rtf", FileFormat.Rtf);

                var range = new TextRange(rtb.Document.ContentStart, rtb.Document.ContentEnd);
                var fs = new FileStream("конвертировали.rtf", FileMode.OpenOrCreate);
                range.Load(fs, DataFormats.Rtf);
                fs.Close();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Word|*.docx";
            if (saveFileDialog.ShowDialog() == true)
            {
                Path.path = saveFileDialog.FileName;

                var range = new TextRange(rtb.Document.ContentStart, rtb.Document.ContentEnd);
                var fs = new FileStream("конвертировали.rtf", FileMode.Create);
                range.Save(fs, DataFormats.Rtf);
                fs.Close();

                Document d = new Document();
                d.LoadFromFile("конвертировали.rtf");
                d.SaveToFile(Path.path, FileFormat.Docx);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (Path.path == null)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Word|*.docx";
                if (saveFileDialog.ShowDialog() == true)
                {
                    Path.path = saveFileDialog.FileName;

                    var range = new TextRange(rtb.Document.ContentStart, rtb.Document.ContentEnd);
                    var fs = new FileStream("конвертировали.rtf", FileMode.Create);
                    range.Save(fs, DataFormats.Rtf);
                    fs.Close();

                    Document d = new Document();
                    d.LoadFromFile("конвертировали.rtf");
                    d.SaveToFile(Path.path, FileFormat.Docx);

                    SendFile sendFile = new SendFile();
                    sendFile.Show();
                }
            }
            else
            {
                SendFile sendFile = new SendFile();
                sendFile.Show();
            }
        }
    }
}
