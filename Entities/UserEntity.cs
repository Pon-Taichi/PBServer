using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PBServer.Entities;

#nullable disable
[Table(name: "m_user", Schema = "pb")]
public class UserEntity
{
  [Key]
  [Column("user_id")]
  public Guid UserId { get; set; }

  [Required]
  [Column("user_name")]
  public string UserName { get; set; }
}