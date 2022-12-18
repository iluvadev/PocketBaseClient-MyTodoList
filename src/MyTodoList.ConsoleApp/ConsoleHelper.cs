using PocketBaseClient;
using PocketBaseClient.MyTodoList.Models;
using PocketBaseClient.Orm;
using PocketBaseClient.Orm.Structures;
using Task = PocketBaseClient.MyTodoList.Models.Task;

namespace MyTodoList.ConsoleApp
{
    internal static class ConsoleHelper
    {
        public static void Write(string? text, ConsoleColor foreColor)
        {
            var color = Console.ForegroundColor;
            Console.ForegroundColor = foreColor;
            Console.Write(text);
            Console.ForegroundColor = color;
        }
        public static void WriteLine(string? text, ConsoleColor foreColor)
            => Write(text + Environment.NewLine, foreColor);

        public static void WriteYouAreIn(object element, string? action = null)
        {
            Console.WriteLine();
            Write("  You are in", ConsoleColor.DarkYellow);

            foreach (var section in GetWhereIam(element))
            {
                Write(" >> ", ConsoleColor.DarkGreen);
                Write(section, ConsoleColor.Cyan);
            }
            if (action != null)
            {
                Write(" >> ", ConsoleColor.DarkBlue);
                Write(action, ConsoleColor.DarkMagenta);
                Write(". ", ConsoleColor.DarkGray);
            }
            Console.WriteLine();
        }
        static List<string> GetWhereIam(object? element)
        {
            var whereIam = new List<string>();
            if (element is IBasicList list)
                whereIam.Add(list.Name ?? "");

            if (element is TodoList todoList)
                whereIam.Add(todoList.Name ?? "");

            if (element is Task task)
                whereIam.Add(task.Title ?? "");

            if (element is Priority priority)
                whereIam.Add(priority.Name ?? "");

            if (element is IOwnedByItem owned)
                whereIam.AddRange(GetWhereIam(owned.Owner));

            if (element is ItemBase item)
                whereIam.AddRange(GetWhereIam(item.Collection));

            if(element is string strElem)
                whereIam.Add(strElem);

            whereIam.Reverse();
            return whereIam;
        }

        public static void WriteAllItems<T>(CollectionBase<T> collection) where T : ItemBase, new()
        {
            Write("Collection: ", ConsoleColor.DarkGray);
            WriteLine(collection.Name, ConsoleColor.Cyan);

            WriteAllItemsInternal(collection.GetItems(false, GetItemsFilter.New | GetItemsFilter.Load | GetItemsFilter.Erased));
        }
        public static void WriteAllItems<T>(IEnumerable<T> list) where T : ItemBase, new()
        {
            Write("List of: ", ConsoleColor.DarkGray);
            WriteLine(typeof(T).Name, ConsoleColor.Cyan);

            WriteAllItemsInternal(list as IEnumerable<T>);
        }

        private static void WriteAllItemsInternal<T>(IEnumerable<T> items) where T : ItemBase
        {
            bool any = false;
            foreach (var item in items)
            {
                WriteLine("---", ConsoleColor.DarkGray);
                WriteItem(item);
                any = true;
            }
            if (!any)
                WriteLine($"    [No items]", ConsoleColor.DarkMagenta);
            WriteLine("---", ConsoleColor.DarkGray);

            Console.WriteLine();
        }

        public static void WriteItem(ItemBase item)
        {
            Write($" · {item.Id} ", ConsoleColor.DarkCyan);

            if (item.Metadata_.IsNew)
                Write("[New] ", ConsoleColor.DarkYellow);
            if (item.Metadata_.IsCached)
                Write("[Cached] ", ConsoleColor.DarkGreen);
            else if (!item.Metadata_.IsNew)
                Write("[Downloaded] ", ConsoleColor.DarkMagenta);
            if (!item.Metadata_.IsNew && item.Metadata_.HasLocalChanges)
                Write("[Changed] ", ConsoleColor.DarkYellow);
            if (item.Metadata_.IsTobeDeleted)
                Write("[Deleted] ", ConsoleColor.DarkRed);
            if (item.Metadata_.IsTrash)
                Write("[Trash] ", ConsoleColor.DarkRed);

            WriteLine(Environment.NewLine + item.ToJson(), ConsoleColor.DarkGray);
            if (!item.Validate(out var errors))
            {
                WriteLine("Validation errors: ", ConsoleColor.DarkRed);
                foreach (var error in errors)
                    WriteLine($"  · {error}", ConsoleColor.DarkRed);
            }
            else
                WriteLine("Without validation errors", ConsoleColor.DarkGreen);
        }


        public static void WriteProcess(string process)
            => Write($"  · {process}...", ConsoleColor.DarkGray);
        public static void WriteError(string error)
            => WriteLine($"  >> {error}", ConsoleColor.Red);

        public static void WriteDone()
            => WriteLine("  >> Done!", ConsoleColor.Green);
    }
}
