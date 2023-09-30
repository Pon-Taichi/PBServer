using System.ComponentModel.DataAnnotations;

namespace PBServer.Dto;

public class ProjectUsersDto
{
  [Required]
  public ICollection<string> Users { get; set; } = new List<string>();
}