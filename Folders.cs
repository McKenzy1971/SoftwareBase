using System;
using System.Collections.Generic;
using System.IO;

namespace SoftwareBase
{
    /// <summary>
    /// Class for managment of files and directories
    /// </summary>
    public class Folder
    {
        #region Constructors
        /// <summary>
        /// Creats new instanz of this object
        /// </summary>
        public Folder() { this.File = new SortedSet<string>(); }

        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets path of the directory
        /// </summary>
        public string DirectoryPath { get; set; }
        /// <summary>
        /// Gets used files in this directory
        /// </summary>
        public SortedSet<string> File { get; private set; }
        /// <summary>
        /// Gets directory informations of this directory
        /// </summary>
        public DirectoryInfo DirectoryInfo
        {
            get
            {
                if (String.IsNullOrWhiteSpace(this.DirectoryPath))
                    throw new ArgumentNullException("this.DirectoryPath", "IsNullOrWhiteSpace");
                return new DirectoryInfo(this.DirectoryPath);
            }
        }

        #endregion

        #region Methods
        /// <summary>
        /// Adds a filename to File property on this Object
        /// </summary>
        /// <param name="fileName">The filename you choose</param>
        public void AddFile(string fileName)
        {
            if (String.IsNullOrWhiteSpace(fileName))
                throw new ArgumentNullException(nameof(fileName), "IsNullOrWhiteSpace, Check File the Filename");
            if (!String.IsNullOrWhiteSpace(this.DirectoryPath))
            {
                if (this.File.Add(fileName))
                    this.File.Add(fileName);
            }
            else
                throw new ArgumentNullException("this.DirectoryPath", "IsNullOrWhiteSpace");
        }
        
        #endregion
    }
}
