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
    class OpenImage : ChangableCommand
    {
        ImageConverterViewModel ViewModel { get; set; }
        public OpenImage(ImageConverterViewModel viewModel)
        {
            ViewModel = viewModel;
        }
        public override void Execute(object parameter)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "All supported graphics|*.jpg;*.jpeg;*.bmp;*.gif;*.png|JPeg Image|*.jpg;*.jpeg;|Bitmap Image|*.bmp|Gif Image|*.gif|Png Image|*.png";
                openFileDialog.Title = "Select a picture";

                if (openFileDialog.ShowDialog() == DialogResult.OK && openFileDialog.FileName.Trim() != "")
                {

                    try
                    {
                        ViewModel.OriginalImage = new BitmapImage(new Uri(openFileDialog.FileName));
                    }
                    catch (IOException ex)
                    {
                        MessageBox.Show("Unable to read specified file try another one!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
            }
        }
    }
}



