using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace ManticoreViewer
{
    public class MonsterManager
    {
        private StatBlockParser _parser = new StatBlockParser();

        public List<Monster> MonsterDatabase { get; private set; }
        public List<Monster> ActiveMonsters { get; private set; }

        public MonsterManager(IFileDeserialiser deserialiser, string path)
        {
            ActiveMonsters = new List<Monster>();
            MonsterDatabase = _parser.ParseObjects(deserialiser.Deserialise(path));
        }

        public void AddMonster(Monster monster)
        {
            ActiveMonsters.Add(monster);
        }
    }
}
