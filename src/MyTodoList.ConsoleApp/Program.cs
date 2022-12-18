using PocketBaseClient.MyTodoList;
using PocketBaseClient.MyTodoList.Models;
using PocketBaseClient.Orm;
using PocketBaseClient.Orm.Structures;
using Sharprompt;
using Task = PocketBaseClient.MyTodoList.Models.Task;

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
            MenuMain();
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

        static void MenuMain()
        {
            Console.WriteLine();
            bool exit = false;
            while (!exit)
            {
                ConsoleHelper.WriteYouAreIn("Main menu");
                var action = Prompt.Select<MainMenuActions>("Action to do?");
                switch (action)
                {
                    case MainMenuActions.ToDoLists: MenuItemList(MyApp.Data.TodoListsCollection); break;
                    case MainMenuActions.Tasks: MenuItemList(MyApp.Data.TasksCollection); break;
                    case MainMenuActions.Priorities: MenuItemList(MyApp.Data.PrioritiesCollection); break;

                    case MainMenuActions.Schema: ShowSchema(); break;
                    case MainMenuActions.Clear: Console.Clear(); break;
                    case MainMenuActions.Exit: exit = true; break;
                }
            }
        }

        static void MenuItemList<T>(IItemList<T> itemList) where T : ItemBase, new()
        {
            bool exit = false;
            while (!exit)
            {
                ConsoleHelper.WriteYouAreIn(itemList);
                var action = Prompt.Select<ItemListActions>("Action to do?");
                switch (action)
                {
                    case ItemListActions.List: ConsoleHelper.WriteAllItems(itemList); ; break;
                    case ItemListActions.Create: EditItem(itemList.AddNew(), true); break;
                    case ItemListActions.Enter: EnterItem(itemList); break;
                    case ItemListActions.SaveAllChanges: SaveChanges(itemList); break;
                    case ItemListActions.DiscardAllChanges: DiscardChanges(itemList); break;

                    case ItemListActions.Schema: ShowSchema(); break;
                    case ItemListActions.Clear: Console.Clear(); break;
                    case ItemListActions.Exit: exit = true; break;
                }
            }
        }

        static void MenuItem<T>(T item) where T : ItemBase, new()
        {
            bool exit = false;
            while (!exit)
            {
                ConsoleHelper.WriteYouAreIn(item);

                var action = Prompt.Select<ItemActions>("Action to do?");
                switch (action)
                {
                    case ItemActions.View: ConsoleHelper.WriteItem(item); break;
                    case ItemActions.Edit: EditItem(item); break;

                    case ItemActions.Navigate: break;

                    case ItemActions.SaveChanges: Save(item); break;
                    case ItemActions.Delete: Delete(item); break;
                    case ItemActions.DiscardChanges: DiscardChanges(item); break;

                    case ItemActions.Schema: ShowSchema(); break;
                    case ItemActions.Clear: Console.Clear(); break;
                    case ItemActions.Exit: exit = true; break;
                }
            }
        }

        static void EnterItem<T>(IItemList<T> itemList) where T : ItemBase, new()
        {
            ConsoleHelper.WriteYouAreIn(itemList, "Enter in Item");

            var item = SelectItem(itemList);

            ConsoleHelper.WriteItem(item);
            MenuItem(item);
        }

        static T SelectItem<T>(IItemList<T> items) where T : ItemBase, new()
        {
            var selectOptions = new SelectOptions<T>()
            {
                Message = $"Select an item of {items.Name}",
                Items = items,
                TextSelector = t => GetItemName(t)
            };
            return Prompt.Select(selectOptions);
        }

        static string GetItemName(ItemBase item)
        {
            if (item is TodoList todoList) return todoList.Name ?? item.Id!;
            if (item is Task task) return task.Title ?? item.Id!;
            if (item is Priority priority) return priority.Name ?? item.Id!; return item.Id!;
        }


        static void EditItem(ItemBase item, bool isNew = false)
        {
            ConsoleHelper.WriteYouAreIn(item, isNew ? "New" : "Edit");

            if (!isNew)
                ConsoleHelper.WriteItem(item);

            if (item is TodoList todoList)
                EditTodoList(todoList);
            else if (item is Task task)
                EditTask(task);
            else if (item is Priority priority)
                EditPriority(priority);

            ConsoleHelper.WriteItem(item);
        }
        static void EditTodoList(TodoList todoList)
        {
            todoList.Name = Prompt.Input<string>("Name for TodoList", todoList.Name);
            todoList.Description = Prompt.Input<string>("Description for TodoList", todoList.Description);
            //todoList.Tasks 
            MenuItemList(todoList.Tasks);
        }

        static void EditTask(Task task)
        {
            task.Title = Prompt.Input<string>("Title for Task", task.Title);
            task.Description = Prompt.Input<string>("Description for Task", task.Description);
            task.Priority = SelectItem(MyApp.Data.PrioritiesCollection);
            task.Status = Prompt.Select<Task.StatusEnum>("Status for Task");
        }

        static void EditPriority(Priority priority)
        {
            priority.Name = Prompt.Input<string>("Name for Priority", priority.Name);
            priority.Description = Prompt.Input<string>("Description for Priority", priority.Description);
            priority.Value = Prompt.Input<int>("Value for Priority", priority.Value);
        }

        static void Save(ItemBase item)
        {
            ConsoleHelper.WriteYouAreIn(item, "Save changes");
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
            ConsoleHelper.WriteYouAreIn(item, "Delete");
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

        static void SaveChanges(IBasicList list)
        {
            ConsoleHelper.WriteYouAreIn(list, "Save changes");
            ConsoleHelper.WriteProcess("Saving local changes");
            list.SaveChanges(ListSaveDiscardModes.AllChanges);
            ConsoleHelper.WriteDone();
        }

        static void DiscardChanges(IBasicList list)
        {
            ConsoleHelper.WriteYouAreIn(list, "Discard changes");
            ConsoleHelper.WriteProcess("Discarding local changes");
            list.DiscardChanges(ListSaveDiscardModes.AllChanges);
            ConsoleHelper.WriteDone();
        }

        static void DiscardChanges(ItemBase item)
        {
            ConsoleHelper.WriteYouAreIn(item, "Discard changes");
            ConsoleHelper.WriteItem(item);

            ConsoleHelper.WriteProcess("Discarding local changes");
            item.DiscardChanges();
            ConsoleHelper.WriteDone();

            ConsoleHelper.WriteItem(item);
        }
    }
}