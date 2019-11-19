using AutoMapper;
using GeekGrapher.FractalCore;
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
    class OpenXml : ChangableCommand
    {

        private readonly FractalPainterViewModel _windowViewModel;

        public OpenXml(FractalPainterViewModel windowViewModel)
        {
            _windowViewModel = windowViewModel;
        }

        public override void Execute(object parameter)
        {
            var mapper = FractalPainter.Kernel.Get<IMapper>();

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "XML file|*.xml";
                openFileDialog.Title = "open xml";

                if (openFileDialog.ShowDialog() == DialogResult.OK && openFileDialog.FileName.Trim() != "")
                {
                    using (var reader = new FileStream(openFileDialog.FileName, FileMode.Open))
                    {
                        var serializer = new DataContractSerializer(typeof(FractalModel));
                        FractalModel model;
                        try
                        {
                            model = (FractalModel)serializer.ReadObject(reader);
                        }
                        catch(SerializationException ex)
                        {
                            MessageBox.Show("Unable to read specified file try another one!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        catch(IOException ex)
                        {
                            MessageBox.Show("Unable to read specified file try another one!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        var viewModel = mapper.Map<FractalModel, FractalPainterViewModel>(model); ;
                        viewModel.Window = _windowViewModel.Window;
                        _windowViewModel.Window.ViewModel = viewModel;
                    }
                }
            }
        }
    }
}
