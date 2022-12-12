
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
using PocketBaseClient.MyTodoList.Services;

namespace PocketBaseClient.MyTodoList
{
    public partial class MyTodoListApplication : PocketBaseClientApplication
    {
        private MyTodoListDataService? _Data = null;
        public MyTodoListDataService Data => _Data ??= new MyTodoListDataService(this);

        #region Constructors
        public MyTodoListApplication() : this("https://my-todo-list.pockethost.io") { }
        public MyTodoListApplication(string url, string appName = "my-todo-list") : base(url, appName) { }
        #endregion Constructors
    }
}
