using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PBServer.Entities;

#nullable disable
[Table("m_proj_user", Schema = "pb")]
public class ProjectUserEntity
{
  [Key]
  [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
  [Column("id")]
  public int Id { get; set; }

  [Required]
  [Column("proj_id")]
  public int ProjectId { get; set; }

  [Required]
  [Column("user_id")]
  public Guid UserId { get; set; }

  public UserEntity User { get; set; }
  public ProjectEntity Project { get; set; }
}