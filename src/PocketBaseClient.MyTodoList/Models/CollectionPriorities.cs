
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
        /// <inheritdoc />
        public override string Id => "qiaa7aqz9a6u1yg";

        /// <inheritdoc />
        public override string Name => "priorities";

        /// <inheritdoc />
        public override bool System => false;

        /// <summary> Contructor: The Collection 'priorities' </summary>
        /// <param name="context">The DataService for the collection</param>
        internal CollectionPriorities(DataServiceBase context) : base(context) { }

        /// <summary> Query data at PocketBase, defining a Filter over collection 'priorities' </summary>
        public CollectionQuery<CollectionPriorities, Priority.Sorts, Priority> Filter(Func<Priority.Filters, FilterCommand> filter)
            => new CollectionQuery<CollectionPriorities, Priority.Sorts, Priority>(this, filter(new Priority.Filters()));

        /// <summary> Query all data at PocketBase, over collection 'priorities' </summary>
        public CollectionQuery<CollectionPriorities, Priority.Sorts, Priority> All()
            => new CollectionQuery<CollectionPriorities, Priority.Sorts, Priority>(this, null);

    }
}
