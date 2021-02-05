using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Linq;

namespace ManticoreViewer
{
    public partial class MainWindow : Window
    {
        string databaseDiskPath = @"C:\Users\eddie\OneDrive\ComputerScience\ProjectManticore\Database\5e_monsters.json";
        //string databaseDiskPath = @"C:\Users\eddie\Documents\OneDrive\ComputerScience\ProjectManticore\Database\5e_monsters.json";
        IFileDeserialiser diskDeserialiser = new DiskDeserialiser();

        MonsterManager _monsterManager;
        List<Monster> _monsterDatabase;
        public ObservableCollection<Monster> activeMonsters;
        DiceRoller diceRoller = new DiceRoller();
        public ObservableCollection<string> rollResultList;



        public MainWindow()
        {
            InitializeComponent();
            _monsterManager = new MonsterManager(diskDeserialiser, databaseDiskPath);
            
            _monsterDatabase = _monsterManager.MonsterDatabase ?? new List<Monster>();
            activeMonsters = new ObservableCollection<Monster>();
            rollResultList = new ObservableCollection<string>();
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
                speed2ComboBox.ItemsSource = new List<string>() { "swim", "fly", "burrow", "climb" };
                rollResultLog.ItemsSource = rollResultList;
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

        private void RemoveButtonClick(object sender, RoutedEventArgs e)
        {
            if (activeMonsters.Count > 0)
                activeMonsters.RemoveAt(ActiveMonsters.SelectedIndex);
        }

        protected virtual void OnDiceRolled(object sender, RoutedEventArgs e)
        {
            try
            {
                int numberOfDice = Convert.ToInt32(diceNumber.Text);
                int typeOfDice = Convert.ToInt32(diceType.Text);
                int modifier = Convert.ToInt32(diceModifier.Text);

                DRollResult roll = diceRoller.OnDiceRolled(sender, new DiceEventArgs() { Dice = new Dice(numberOfDice, typeOfDice, modifier) });
                rollResultBox.Text = roll.RollResult.ToString();
                rollResultStringBox.Text = roll.RollString;

                rollResultList.Add(roll.RollString);

            }
            catch (Exception)
            {
                MessageBox.Show("Dice parameters must be integers");
            }
        }

        private void SaveButtonClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Saved");
        }

        private void LoadButtonClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Loaded");
        }

        private void ClearRollsButtonClick(object sender, RoutedEventArgs e)
        {
            rollResultList.Clear();
        }

        private void SaveMonster(object sender, RoutedEventArgs e)
        {
            var monster = new Monster();

            try
            {
                monster.Name = entryName.Text;

                try
                {
                    monster.HitPoints = Convert.ToInt32(entryHP.Text);
                    monster.CurrentHitPoints = monster.HitPoints;
                }
                catch (Exception)
                {
                    MessageBox.Show("Error: HP must be integer");
                    return;
                }

                try
                {
                    monster.ArmourClass = Convert.ToByte(entryAC.Text);
                }
                catch (Exception)
                {

                    MessageBox.Show("Error: AC must be integer");
                    return;
                }

                try
                {
                    if (string.IsNullOrWhiteSpace(entrySpeed2.Text))
                        monster.Speed = Convert.ToInt32(entrySpeed1.Text) + " ft., ";
                    else if (speed2ComboBox.SelectedItem == null)
                    {
                        MessageBox.Show("Please select second movement type");
                        return;
                    }

                    else
                        monster.Speed = Convert.ToInt32(entrySpeed1.Text) + " ft., " + speed2ComboBox.SelectedItem + " " + Convert.ToInt32(entrySpeed2.Text) + " ft.";
                }
                catch (Exception)
                {
                    MessageBox.Show("Error: speed values must be integer");
                    return;
                }

                try
                {
                    monster.Strength = Convert.ToByte(entrySTR.Text);
                    monster.Dexterity = Convert.ToByte(entryDEX.Text);
                    monster.Constitution = Convert.ToByte(entryCON.Text);
                    monster.Intelligence = Convert.ToByte(entryINT.Text);
                    monster.Wisdom = Convert.ToByte(entryWIS.Text);
                    monster.Charisma = Convert.ToByte(entryCHA.Text);
                }
                catch (Exception)
                {
                    MessageBox.Show("Error: ability scores must be integer values");
                    return;
                }

                if (!string.IsNullOrEmpty(ImageURLTextBox.Text))
                    monster.ImgURL = ImageURLTextBox.Text;

                monster.ChallengeRating = 1;
                monster.SetModifiers();
                _monsterDatabase.Add(monster);
                activeMonsters.Add(monster);
            }
            catch (Exception)
            {
                MessageBox.Show("Error creating mosnter - did you fill in all the boxes?");
            }
        }

        private void RollWithModifier(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;

            try
            {
                int modifier = Convert.ToInt32(button.Content);
                DRollResult roll = diceRoller.OnDiceRolled(sender, new DiceEventArgs() { Dice = new Dice(1, 20, modifier) });
                rollResultBox.Text = roll.RollResult.ToString();
                rollResultStringBox.Text = roll.RollString;
                rollResultList.Add(roll.RollString);
            }
            catch (Exception)
            {
                MessageBox.Show("No active monster selected");
            }
        }

        private void ApplyDamage(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            int modifier = button.Name == "healButton" ? 1 : -1;

            try
            {
                int damage = Convert.ToInt32(DamageBox.Text);

                int newHP = activeMonsters[ActiveMonsters.SelectedIndex].CurrentHitPoints += (damage * modifier);

                if (newHP < 0)
                    newHP = 0;
                else if (newHP > activeMonsters[ActiveMonsters.SelectedIndex].HitPoints)
                    newHP = activeMonsters[ActiveMonsters.SelectedIndex].HitPoints;

                activeMonsters[ActiveMonsters.SelectedIndex].CurrentHitPoints = newHP;
                currentHP.Text = newHP.ToString();

            }
            catch (Exception)
            {
            }
        }

        private void AddMonsterInstance(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;

            try
            {
                if (button.Name == "addInstanceButton")
                {
                    activeMonsters[ActiveMonsters.SelectedIndex].AddInstance();
                    monsterDuplicates.ItemsSource = activeMonsters[ActiveMonsters.SelectedIndex].CurrentHPCount;
                }
                else if (button.Name == "removeInstanceButton")
                {
                    activeMonsters[ActiveMonsters.SelectedIndex].RemoveInstance();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Select a monster");
            }
        }
    }
}
