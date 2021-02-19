using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Shapes;

namespace ManticoreViewer.ProjectManticore.Views
{
    public partial class EncountersWindow : Window
    {
        string databaseDiskPath = @"C:\Users\eddie\OneDrive\ComputerScience\ProjectManticore\Database\5e_monsters.json";
        IFileDeserialiser diskDeserialiser = new DiskDeserialiser();
        MonsterManager _monsterManager;
        List<Monster> _monsterDatabase;

        ObservableCollection<Monster> _activeMonsters;
        ObservableCollection<string> _rollResultList;

        CreateMonsterWindow createMonsterWindow;

        public EncountersWindow()
        {
            InitializeComponent();
            _monsterManager = new MonsterManager(diskDeserialiser, databaseDiskPath);
            _activeMonsters = new ObservableCollection<Monster>();
            _rollResultList = new ObservableCollection<string>();
            _monsterDatabase = _monsterManager.MonsterDatabase ?? new List<Monster>();

            SetupDatabaseBrowser();
        }

        private void SetupDatabaseBrowser()
        {
            DbNameCombobox.ItemsSource = _monsterDatabase;
            DbNameCombobox.DisplayMemberPath = "Name";
            DbNameCombobox.Text = "Select Monster";
        }

        private void SetupActiveMonsters()
        {

        }
    }
}
