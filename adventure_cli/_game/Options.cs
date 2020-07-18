using System;
using System.Collections.Generic;
using adventure_cli._models.actions;
using adventure_cli._models.actions._options;
using adventure_cli._models.entities.characters;
using adventure_cli._models.entities.items;
using adventure_cli._models.entities.items.equipable;
using adventure_cli._models.entities.items.equipable.armor;
using adventure_cli._models.entities.items.equipable.weapon;

namespace adventure_cli._game
{
    public static class Options
    {
        public static void GetCombatOptions(PlayerEntity player, EnemyEntity enemy)
        {
            List<Option> attackSublist = new List<Option>();
            int counter = 1;
            foreach(var item in player._equipped._Items)
            {
                if(isTypeEqual(item, typeof(Weapon)))
                {
                    attackSublist.Add(new Attack(counter, item._name, (Weapon) item, enemy));
                }
                else if(isTypeEqual(item, typeof(Armor)))
                {
                    attackSublist.Add(new Defend(counter, item._name, (Armor) item, enemy));
                }
                counter++;
            }
            HeaderOption chooseAttack = new HeaderOption(1, "Choose Attack", attackSublist);
            Console.WriteLine(chooseAttack.SubListToString());
        }

        private static bool isTypeEqual(Item item, Type classType)
        {
            return item.GetType().Equals(classType);
        }
    }
}