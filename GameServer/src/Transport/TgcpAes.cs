using System.Security.Cryptography;

namespace LocalGameServer.Transport;

// 使用 Apollo 自定义填充。
public static class TgcpAes
{
    private static readonly byte[] Iv = [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15];
    private static int PaddingSize(int length) => (length % 16 > 10 ? 32 : 16) - length % 16;

    public static byte[] Encrypt(byte[] plaintext, byte[] key)
    {
        var padding = PaddingSize(plaintext.Length);
        var padded = new byte[plaintext.Length + padding];
        plaintext.CopyTo(padded, 0);
        RandomNumberGenerator.Fill(padded.AsSpan(plaintext.Length, padding - 6));
        "tsf4g"u8.CopyTo(padded.AsSpan(padded.Length - 6));
        padded[^1] = (byte)padding;
        using var aes = Aes.Create();
        aes.Key = key;
        return aes.EncryptCbc(padded, Iv, PaddingMode.None);
    }

    public static byte[] Decrypt(byte[] ciphertext, byte[] key)
    {
        if (ciphertext.Length < 16 || ciphertext.Length % 16 != 0)
            throw new InvalidDataException("Invalid TGCP AES block length.");
        using var aes = Aes.Create();
        aes.Key = key;
        var plaintext = aes.DecryptCbc(ciphertext, Iv, PaddingMode.None);
        var padding = plaintext[^1];
        if (padding < 6 || padding > plaintext.Length ||
            !plaintext.AsSpan(plaintext.Length - 6, 5).SequenceEqual("tsf4g"u8) ||
            padding != PaddingSize(plaintext.Length - padding))
            throw new InvalidDataException("TGCP AES padding marker is invalid.");
        return plaintext.AsSpan(0, plaintext.Length - padding).ToArray();
    }
}
