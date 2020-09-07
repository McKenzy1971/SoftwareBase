using System;
using System.Windows.Input;

namespace SoftwareBase.DelegateCommand
{
    /// <summary>
    /// Base class for Commands
    /// </summary>
    /// <typeparam name="T">The type of the parameters of the methods that this object encapsulates.</typeparam>
    public class DelegateCommand<T> : ICommand
    {
        #region constructos
        /// <summary>
        /// Initialates new instanz of DelegateCommand
        /// </summary>
        /// <param name="executeHdl">Encapsulates the method that's been called at Execute</param>
        /// <param name="canExecuteHdl">Encapsulates the method that's been called to check CanExecute</param>
        public DelegateCommand(Action<T> executeHdl, Predicate<T> canExecuteHdl)
        {
            this.canExecuteHdl = canExecuteHdl;
            this.executeHdl = executeHdl;
            if (this.executeHdl == null)
                throw new ArgumentNullException(nameof(executeHdl), "Please specifiy the command");
        }
        /// <summary>
        /// Initialate a new instanz of DelegateCommand. CanExecute is true by default.
        /// </summary>
        /// <param name="executeHdl">Encapsulates the method that's been called at Execute</param>
        public DelegateCommand(Action<T> executeHdl) : this(executeHdl, null) { }
        #endregion

        private Action<T> executeHdl { get; set; }
        private Predicate<T> canExecuteHdl { get; set; }

        public event EventHandler CanExecuteChanged;

        #region Methods
        /// <summary>
        /// Invokes CanExecuteChanged event
        /// </summary>
        public void RaiseCanExecuteChanged() => this.CanExecuteChanged?.Invoke(this, null);

        public bool CanExecute(object parameter) => canExecuteHdl == null || canExecuteHdl((T)parameter) == true;

        public void Execute(object parameter) => executeHdl((T)parameter);
        #endregion
    }

    public class DelegateCommand : ICommand
    {
        #region constructos
        /// <summary>
        /// Initialates new instanz of DelegateCommand
        /// </summary>
        /// <param name="executeHdl">Encapsulates the method that's been called at Execute</param>
        /// <param name="canExecuteHdl">Encapsulates the method that's been called to check CanExecute</param>
        public DelegateCommand(Action executeHdl, Predicate<object> canExecuteHdl)
        {
            this.canExecuteHdl = canExecuteHdl;
            this.executeHdl = executeHdl;
            if (this.executeHdl == null)
                throw new ArgumentNullException("executeHdl", "Please specifiy the command");
        }
        /// <summary>
        /// Initialate a new instanz of DelegateCommand. CanExecute is true by default.
        /// </summary>
        /// <param name="executeHdl">Encapsulates the method that's been called at Execute</param>
        public DelegateCommand(Action executeHdl) : this(executeHdl, null) { }
        #endregion

        private Action executeHdl { get; set; }
        private Predicate<object> canExecuteHdl { get; set; }

        public event EventHandler CanExecuteChanged;

        #region Methods
        /// <summary>
        /// Invokes CanExecuteChanged event
        /// </summary>
        public void RaiseCanExecuteChanged() => this.CanExecuteChanged?.Invoke(this, null);

        public bool CanExecute(object parameter) => canExecuteHdl == null || canExecuteHdl(parameter) == true;

        public void Execute(object parameter) => executeHdl();
        #endregion
    }
}
