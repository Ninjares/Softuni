using System;

namespace UnitTesting
{
    class Program
    {

        /*7 testing principles
         * 1. Testing is context dependent
         * 2. Exhaustive testing is impossible (brute force - trying every software condition)
         * 3. The later a bug is id'd and fixed the more it costs
         * 4. Testing effort shell ba focused proportionally (focus on the risky stuff)
         * 5. Same tests repeated over and over tend to lose their effectiveness
         * 6. Testing shows presence of defects. 
         * 7. If all tests pass it doesn't necessarily mean there aren't any bugs - system must be usable, must fulful the users's needs
         * 
         * Install from get nuget packages:
         * NUnit
         * NUnit3TestAdapter
         * Microsoft.Net.Test.Sdk
         * 
         * Mock - falshiv obekt, koyto enkapsulira fuknciq koqto iskash da testvash
         * 
         * 
         * [Test]
            public void HeroGainsExperienceAfterAttackIfTargetDies() {
            Mock<ITarget> fakeTarget = new Mock<ITarget>();
            fakeTarget.Setup(p => p.Health).Returns(0);
            fakeTarget.Setup(p => p.GiveExperience()).Returns(20);
            fakeTarget.Setup(p => p.IsDead()).Returns(true);
            Mock<IWeapon> fakeWeapon = new Mock<IWeapon>();\
            Hero hero = new Hero("Pesho", fakeWeapon.Object);
            hero.Attack(fakeTarget.Object);
            Assert.That(hero.Experience, Is.EqualTo(20));
        */
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        static int ReturnN(int n)
        {
            return n*2;
        }
    }
}
