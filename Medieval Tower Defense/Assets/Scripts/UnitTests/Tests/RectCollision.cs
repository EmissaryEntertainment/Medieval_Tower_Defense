using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class RectCollision
{
    public struct Point
    {
        public int x, y;
    };
    Point l1 = new Point();
    Point r1 = new Point();
    Point l2 = new Point();
    Point r2 = new Point();

    [Test]
    public void UniqueCharactersSimplePasses()
    {
        l1.x = 0; l1.y = 10; r1.x = 10; r1.y = 10;
        l2.x = 5; l2.y = 5; r2.x = 15; r2.y = 0;
        Assert.That(DoOverlap(l1,r1,l2,r2) == false);
    }

    public bool DoOverlap(Point l1,Point r1,Point l2,Point r2)
    {
        if(l1.x > r2.x || l2.x > r1.x)
        {
            return false;
        }

        if(l1.y<r2.y||l2.y<r1.y)
        {
            return false;
        }

        return true;
    }

}


