using System;
using System.Text;

namespace Bijection;

/// <summary>
/// Provides bijective encoding and decoding functions.
/// </summary>
public static class Bijective
{
    /// <summary>
    /// Encodes the specified value using the specified alphabet.
    /// </summary>
    /// <param name="value">The value to encode.</param>
    /// <param name="alphabet">The alphabet to encode the value with.</param>
    /// <returns>The specified value encoded with the specified alphabet.</returns>
    public static string Encode(int value, string alphabet)
    {
        return Encode(value, alphabet, null);
    }

    /// <summary>
    /// Encodes the specified value using the specified alphabet.
    /// </summary>
    /// <param name="value">The value to encode.</param>
    /// <param name="alphabet">The alphabet to encode the value with.</param>
    /// <param name="padding">The number of characters to pad the result to.</param>
    /// <returns>The specified value encoded with the specified alphabet.</returns>
    public static string Encode(int value, string alphabet, int? padding)
    {
        if (value < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(value), $"{nameof(value)} must be greater than or equal to zero");
        }

        if (alphabet == null)
        {
            throw new ArgumentNullException(nameof(alphabet), $"{nameof(alphabet)} must not be null");
        }

        if (alphabet.Length == 0)
        {
            throw new ArgumentException($"{nameof(alphabet)} must not be an empty string", nameof(alphabet));
        }

        if (padding < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(padding), $"{nameof(padding)} must be greater than or equal to zero");
        }

        var sb = new StringBuilder();

        if (value == 0)
        {
            sb.Append(alphabet[0]);
        }

        while (value > 0)
        {
            sb.Insert(0, alphabet[value % alphabet.Length]);
            value /= alphabet.Length;
        }

        if (padding.HasValue)
        {
            while (sb.Length < padding.Value)
            {
                sb.Insert(0, alphabet[0]);
            }
        }

        return sb.ToString();
    }

    /// <summary>
    /// Decodes the specified value using the specified alphabet.
    /// </summary>
    /// <param name="value">The value to decode.</param>
    /// <param name="alphabet">The alphabet to decode the value with.</param>
    /// <returns>The specified value decoded using the specified alphabet.</returns>
    public static int Decode(string value, string alphabet)
    {
        if (value == null)
        {
            throw new ArgumentNullException(nameof(value), $"{nameof(value)} must not be null");
        }

        if (value.Length == 0)
        {
            throw new ArgumentException($"{nameof(value)} must not be an empty string", nameof(alphabet));
        }

        if (alphabet == null)
        {
            throw new ArgumentNullException(nameof(alphabet), $"{nameof(alphabet)} must not be null");
        }

        if (alphabet.Length == 0)
        {
            throw new ArgumentException($"{nameof(alphabet)} must not be an empty string", nameof(alphabet));
        }

        var result = 0;

        for (int i = 0; i < value.Length; i++)
        {
            var c = value[value.Length - 1 - i];
            var index = alphabet.IndexOf(c);
            result += index * (int)Math.Pow(alphabet.Length, i);
        }

        return result;
    }
}
