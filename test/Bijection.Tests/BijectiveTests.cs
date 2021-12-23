using System;
using Xunit;

namespace Bijection.Tests;

public class BijectiveTests
{
    [Theory]
    [InlineData("0", 0, Alphabet.Base62)]
    [InlineData("1", 1, Alphabet.Base62)]
    [InlineData("z", 61, Alphabet.Base62)]
    [InlineData("10", 62, Alphabet.Base62)]
    [InlineData("zz", 3843, Alphabet.Base62)]
    public void Encode(string result, int value, string alphabet)
    {
        Assert.Equal(result, Bijective.Encode(value, alphabet));
    }

    [Theory]
    [InlineData("LZ", 1337, Alphabet.Base62, 0)]
    [InlineData("LZ", 1337, Alphabet.Base62, 1)]
    [InlineData("LZ", 1337, Alphabet.Base62, 2)]
    [InlineData("0LZ", 1337, Alphabet.Base62, 3)]
    [InlineData("00000000LZ", 1337, Alphabet.Base62, 10)]
    public void EncodeWithPadding(string expected, int value, string alphabet, int padding)
    {
        Assert.Equal(expected, Bijective.Encode(value, alphabet, padding));
    }

    [Theory]
    [InlineData(0, "0", Alphabet.Base62)]
    [InlineData(1, "1", Alphabet.Base62)]
    [InlineData(61, "z", Alphabet.Base62)]
    [InlineData(62, "10", Alphabet.Base62)]
    [InlineData(3843, "zz", Alphabet.Base62)]
    [InlineData(1337, "000LZ", Alphabet.Base62)]
    [InlineData(1337, "00000000LZ", Alphabet.Base62)]
    public void Decode(int expected, string value, string alphabet)
    {
        Assert.Equal(expected, Bijective.Decode(value, alphabet));
    }

    [Fact]
    public void Encode_ValueLessThanZero_ThrowsArgumentOutOfRangeException()
    {
        var exception = Assert.Throws<ArgumentOutOfRangeException>(() => Bijective.Encode(-1, Alphabet.Base62));
        Assert.Contains("value must be greater than or equal to zero", exception.Message);
    }

    [Fact]
    public void EncodeWithPadding_ValueLessThanZero_ThrowsArgumentOutOfRangeException()
    {
        var exception = Assert.Throws<ArgumentOutOfRangeException>(() => Bijective.Encode(-1, Alphabet.Base62, 10));
        Assert.Contains("value must be greater than or equal to zero", exception.Message);
    }

    [Fact]
    public void Encode_AlphabetIsNull_ThrowsArgumentNullException()
    {
        var exception = Assert.Throws<ArgumentNullException>(() => Bijective.Encode(1, null));
        Assert.Contains("alphabet must not be null", exception.Message);
    }

    [Fact]
    public void EncodeWithPadding_AlphabetIsNull_ThrowsArgumentNullException()
    {
        var exception = Assert.Throws<ArgumentNullException>(() => Bijective.Encode(1, null, 10));
        Assert.Contains("alphabet must not be null", exception.Message);
    }

    [Fact]
    public void Encode_AlphabetIsAnEmptyString_ThrowsArgumentNullException()
    {
        var exception = Assert.Throws<ArgumentException>(() => Bijective.Encode(1, ""));
        Assert.Contains("alphabet must not be an empty string", exception.Message);
    }

    [Fact]
    public void EncodeWithPadding_AlphabetIsAnEmptyString_ThrowsArgumentNullException()
    {
        var exception = Assert.Throws<ArgumentException>(() => Bijective.Encode(1, "", 10));
        Assert.Contains("alphabet must not be an empty string", exception.Message);
    }

    [Fact]
    public void EncodeWithPadding_PaddingLessThanZero_ThrowsArgumentOutOfRangeException()
    {
        var exception = Assert.Throws<ArgumentOutOfRangeException>(() => Bijective.Encode(1, Alphabet.Base62, -1));
        Assert.Contains("padding must be greater than or equal to zero", exception.Message);
    }

    [Fact]
    public void Decode_ValueIsNull_ThrowsArgumentNullException()
    {
        var exception = Assert.Throws<ArgumentNullException>(() => Bijective.Decode(null, Alphabet.Base62));
        Assert.Contains("value must not be null", exception.Message);
    }

    [Fact]
    public void Decode_ValueIsAnEmptyString_ThrowsArgumentNullException()
    {
        var exception = Assert.Throws<ArgumentException>(() => Bijective.Decode("", Alphabet.Base62));
        Assert.Contains("value must not be an empty string", exception.Message);
    }

    [Fact]
    public void Decode_AlphabetIsNull_ThrowsArgumentNullException()
    {
        var exception = Assert.Throws<ArgumentNullException>(() => Bijective.Decode("1", null));
        Assert.Contains("alphabet must not be null", exception.Message);
    }

    [Fact]
    public void Decode_AlphabetIsAnEmptyString_ThrowsArgumentNullException()
    {
        var exception = Assert.Throws<ArgumentException>(() => Bijective.Decode("1", ""));
        Assert.Contains("alphabet must not be an empty string", exception.Message);
    }
}
