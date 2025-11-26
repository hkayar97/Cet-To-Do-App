using System;
using System.ComponentModel;

namespace CetTodoApp.Data
{
    public class TodoItem : INotifyPropertyChanged
    {
        private string title;
        private DateTime dueDate;
        private bool isComplete;
        private bool isOverdue;

        public string Title
        {
            get => title;
            set { title = value; OnPropertyChanged(nameof(Title)); }
        }

        public DateTime DueDate
        {
            get => dueDate;
            set { dueDate = value; OnPropertyChanged(nameof(DueDate)); }
        }

        public bool IsComplete
        {
            get => isComplete;
            set
            {
                if (isComplete != value)
                {
                    isComplete = value;
                    OnPropertyChanged(nameof(IsComplete));
                    IsOverdue = !isComplete && DueDate < DateTime.Now;
                }
            }
        }

        public bool IsOverdue
        {
            get => isOverdue;
            set { isOverdue = value; OnPropertyChanged(nameof(IsOverdue)); }
        }

        public TodoItem(string title, DateTime dueDate)
        {
            Title = title;
            DueDate = dueDate;
            IsComplete = false;
            IsOverdue = !IsComplete && DueDate < DateTime.Now;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
