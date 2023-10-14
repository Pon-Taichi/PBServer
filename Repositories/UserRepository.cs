using Microsoft.EntityFrameworkCore;
using PBServer.Entities;
using PBServer.Services.Interfaces;
using PBServer.Utils;

namespace PBServer.Repositories;

public class UserRepository : IUserRepository
{
  private readonly PbContext _context;

  public UserRepository(PbContext context)
  {
    _context = context;
  }

  public void CreateUser(UserEntity user)
  {
    _context.UserEntities.Add(user);
    _context.SaveChanges();
  }

  public ICollection<UserEntity> GetUsers()
  {
    return _context.UserEntities.ToList();
  }
}