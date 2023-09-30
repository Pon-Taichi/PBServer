using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PBServer.Entities;

#nullable disable
[Table(name: "m_user", Schema = "pb")]
public class UserEntity
{
  [Key]
  [Required]
  [Column("user_id")]
  public string UserId { get; set; }

  [Column("user_name")]
  public string UserName { get; set; }
}