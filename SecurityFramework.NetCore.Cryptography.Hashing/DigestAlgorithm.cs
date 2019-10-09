using System;

namespace SecurityFramework.NetCore.Cryptography.Hashing.Enums
{
    /// <summary>
    /// Enumerado que contiene los algoritmos de hash disponibles en la libreria para ser utilizados
    /// </summary>
    public enum DigestAlgorithm
    {
        GOST3411,
        KECCAK_224, KECCAK_256, KECCAK_288, KECCAK_384, KECCAK_512,
        MD2, MD4, MD5,
        RIPEMD128, RIPEMD160, RIPEMD256, RIPEMD320,
        SHA_1, SHA_224, SHA_256, SHA_384, SHA_512,
        SHA_512_224, SHA_512_256,
        SHA3_224, SHA3_256, SHA3_384, SHA3_512,
        SHAKE128, SHAKE256,
        TIGER,
        WHIRLPOOL
    }
}
