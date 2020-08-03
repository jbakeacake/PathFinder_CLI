using System.Collections.Generic;
using Pathfinder_CLI.Game.GameEntities.Characters;
using Pathfinder_CLI.Game.GameEntities.Characters.Interfaces;
using Pathfinder_CLI.Game.GameEntities.Common.Stats;
using Pathfinder_CLI.Tests.Helpers;
using Xunit;
using Xunit.Abstractions;

namespace Pathfinder_CLI.Tests
{
    public class CombativeTests
    {
        private readonly ITestOutputHelper _output;

        public CombativeTests(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public void PlayerDodge_Tests()
        {
            Dictionary<string, Skill> playerSkills = TestingUtils.GenerateSkills(1, 11, 1);
            Dictionary<string, Skill> enemySkills = TestingUtils.GenerateSkills(1, 3, 1);

            Stats playerStats = new Stats(10, 10, 0, 10, playerSkills);
            Stats enemyStats = new Stats(10, 10, 0, 10, enemySkills);

            PlayerEntity player = new PlayerEntity("Player",
            "PLAYER",
            playerStats,
            TestingUtils.GenerateInventory(),
            TestingUtils.GenerateEquipment()
            );

            EnemyEntity enemy = new EnemyEntity("Enemy",
            "ENEMY",
            enemyStats,
            TestingUtils.GenerateInventory(),
            TestingUtils.GenerateEquipment()
            );

            int hitMargin = 100 - (player._stats.GetSpeed() * 10); // Should be 50 with Dexterity = 10 (speed is +5 modifier)
            int missRoll = 69;
            int hitRoll = 70;
            int hitRoll_2 = 100;

            Assert.True(isHitDodged(player, enemy, missRoll));
            Assert.False(isHitDodged(player, enemy, hitRoll));
            Assert.False(isHitDodged(player, enemy, hitRoll_2));
        }

        private bool isHitDodged(ICombative dodger, ICombative attacker, int rollToHit)
        {
            _output.WriteLine($"\nDodger Speed: {dodger.GetCombatStats().GetSpeed()}");
            _output.WriteLine($"Attack Speed: {attacker.GetCombatStats().GetSpeed()}");
            // The difference between speeds determines how large the hit margin is / how small the dodge margin is
            int speedDifference = dodger.GetCombatStats().GetSpeed() - attacker.GetCombatStats().GetSpeed();
            // Having a speed difference less than or equal to 0 will result in a definite hit
            if (speedDifference < 0)
                speedDifference = 0;

            int hitMargin = 100 - (speedDifference * 10);
            _output.WriteLine($"Percentage to Dodge: {speedDifference * 10}%");
            _output.WriteLine($"Hit Margin: {hitMargin}");
            _output.WriteLine($"Attack Roll: {rollToHit}");

            if (rollToHit < hitMargin) // Hit Successful; We use '<' because a 100 roll is always going to hit
            {
                _output.WriteLine($"Result: Hit Success; (Lower: {0} <= Roll: {rollToHit} < Upper: {hitMargin})");
                return true;
            }
            else // Hit Missed
            {
                _output.WriteLine($"Result: Dodged; (Lower: {hitMargin} <= Roll: {rollToHit} <= Upper: 100)");
                return false;
            }
        }
    }
}