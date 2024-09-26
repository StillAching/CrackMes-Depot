using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        Console.Title = "CrackMe by flcksr | Keygen by StillAching";
        string generatedKey = GenerateKey();
        Console.WriteLine("Generated Key --> " + generatedKey);
        Console.WriteLine("Job Done! Press [Enter] to exit...");
        Console.ReadLine();
    }

    static int smethod_1(char char0)
    {
        return (char0 - '0') * 3 + (char0 % 2 == 0 ? 2 : 1) - (char0 / 3);
    }

    static bool IsValidKey(string string0)
    {
        int num = 55;
        if (!string0.StartsWith("4409"))
        {
            return false;
        }

        if (string0.Count(c => c == '8') < 4)
        {
            return false;
        }

        if (string0.Substring(4).Replace("-", "").Contains('4'))
        {
            return false;
        }

        if (!Regex.IsMatch(string0, @"^\d{4}-\d{4}-\d{4}-\d{4}$"))
        {
            return false;
        }

        string text = string0.Replace("-", "");
        if (text.Distinct().Count() < 5)
        {
            return false;
        }

        int num3 = text.Sum(c => smethod_1(c));
        if (Regex.IsMatch(text, @"(\d)\1\1"))
        {
            return false;
        }

        if (num3 >= 55 && num3 <= 110)
        {
            return false;
        }

        int num4 = (55 + 110) / 2;
        for (int i = 0; i < num4; i++)
        {
            num3 = (num3 + i) % 110;
        }

        if (num3 < 55)
        {
            return false;
        }

        if (text.Count(c => "2357".Contains(c)) < 2)
        {
            return false;
        }

        foreach (var block in string0.Split('-').Skip(1))
        {
            for (int k = 0; k < block.Length - 1; k++)
            {
                if (block[k] == block[k + 1])
                {
                    return false;
                }
            }
        }

        return true;
    }

    static string GenerateKey()
    {
        Random random = new Random();
        while (true)
        {
            string key = "4409-";
            for (int i = 0; i < 3; i++)
            {
                string block = "";
                while (block.Length < 4)
                {
                    char c = (char)random.Next('0', '9' + 1);
                    if (c == '4' && i > 0)
                    {
                        continue;
                    }
                    block += c;
                }
                key += block + (i < 2 ? "-" : "");
            }

            if (IsValidKey(key))
            {
                return key;
            }
        }
    }
}
