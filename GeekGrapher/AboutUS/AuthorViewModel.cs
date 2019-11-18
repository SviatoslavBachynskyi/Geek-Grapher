using GeekGrapher.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeekGrapher.AboutUS
{
    class AuthorViewModel : BaseViewModel
    {
        private string _firstName;
        public string FirstName { get => _firstName; set
            {
                _firstName = value;
                OnPropertyChanged(nameof(FirstName));
            }
        }

        private string _lastName;
        public string LastName
        {
            get => _lastName; set
            {
                _lastName = value;
                OnPropertyChanged(nameof(LastName));
            }
        }

        private string _description;
        public string Description
        {
            get => _description; set
            {
                _description = value;
                OnPropertyChanged(nameof(Description));
            }
        }

        private string _imagePath;
        public string ImagePath
        {
            get => _imagePath; set
            {
                _imagePath = value;
                OnPropertyChanged(nameof(ImagePath));
            }
        }

        private string _donateLink;
        public string DonateLink
        {
            get => _donateLink; set
            {
                _donateLink = value;
                OnPropertyChanged(nameof(DonateLink));
            }
        }
    }
}
