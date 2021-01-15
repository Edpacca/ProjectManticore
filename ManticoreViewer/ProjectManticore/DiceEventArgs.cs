using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ManticoreViewer
{
    public class DiceEventArgs : RoutedEventArgs
    {
        public Dice Dice { get; set; }
    }
}
