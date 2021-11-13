namespace ConsoleApp1;

public class UIntX
{
    public Expression[] Bits { get; }

    public UIntX(Expression[] bits)
    {
        Bits = bits;
    }

    public static implicit operator uint(UIntX x)
    {
        uint result = 0;
        uint c = 1;
        for (int i = 0; i < 32; i++)
        {
            var bi = x.Bits[i];
            var addBit = bi switch
            {
                TrueExp => true,
                FalseExp => false,
                _ => throw new InvalidOperationException($"Unknown exp {bi.GetType()}")
            };

            if (addBit)
            {
                result |= c;
            }

            c <<= 1;
        }

        return result;
    }


    public static implicit operator UIntX(uint x)
    {
        var list = new Expression[32];


        uint c = 1;
        for (int i = 0; i < 32; i++)
        {
            list[i] = (x & c) != 0;
            c <<= 1;
        }

        return new UIntX(list);
    }

    public static UIntX operator &(UIntX a, UIntX b)
    {
        return new UIntX(a.Bits.Zip(b.Bits, (x, y) => x & y).ToArray());
    }

    public static UIntX operator |(UIntX a, UIntX b)
    {
        return new UIntX(a.Bits.Zip(b.Bits, (x, y) => x | y).ToArray());
    }

    public static UIntX operator ^(UIntX a, UIntX b)
    {
        return new UIntX(a.Bits.Zip(b.Bits, (x, y) => x ^ y).ToArray());
    }


    public static UIntX operator ~(UIntX a)
    {
        return new UIntX(a.Bits.Select(x => !x).ToArray());
    }

    public static UIntX operator +(UIntX a, UIntX b)
    {
        Expression ca = false;
        var result = new Expression[32];
        for (int i = 0; i < 32; i++)
        {
            var ax = a.Bits[i];
            var bx = b.Bits[i];

            var cx = ax ^ bx ^ ca;
            ca = (ax & bx) | (bx & ca) | (ca & ax);
            result[i] = cx;
        }

        return new UIntX(result);
    }

    public UIntX LeftRotate(int amount)
    {
        var result = new Expression[32];
        for (var i = 0; i < 32; i++)
        {
            var bit = Bits[(32 + i - amount) % 32];
            result[i] = bit;
        }

        return new UIntX(result);
    }
}