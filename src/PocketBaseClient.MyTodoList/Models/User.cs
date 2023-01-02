
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
    public partial class User : ItemBase
    {
        #region Collection
        private static CollectionBase? _Collection = null;
        /// <inheritdoc />
        [JsonIgnore]
        public override CollectionBase Collection => _Collection ??= DataServiceBase.GetCollection<User>()!;
        #endregion Collection

        #region Field Properties
        private string? _Name = null;
        /// <summary> Maps to 'name' field in PocketBase </summary>
        [JsonPropertyName("name")]
        [PocketBaseField(id: "users_name", name: "name", required: false, system: false, unique: false, type: "text")]
        [Display(Name = "Name")]
        public string? Name { get => Get(() => _Name); set => Set(value, ref _Name); }

        private object? _Avatar = null;
        /// <summary> Maps to 'avatar' field in PocketBase </summary>
        [JsonPropertyName("avatar")]
        [PocketBaseField(id: "users_avatar", name: "avatar", required: false, system: false, unique: false, type: "file")]
        [Display(Name = "Avatar")]
        public object? Avatar { get => Get(() => _Avatar); set => Set(value, ref _Avatar); }

        #endregion Field Properties

        /// <inheritdoc />
        public override void UpdateWith(ItemBase itemBase)
        {
            base.UpdateWith(itemBase);

            if (itemBase is User item)
            {
                Name = item.Name;
                Avatar = item.Avatar;

            }
        }

        #region Collection
        public static CollectionUsers GetCollection() 
            => (CollectionUsers)DataServiceBase.GetCollection<User>()!;
        #endregion Collection

        #region GetById
        public static User? GetById(string id, bool reload = false) 
            => GetByIdAsync(id, reload).Result;

        public static async Task<User?> GetByIdAsync(string id, bool reload = false)
            => await DataServiceBase.GetCollection<User>()!.GetByIdAsync(id, reload);
        #endregion GetById
    }
}
