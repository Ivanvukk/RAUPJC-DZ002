using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Repository
{
    public interface ITodoRepository
    {
        /// <summary>
        /// Gets TodoItem for a given id
        /// </summary>
        /// <returns>TodoItem if found, null otherwise</returns>
        TodoItem Get(Guid todoId);

        /// <summary>
        /// Adds new TodoItem object in database.
        /// If object with the same id already exists,
        /// method should throw DuplicateTodoItemException with the message "duplicate id: {id}".
        /// </summary>
        void Add(TodoItem todoItem);

        /// <summary>
        /// Tries to remove a TodoItem with given id from the database.
        /// </summary>
        /// <returns>True if success, false otherwise</returns>
        bool Remove(Guid todoId);

        /// <summary>
        /// Updates given TodoItem in database.
        /// If TodoItem does not exist, method will add one.
        /// </summary>
        void Update(TodoItem todoItem);

        /// <summary>
        /// Tries to mark a TodoItem as completed in database.
        /// </summary>
        /// <returns>True if success, false otherwise</returns> 
        bool MarkAsCompleted(Guid todoId);

        /// <summary>
        /// Gets all TodoItem objects in database, sorted by date created (descending)
        /// </summary>
        List<TodoItem> GetAll();

        /// <summary>
        /// Gets all incomplete TodoItem objects in database
        /// </summary>
        List<TodoItem> GetActive();

        /// <summary>
        /// Gets all completed TodoItem objects in database
        /// </summary>
        List<TodoItem> GetCompleted();

        /// <summary>
        /// Gets all TodoItem objects in database that apply to the filter
        /// </summary>
        List<TodoItem> GetFiltered(Func<TodoItem, bool> filterFunction);
    }

    public class TodoRepository : ITodoRepository
    {

        private readonly List<TodoItem> _inMemoryTodoDatabase;

        public TodoRepository(List<TodoItem> initialDbState = null)
        {
            if (initialDbState != null)
            {
                _inMemoryTodoDatabase = initialDbState;
            }
            else
            {
                _inMemoryTodoDatabase = new List<TodoItem>();
            }

        }

        public void Add(TodoItem todoItem)
        {
            if(_inMemoryTodoDatabase.Where(TodoItem => TodoItem.Id == todoItem.Id).FirstOrDefault() != null)
            {
                System.ArgumentException DuplicateTodoItemException = new System.ArgumentException("Duplicate id: " + todoItem.Id);
                throw DuplicateTodoItemException;
            }
            else
            {
                _inMemoryTodoDatabase.Add(todoItem);
            }
            
        }

        public TodoItem Get(Guid todoId)
        { 
            TodoItem findByID = _inMemoryTodoDatabase.Where(TodoItem => TodoItem.Id == todoId)
                                                      .FirstOrDefault();

            return findByID;
        }

        public List<TodoItem> GetActive()
        {
            List<TodoItem> findActive = _inMemoryTodoDatabase.Where(TodoItem => TodoItem.IsCompleted == false)
                                                      .ToList();

            return findActive;
        }

        public List<TodoItem> GetAll()
        {
            return _inMemoryTodoDatabase.ToList();
        }

        public List<TodoItem> GetCompleted()
        {
            List<TodoItem> findCompleted = _inMemoryTodoDatabase.Where(TodoItem => TodoItem.IsCompleted == true)
                                                                .ToList();

            return findCompleted;
        }

        public List<TodoItem> GetFiltered(Func<TodoItem, bool> filterFunction)
        {
            List<TodoItem> filtered = _inMemoryTodoDatabase.Where(filterFunction)
                                                           .ToList();

            return filtered;
        }

        public bool MarkAsCompleted(Guid todoId)
        {
            if (_inMemoryTodoDatabase.Where(TodoItem => TodoItem.Id == todoId).First().IsCompleted != true)
            {
                _inMemoryTodoDatabase.Where(TodoItem => TodoItem.Id == todoId).First().IsCompleted = true;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Remove(Guid todoId)
        {
            return _inMemoryTodoDatabase.Remove(_inMemoryTodoDatabase.Where(TodoItem => TodoItem.Id == todoId).FirstOrDefault());
        }

        public void Update(TodoItem todoItem)
        {
            TodoItem x = _inMemoryTodoDatabase.Where(TodoItem => TodoItem.Id == todoItem.Id).FirstOrDefault();

            if ( x != null)
            {
                x.Text = todoItem.Text;
                x.IsCompleted = todoItem.IsCompleted;
                x.DateCreated = todoItem.DateCreated;
                x.DateCompleted = todoItem.DateCompleted;
            }
            else
            {
                Add(todoItem);
            }
        }
    }
}

