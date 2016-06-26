Bijection
=========

Introduction
------------

Lightweight bijective encode/decode library for .NET

Installation
------------

```
PM> Install-Package Bijection
```

Encoding an integer as a string value
-------------------------------------

You can encode an integer as a string value, using an alphabet of your choice:

```csharp
string encoded = Bijective.Encode(1234, Alphabet.Base62);
```

Optionally, you can also pad the encoded values out to a certain length:

```csharp
string encoded = Bijective.Encode(1234, Alphabet.Base62, 10);
```

Decoding a string value to an integer
-------------------------------------

You can decode a string value to an integer, using an alphabet of your choice:

```csharp
int value = Bijective.Decode("n8i12F", Alphabet.Base62);
```

Copyright
---------

Copyright Matthew King 2016.

License
-------

Bijection is licensed under the [MIT License](https://opensource.org/licenses/MIT). Refer to license.txt for more information.
