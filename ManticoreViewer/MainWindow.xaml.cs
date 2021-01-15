using System;
using System.Collections.Generic;
using System.Windows;
using ProjectManticore;

namespace ManticoreViewer
{
    public partial class MainWindow : Window
    {
        string databaseDiskPath = @"C:\Users\eddie\OneDrive\ComputerScience\ProjectManticore\Database\5e_monsters.json";
        //string databaseWebPath = "https://gist.githubusercontent.com/tkfu/9819e4ac6d529e225e9fc58b358c3479/raw/d4df8804c25a662efc42936db60cfbc0a5b19db8/srd_5e_monsters.json";

        //IFileDeserialiser webDeserialiser = new WebDeserialiser();
        IFileDeserialiser diskDeserialiser = new DiskDeserialiser();

        MonsterManager monsterManager;
        List<Stats> _monsterStats;

        public MainWindow()
        {
            InitializeComponent();
            monsterManager = new MonsterManager(diskDeserialiser, databaseDiskPath);

            _monsterStats = monsterManager.MonsterStats ?? new List<Stats>();
            Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                nameComboBox.DisplayMemberPath = "Name";
                nameComboBox.ItemsSource = _monsterStats;
                nameComboBox.Text = "Select monster";
            }
            catch (Exception)
            {
                Console.WriteLine("Error occured");
            }
        }
    }
}
