using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XamarinFormsTodo.Model;

namespace DatabaseTodo
{
    public class TodoRepository : ITodoRepository
    {
        EfContext context;
        public TodoRepository(string path)
        {
            context = new EfContext(path);
        }
        public async Task<bool> AddTodo(Todo todo)
        {
            try
            {
                if (todo != null)
                {
                    var entity = await context.Todo.AddAsync(todo);
                    await context.SaveChangesAsync();
                    var isAdd = entity.State == Microsoft.EntityFrameworkCore.EntityState.Added;
                    return isAdd;
                }
                else
                    return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public ObservableCollection<Todo> GetTodos()
        {
            try
            {
                var list = context.Todo.OrderBy(p => p.Id).ToList();
                ObservableCollection<Todo> todoList = new ObservableCollection<Todo>();
                foreach (var item in list)
                {
                    todoList.Add(item);
                }
                return todoList;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<bool> TodoListClear()
        {
            try
            {
                var list = await context.Todo.ToListAsync();
                if (list != null)
                {
                    foreach (var item in list)
                    {
                        context.Todo.Remove(item);
                    }
                    await context.SaveChangesAsync();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> UpdateTodo(Todo todo)
        {
            try
            {
                if (todo != null)
                {
                    var entity = context.Todo.Find(todo.Id);
                    entity.Done = true;
                    await context.SaveChangesAsync();
                    return true;
                }
                else
                    return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
