using PocketBaseClient;
using PocketBaseClient.Orm;

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

        public static void WriteYouAreIn(CollectionBase collection, ItemBase? item = null, string? section = null)
        {
            Console.WriteLine();
            Write("  Collection ", ConsoleColor.DarkGray);
            Write(collection.Name, ConsoleColor.Blue);
            Write(". ", ConsoleColor.DarkGray);

            if (item != null)
            {
                Write("Item ", ConsoleColor.DarkGray);
                Write(item.Id, ConsoleColor.Blue);
                Write(". ", ConsoleColor.DarkGray);
            }
            if (section != null)
            {
                Write("Action ", ConsoleColor.DarkGray);
                Write(section, ConsoleColor.Blue);
                Write(": ", ConsoleColor.DarkGray);
            }
            Console.WriteLine();
        }

        public static void WriteAllItems<T>(IEnumerable<T> items) where T : ItemBase
        {
            bool any = false;
            foreach (var item in items)
            {
                WriteItem(item);
                any = true;
            }
            if (!any)
                WriteLine($"    [No items]", ConsoleColor.DarkMagenta);
            Console.WriteLine();
        }

        public static void WriteItem(ItemBase item)
        {
            WriteLine("--", ConsoleColor.DarkGray);
            Write($"{item.Id} ", ConsoleColor.DarkCyan);

            if (item.Metadata_.IsNew)
                Write("[New] ", ConsoleColor.DarkYellow);
            if (item.Metadata_.IsCached)
                Write("[Cached] ", ConsoleColor.DarkGreen);
            else if(!item.Metadata_.IsNew)
                Write("[Downloaded] ", ConsoleColor.DarkMagenta);
            if (!item.Metadata_.IsNew && item.Metadata_.HasLocalChanges)
                Write("[Changed] ", ConsoleColor.DarkYellow);
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
