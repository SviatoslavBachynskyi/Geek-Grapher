using GeekGrapher.AboutUsCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
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

namespace GeekGrapher.AboutUS
{
    /// <summary>
    /// Interaction logic for AboutUS.xaml
    /// </summary>
    public partial class AboutUS : Window
    {
        public AboutUS()
        {
            InitializeComponent();

            var mapper = Mapping.Create();

            using (var reader = new FileStream((string)FindResource("Authors"), FileMode.Open))
            {
                var serializer = new DataContractSerializer(typeof(AboutUsModel));
                var model = (AboutUsModel)serializer.ReadObject(reader);
                DataContext = mapper.Map<AboutUsModel, AboutUsViewModel>(model);
            }

        }
    }
}
