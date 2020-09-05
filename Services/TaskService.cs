using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoftwareBase.Services
{
    /// <summary>
    /// 
    /// </summary>
    public static class TaskService
    {
        private static HashSet<Task> tasks;
        private static readonly object locker = new object();

        /// <summary>
        /// Add task
        /// </summary>
        /// <param name="t">Task</param>
        public static void Add(Task t)
        {
            lock (locker)
                tasks.Add(t);
        }

        /// <summary>
        /// Remove task
        /// </summary>
        /// <param name="t">Task</param>
        public static void Remove(Task t)
        {
            lock (locker)
                tasks.Remove(t);
        }

        /// <summary>
        /// Remove every task thats != Status.Running || Status.WaitingForActivation
        /// </summary>
        public static void CleanUp()
        {
            tasks.RemoveWhere((t) => t.Status != TaskStatus.Running || t.Status != TaskStatus.WaitingForActivation);
        }

        /// <summary>
        /// Waits for all tasks
        /// </summary>
        public static void WaitForTasks()
        {
            Task.WaitAll(tasks.ToArray());
            TaskService.CleanUp();
        }
    }
}