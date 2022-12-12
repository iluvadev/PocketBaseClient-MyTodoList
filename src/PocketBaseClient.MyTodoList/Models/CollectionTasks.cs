
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
    public partial class CollectionTasks : CollectionBase<Task>
    {
        public override string Id => "zqszc5ugiu7g2i8";
        public override string Name => "tasks";
        public override bool System => false;

        public CollectionTasks(DataServiceBase context) : base(context) { }


        public CollectionQuery<CollectionTasks, Task> Filter(string filterString)
             => new CollectionQuery<CollectionTasks, Task>(this, FilterQuery.Create(filterString));

        public CollectionQuery<CollectionTasks, Task> Filter(Func<Task.Filters, FilterQuery> filter)
            => new CollectionQuery<CollectionTasks, Task>(this, filter(new Task.Filters()));

    }
}
