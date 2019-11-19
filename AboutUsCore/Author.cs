using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace GeekGrapher.AboutUsCore
{
    [DataContract]
    public class Author
    {
        [DataMember]
        public string FirstName { get; set; }

        [DataMember]
        public string LastName { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public string ImagePath { get; set; }

        [DataMember]
        public string DonateLink { get; set; }
    }
}
