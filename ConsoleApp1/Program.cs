using SecurityFramework.NetCore.Cryptography.Hashing;
using SecurityFramework.NetCore.Cryptography.Hashing.Enums;
using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            IHashing hashing = new Hashing(); 
            Console.WriteLine(hashing.getHashingStr("Hello World!",DigestAlgorithm. KECCAK_256));
            Console.ReadLine();
        }
    }
}
