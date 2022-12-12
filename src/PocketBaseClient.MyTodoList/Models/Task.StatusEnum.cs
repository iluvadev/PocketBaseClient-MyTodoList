
// This file was generated automatically for the PocketBase Application my-todo-list (https://my-todo-list.pockethost.io)
//    See CodeGenerationSummary.txt for more details
//
// PocketBaseClient-csharp project: https://github.com/iluvadev/PocketBaseClient-csharp
// Issues: https://github.com/iluvadev/PocketBaseClient-csharp/issues
// License (MIT): https://github.com/iluvadev/PocketBaseClient-csharp/blob/main/LICENSE
//
// pocketbase-csharp-sdk project: https://github.com/PRCV1/pocketbase-csharp-sdk 
// pocketbase project: https://github.com/pocketbase/pocketbase

using System.ComponentModel;

namespace PocketBaseClient.MyTodoList.Models
{
    public partial class Task
    {
        public enum StatusEnum
        {
            [Description("to do")]
            ToDo,

            [Description("doing")]
            Doing,

            [Description("paused")]
            Paused,

            [Description("done")]
            Done,


        }
    }
}
