using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Native.Csharp.App.Gameplay.Generator;

namespace UnitTestDungeonBot.System
{
    [TestClass]
    public class AbilityGenTest
    {
        [TestMethod]
        public void Create()
        {
            new AbilityScoreGenerator();
        }

        [TestMethod]
        public void Generate()
        {
            AbilityScoreGenerator generator = new AbilityScoreGenerator();
            generator.Generate();
        }
    }
}
