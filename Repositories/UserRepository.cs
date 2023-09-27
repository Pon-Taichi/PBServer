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

  public async Task CreateUser(UserEntity user)
  {
    await _context.UserEntities.AddAsync(user);
    await _context.SaveChangesAsync();
  }

  public async Task<ICollection<UserEntity>> GetUsers()
  {
    return await _context.UserEntities.ToListAsync();
  }
}