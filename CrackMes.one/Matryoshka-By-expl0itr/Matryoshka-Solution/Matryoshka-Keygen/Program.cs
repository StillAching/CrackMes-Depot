using System.Security.Cryptography;
using System.Text;


string SecretKey = "crackmes.onecrackmes.onecrackmes";

Console.Title = "Matryoshka CrackMe by expl0itr | Keygen by StillAching";

Console.Write("Enter Username: ");
string username = Console.ReadLine();

string licenseKey = GenerateLicenseKey(username);
Console.WriteLine($"Generated License Key: {licenseKey}");
Console.WriteLine("Job Done!");
Console.WriteLine("Press [Enter] to exit...");
Console.ReadLine();

string GenerateLicenseKey(string username)
{
    string hash = ComputeSha256Hash(username);
    string licenseKey = EncryptString(hash, SecretKey);
    return licenseKey;
}

string ComputeSha256Hash(string rawData)
{
    using (SHA256 sha256 = SHA256.Create())
    {
        byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(rawData));
        StringBuilder stringBuilder = new StringBuilder();
        foreach (byte b in bytes)
        {
            stringBuilder.Append(b.ToString("x2").ToUpper());
        }
        return stringBuilder.ToString();
    }
}

string EncryptString(string text, string key)
{
    using (Aes aes = Aes.Create())
    {
        aes.Key = Encoding.UTF8.GetBytes(key);
        aes.Mode = CipherMode.ECB;
        aes.Padding = PaddingMode.PKCS7;

        ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);
        byte[] encryptedBytes = encryptor.TransformFinalBlock(Encoding.UTF8.GetBytes(text), 0, text.Length);

        return BitConverter.ToString(encryptedBytes.Take(16).ToArray()).Replace("-", "").Substring(0, 20);
    }
}
