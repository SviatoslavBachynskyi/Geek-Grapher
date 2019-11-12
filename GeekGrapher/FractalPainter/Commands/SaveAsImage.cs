using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Forms;
using System.IO;
using System.Drawing;
using System.Windows.Media.Imaging;

namespace GeekGrapher.FractalPainter.Commands
{
    internal class SaveAsImage : ICommand
    {
        private readonly FractalPainterViewModel _windowViewModel;

        public SaveAsImage(FractalPainterViewModel windowViewModel)
        {
            _windowViewModel = windowViewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {

            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.Filter = "JPeg Image|*.jpg|Bitmap Image|*.bmp|Gif Image|*.gif|Png Image|*.png";
            saveFileDialog.Title = "Save an Image File";

            saveFileDialog.ShowDialog();

            BitmapEncoder encoder = null;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (saveFileDialog.FileName != "")
                {
                    switch (saveFileDialog.FilterIndex)
                    {
                        case 1:
                            encoder = new JpegBitmapEncoder();
                            break;

                        case 2:
                            encoder = new BmpBitmapEncoder();
                            break;

                        case 3:
                            encoder = new GifBitmapEncoder();
                            break;

                        case 4:
                            encoder = new PngBitmapEncoder();
                            break;
                    }

                    var bitmapSource = _windowViewModel.Window.Image.Source as BitmapSource;

                    if (bitmapSource != null)
                    {
                        Stream fileStream = (FileStream)saveFileDialog.OpenFile();
                        byte[] imageByteArray = null;

                        encoder.Frames.Add(BitmapFrame.Create(bitmapSource));

                        using (var stream = new MemoryStream())
                        {
                            encoder.Save(stream);
                            imageByteArray = stream.ToArray();
                        }

                        fileStream.Write(imageByteArray, 0, imageByteArray.Length);
                        fileStream.Close();
                    }
                    else
                    {
                        MessageBox.Show("Nothing to save!");
                        return;
                    }

                }
            }
                

        }
    }
}
