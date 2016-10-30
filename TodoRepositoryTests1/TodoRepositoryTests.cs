using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Tests
{
    [TestClass()]
    public class TodoRepositoryTests
    {
        [TestMethod()]
        public void TodoRepositoryTest()
        {
            //Assert.Fail();
        }

        [TestMethod()]
        public void AddTest()
        {
            ITodoRepository repository = new TodoRepository();
            var todoItem = new TodoItem("Groceries");
            repository.Add(todoItem);

            Assert.AreEqual(1, repository.GetAll().Count);
            Assert.IsTrue(repository.Get(todoItem.Id) != null);
            Assert.IsTrue(repository.Get(todoItem.Id).Text == "Groceries");

        }

        [ExpectedException(typeof(ArgumentException))]
        public void AddingExistingItemWillThrowException()
        {
            ITodoRepository repository = new TodoRepository();

            var todoItem = new TodoItem("Groceries");

            repository.Add(todoItem);
            repository.Add(todoItem);
        }


        [TestMethod()]
        public void GetTest()
        {

            ITodoRepository repository = new TodoRepository();

            var todoItem = new TodoItem("Groceries");
            var todoItem2 = new TodoItem("Football match");
            var todoItem3 = new TodoItem("Empty trash");

            repository.Add(todoItem);
            repository.Add(todoItem2);

            Assert.IsTrue(repository.Get(todoItem.Id) == todoItem &&
                          repository.Get(todoItem2.Id) == todoItem2 &&
                          repository.Get(todoItem3.Id) == default(TodoItem));
        }

        [TestMethod()]
        public void GetActiveTest()
        {
            ITodoRepository repository = new TodoRepository();

            var todoItem = new TodoItem("Groceries");
            var todoItem2 = new TodoItem("Football match");
            var todoItem3 = new TodoItem("Empty trash");
            var todoItem4 = new TodoItem("Homework");
            var todoItem5 = new TodoItem("Empty trash");

            repository.Add(todoItem);
            repository.Add(todoItem2);
            repository.Add(todoItem3);
            repository.Add(todoItem4);
            repository.Add(todoItem5);

            repository.MarkAsCompleted(todoItem.Id);
            repository.MarkAsCompleted(todoItem3.Id);

            List<TodoItem> activeTask = new List<TodoItem>();

            activeTask = repository.GetActive();

            Assert.IsTrue(activeTask[0].Id == todoItem2.Id &&
                          activeTask[1].Id == todoItem4.Id &&
                          activeTask[2].Id == todoItem5.Id &&
                          activeTask.Count() == 3);
        }

        [TestMethod()]
        public void GetAllTest()
        {
            ITodoRepository repository = new TodoRepository();

            var todoItem = new TodoItem("Groceries");
            var todoItem2 = new TodoItem("Football match");
            var todoItem3 = new TodoItem("Empty trash");
            var todoItem4 = new TodoItem("Homework");
            var todoItem5 = new TodoItem("Empty trash");

            repository.Add(todoItem);
            repository.Add(todoItem2);
            repository.Add(todoItem3);
            repository.Add(todoItem4);
            repository.Add(todoItem5);

            repository.MarkAsCompleted(todoItem.Id);
            repository.MarkAsCompleted(todoItem3.Id);

            List<TodoItem> activeTask = new List<TodoItem>();

            activeTask = repository.GetAll();

            Assert.IsTrue(activeTask[0].Id == todoItem.Id &&
                          activeTask[1].Id == todoItem2.Id &&
                          activeTask[4].Id == todoItem5.Id &&
                          activeTask.Count() == 5);
        }

        [TestMethod()]
        public void GetCompletedTest()
        {
            ITodoRepository repository = new TodoRepository();

            var todoItem = new TodoItem("Groceries");
            var todoItem2 = new TodoItem("Football match");
            var todoItem3 = new TodoItem("Empty trash");
            var todoItem4 = new TodoItem("Homework");
            var todoItem5 = new TodoItem("Repair car");

            repository.Add(todoItem);
            repository.Add(todoItem2);
            repository.Add(todoItem3);
            repository.Add(todoItem4);
            repository.Add(todoItem5);

            repository.MarkAsCompleted(todoItem.Id);
            repository.MarkAsCompleted(todoItem3.Id);

            List<TodoItem> activeTask = new List<TodoItem>();

            activeTask = repository.GetCompleted();

            Assert.IsTrue(activeTask[0].Id == todoItem.Id &&
                          activeTask[1].Id == todoItem3.Id &&
                          activeTask.Count() == 2);
        }

        [TestMethod()]
        public void GetFilteredTest()
        {
            ITodoRepository repository = new TodoRepository();

            var todoItem = new TodoItem("Groceries");
            var todoItem2 = new TodoItem("Football match");
            var todoItem3 = new TodoItem("Empty trash");
            var todoItem4 = new TodoItem("Homework");
            var todoItem5 = new TodoItem("Repair car");

            repository.Add(todoItem);
            repository.Add(todoItem2);
            repository.Add(todoItem3);
            repository.Add(todoItem4);
            repository.Add(todoItem5);

            repository.MarkAsCompleted(todoItem.Id);
            repository.MarkAsCompleted(todoItem3.Id);

            List<TodoItem> activeTask = new List<TodoItem>();

            activeTask = repository.GetFiltered(Method);

            Assert.IsTrue(activeTask.Count() == 2);
        }

            private bool Method(TodoItem t)
           {
                if (t.IsCompleted == true)
                {
                    return true;
                }
                else
                {
                    return false;
                }
                
            }

        [TestMethod()]
        public void MarkAsCompletedTest()
        {
            ITodoRepository repository = new TodoRepository();

            var todoItem = new TodoItem("Groceries");

            repository.Add(todoItem);
            repository.MarkAsCompleted(todoItem.Id);
            repository.MarkAsCompleted(todoItem.Id);

            List<TodoItem> compleatedTask = repository.GetCompleted();

            Assert.IsTrue(compleatedTask[0].IsCompleted == true);

        }

        [TestMethod()]
        public void RemoveTest()
        {
            ITodoRepository repository = new TodoRepository();

            var todoItem = new TodoItem("Groceries");
            var todoItem2 = new TodoItem("Football match");
            var todoItem3 = new TodoItem("Empty trash");
            var todoItem4 = new TodoItem("Homework");
            var todoItem5 = new TodoItem("Repair car");

            repository.Add(todoItem);
            repository.Add(todoItem2);
            repository.Add(todoItem3);
            repository.Add(todoItem4);
            repository.Add(todoItem5);

            repository.MarkAsCompleted(todoItem.Id);
            repository.MarkAsCompleted(todoItem3.Id);

            repository.Remove(todoItem.Id);
            repository.Remove(todoItem4.Id);
            repository.Remove(todoItem.Id);

            List<TodoItem> activeTask = new List<TodoItem>();

            activeTask = repository.GetAll();

            Assert.IsTrue(activeTask.Count == 3);

        }

        [TestMethod()]
        public void UpdateTest()
        {
            ITodoRepository repository = new TodoRepository();

            var todoItem = new TodoItem("Groceries");
            var todoItem2 = new TodoItem("Football match");

            repository.Add(todoItem);
            repository.Add(todoItem2);

            repository.MarkAsCompleted(todoItem.Id);

            todoItem.Text = "Groceries fridge";

            repository.Update(todoItem);

            Assert.IsTrue(repository.Get(todoItem.Id).Text == "Groceries fridge");

        }
    }
}