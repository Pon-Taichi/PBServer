using System.Security.Claims;

namespace PBServer.Context;

public class ContextProvider : IContextProvider
{
  public string UserId { get; }

  public ContextProvider(IHttpContextAccessor accessor)
  {
    var context = accessor.HttpContext ?? throw new Exception("コンテキストが取得できません");
    UserId = context.User.FindFirstValue(ClaimTypes.NameIdentifier) ?? throw new Exception("ユーザーIDが取得できません");
  }
}