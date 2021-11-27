using System;
using System.IO;
using System.Text;

namespace MyTestNamespace
{
    public class Program
    {
        public static void Main(string[] args)
        {
            TestFileRead();
            TestFileWrite();
        }

        private static void TestFileWrite()
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "activity.txt");
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Hello");
            sb.AppendLine("World");
            File.WriteAllText(path, sb.ToString());
        }

        private static void TestFileRead()
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "accounts.txt");
            string[] lines = File.ReadAllLines(path);
            foreach (string line in lines)
            {
                // use Split to split the line based on separator
                string[] parts = line.Split(',');
                foreach (string part in parts)
                {
                    Console.Write(part);
                    Console.Write("|");
                }
                Console.WriteLine();
            }
        }
    }
}