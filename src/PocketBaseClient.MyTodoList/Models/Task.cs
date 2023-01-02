
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
    public partial class Task : ItemBase
    {
        #region Collection
        private static CollectionBase? _Collection = null;
        /// <inheritdoc />
        [JsonIgnore]
        public override CollectionBase Collection => _Collection ??= DataServiceBase.GetCollection<Task>()!;
        #endregion Collection

        #region Field Properties
        private string? _Title = null;
        /// <summary> Maps to 'title' field in PocketBase </summary>
        [JsonPropertyName("title")]
        [PocketBaseField(id: "4kxyduic", name: "title", required: true, system: false, unique: false, type: "text")]
        [Display(Name = "Title")]
        [Required(ErrorMessage = @"Title is required")]
        [StringLength(2147483647, MinimumLength = 3, ErrorMessage = "Minimum 3, Maximum 2147483647 characters")]
        public string? Title { get => Get(() => _Title); set => Set(value, ref _Title); }

        private string? _Description = null;
        /// <summary> Maps to 'description' field in PocketBase </summary>
        [JsonPropertyName("description")]
        [PocketBaseField(id: "hffqq44h", name: "description", required: false, system: false, unique: false, type: "text")]
        [Display(Name = "Description")]
        public string? Description { get => Get(() => _Description); set => Set(value, ref _Description); }

        private Priority? _Priority = null;
        /// <summary> Maps to 'priority' field in PocketBase </summary>
        [JsonPropertyName("priority")]
        [PocketBaseField(id: "pp2uicwe", name: "priority", required: true, system: false, unique: false, type: "relation")]
        [Display(Name = "Priority")]
        [Required(ErrorMessage = @"Priority is required")]
        [JsonConverter(typeof(RelationConverter<Priority>))]
        public Priority? Priority { get => Get(() => _Priority); set => Set(value, ref _Priority); }

        private StatusEnum? _Status = null;
        /// <summary> Maps to 'status' field in PocketBase </summary>
        [JsonPropertyName("status")]
        [PocketBaseField(id: "4e4k0hod", name: "status", required: false, system: false, unique: false, type: "select")]
        [Display(Name = "Status")]
        [JsonConverter(typeof(EnumConverter<StatusEnum>))]
        public StatusEnum? Status { get => Get(() => _Status); set => Set(value, ref _Status); }

        #endregion Field Properties

        /// <inheritdoc />
        public override void UpdateWith(ItemBase itemBase)
        {
            base.UpdateWith(itemBase);

            if (itemBase is Task item)
            {
                Title = item.Title;
                Description = item.Description;
                Priority = item.Priority;
                Status = item.Status;

            }
        }

        /// <inheritdoc />
        protected override IEnumerable<ItemBase?> RelatedItems 
            => base.RelatedItems.Union(new List<ItemBase?>() { Priority });

        #region Collection
        public static CollectionTasks GetCollection() 
            => (CollectionTasks)DataServiceBase.GetCollection<Task>()!;
        #endregion Collection

        #region GetById
        public static Task? GetById(string id, bool reload = false) 
            => GetByIdAsync(id, reload).Result;

        public static async Task<Task?> GetByIdAsync(string id, bool reload = false)
            => await DataServiceBase.GetCollection<Task>()!.GetByIdAsync(id, reload);
        #endregion GetById
    }
}
