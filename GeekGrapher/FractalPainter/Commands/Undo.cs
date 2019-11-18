﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GeekGrapher.FractalPainter.Commands
{
    internal class Undo : ICommand
    {
        private readonly FractalPainterViewModel WindowViewModel;

        public Undo(FractalPainterViewModel _windowViewModel)
        {
            WindowViewModel = _windowViewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if(WindowViewModel.FrameIndex > 1)
            {
                var frame = WindowViewModel.Frames[--WindowViewModel.FrameIndex-1];
                WindowViewModel.Window.Image.Source = frame.Image;
                WindowViewModel.Drawer.XStart = frame.XStart;
                WindowViewModel.Drawer.XFinish = frame.XFinish;
                WindowViewModel.Drawer.YStart = frame.YStart;
                WindowViewModel.Drawer.YFinish = frame.YFinish;
            }
        }
    }
}