
using LivePlay.Server.Core.Abstracts;

namespace LivePlay.Server.Application.Interfaces;

public interface IEmailProvider
{
    public BaseException? SendCodeEmail(string email, string code);
    public void Disconect();
}
