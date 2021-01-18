using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;

namespace ManticoreViewer
{
    public partial class MainWindow : Window
    {
        string databaseDiskPath = @"C:\Users\eddie\OneDrive\ComputerScience\ProjectManticore\Database\5e_monsters.json";
        IFileDeserialiser diskDeserialiser = new DiskDeserialiser();

        MonsterManager _monsterManager;
        List<Monster> _monsterDatabase;
        public ObservableCollection<Monster> activeMonsters;
        DiceRoller diceRoller = new DiceRoller();

        public MainWindow()
        {
            InitializeComponent();
            _monsterManager = new MonsterManager(diskDeserialiser, databaseDiskPath);
            
            _monsterDatabase = _monsterManager.MonsterDatabase ?? new List<Monster>();
            activeMonsters = new ObservableCollection<Monster>();
            DataContext = this;
            Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                nameComboBox.DisplayMemberPath = "Name";
                nameComboBox.ItemsSource = _monsterDatabase;
                nameComboBox.Text = "Select monster";
                ActiveMonsters.ItemsSource = activeMonsters;
            }
            catch (Exception)
            {
                Console.WriteLine("Error occured");
            }
        }

        private void AddButtonClick(object sender, RoutedEventArgs e)
        {
            try
            {
                var monster = (Monster)nameComboBox.SelectedItem;
                if (monster != null && !activeMonsters.Contains(monster))
                {
                    activeMonsters.Add(monster);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Monster must be selected to add to list");
            }
        }

        protected virtual void OnDiceRolled(object sender, RoutedEventArgs e)
        {
            try
            {
                int numberOfDice = Convert.ToInt32(diceNumber.Text);
                int typeOfDice = Convert.ToInt32(diceType.Text);
                int modifier = Convert.ToInt32(diceModifier.Text);

                diceRoller.OnDiceRolled(sender, new DiceEventArgs() { Dice = new Dice(numberOfDice, typeOfDice, modifier) });
            }
            catch (Exception)
            {
                MessageBox.Show("Dice parameters must be integers");
            }
        }
    }
}
