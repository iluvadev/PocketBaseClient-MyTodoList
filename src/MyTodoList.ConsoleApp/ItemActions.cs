using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MyTodoList.ConsoleApp
{
    internal enum ItemActions
    {
        [Display(Name = "View item")]
        View,
        [Display(Name = "Edit item")]
        Edit,
        [Display(Name = "Navigate to...")]
        Navigate,
        [Display(Name = "Save changes to PocketBase")]
        SaveChanges,
        [Display(Name = "Discard local changes")]
        DiscardChanges,
        [Display(Name = "Delete item")]
        Delete,
        [Display(Name = "View Schema")]
        Schema,
        [Display(Name = "Clear screen")]
        Clear,
        [Display(Name = "Go Back")]
        Exit,
    }
}
