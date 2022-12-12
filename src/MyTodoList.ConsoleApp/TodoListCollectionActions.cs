using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MyTodoList.ConsoleApp
{
    internal enum TodoListCollectionActions
    {
        [Display(Name = "Get all ToDo Lists")]
        List,
        [Display(Name = "Create a new ToDo List")]
        Create,
        [Display(Name = "Enter in a ToDo List")]
        Enter,
        [Display(Name = "Discard all ToDo List changes")]
        DiscardAllChanges,
        [Display(Name = "Clear screen")]
        Clear,
        [Display(Name = "Exit")]
        Exit,
    }
}
