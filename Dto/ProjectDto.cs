namespace PBServer.Dto;

public class ProjectDto
{
  public required string Name { get; set; }
  public required string Description { get; set; }
  public Guid Owner { get; set; }
  public ICollection<Guid> Users { get; set; } = new List<Guid>();
}

public class ProjectId
{
  public int Id { get; set; }
}