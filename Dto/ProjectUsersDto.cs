namespace PBServer.Dto;

public class ProjectUsersDto
{
  public ICollection<Guid> Users { get; set; } = new List<Guid>();
}