
// This file was generated automatically for the PocketBase Application my-todo-list (https://my-todo-list.pockethost.io)
//    See CodeGenerationSummary.txt for more details
//
// PocketBaseClient-csharp project: https://github.com/iluvadev/PocketBaseClient-csharp
// Issues: https://github.com/iluvadev/PocketBaseClient-csharp/issues
// License (MIT): https://github.com/iluvadev/PocketBaseClient-csharp/blob/main/LICENSE
//
// pocketbase-csharp-sdk project: https://github.com/PRCV1/pocketbase-csharp-sdk 
// pocketbase project: https://github.com/pocketbase/pocketbase

using pocketbase_csharp_sdk.Json;
using PocketBaseClient.Orm;
using PocketBaseClient.Orm.Attributes;
using PocketBaseClient.Orm.Json;
using PocketBaseClient.Orm.Validators;
using PocketBaseClient.Services;
using System.ComponentModel.DataAnnotations;
using System.Net.Mail;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PocketBaseClient.MyTodoList.Models
{
    public partial class Priority : ItemBase
    {
        #region Collection
        private static CollectionBase? _Collection = null;
        /// <inheritdoc />
        [JsonIgnore]
        public override CollectionBase Collection => _Collection ??= DataServiceBase.GetCollection<Priority>()!;
        #endregion Collection

        #region Field Properties
        private string? _Name = null;
        /// <summary> Maps to 'name' field in PocketBase </summary>
        [JsonPropertyName("name")]
        [PocketBaseField(id: "ibvcphat", name: "name", required: true, system: false, unique: true, type: "text")]
        [Display(Name = "Name")]
        [Required(ErrorMessage = @"name is required")]
        [StringLength(2147483647, MinimumLength = 3, ErrorMessage = "Minimum 3, Maximum 2147483647 characters")]
        public string? Name
        {
           get => Get(() => _Name);
           set => Set(value, ref _Name);
        }

        private int? _Value = null;
        /// <summary> Maps to 'value' field in PocketBase </summary>
        [JsonPropertyName("value")]
        [PocketBaseField(id: "gmaupy0p", name: "value", required: true, system: false, unique: false, type: "number")]
        [Display(Name = "Value")]
        [Required(ErrorMessage = @"value is required")]
        [Range(0, 100, ErrorMessage = "Minimum 0, Maximum 100")]
        public int? Value
        {
           get => Get(() => _Value);
           set => Set(value, ref _Value);
        }

        private string? _Description = null;
        /// <summary> Maps to 'description' field in PocketBase </summary>
        [JsonPropertyName("description")]
        [PocketBaseField(id: "bi4zhhtt", name: "description", required: false, system: false, unique: false, type: "text")]
        [Display(Name = "Description")]
        public string? Description
        {
           get => Get(() => _Description);
           set => Set(value, ref _Description);
        }


        #endregion Field Properties

        /// <inheritdoc />
        public override void UpdateWith(ItemBase itemBase)
        {
            base.UpdateWith(itemBase);

            if (itemBase is Priority item)
            {
                Name = item.Name;
                Value = item.Value;
                Description = item.Description;

            }
        }

        #region Collection
        public static CollectionPriorities GetCollection() 
            => (CollectionPriorities)DataServiceBase.GetCollection<Priority>()!;
        #endregion Collection


        #region GetById
        public static Priority? GetById(string id, bool reload = false) 
            => GetByIdAsync(id, reload).Result;

        public static async Task<Priority?> GetByIdAsync(string id, bool reload = false)
            => await DataServiceBase.GetCollection<Priority>()!.GetByIdAsync(id, reload);
        #endregion GetById
    }
}
