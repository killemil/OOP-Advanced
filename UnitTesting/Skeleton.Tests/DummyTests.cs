using NUnit.Framework;
using System;

[TestFixture]
public class DummyTests
{
    [Test]
    public void DummyLosesHealthAfterAttack()
    {
        Dummy dummy = new Dummy(10, 10);
        Axe axe = new Axe(5, 5);

        axe.Attack(dummy);

        Assert.AreEqual(5, dummy.Health);
    }

    [Test]
    public void DummyThrowsExceptionIfAttacked()
    {
        Dummy dummy = new Dummy(0, 10);
        Axe axe = new Axe(5, 5);

        InvalidOperationException ex =
            Assert.Throws<InvalidOperationException>(() => axe.Attack(dummy));
        Assert.AreEqual("Dummy is dead.", ex.Message);
    }

    [Test]
    public void DeadDummyGivesXP()
    {
        Dummy dummy = new Dummy(0, 10);

        Assert.AreEqual(10, dummy.GiveExperience());
    }

    [Test]
    public void AliveDummyDontGiveXP()
    {
        Dummy dummy = new Dummy(5, 10);

        InvalidOperationException ex =
            Assert.Throws<InvalidOperationException>(() => dummy.GiveExperience());
        Assert.AreEqual("Target is not dead.", ex.Message);
    }
}

