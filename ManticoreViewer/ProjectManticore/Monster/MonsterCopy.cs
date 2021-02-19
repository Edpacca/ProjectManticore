using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManticoreViewer
{
    public static class MonsterCopy
    {
        public static Monster CopyMonster(Monster monster)
        {
            var copiedMonster = new Monster();

            copiedMonster.Name = monster.Name;
            copiedMonster.HitPoints = monster.HitPoints;
            copiedMonster.CurrentHitPoints = monster.CurrentHitPoints;
            copiedMonster.Strength = monster.Strength;
            copiedMonster.Dexterity = monster.Dexterity;
            copiedMonster.Constitution = monster.Constitution;
            copiedMonster.Intelligence = monster.Intelligence;
            copiedMonster.Wisdom = monster.Wisdom;
            copiedMonster.Charisma = monster.Charisma;
            copiedMonster.ImgURL = monster.ImgURL;
            copiedMonster.Speed = monster.Speed;
            copiedMonster.ChallengeRating = monster.ChallengeRating;
            copiedMonster.ArmourClass = monster.ArmourClass;
            copiedMonster.SetModifiers();

            return copiedMonster;
        }
    }
}
