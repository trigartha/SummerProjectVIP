﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace DomainLibrary.ViewModels
{
    public class RelayCommand : ICommand
    {
        private readonly Action _handler;
        private bool _isEnabled;

        public event EventHandler CanExecuteChanged;

        public RelayCommand(Action handler)
        {
            _handler = handler;
        }

        public bool IsEnabled
        {
            get { return _isEnabled; }
            set
            {
                if (value != _isEnabled)
                {
                    _isEnabled = value;
                    if (CanExecuteChanged != null)
                    {
                        CanExecuteChanged(this, EventArgs.Empty);
                    }
                }
            }
        }

        public bool CanExecute(object parameter)
        {
            return IsEnabled;
        }

        public void Execute(object parameter)
        {
            _handler();
        }
    }
}
