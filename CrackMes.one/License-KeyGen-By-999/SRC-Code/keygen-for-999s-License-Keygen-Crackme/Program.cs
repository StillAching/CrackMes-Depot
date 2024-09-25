using System.Security.Cryptography;
using System.Text;

namespace keygen_for_999s_License_Keygen_Crackme
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "License KeyGen CrackMe By 999 | Keygen by StillAching";
            Console.WriteLine("Enter username: ");
            string username = Console.ReadLine();

            if (username.Length < 4)
            {
                Console.WriteLine("The username must contain at least 4 characters.");
                return;
            }

            string segment1, segment2, segment3;
            GenerateSerialKey(username, out segment1, out segment2, out segment3);

            Console.WriteLine($"Generated License Key: {segment1}-{segment2}-{segment3}");
            Console.WriteLine("Job Done! Press [Enter] to exit.");
            Console.ReadLine();
        }

        public static void GenerateSerialKey(string username, out string segment1, out string segment2, out string segment3)
        {
            segment1 = GenerateSegment(username);
            segment2 = GenerateSegment(username + "salt1");
            segment3 = GenerateSegment(username + "salt2");
        }

        private static string GenerateSegment(string input)
        {
            using (SHA256 sha = SHA256.Create())
            {
                byte[] hash = sha.ComputeHash(Encoding.UTF8.GetBytes(input));
                StringBuilder segmentBuilder = new StringBuilder();

                for (int i = 0; i < 2; i++)
                {
                    int num1 = hash[i] % 36;
                    int num2 = hash[i + 2] % 36;

                    char c1 = (num1 < 10) ? (char)(48 + num1) : (char)(65 + (num1 - 10));
                    char c2 = (num2 < 10) ? (char)(48 + num2) : (char)(65 + (num2 - 10));

                    segmentBuilder.Append(c1).Append(c2);
                }

                return segmentBuilder.ToString();
            }
        }
    }
}
