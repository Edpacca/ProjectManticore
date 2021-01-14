using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace ProjectManticore
{
    public class MonsterManager
    {
        private StatBlockParser _parser = new StatBlockParser();

        public List<Stats> MonsterStats { get; private set; }
        public List<object> MonsterList { get; private set; }

        public MonsterManager(IFileDeserialiser deserialiser, string path)
        {
            MonsterStats = _parser.ParseObjects(deserialiser.Deserialise(path));
        }
    }
}
