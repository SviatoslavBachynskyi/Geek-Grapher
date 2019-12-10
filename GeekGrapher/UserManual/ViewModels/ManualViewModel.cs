using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GeekGrapher.General;
using GeekGrapher.UserManual.Commands;

namespace GeekGrapher.UserManual.ViewModels
{
    internal class ManualViewModel : BaseViewModel
    {
        public List<TopicViewModel> Topics { get; set; }

        private string _text;

        public string Text
        {
            get => _text;
            set
            {
                _text = value;
                OnPropertyChanged(nameof(Text));
            }
        }

        private ICommand _loadFromFile;

        public ICommand LoadFromFile
        {
            get
            {
                if (_loadFromFile == null)
                {
                    _loadFromFile = new LoadFromFile(this);
                }
                return _loadFromFile;
            }
        }
    }
}
