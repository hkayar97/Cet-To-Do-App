using System;
using System.Collections.ObjectModel;

namespace CetTodoApp.Data
{
    public static class FakeDb
    {
        public static ObservableCollection<TodoItem> Data { get; } = new ObservableCollection<TodoItem>();

        public static void AddToDo(string title, DateTime dueDate)
        {
            if (!string.IsNullOrWhiteSpace(title))
                Data.Add(new TodoItem(title, dueDate));
        }

        public static void ChageCompletionStatus(TodoItem item)
        {
            if (item != null)
                item.IsComplete = !item.IsComplete;
        }
    }
}
