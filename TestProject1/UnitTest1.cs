using ConsoleApp1;
using NUnit.Framework;

namespace TestProject1;

public class Tests
{
    [Test]
    public void Test1()
    {
        uint y = 123;
        UIntX x = y;
        uint z = x;
        
        Assert.AreEqual(y, z);
    }
    
    [Test]
    public void Add()
    {
        UIntX a = 123;
        UIntX b = 399;
        uint s = a + b;
        
        Assert.AreEqual(123+399, s);
    }
    
    [Test]
    public void LeftRotate()
    {
        UIntX a = 0x0F;
        uint b = a;
        UIntX ar =MD5.leftRotate(a, 1);
        uint br =MD5.leftRotate(b, 1);

        Assert.AreEqual(br, (uint)ar);
    }
}