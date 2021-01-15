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
        DiceRoller diceRoller = new DiceRoller();

        public MainWindow()
        {
            InitializeComponent();
            monsterManager = new MonsterManager(diskDeserialiser, databaseDiskPath);
            
            _monsterStats = monsterManager.MonsterStats ?? new List<Stats>();
            Loaded += MainWindow_Loaded;
            //rollButton.Click += diceRoller.OnDiceRolled;
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

        private void AddButtonClick(object sender, EventArgs e)
        {

        }

        public delegate void DiceRolledEventHandler(object source, RoutedEventArgs args);
        public event DiceRolledEventHandler DiceRolled;

        protected virtual void OnDiceRolled(object sender, RoutedEventArgs e)
        {
            try
            {
                int numberOfDice = Convert.ToInt32(diceNumber.Text);
                int typeOfDice = Convert.ToInt32(diceType.Text);
                int modifier = Convert.ToInt32(diceModifier.Text);

                diceRoller.OnDiceRolled(sender, new DiceEventArgs() { Dice = new Dice(numberOfDice, typeOfDice, modifier) });

               //if (DiceRolled != null)
                    //DiceRolled(sender, new DiceEventArgs() { Dice = new Dice(numberOfDice, typeOfDice, modifier) });
            }
            catch (Exception)
            {
                MessageBox.Show("Dice parameters must be integers");
            }
        }
    }
}
