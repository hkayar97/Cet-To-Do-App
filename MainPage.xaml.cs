using CetTodoApp.Data;
using Microsoft.Maui.Controls;
using Microsoft.VisualBasic;
using System;

namespace CetTodoApp
{
    public partial class MainPage : ContentPage
    { 

        public MainPage()
        {
            InitializeComponent();

            FakeDb.AddToDo("Test1", DateTime.Now.AddDays(-1));
            FakeDb.AddToDo("Test2", DateTime.Now.AddDays(1));
            FakeDb.AddToDo("Test3", DateTime.Now);

            TasksListView.ItemsSource = FakeDb.Data;
        }

        private void AddButton_OnClicked(object sender, EventArgs e)
        {
            string title = TitleEntry.Text?.Trim();
            if (string.IsNullOrWhiteSpace(title))
            {
                DisplayAlert("Warning", "Please enter a title.", "OK");
                return;
            }

            FakeDb.AddToDo(title, DueDate.Date);

            TitleEntry.Text = string.Empty;
            DueDate.Date = DateTime.Now;
        }

        private void CheckBox_OnCheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if (sender is CheckBox checkbox && checkbox.BindingContext is TodoItem item)
            {
                item.IsComplete = e.Value;
            }
        }
    }
}
