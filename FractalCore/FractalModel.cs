using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace GeekGrapher.FractalCore
{
    [DataContract]
    public class FractalModel
    {
        [DataMember]
        public string CReal { get; set; }
        [DataMember]
        public string CImaginary { get; set; }
        [DataMember]
        public string MaxIterations { get; set; }
        [DataMember]
        public FractalFunction SelectedFractalFunction { get; set; }
        [DataMember]
        public ColorScheme SelectedColorScheme { get; set; }
        [DataMember]
        public string ColorCount { get; set; }
        [DataMember]
        public Color[] _palette { get; set; }

    }
}
