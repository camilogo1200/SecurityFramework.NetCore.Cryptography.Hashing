using SecurityFramework.NetCore.Cryptography.Hashing.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace SecurityFramework.NetCore.Cryptography.Hashing
{
    public interface IHashing
    {
        /// <summary>
        /// Obtiene el Hashing del texto plano
        /// </summary>
        /// <param name="plainText">Texto plano</param>
        /// <param name="algorithm">Algoritmo mediante el cual se realizara el hashing</param>
        /// <returns></returns>
        string getHashingStr(String plainText, DigestAlgorithm algorithm);

        /// <summary>
        /// Obtiene el Hashing del texto plano
        /// </summary>
        /// <param name="plainText">Texto plano</param>
        /// <param name="algorithm">Algoritmo mediante el cual se realizara el hashing</param>
        /// <returns></returns>
        byte[] getHashing(String plainText, DigestAlgorithm algorithm);

        string GetSaltString(int size);

        byte[] GetSaltBytes(int size);
    }
}
