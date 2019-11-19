using AutoMapper;
using GeekGrapher.FractalCore;
using GeekGrapher.General;
using Ninject;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeekGrapher.FractalPainter.Commands
{
    class SaveAsXml : ChangableCommand
    {

        private readonly FractalPainterViewModel _windowViewModel;

        public SaveAsXml(FractalPainterViewModel windowViewModel)
        {
            _windowViewModel = windowViewModel;
        }

        public override bool CanExecute(object parameter)
        {
            return _windowViewModel.IsValid();
        }

        public override void Execute(object parameter)
        {
            var mapper = FractalPainter.Kernel.Get<IMapper>();

            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "XML file|*.xml";
                saveFileDialog.Title = "Save fractal as xml";

                if (saveFileDialog.ShowDialog() == DialogResult.OK && saveFileDialog.FileName.Trim() != "")
                {
                    using (var writer = new FileStream(saveFileDialog.FileName, FileMode.Create))
                    {
                        var serializer = new DataContractSerializer(typeof(FractalModel));
                        serializer.WriteObject(writer, mapper.Map<FractalPainterViewModel, FractalModel>(_windowViewModel));
                    }
                }
            }
        }
    }
}
