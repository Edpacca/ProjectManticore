using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectManticore
{
    public class MonsterManager
    {
        private string _databaseFilePath = @"C:\Users\eddie\OneDrive\ComputerScience\ProjectManticore\Database\5e_monsters.json";
        private string _databaseHTML = "https://gist.githubusercontent.com/tkfu/9819e4ac6d529e225e9fc58b358c3479/raw/d4df8804c25a662efc42936db60cfbc0a5b19db8/srd_5e_monsters.json";

        private dynamic _monsters;
        private StatBlockParser _parser = new StatBlockParser();
        public List<Stats> MonsterStats { get => _monsterStats; }
        private List<Stats> _monsterStats = new List<Stats>();

        public MonsterManager()
        {
            _monsters = Deserialiser.DeserialiseJSONFromDisk(_databaseFilePath);
            _monsterStats = _parser.ParseObjects(_monsters);

            Deserialiser.DeserialiseJSONFromWeb(_databaseHTML);
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
    }
}
