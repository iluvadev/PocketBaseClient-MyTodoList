
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
    public partial class CollectionPriorities : CollectionBase<Priority>
    {
        public override string Id => "qiaa7aqz9a6u1yg";
        public override string Name => "priorities";
        public override bool System => false;

        public CollectionPriorities(DataServiceBase context) : base(context) { }


        public CollectionQuery<CollectionPriorities, Priority> Filter(string filterString)
             => new CollectionQuery<CollectionPriorities, Priority>(this, FilterQuery.Create(filterString));

        public CollectionQuery<CollectionPriorities, Priority> Filter(Func<Priority.Filters, FilterQuery> filter)
            => new CollectionQuery<CollectionPriorities, Priority>(this, filter(new Priority.Filters()));

    }
}
