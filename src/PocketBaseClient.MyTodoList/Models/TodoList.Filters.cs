
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
using System.Net.Mail;

namespace PocketBaseClient.MyTodoList.Models
{
    public partial class TodoList 
    {
        public class Filters : ItemBaseFilters
        {

            public FilterQuery Name(OperatorText op, string value) => FilterQuery.Create("name", op, value);
            public FilterQuery Description(OperatorText op, string value) => FilterQuery.Create("description", op, value);

        }
    }
}
