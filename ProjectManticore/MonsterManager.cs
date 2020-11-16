using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectManticore
{
    public class MonsterManager
    {
        private string _databaseFilePath = @"C:\Users\eddie\OneDrive\ComputerScience\ProjectManticore\Database\5e_monsters.json";
        private dynamic _monsters;
        private StatBlockParser _parser = new StatBlockParser();
        public List<Stats> MonsterStats { get => _monsterStats; }
        private List<Stats> _monsterStats = new List<Stats>();

        public MonsterManager()
        {
            _monsters = Deserialiser.DeserialiseJSON(_databaseFilePath);
            _monsterStats = _parser.ParseObjects(_monsters);
        }

        public void PrintMonsters()
        {
            foreach (var monster in _monsters)
            {
                Console.WriteLine(monster);
            }
        }

        public void PrintFirstMonster()
        {
            Console.WriteLine(_monsters[0]);
        }

        public void PrintMonsterNames()
        {
            foreach (var name in _parser.ParseObjects(_monsters))
            {
                Console.WriteLine(name);
            }
        }

        public void PrintMonsterStats()
        {
            for (int i = 0; i < 10; i++)
            {
                _monsterStats[i].PrintStats();
            }
        }
    }
}
