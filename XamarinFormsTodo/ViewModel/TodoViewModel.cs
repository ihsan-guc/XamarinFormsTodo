using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;
using XamarinFormsTodo.Model;

namespace XamarinFormsTodo.ViewModel
{
    public class TodoViewModel : NotifyPropertyChanged
    {
        private int id;
        public int Id
        {
            get { return id; }
            set { id = value; OnPropertyChanged(); }
        }
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; OnPropertyChanged(); }
        }
        private bool done;
        public bool Done
        {
            get { return done; }
            set { done = value; OnPropertyChanged(); }
        }
        public TodoViewModel()
        {
            TodoData.Add(new Todo() { Id = 1, Done = true, Name = "Meyve" });
            todoAdd = new Command(AddTodo);
            todoDone = new Command(DoneTodo);
        }
        private ObservableCollection<Todo> todoData;
        public ObservableCollection<Todo> TodoData
        {
            get
            {
                if (todoData == null)
                    return todoData = new ObservableCollection<Todo>();
                return todoData;
            }
            set { todoData = value; }
        }
        public ICommand todoAdd;
        public ICommand TodoAdd
        {
            get { return todoAdd; }
            set { todoAdd = value; OnPropertyChanged(); }
        }
        public ICommand todoDone;
        public ICommand TodoDone
        {
            get { return todoDone; }
            set { todoDone = value; OnPropertyChanged(); }
        }
        public void AddTodo()
        {
            var todo = new Todo
            {
                Id = todoData.Count + 1,
                Done = Done,
                Name = name,
            };
            todoData.Add(todo);
            App.Current.MainPage.DisplayAlert("Message", "Item Add :" + todo.Name, "Ok");
        }
        public void DoneTodo(object data)
        {
            Todo todo = (Todo)data;
            if (todo != null)
            {
                App.Current.MainPage.DisplayAlert("Message", "Item Done :" + todo.Name, "Ok");
                todo.Done = true;
            }
        }
    }
}
