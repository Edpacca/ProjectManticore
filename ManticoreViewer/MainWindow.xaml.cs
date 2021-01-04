using System;
using System.Collections.Generic;
using System.Windows;

namespace ManticoreViewer
{
    public partial class MainWindow : Window
    {
        private string _databaseFilePath = @"C:\Users\eddie\OneDrive\ComputerScience\ProjectManticore\Database\5e_monsters.json";
        //private string _databaseFilePath = @"C:\Users\eddie\Documents\5e_monsters.json";
        private StatBlockParser _parser = new StatBlockParser();
        private dynamic _monsters;
        private List<Stats> _monsterStats;

        public MainWindow()
        {
            InitializeComponent();
            _monsters = Deserialiser.DeserialiseJSON(_databaseFilePath);
            _monsterStats = _parser.ParseObjects(_monsters) ?? new List<Stats>();

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
