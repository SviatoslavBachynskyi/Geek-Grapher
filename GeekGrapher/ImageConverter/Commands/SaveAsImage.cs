using GeekGrapher.General;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media.Imaging;

namespace GeekGrapher.ImageConverter.Commands
{
    internal class SaveAsImage : ChangableCommand
    {
        private readonly ImageConverterViewModel _windowViewModel;

        public SaveAsImage(ImageConverterViewModel windowViewModel)
        {
            _windowViewModel = windowViewModel;
        }

        public override bool CanExecute(object parameter)
        {
            return _windowViewModel?.ConvertedImage != null;
        }

        public override void Execute(object parameter)
        {

            var bitmapSource = _windowViewModel.ConvertedImage as BitmapSource;

            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.Filter = "JPeg Image|*.jpg|Bitmap Image|*.bmp|Gif Image|*.gif|Png Image|*.png";
            saveFileDialog.Title = "Save an Image File";

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
            }
        }
    }
}
