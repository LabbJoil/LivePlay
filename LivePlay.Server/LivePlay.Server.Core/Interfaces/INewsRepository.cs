
using LivePlay.Server.Core.Models;

namespace LivePlay.Server.Core.Interfaces;

public interface INewsRepository
{
    public News[] GetLastNews();
}
