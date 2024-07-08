
using LivePlay.Server.Core.CustomExceptions;

namespace LivePlay.Server.Application.Interfaces;

public interface IEmailProvider
{
    public ServerException? SendCodeEmail(string email, string code);
    public void Disconect();
}
