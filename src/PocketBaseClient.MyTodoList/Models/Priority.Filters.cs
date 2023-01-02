
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
    public partial class Priority
    {
        public class Filters : ItemBaseFilters
        {

            /// <summary> Gets a Filter to Query data over the 'name' field in PocketBase </summary>
            public FieldFilterText Name => new FieldFilterText("name");

            /// <summary> Gets a Filter to Query data over the 'value' field in PocketBase </summary>
            public FieldFilterNumber Value => new FieldFilterNumber("value");

            /// <summary> Gets a Filter to Query data over the 'description' field in PocketBase </summary>
            public FieldFilterText Description => new FieldFilterText("description");


        }
    }
}
