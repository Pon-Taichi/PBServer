using System.ComponentModel.DataAnnotations;

namespace PBServer.Dto;

#nullable disable
public class ProjectDto
{
  [Required]
  public string Name { get; set; }
  [Required]
  public string Description { get; set; }
  [Required]
  public string Owner { get; set; }
}

public class ProjectId
{
  public int Id { get; set; }
}