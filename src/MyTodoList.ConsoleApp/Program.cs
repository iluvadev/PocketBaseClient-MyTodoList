using PocketBaseClient.MyTodoList;
using PocketBaseClient.MyTodoList.Models;
using PocketBaseClient.Orm;
using Sharprompt;
using System.Runtime.CompilerServices;

namespace MyTodoList.ConsoleApp
{
    internal class Program
    {
        private const string _Header = @"
  _____           _        _   ____                  _____ _ _            _   
 |  __ \         | |      | | |  _ \                / ____| (_)          | |  
 | |__) |__   ___| | _____| |_| |_) | __ _ ___  ___| |    | |_  ___ _ __ | |_ 
 |  ___/ _ \ / __| |/ / _ \ __|  _ < / _` / __|/ _ \ |    | | |/ _ \ '_ \| __|
 | |  | (_) | (__|   <  __/ |_| |_) | (_| \__ \  __/ |____| | |  __/ | | | |_ 
 |_|   \___/ \___|_|\_\___|\__|____/ \__,_|___/\___|\_____|_|_|\___|_| |_|\__|
";

        private const string _Schema = @"
 ┌──────────────────┐       ┌──────────────────┐
 │ todo_lists       │       │ tasks            │       ┌────────────────┐
 ├──────────────────┤       ├──────────────────┤       │ priorities     │
 │ name        :T   │       │ title       :T   │       ├────────────────┤
 │ description :T   │     N │ description :T   │     1 │ name        :T │
 │ tasks       :Rel ------->│ priority    :Rel ------->│ value       :# │
 └──────────────────┘       │ status      :Sel │       │ description :T │
                            │     │to do       │       └────────────────┘
                            │     │doing       │
                            │     │paused      │
                            │     │done        │
                            └──────────────────┘
";//┼

        public static MyTodoListApplication MyApp = new MyTodoListApplication();

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to MyTodoList example, using PocketBaseClient c#");
            Console.WriteLine();

            ShowAbout();
        }

        static void ShowAbout()
        {
            ConsoleHelper.WriteLine("Welcome to the Consele Application demo of ", ConsoleColor.DarkGray);
            ConsoleHelper.WriteLine(_Header, ConsoleColor.Blue);
            ConsoleHelper.WriteLine("All data is online and its navigation and edition is for demostration purposes", ConsoleColor.DarkGray);
            ConsoleHelper.Write("   · There can be inapropiate content... ", ConsoleColor.DarkGray);
            ConsoleHelper.WriteLine("(All data is open to world)", ConsoleColor.DarkMagenta);
            ConsoleHelper.WriteLine("Online server:", ConsoleColor.DarkGray);
            ConsoleHelper.Write("   · Url: ", ConsoleColor.DarkGray);
            ConsoleHelper.WriteLine(MyApp.AppUrl, ConsoleColor.Cyan);
            ConsoleHelper.Write("   · Application Name: ", ConsoleColor.DarkGray);
            ConsoleHelper.WriteLine(MyApp.AppName, ConsoleColor.Cyan);
            MainMenu();
        }

        static void MainMenu()
        {
            Console.WriteLine();
            bool exit = false;
            while (!exit)
            {
                var action = Prompt.Select<MainMenuActions>("Main Menu");
                switch (action)
                {
                    case MainMenuActions.ToDoLists: CollectionMenu(MyApp.Data.TodoListsCollection); break;
                    case MainMenuActions.Tasks: CollectionMenu(MyApp.Data.TasksCollection); break;
                    case MainMenuActions.Priorities: CollectionMenu(MyApp.Data.PrioritiesCollection); break;


                    case MainMenuActions.Schema: ShowSchema(); break;
                    case MainMenuActions.Clear: Console.Clear(); break;
                    case MainMenuActions.Exit: Console.Clear(); exit = true; break;
                }
            }
        }

        static void ShowSchema()
        {
            ConsoleHelper.Write("   · Url: ", ConsoleColor.DarkGray);
            ConsoleHelper.WriteLine(MyApp.AppUrl, ConsoleColor.Cyan);
            ConsoleHelper.Write("   · Application Name: ", ConsoleColor.DarkGray);
            ConsoleHelper.WriteLine(MyApp.AppName, ConsoleColor.Cyan);
            ConsoleHelper.Write("   · Collection Schema in Server:", ConsoleColor.DarkGray);
            ConsoleHelper.WriteLine(_Schema, ConsoleColor.DarkCyan);
        }

        static void CollectionMenu<T>(CollectionBase<T> collection) where T : ItemBase, new()
        {
            bool exit = false;
            while (!exit)
            {
                ConsoleHelper.WriteYouAreIn(collection);
                var action = Prompt.Select<CollectionActions>("ToDo Lists");
                switch (action)
                {
                    case CollectionActions.List: ListItems(collection); break;
                    case CollectionActions.Create: CreateItem<T>(); break;
                    case CollectionActions.Enter: SelectItem(collection); break;
                    case CollectionActions.DiscardAllChanges: DiscardChanges(collection); break;

                    case CollectionActions.Schema: ShowSchema(); break;
                    case CollectionActions.Clear: Console.Clear(); break;
                    case CollectionActions.Exit: Console.Clear(); exit = true; break;
                }
            }
        }

        static void SelectItem<T>(CollectionBase<T> collection) where T : ItemBase, new()
        {
            ConsoleHelper.WriteYouAreIn(collection, section: "Enter in Item");

            var selectOptions = new SelectOptions<T>()
            {
                Message = $"Select an item of {collection.Name}",
                Items = collection.GetItems(),
                TextSelector = t => {
                    if (t is TodoList todoList) return todoList.Name;
                    if (t is PocketBaseClient.MyTodoList.Models.Task task) return task.Title;
                    if (t is Priority priority) return priority.Name;
                    return t.Id;
                }
            };
            var item = Prompt.Select(selectOptions);

            ConsoleHelper.WriteItem(item);
            MenuItem(item);
        }

        static void MenuItem<T>(T item) where T : ItemBase, new()
        {
            if(item is TodoList todoList)
            {
                MenuTodoList(todoList);
                return;
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

                    case TodoListItemActions.Schema: ShowSchema(); break;
                    case TodoListItemActions.Clear: Console.Clear(); break;
                    case TodoListItemActions.Exit: Console.Clear(); exit = true; break;
                }
            }
        }

        static void CreateItem<T>()
        {
            if (typeof(T) == typeof(TodoList))
            {
                CreateTodoList(); 
                return;
            }
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

        static void ListItems<T>(CollectionBase<T> collection) where T : ItemBase, new()
        {
            ConsoleHelper.WriteYouAreIn(collection, section: "Get Items");
            ConsoleHelper.WriteAllItems(collection.GetItems());
        }


    }
}