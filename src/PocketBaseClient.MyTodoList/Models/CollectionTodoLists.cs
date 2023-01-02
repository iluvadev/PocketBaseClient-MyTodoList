
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
        /// <inheritdoc />
        public override string Id => "w4ykjpp5mxau16a";

        /// <inheritdoc />
        public override string Name => "todo_lists";

        /// <inheritdoc />
        public override bool System => false;

        /// <summary> Contructor: The Collection 'todo_lists' </summary>
        /// <param name="context">The DataService for the collection</param>
        internal CollectionTodoLists(DataServiceBase context) : base(context) { }

        /// <summary> Query data at PocketBase, defining a Filter over collection 'todo_lists' </summary>
        public CollectionQuery<CollectionTodoLists, TodoList.Sorts, TodoList> Filter(Func<TodoList.Filters, FilterCommand> filter)
            => new CollectionQuery<CollectionTodoLists, TodoList.Sorts, TodoList>(this, filter(new TodoList.Filters()));

        /// <summary> Query all data at PocketBase, over collection 'todo_lists' </summary>
        public CollectionQuery<CollectionTodoLists, TodoList.Sorts, TodoList> All()
            => new CollectionQuery<CollectionTodoLists, TodoList.Sorts, TodoList>(this, null);

    }
}
