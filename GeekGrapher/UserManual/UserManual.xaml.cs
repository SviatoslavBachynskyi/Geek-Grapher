using System;
using System.Collections.Generic;
using System.IO;
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
using GeekGrapher.UserManual.ViewModels;

namespace GeekGrapher.UserManual
{
    /// <summary>
    /// Interaction logic for UserManual.xaml
    /// </summary>
    public partial class UserManual : Window
    {
        private ManualViewModel _viewModel;

        internal ManualViewModel ViewModel
        {
            get => _viewModel;
            set
            {
                _viewModel = value;
                DataContext = value;
            }
        }

        public UserManual()
        {
            InitializeComponent();

            //TODO load manual from json

            var topics = new List<TopicViewModel>()
            {
                new TopicViewModel()
                {
                    Header = "Загальна інформація",
                    FilePath = "../../Assets/Manual/General.rtf"
                },
                new TopicViewModel()
                {
                    Header = "Комплексні числа",
                    FilePath = "../../Assets/Manual/Complex.rtf"
                },
                new TopicViewModel()
                {
                    Header = "Фрактальні зображення",
                    FilePath = "../../Assets/Manual/Fractal.rtf"
                },
                new TopicViewModel()
                {
                    Header = "Колірні моделі",
                    FilePath = "../../Assets/Manual/Models.rtf"
                },
                new TopicViewModel()
                {
                    Header = "Афінні перетворення",
                    FilePath = "../../Assets/Manual/Transformations.rtf"
                },
            };

            ViewModel = new ManualViewModel()
            {
                Topics = topics
            };

            ViewModel.LoadFromFile.Execute(topics[0].FilePath);
        }
    }
}
