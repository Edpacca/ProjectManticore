using System;
using System.Collections.Generic;
using System.Windows;

namespace ManticoreViewer
{
    public partial class MainWindow : Window
    {
        string databaseDiskPath = @"C:\Users\eddie\OneDrive\ComputerScience\ProjectManticore\Database\5e_monsters.json";
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
