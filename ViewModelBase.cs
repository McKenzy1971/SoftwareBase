using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace SoftwareBase.ViewModelBase
{
    /// <summary>
    /// Base class of all ViewModels
    /// </summary>
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public Folder folder = new Folder();
    }

    public class DelegateCommand<T> : ICommand
    {
        #region constructos

        public DelegateCommand(Action<T> executeHdl, Predicate<T> canExecuteHdl)
        {
            this.canExecuteHdl = canExecuteHdl;
            if (this.canExecuteHdl == null)
                throw new ArgumentNullException("executeHdl", "Please specifiy the command");
            this.executeHdl = executeHdl;
        }
        #endregion

        private Predicate<T> canExecuteHdl { get; set; }
        private Action<T> executeHdl { get; set; }

        public event EventHandler CanExecuteChanged;

        #region Methods

        public void RaiseCanExecuteChanged()
        {
            this.CanExecuteChanged?.Invoke(this, null);
        }

        public bool CanExecute(object parameter)
        {
            return canExecuteHdl == null || canExecuteHdl((T)parameter) == true;
        }

        public void Execute(object parameter)
        {
            executeHdl((T)parameter);
        }
        #endregion
    }
}
