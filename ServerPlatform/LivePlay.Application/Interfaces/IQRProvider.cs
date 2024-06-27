
using LivePlay.Server.Core.Models;

namespace LivePlay.Server.Application.Interfaces;

public interface IQRProvider
{
    public string EncryptQR(UserQR userQR);
    public UserQR DecryptQR(string encryptedUserQR);
}
