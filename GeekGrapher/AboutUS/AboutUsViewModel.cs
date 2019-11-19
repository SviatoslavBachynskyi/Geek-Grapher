using GeekGrapher.General;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeekGrapher.AboutUS
{
    class AboutUsViewModel : BaseViewModel
    {
        private ObservableCollection<AuthorViewModel> _authors;
        public ObservableCollection<AuthorViewModel> Authors
        {
            get => _authors; set
            {
                _authors = value;
                OnPropertyChanged(nameof(Authors));
            }
        }
    }
}
