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
using System.IO;
using System.Xml;
using Newtonsoft.Json;
using SerializationLibrary;

namespace блокнот
{
    public partial class MainWindow : Window
    {
        private List<Note> _notes;
        private const string FilePath = "notes.json";

        public MainWindow()
        {
            InitializeComponent();
            _notes = Serializer.Deserialize<Note>(FilePath);
            datePicker.SelectedDate = DateTime.Today;
            UpdateNotesList();
        }

        public class Note
        {
            public string Title { get; set; }
            public string Description { get; set; }
            public DateTime Date { get; set; }
            public int Day { get; set; }
            public int Month { get; set; }
            public int Year { get; set; }
        }

        private void UpdateNotesList()
        {
            var selectedDate = datePicker.SelectedDate ?? DateTime.Today;
            var filteredNotes = _notes.Where(note => note.Date.Date == selectedDate.Date).ToList();
            notesListBox.ItemsSource = filteredNotes;
            notesListBox.DisplayMemberPath = "Title";
        }

        private void Add(object sender, RoutedEventArgs e)
        {
            var title = titleTextBox.Text;
            var description = descriptionTextBox.Text;
            var selectedDate = datePicker.SelectedDate ?? DateTime.Today;

            if (!string.IsNullOrEmpty(title))
            {
                var newNote = new Note
                {
                    Title = title,
                    Description = description,
                    Date = selectedDate,
                    Day = selectedDate.Day,
                    Month = selectedDate.Month,
                    Year = selectedDate.Year
                };

                _notes.Add(newNote);
                UpdateNotesList();
                FileManager.Serialize(FilePath, _notes);
            }
        }

        private void UpdateButton(object sender, RoutedEventArgs e)
        {
            if (notesListBox.SelectedItem != null)
            {
                var selectedNote = (Note)notesListBox.SelectedItem;
                var title = titleTextBox.Text;
                var description = descriptionTextBox.Text;

                selectedNote.Title = title;
                selectedNote.Description = description;

                UpdateNotesList();
                FileManager.Serialize(FilePath, _notes);
            }
        }

        private void DeleteButton(object sender, RoutedEventArgs e)
        {
            if (notesListBox.SelectedItem != null)
            {
                var selectedNote = (Note)notesListBox.SelectedItem;
                _notes.Remove(selectedNote);
                UpdateNotesList();
                FileManager.Serialize(FilePath, _notes);
            }
        }

        private void NotesListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (notesListBox.SelectedItem != null)
            {
                var selectedNote = (Note)notesListBox.SelectedItem;
                titleTextBox.Text = selectedNote.Title;
                descriptionTextBox.Text = selectedNote.Description;
            }
        }
    }
}
