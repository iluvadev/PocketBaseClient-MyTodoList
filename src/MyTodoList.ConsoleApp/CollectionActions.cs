using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MyTodoList.ConsoleApp
{
    internal enum CollectionActions
    {
        [Display(Name = "Get all items in the collection")]
        List,
        [Display(Name = "Create a new item")]
        Create,
        [Display(Name = "Enter in an item of the collection")]
        Enter,
        [Display(Name = "Discard all changes in the collection")]
        DiscardAllChanges,
        [Display(Name = "View Collections schema")]
        Schema,
        [Display(Name = "Clear screen")]
        Clear,
        [Display(Name = "Go Back")]
        Exit,
    }
}
