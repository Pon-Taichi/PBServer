using Microsoft.EntityFrameworkCore;
using PBServer.Controllers;
using PBServer.Entities;
using PBServer.Utils;

namespace PBServer.Services;

public class UserService : IUserService
{
  private readonly PbContext _context;

  public UserService(PbContext context)
  {
    _context = context;
  }

  public async Task<ICollection<UserEntity>> GetUsers()
  {
    return await _context.UserEntities.ToListAsync();
  }

  public async Task CreateUser(UserEntity user)
  {
    await _context.UserEntities.AddAsync(user);
    await _context.SaveChangesAsync();
  }
}