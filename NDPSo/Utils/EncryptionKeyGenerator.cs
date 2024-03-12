using System;
using System.Security.Cryptography;
using System.Text;

public class EncryptionKeyGenerator
{
    public static byte[] GenerateEncryptionKey(string password, string salt, int keySizeInBytes)
    {
        byte[] saltBytes = Encoding.UTF8.GetBytes(salt);
        byte[] passwordBytes = Encoding.UTF8.GetBytes(password);

        // Kết hợp salt và mật khẩu
        byte[] combinedBytes = new byte[saltBytes.Length + passwordBytes.Length];
        Array.Copy(saltBytes, 0, combinedBytes, 0, saltBytes.Length);
        Array.Copy(passwordBytes, 0, combinedBytes, saltBytes.Length, passwordBytes.Length);

        // Sử dụng hàm băm SHA256 để tạo khóa
        using (SHA256 sha256 = SHA256.Create())
        {
            byte[] hash = sha256.ComputeHash(combinedBytes);

            // Cắt hoặc mở rộng kết quả thành kích thước khóa phù hợp
            byte[] key = new byte[keySizeInBytes];
            Array.Copy(hash, key, Math.Min(keySizeInBytes, hash.Length));

            return key;
        }
    }

}
