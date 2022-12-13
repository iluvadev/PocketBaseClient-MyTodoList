
// This file was generated automatically for the PocketBase Application my-todo-list (https://my-todo-list.pockethost.io)
//    See CodeGenerationSummary.txt for more details
//
// PocketBaseClient-csharp project: https://github.com/iluvadev/PocketBaseClient-csharp
// Issues: https://github.com/iluvadev/PocketBaseClient-csharp/issues
// License (MIT): https://github.com/iluvadev/PocketBaseClient-csharp/blob/main/LICENSE
//
// pocketbase-csharp-sdk project: https://github.com/PRCV1/pocketbase-csharp-sdk 
// pocketbase project: https://github.com/pocketbase/pocketbase

using PocketBaseClient;
using PocketBaseClient.Services;
using PocketBaseClient.MyTodoList.Models;

namespace PocketBaseClient.MyTodoList.Services
{
    public partial class MyTodoListDataService : DataServiceBase
    {
        #region Collections
        /// <summary> Collection 'users' in PocketBase </summary>
        public CollectionUsers UsersCollection { get; }
        /// <summary> Collection 'todo_lists' in PocketBase </summary>
        public CollectionTodoLists TodoListsCollection { get; }
        /// <summary> Collection 'tasks' in PocketBase </summary>
        public CollectionTasks TasksCollection { get; }
        /// <summary> Collection 'priorities' in PocketBase </summary>
        public CollectionPriorities PrioritiesCollection { get; }

        /// <inheritdoc />
        protected override void RegisterCollections()
        {
            RegisterCollection(typeof(PocketBaseClient.MyTodoList.Models.User), UsersCollection);
            RegisterCollection(typeof(PocketBaseClient.MyTodoList.Models.TodoList), TodoListsCollection);
            RegisterCollection(typeof(PocketBaseClient.MyTodoList.Models.Task), TasksCollection);
            RegisterCollection(typeof(PocketBaseClient.MyTodoList.Models.Priority), PrioritiesCollection);
        }
        #endregion Collections

        #region Constructor
        public MyTodoListDataService(PocketBaseClientApplication app) : base(app)
        {
            // Collections
            UsersCollection = new CollectionUsers(this);
            TodoListsCollection = new CollectionTodoLists(this);
            TasksCollection = new CollectionTasks(this);
            PrioritiesCollection = new CollectionPriorities(this);

            RegisterCollections();
        }
        #endregion Constructor
    }
}
