using System.ComponentModel.DataAnnotations;

namespace PBServer.Dto;

public class ProjectUsersDto
{
  [Required]
  public ICollection<Guid> Users { get; set; } = new List<Guid>();
}