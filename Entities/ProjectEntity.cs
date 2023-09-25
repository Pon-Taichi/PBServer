using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace PBServer.Entities;

#nullable disable
[Table(name: "m_project", Schema = "pb")]
public class ProjectEntity
{
  [Key]
  [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
  [Column("id")]
  public int Id { get; set; }

  [Required]
  [Column(name: "proj_name")]
  public string Name { get; set; }

  [Required]
  [Column(name: "proj_description")]
  public string Description { get; set; }

  [Required]
  [Column(name: "proj_owner")]
  [JsonIgnore]
  public Guid OwnerId { get; set; }

  public UserEntity Owner { get; set; }

  [NotMapped]
  public ICollection<UserEntity> Users { get; set; }
}