using System.IO;

namespace SoftwareBase
{
    #region Classes
    /// <summary>
    /// Class for managment of files and directories
    /// </summary>
    public class Folder
    {
        #region Constructors
        /// <summary>
        /// Creates new instanz of Folder
        /// </summary>
        /// <param name="directoryPath">The directory path</param>
        public Folder(string directoryPath)
        {
            try
            {
                this.DirectoryPath = directoryPath + @"\";
            }
            catch (DirectoryNotFoundException e)
            {
                throw new DirectoryNotFoundException("Directory not exist", e);
            }
            this.Files = this.DirectoryInfo.GetFiles();
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets path of directory
        /// </summary>
        public string DirectoryPath { get; set; }
        /// <summary>
        /// Get costum files in this directory
        /// </summary>
        public FileInfo[] Files { get; private set; }
        /// <summary>
        /// Gets directory informations
        /// </summary>
        public DirectoryInfo DirectoryInfo { get { return new DirectoryInfo(DirectoryPath); } }
        #endregion

        #region Methods
        /// <summary>
        /// Gets a spacific file
        /// </summary>
        /// <param name="filename">The filename inkl. extension</param>
        /// <returns>Directory path and filename as string</returns>
        public string GetFile(string filename)
        {
            foreach (FileInfo fileInfo in Files)
            {
                if (fileInfo.Name == filename)
                    return DirectoryPath + filename;
            }
            throw new FileNotFoundException("File not found", filename);
        }
        /// <summary>
        /// Add file to directory
        /// </summary>
        /// <param name="filename">The filename inkl. extension</param>
        public void AddFile(string filename)
        {
            if (!File.Exists(DirectoryPath + filename))
            {
                using (File.Create(DirectoryPath + filename)) { };
            }
            Files = DirectoryInfo.GetFiles(DirectoryPath);
        }
        /// <summary>
        /// Check file exist
        /// </summary>
        /// <param name="filename">The filename inkl. extention</param>
        /// <returns>true if file was found, otherwise false</returns>
        public bool CheckFileExist(string filename)
        {
            foreach(FileInfo fileInfo in Files)
            {
                if (fileInfo.Name == filename)
                    return true;
            }
            return false;
        }
        /// <summary>
        /// Creates directory
        /// </summary>
        /// <param name="path">Directory path</param>
        /// <returns>The directorys path as string</returns>
        public static string CreateDirectory(string path)
        {
            Directory.CreateDirectory(path);
            return path;
        }
        #endregion
    }
    #endregion
}
