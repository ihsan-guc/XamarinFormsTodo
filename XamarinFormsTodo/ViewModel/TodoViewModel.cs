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
        public TodoViewModel(ITodoRepository todoRepository)
        {
            todoAdd = new Command(AddTodo);
            todoDone = new Command(DoneTodo);
            TodoRepository = todoRepository;
        }
        public ObservableCollection<Todo> todoList;
        public ObservableCollection<Todo> TodoList
        {
            get
            {
                if (todoList == null)
                    todoList = new ObservableCollection<Todo>();
                return todoList = (TodoRepository.GetTodos());
            }
            set { todoList = value; OnPropertyChanged(); }
        }
        public ITodoRepository  TodoRepository { get; set; }
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
        public ICommand todolistclear;
        public ICommand TodoListClear
        {
            get { return todolistclear; }
            set { todolistclear = value; OnPropertyChanged(); }
        }
        public async void TodoClear()
        {
            var isOk = await App.Current.MainPage.DisplayAlert("Message", "Item Done :", "Ok","Cancel");
            if (isOk)
            {
                TodoRepository.TodoListClear();
            }
        }
        public void AddTodo()
        {
            var todo = new Todo
            {
                Id = TodoList.Count + 1,
                Done = Done,
                Name = name,
            };
            TodoRepository.AddTodo(todo);
            TodoList = TodoRepository.GetTodos();
            App.Current.MainPage.DisplayAlert("Message", "Item Add :" + todo.Name, "Ok");
        }
        public async void DoneTodo(object data)
        {
            Todo todo = (Todo)data;
            if (todo != null)
            {
                App.Current.MainPage.DisplayAlert("Message", "Item Done :" + todo.Name, "Ok");
                TodoRepository.UpdateTodo(todo);
                TodoList = TodoRepository.GetTodos();
            }
        }
    }
}
