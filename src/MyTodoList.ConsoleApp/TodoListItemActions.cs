using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MyTodoList.ConsoleApp
{
    internal enum TodoListItemActions
    {
        [Display(Name = "View ToDo List")]
        View,
        [Display(Name = "Enter in Tasks")]
        Select,
        [Display(Name = "Edit ToDo List")]
        Edit,
        [Display(Name = "Save changes to PocketBase")]
        SaveChanges,
        [Display(Name = "Discard local changes")]
        DiscardChanges,
        [Display(Name = "Delete ToDo List")]
        Delete,
        [Display(Name = "Clear screen")]
        Clear,
        [Display(Name = "Go Back")]
        Return,
    }
}
