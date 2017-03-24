using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI
{
    static class GameStateConst
    {
        public const int ground = 1;

        public static class Character
        {
            public const int walk = 2;
            public const int jump = 3;
            public const int block = 4;
            public const int attackingRanged = 5;
            public const int attackingMelee = 6;
            public const int meleeHitbox = 7;
            public const int rangeHitbox = 8;
        }

        public class Opponent
        {
            public const int walk = -Character.walk;
            public const int jump = -Character.jump;
            public const int block = -Character.block;
            public const int attackingRanged = -Character.attackingRanged;
            public const int attackingMelee = -Character.attackingMelee;
            public const int meleeHitbox = -Character.meleeHitbox;
            public const int rangeHitbox = -Character.rangeHitbox;
        }
    }
}
