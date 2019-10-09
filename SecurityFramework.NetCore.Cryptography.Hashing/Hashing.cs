using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.Utilities.Encoders;
using SecurityFramework.NetCore.Cryptography.Hashing.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace SecurityFramework.NetCore.Cryptography.Hashing
{
    public class Hashing : IHashing
    {
        /// <summary>
        /// Obtiene el hash de una string basado en un algoritmo seleccionado
        /// <see cref=""/> DigestAlgorithm</summary>
        /// <param name="plainText"></param>
        /// <param name="algorithm"></param>
        /// </summary>
        /// <param name="text">texto a realizar hash</param>
        /// <param name="algorithm">Algoritmo seleccionado para realizar el proceso de hashing</param>
        /// <returns>Hash del texto en bytes</returns>
        public byte[] getHashing(string plainText, DigestAlgorithm algorithm = DigestAlgorithm.KECCAK_256)
        {
            if (String.IsNullOrEmpty(plainText))
            {
                //TODO throw new SecurityException();
            }
            byte[] result = doHashing(plainText, algorithm);

            return result;
        }

        /// <summary>
        /// Obtiene el hash de una string basado en un algoritmo seleccionado
        /// @see DigestAlgorithm
        /// </summary>
        /// <param name="text">texto a realizar hash</param>
        /// <param name="algorithm">Algoritmo seleccionado para realizar el proceso de hashing</param>
        /// <returns>String con el hash.</returns>
        public string getHashingStr(string text, DigestAlgorithm algorithm)
        {
            byte[] hash = getHashing(text, algorithm);
            String hexString = BitConverter.ToString(hash).Replace("-", "").ToLower();
            return hexString;
        }

        /// <summary>
        /// Método encargado de realizar el proceso de seleccion de hashing dependiendo del algoritmo
        /// </summary>
        /// <param name="message">Mensaje a realizar el proceso de hashing</param>
        /// <param name="algorithm">Algoritmo con el cual se realizara el proceso de hashing</param>
        /// <returns></returns>
        private byte[] doHashing(string message, DigestAlgorithm algorithm)
        {
            if (algorithm.ToString().Contains("KECCAK") || algorithm.ToString().Contains("SHA3_"))
            {
                return doSHA3Hashing(message, algorithm);
            }
            else
            {
                return doHashes(message, algorithm);
            }
        }

        private byte[] doHashes(string message, DigestAlgorithm algorithm)
        {
            byte[] mBytes = Encoding.UTF8.GetBytes(message);
            IDigest digest = DigestUtilities.GetDigest(algorithm.ToString());
            byte[] hash = DigestUtilities.DoFinal(digest, mBytes);
            return hash;
        }

        /// <summary>
        /// Método encargado los hashing para métodos de tipo crypto esponja
        /// </summary>
        /// <param name="message">Mensaje al que se realizara el hashing</param>
        /// <param name="algorithm"></param>
        /// <returns></returns>
        private byte[] doSHA3Hashing(string message, DigestAlgorithm algorithm)
        {
            IDigest digest = DigestUtilities.GetDigest(algorithm.ToString());
            byte[] hash = new byte[digest.GetDigestSize()];
            byte[] databt = Encoding.Default.GetBytes(message);
            String hexString = BitConverter.ToString(databt).Replace("-", "").ToLowerInvariant();
            byte[] data = Hex.Decode(hexString);
            digest.BlockUpdate(data, 0, data.Length);
            digest.DoFinal(hash, 0);
            return hash;
        }

        public string GetSaltString(int size)
        {
            SecureRandom saltstring = new SecureRandom();
            byte[] ba = saltstring.GenerateSeed(size);
            return Convert.ToBase64String(ba);
        }

        public byte[] GetSaltBytes(int size)
        {
            SecureRandom saltstring = new SecureRandom();
            byte[] ba = saltstring.GenerateSeed(size);
            return ba;
        }

        private byte[] toByteArray(string input)
        {
            byte[] bytes = new byte[input.Length];

            for (int i = 0; i != bytes.Length; i++)
            {
                bytes[i] = (byte)input[i];
            }

            return bytes;
        }

        public string GetString(byte[] bytes)
        {
            char[] chars = new char[bytes.Length / sizeof(char)];
            System.Buffer.BlockCopy(bytes, 0, chars, 0, bytes.Length);
            return new string(chars);
        }
    }
}
