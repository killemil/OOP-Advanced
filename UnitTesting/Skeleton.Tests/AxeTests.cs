using NUnit.Framework;
using System;

[TestFixture]
public class AxeTests
{
    [Test]
    public void AxeLosesDurabilityAfterAttack()
    {
        Axe axe = new Axe(10, 10);
        Dummy dummy = new Dummy(10, 10);

        axe.Attack(dummy);

        Assert.AreEqual(9, axe.DurabilityPoints, "Axe durability doesn't cgange after the attack");
    }

    [Test]
    public void AttackWithBrokenAxe()
    {
        Axe axe = new Axe(10, 0);
        Dummy dummy = new Dummy(10, 10);

        InvalidOperationException ex = 
            Assert.Throws<InvalidOperationException>(() => axe.Attack(dummy));
        Assert.AreEqual("Axe is broken.", ex.Message);
    }
}
