
// This file was generated automatically for the PocketBase Application my-todo-list (https://my-todo-list.pockethost.io)
//    See CodeGenerationSummary.txt for more details
//
// PocketBaseClient-csharp project: https://github.com/iluvadev/PocketBaseClient-csharp
// Issues: https://github.com/iluvadev/PocketBaseClient-csharp/issues
// License (MIT): https://github.com/iluvadev/PocketBaseClient-csharp/blob/main/LICENSE
//
// pocketbase-csharp-sdk project: https://github.com/PRCV1/pocketbase-csharp-sdk 
// pocketbase project: https://github.com/pocketbase/pocketbase

using PocketBaseClient.Orm.Filters;

namespace PocketBaseClient.MyTodoList.Models
{
    public partial class Task
    {
        public class Sorts : ItemBaseSorts
        {

            /// <summary>Makes a SortCommand to Order by the 'title' field</summary>
            public SortCommand Title => new SortCommand("title");

            /// <summary>Makes a SortCommand to Order by the 'description' field</summary>
            public SortCommand Description => new SortCommand("description");

            /// <summary>Makes a SortCommand to Order by the 'priority' field</summary>
            public SortCommand Priority => new SortCommand("priority");

            /// <summary>Makes a SortCommand to Order by the 'status' field</summary>
            public SortCommand Status => new SortCommand("status");


        }
    }
}
