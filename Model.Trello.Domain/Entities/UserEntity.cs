using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Trello.Domain.Entities
{
    [Table("tab_user")]
    public sealed class UserEntity : BaseEntity
    {
        public string Name { get; set; }
        public string Password { get; set; }
    }
}
