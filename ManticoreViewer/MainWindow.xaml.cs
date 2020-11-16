using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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
            _monsterStats = _parser.ParseObjects(_monsters);

            Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                nameComboBox.DisplayMemberPath = "Name";
                nameComboBox.SelectedValue = "Strength";
                nameComboBox.ItemsSource = _monsterStats;
                nameComboBox.Text = "Select monster";
                //DEX.Text = nameComboBox.SelectedValuePath = "DEX";
                //CON.Text = nameComboBox.SelectedValuePath = "CON";
                //INT.Text = nameComboBox.SelectedValuePath = "INT";
                //WIS.Text = nameComboBox.SelectedValuePath = "WIS";
                //CHA.Text = nameComboBox.SelectedValuePath = "CHA";
            }
            catch (Exception)
            {
                Console.WriteLine("Error occured");
            }
        }
    }
}
