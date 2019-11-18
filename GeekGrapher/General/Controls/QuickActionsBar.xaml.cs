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

namespace GeekGrapher.General.Controls
{
    /// <summary>
    /// Interaction logic for QuickActionsBar.xaml
    /// </summary>
    public partial class QuickActionsBar : UserControl
    {
        public QuickActionsBar()
        {
            InitializeComponent();
        }

        public ICommand UndoCommand
        {
            get
            {
                return (ICommand)GetValue(UndoCommandProperty);
            }
            set
            {
                SetValue(UndoCommandProperty, value);
            }
        }

        public static readonly DependencyProperty UndoCommandProperty =
            DependencyProperty.Register("UndoCommand", typeof(ICommand),
            typeof(QuickActionsBar), new PropertyMetadata(null));

        public ICommand RedoCommand
        {
            get
            {
                return (ICommand)GetValue(RedoCommandProperty);
            }
            set
            {
                SetValue(RedoCommandProperty, value);
            }
        }

        public static readonly DependencyProperty RedoCommandProperty =
            DependencyProperty.Register("RedoCommand", typeof(ICommand),
            typeof(QuickActionsBar), new PropertyMetadata(null));

        public ICommand SaveCommand
        {
            get
            {
                return (ICommand)GetValue(SaveCommandProperty);
            }
            set
            {
                SetValue(SaveCommandProperty, value);
            }
        }

        public static readonly DependencyProperty SaveCommandProperty =
            DependencyProperty.Register("SaveCommand", typeof(ICommand),
            typeof(QuickActionsBar), new PropertyMetadata(null));
    }
}
