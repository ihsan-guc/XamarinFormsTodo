using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
			todoAdd = new Command(AddTodo);
			todoDone = new Command(DoneTodo);
		}
		private ObservableCollection<Todo> todoData;
		public  ObservableCollection<Todo> TodoData
		{
			get
			{
				if (todoData == null)
					return todoData = new ObservableCollection<Todo>();
				return todoData;
			}	
			set { todoData = value; OnPropertyChanged();}
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
			TodoData.Add(todo);
		}
		public void DoneTodo(object data)
		{
			foreach (var item in todoData)
			{
				if (item.Id == Convert.ToInt32(data))
				{
					item.Done = true;
				}
			}
		}
	}
}
