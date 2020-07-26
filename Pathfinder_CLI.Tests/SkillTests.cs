using System;
using Pathfinder_CLI.Game.GameEntities.Common.Interfaces;
using Pathfinder_CLI.Game.GameEntities.Common.Stats;
using Xunit;

namespace Pathfinder_CLI.Tests
{
    public class SkillTests
    {
        [Fact]
        public void BaseSkills_Test()
        {
            ISkill str, dex, intelli, str2, dex2, intelli2;
            str = new Strength(1);
            dex = new Dexterity(3);
            intelli = new Intelligence(5);
            str2 = new Strength(7);
            dex2 = new Dexterity(9);
            intelli2 = new Intelligence(1000); // big brain time
            
            Assert.True(str.GetModifier() == 1);
            Assert.True(dex.GetModifier() == 2);
            Assert.True(intelli.GetModifier() == 3);
            Assert.True(str2.GetModifier() == 4);
            Assert.True(dex2.GetModifier() == 5);
            Assert.True(intelli2.GetModifier() == 5);
        }
    }
}
