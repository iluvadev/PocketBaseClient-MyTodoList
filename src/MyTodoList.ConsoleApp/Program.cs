
using Microsoft.VisualBasic.FileIO;
using PocketBaseClient.MyTodoList;
using PocketBaseClient.MyTodoList.Models;
using PocketBaseClient.Orm;
using Sharprompt;

namespace MyTodoList.ConsoleApp
{
    internal class Program
    {
        public static MyTodoListApplication MyApp = new MyTodoListApplication();

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to MyTodoList example, using PocketBaseClient c#");
            Console.WriteLine();

            MenuMain();
        }

        static void MenuMain()
        {
            bool exit = false;
            var collection = MyApp.Data.TodoListsCollection;

            while (!exit)
            {
                ConsoleHelper.WriteYouAreIn(collection);
                var action = Prompt.Select<TodoListCollectionActions>("ToDo Lists");
                switch (action)
                {
                    case TodoListCollectionActions.List: ListElements(collection); break;
                    case TodoListCollectionActions.Create: CreateTodoList(); break;
                    case TodoListCollectionActions.Enter: SelectTodoList(); break;
                    case TodoListCollectionActions.DiscardAllChanges: DiscardChanges(collection); break;
                    case TodoListCollectionActions.Clear: Console.Clear(); break;
                    case TodoListCollectionActions.Exit: Console.Clear(); exit = true; break;
                }
            }
        }
        static void MenuTodoList(TodoList todoList)
        {
            bool exit = false;
            while (!exit)
            {
                ConsoleHelper.WriteYouAreIn(todoList.Collection, todoList);

                var action = Prompt.Select<TodoListItemActions>(todoList.Name);
                switch (action)
                {
                    case TodoListItemActions.View: ConsoleHelper.WriteItem(todoList); break;
                    case TodoListItemActions.Edit: EditTodoList(todoList); break;

                    case TodoListItemActions.Select: break;

                    case TodoListItemActions.SaveChanges: Save(todoList); break;
                    case TodoListItemActions.Delete: Delete(todoList); break;
                    case TodoListItemActions.DiscardChanges: DiscardChanges(todoList); break;
                    case TodoListItemActions.Clear: Console.Clear(); break;
                    case TodoListItemActions.Return: Console.Clear(); exit = true; break;
                }
            }
        }


        static void SelectTodoList()
        {
            var collection = MyApp.Data.TodoListsCollection;

            ConsoleHelper.WriteYouAreIn(collection, section: "Enter in a ToDo List");

            //var todoList = Prompt.Select("Select ToDo List", collection.GetItems());
            var selectOptions = new SelectOptions<TodoList>()
            {
                Message = "Select a ToDo List",
                Items = collection.GetItems(),
                TextSelector = t => t.Name
            };
            var todoList = Prompt.Select(selectOptions);

            ConsoleHelper.WriteItem(todoList);
            MenuTodoList(todoList);
        }
        static void CreateTodoList()
        {
            var collection = MyApp.Data.TodoListsCollection;

            ConsoleHelper.WriteYouAreIn(collection, section: "Create New");

            var newList = new TodoList();
            newList.Name = Prompt.Input<string>("Name for created TodoList");
            newList.Description = Prompt.Input<string>("Description for created TodoList");

            ConsoleHelper.WriteItem(newList);
            MenuTodoList(newList);
        }

        static void EditTodoList(TodoList item)
        {
            ConsoleHelper.WriteYouAreIn(item.Collection, item, "Edit");
            ConsoleHelper.WriteItem(item);
            
            item.Name = Prompt.Input<string>("Name for created TodoList", item.Name);
            item.Description = Prompt.Input<string>("Description for created TodoList", item.Description);
            
            ConsoleHelper.WriteItem(item);
        }

        static void Save(ItemBase item)
        {
            ConsoleHelper.WriteYouAreIn(item.Collection, item, section: "Save changes");
            ConsoleHelper.WriteItem(item);

            ConsoleHelper.WriteProcess("Saving");
            bool ok = false;
            try { ok = item.Save(); }
            catch (Exception ex) { ConsoleHelper.WriteError(ex.Message); }
            if (ok)
                ConsoleHelper.WriteDone();
            else
                ConsoleHelper.WriteError("Not saved");

            ConsoleHelper.WriteItem(item);
        }
        static void Delete(ItemBase item)
        {
            ConsoleHelper.WriteYouAreIn(item.Collection, item, section: "Delete");
            ConsoleHelper.WriteItem(item);

            ConsoleHelper.WriteProcess("Deleting");
            bool ok = false;
            try { ok = item.Delete(); }
            catch (Exception ex) { ConsoleHelper.WriteError(ex.Message); }
            if (ok)
                ConsoleHelper.WriteDone();
            else
                ConsoleHelper.WriteError("Not deleted");

            ConsoleHelper.WriteItem(item);
        }

        static void DiscardChanges(CollectionBase collection)
        {
            ConsoleHelper.WriteYouAreIn(collection, section: "Discard changes");
            ConsoleHelper.WriteProcess("Discarding local changes");
            collection.DiscardChanges();
            ConsoleHelper.WriteDone();
        }

        static void DiscardChanges(ItemBase item)
        {
            ConsoleHelper.WriteYouAreIn(item.Collection, item, section: "Discard changes");
            ConsoleHelper.WriteItem(item);

            ConsoleHelper.WriteProcess("Discarding local changes");
            item.DiscardChanges();
            ConsoleHelper.WriteDone();

            ConsoleHelper.WriteItem(item);
        }

        static void ListElements<T>(CollectionBase<T> collection) where T : ItemBase, new()
        {
            ConsoleHelper.WriteYouAreIn(collection, section: "Get Items");
            ConsoleHelper.WriteAllItems(collection.GetItems());
        }


    }
}