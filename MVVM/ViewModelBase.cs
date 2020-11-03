using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SoftwareBase.MVVM
{
    /// <summary>
    /// Base class of all ViewModels
    /// </summary>
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        /// <summary>
        /// PropertyChanged evant that represents the methods that's beeing called, if an property changed
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        #region Methods
        /// <summary>
        /// Called if an property has changed and PropertyChanged is't null
        /// </summary>
        /// <param name="propertyName">Name of the property</param>
        public virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
