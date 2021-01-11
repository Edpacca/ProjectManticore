using System;
using System.Collections.Generic;

namespace ProjectManticore
{
    class Program
    {
        static void Main(string[] args)
        {
            string databaseDiskPath = @"C:\Users\eddie\OneDrive\ComputerScience\ProjectManticore\Database\5e_monsters.json";
            string databaseWebPath = "https://gist.githubusercontent.com/tkfu/9819e4ac6d529e225e9fc58b358c3479/raw/d4df8804c25a662efc42936db60cfbc0a5b19db8/srd_5e_monsters.json";

            IFileDeserialiser webDeserialiser = new WebDeserialiser();
            IFileDeserialiser diskDeserialiser = new DiskDeserialiser();

            MonsterManager monsterManager = new MonsterManager(diskDeserialiser, databaseDiskPath);

            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine(monsterManager.MonsterStats[i].Dexterity);

                Console.WriteLine("");
            }
        }
    }
}
