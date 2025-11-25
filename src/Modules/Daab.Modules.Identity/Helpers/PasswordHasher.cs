namespace Daab.Modules.Identity.Helpers;

using System.Security.Cryptography;
using System.Text;
using Konscious.Security.Cryptography;

public static class PasswordHasher
{
    private const int SaltLength = 16;
    private const int HashLength = 32;
    private const int DegreeOfParallelism = 8;
    private const int MemorySize = 65536;
    private const int Iterations = 4;

    public static string HashPassword(string password)
    {
        ArgumentException.ThrowIfNullOrEmpty(password);

        byte[] salt = RandomNumberGenerator.GetBytes(SaltLength);
        byte[] hash = HashPasswordInternal(password, salt);

        byte[] hashBytes = new byte[salt.Length + hash.Length];
        Buffer.BlockCopy(salt, 0, hashBytes, 0, salt.Length);
        Buffer.BlockCopy(hash, 0, hashBytes, salt.Length, hash.Length);

        return Convert.ToBase64String(hashBytes);
    }

    public static bool VerifyPassword(string password, string hashedPassword)
    {
        ArgumentException.ThrowIfNullOrEmpty(password);
        ArgumentException.ThrowIfNullOrEmpty(hashedPassword);

        try
        {
            byte[] hashBytes = Convert.FromBase64String(hashedPassword);

            if (hashBytes.Length != SaltLength + HashLength)
            {
                return false;
            }

            byte[] salt = new byte[SaltLength];
            Buffer.BlockCopy(hashBytes, 0, salt, 0, SaltLength);

            byte[] storedHash = new byte[HashLength];
            Buffer.BlockCopy(hashBytes, SaltLength, storedHash, 0, HashLength);

            byte[] newHash = HashPasswordInternal(password, salt);

            return CryptographicOperations.FixedTimeEquals(storedHash, newHash);
        }
        catch
        {
            return false;
        }
    }

    private static byte[] HashPasswordInternal(string password, byte[] salt)
    {
        using var argon2 = new Argon2id(Encoding.UTF8.GetBytes(password));
        argon2.Salt = salt;
        argon2.DegreeOfParallelism = DegreeOfParallelism;
        argon2.MemorySize = MemorySize;
        argon2.Iterations = Iterations;

        return argon2.GetBytes(HashLength);
    }
}

