namespace Bijection
{
    /// <summary>
    /// Standard alphabets commonly used in bijective encoding/decoding functions.
    /// </summary>
    public static class Alphabet
    {
        /// <summary>
        /// Base-16 / Hexadecimal.
        /// </summary>
        public const string Base16 = "0123456789ABCDEF";

        /// <summary>
        /// Base-52 / Duopentagesimal: Base62 without vowels.
        /// </summary>
        public const string Base52 = "0123456789BCDFGHJKLMNPQRSTVWXYZbcdfghjklmnpqrstvwxyz";

        /// <summary>
        /// Base-62 / Duosexagesimal: 0-9, A-Z, a-z.
        /// </summary>
        public const string Base62 = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
    }
}
