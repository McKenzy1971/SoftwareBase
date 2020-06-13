using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;

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
        public Folder() { this.Files = new HashSet<string>(); }

        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets path of the directory
        /// </summary>
        public string DirectoryPath { get; set; }
        /// <summary>
        /// Gets used files in this directory
        /// </summary>
        public HashSet<string> Files { get; private set; }

        public string File { get; private set; }
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
                throw new ArgumentNullException(nameof(fileName), "IsNullOrWhiteSpace, please specify the filename");
            if (!String.IsNullOrWhiteSpace(this.DirectoryPath))
            {
                if (this.Files.Add(fileName))
                    this.Files.Add(fileName);
            }
            else
                throw new ArgumentNullException("this.DirectoryPath", "IsNullOrWhiteSpace, please set DirecetoryPath first.");
        }

        public void SetActivFile(string fileName)
        {
            if (String.IsNullOrWhiteSpace(fileName))
                throw new ArgumentNullException(nameof(fileName), "IsNullOrWhitespace, please specify the filename");
            if (this.Files.Count == 0)
                throw new NullReferenceException(nameof(this.Files) + "Is empty");
            if (this.Files.Contains(fileName))
            {
                foreach (string item in Files)
                {
                    if (item == fileName)
                        this.File = this.DirectoryPath + item;
                }
            }
        }

        #endregion
    }
}
