
using LivePlay.Server.Application.Interfaces;
using LivePlay.Server.Core.CustomExceptions;
using LivePlay.Server.Core.Enums;
using LivePlay.Server.Core.Models;
using LivePlay.Server.Core.Options;
using Microsoft.Extensions.Options;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

namespace LivePlay.Server.Infrastructure.Providers;

public class QRProvider(IOptions<QROptions> qroptions) : IQRProvider
{
    private readonly QROptions _qrOptions = qroptions.Value;

    public string EncryptQR(UserQR userQR)
    {
        string userQRString = JsonSerializer.Serialize(userQR);
        byte[] encryptedBytes = EncryptString(userQRString, _qrOptions.SecretKey);
        string encryptedBase64 = Convert.ToBase64String(encryptedBytes);
        return encryptedBase64;
    }

    public UserQR DecryptQR(string encryptedUserQR)
    {
        byte[] encryptedBytes = Convert.FromBase64String(encryptedUserQR);
        string decryptedString = DecryptString(encryptedBytes, _qrOptions.SecretKey);
        UserQR userQR = JsonSerializer.Deserialize<UserQR>(decryptedString) 
            ?? throw new RequestException(ErrorCode.QRProviderError, "Couldn't get information from qr.", $"Dont parse this {decryptedString}");
        return userQR;
    }

    private static byte[] EncryptString(string plainText, string key)
    {
        byte[] plainBytes = Encoding.UTF8.GetBytes(plainText);
        byte[] keyBytes = Encoding.UTF8.GetBytes(key);

        using Aes aes = Aes.Create();
        aes.Key = keyBytes;
        aes.IV = new byte[aes.BlockSize / 8];
        aes.Mode = CipherMode.CBC;

        using ICryptoTransform encryptor = aes.CreateEncryptor();
        return encryptor.TransformFinalBlock(plainBytes, 0, plainBytes.Length);
    }

    private static string DecryptString(byte[] cipherText, string key)
    {
        byte[] keyBytes = Encoding.UTF8.GetBytes(key);

        using Aes aes = Aes.Create();
        aes.Key = keyBytes;
        aes.IV = new byte[aes.BlockSize / 8];
        aes.Mode = CipherMode.CBC;

        using ICryptoTransform decryptor = aes.CreateDecryptor();
        byte[] decryptedBytes = decryptor.TransformFinalBlock(cipherText, 0, cipherText.Length);
        return Encoding.UTF8.GetString(decryptedBytes);
    }
}
