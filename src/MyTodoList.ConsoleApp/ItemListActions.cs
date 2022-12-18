using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MyTodoList.ConsoleApp
{
    internal enum ItemListActions
    {
        [Display(Name = "Get all items")]
        List,
        [Display(Name = "Create a new item")]
        Create,
        [Display(Name = "Enter in an item")]
        Enter,
        [Display(Name = "Save all changes")]
        SaveAllChanges,
        [Display(Name = "Discard all changes")]
        DiscardAllChanges,
        [Display(Name = "View Schema")]
        Schema,
        [Display(Name = "Clear screen")]
        Clear,
        [Display(Name = "Go Back")]
        Exit,
    }
}
