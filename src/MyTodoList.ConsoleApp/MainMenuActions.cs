using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MyTodoList.ConsoleApp
{
    internal enum MainMenuActions
    {
        [Display(Name = "View Collections schema")]
        Schema,
        [Display(Name = "Enter in 'todo_lists' Collection")]
        ToDoLists,
        [Display(Name = "Enter in 'tasks' Collection")]
        Tasks,
        [Display(Name = "Enter in 'priorities' Collection")]
        Priorities,
        [Display(Name = "Clear screen")]
        Clear,
        [Display(Name = "Exit")]
        Exit,
    }
}
