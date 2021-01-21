using System;

namespace WorkManager.Services
{
    /// <summary>
    /// RefreshService
    /// </summary>
    public static class RefreshService
    {
        /// <summary>
        /// Refresh event
        /// </summary>
        public static event EventHandler RefreshEvent;

        /// <summary>
        /// Invokes Refresh event if it's not null
        /// </summary>
        /// <param name="sender">Object that called this method</param>
        public static void Refresh(object sender) => RefreshEvent?.Invoke(sender, EventArgs.Empty);
    }
}