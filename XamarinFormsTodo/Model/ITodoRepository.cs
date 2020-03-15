using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace XamarinFormsTodo.Model
{
    public interface ITodoRepository
    {
        Task<bool> AddTodo(Todo todo);
        Task<bool> UpdateTodo(Todo todo);
        ObservableCollection<Todo> GetTodos();
        Task<bool> TodoListClear();
    }
}
