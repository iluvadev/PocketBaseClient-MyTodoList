
// This file was generated automatically for the PocketBase Application my-todo-list (https://my-todo-list.pockethost.io)
//    See CodeGenerationSummary.txt for more details
//
// PocketBaseClient-csharp project: https://github.com/iluvadev/PocketBaseClient-csharp
// Issues: https://github.com/iluvadev/PocketBaseClient-csharp/issues
// License (MIT): https://github.com/iluvadev/PocketBaseClient-csharp/blob/main/LICENSE
//
// pocketbase-csharp-sdk project: https://github.com/PRCV1/pocketbase-csharp-sdk 
// pocketbase project: https://github.com/pocketbase/pocketbase

using PocketBaseClient.Orm;
using PocketBaseClient.Orm.Filters;
using PocketBaseClient.Services;

namespace PocketBaseClient.MyTodoList.Models
{
    public partial class CollectionTodoLists : CollectionBase<TodoList>
    {
        public override string Id => "w4ykjpp5mxau16a";
        public override string Name => "todo_lists";
        public override bool System => false;

        public CollectionTodoLists(DataServiceBase context) : base(context) { }


        public CollectionQuery<CollectionTodoLists, TodoList> Filter(string filterString)
             => new CollectionQuery<CollectionTodoLists, TodoList>(this, FilterQuery.Create(filterString));

        public CollectionQuery<CollectionTodoLists, TodoList> Filter(Func<TodoList.Filters, FilterQuery> filter)
            => new CollectionQuery<CollectionTodoLists, TodoList>(this, filter(new TodoList.Filters()));

    }
}
