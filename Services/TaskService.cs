using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoftwareBase.Services
{
    /// <summary>
    /// Provides methods to manage active tasks and wait for them
    /// </summary>
    public static class TaskService
    {
        private static HashSet<Task> _tasks = new HashSet<Task>();
        private static readonly object _locker = new object();

        /// <summary>
        /// Add task
        /// </summary>
        /// <param name="t">Task</param>
        public static void Add(Task t)
        {
            lock (_locker)
                _tasks.Add(t);
        }

        /// <summary>
        /// Remove task
        /// </summary>
        /// <param name="t">Task</param>
        public static void Remove(Task t)
        {
            lock (_locker)
                _tasks.Remove(t);
        }

        /// <summary>
        /// Remove every task thats != Status.Running || Status.WaitingForActivation
        /// </summary>
        public static void CleanUp()
        {
            _tasks.RemoveWhere((t) => t.Status != TaskStatus.Running || t.Status != TaskStatus.WaitingForActivation);
        }

        /// <summary>
        /// Waits for all tasks
        /// </summary>
        public static void WaitForTasks()
        {
            Task.WaitAll(_tasks.ToArray());
            TaskService.CleanUp();
        }
    }
}