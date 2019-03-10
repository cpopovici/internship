using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Security.Permissions;
using System.Threading;

namespace FileSync
{
    class Program
    {
        const string dir1Path = @"D:\Dir1";
        const string dir2Path = @"D:\Dir2";

        static void Main(string[] args)
        {
            SyncAll();
            StartFileMonitor(dir1Path);
            Console.ReadLine();
        }

        static void StartFileMonitor(string pathToWatching)
        {
            FileSystemWatcher watcher = new FileSystemWatcher();

            watcher.Path = pathToWatching;
            watcher.Changed += Watcher_FileContentChanged;
            watcher.Created += Watcher_FileChanged;
            watcher.Deleted += Watcher_FileChanged;
            watcher.Renamed += Watcher_FileRenamed;
            watcher.IncludeSubdirectories = true;
            watcher.EnableRaisingEvents = true;
        }

        private static void Watcher_FileRenamed(object sender, RenamedEventArgs e)
        {
            string oldFullPath = Path.Combine(dir2Path, e.OldName);
            string newFullPath = Path.Combine(dir2Path, e.Name);

            if (File.Exists(oldFullPath))
            {
                try
                {
                    File.Move(oldFullPath, newFullPath);
                }
                catch (IOException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                return;
            }

            if (Directory.Exists(oldFullPath))
            {
                try
                {
                    Directory.Move(oldFullPath, newFullPath);
                }
                catch (IOException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                return;
            }
        }

        private static void Watcher_FileContentChanged(object sender, FileSystemEventArgs e)
        {
            FileInfo changedFile = new FileInfo(e.FullPath);
            Console.WriteLine($"File ({e.Name}) maybe changed! PATH: {e.FullPath}");
            FileInfo fileFromDir2 = FileUtils.GetFiles(dir2Path).FirstOrDefault(x => x.Name == changedFile.Name);

            if (fileFromDir2 != null)
            {
                Console.WriteLine($"File ({e.Name}) content changed, trying to copy!");
                string fullDirectoryPath = new DirectoryInfo(dir1Path).FullName;
                string fileRelativePath = fileFromDir2.FullName.Substring(fullDirectoryPath.Length + 1);
                try
                {
                    fileFromDir2.Delete();
                    changedFile.CopyTo(Path.Combine(dir2Path, fileRelativePath));
                }
                catch (IOException ex)
                {
                    Console.WriteLine(ex.Message);
                }               
            }
        }

        private static void Watcher_FileChanged(object sender, FileSystemEventArgs e)
        {
            FileInfo file = new FileInfo(e.FullPath);
            bool isDirectory = file.Attributes.HasFlag(FileAttributes.Directory);
            while (!isDirectory && FileUtils.IsFileLocked(file))
            {
                Thread.Sleep(500);
            }
            SyncAll();
        }

        private static void SyncAll()
        {
            List<FileInfo> filesDir1 = FileUtils.GetFiles(dir1Path);
            List<FileInfo> filesDir2 = FileUtils.GetFiles(dir2Path);
            SyncFiles(filesDir1, filesDir2);
            SyncFolders(dir1Path, dir2Path);
        }

        private static void SyncFolders(string dir1Path, string dir2Path)
        {
            // sync new created folders from dir1 to dir2
            string[] dir1Directories = Directory.GetDirectories(dir1Path, "*", SearchOption.AllDirectories);
            foreach (var dir in dir1Directories)
            {
                string relativePath = dir.Substring(dir2Path.Length + 1);
                string newPath = Path.Combine(dir2Path, relativePath);
                //Console.WriteLine("RELATIVE FOLDERS: " + relativePath);
                if (!Directory.Exists(newPath))
                {
                    try
                    {
                        Directory.CreateDirectory(newPath);
                    }
                    catch (IOException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }

            // delete folders from dir2 if not exist in dir1
            string[] dir2Directories = Directory.GetDirectories(dir2Path, "*", SearchOption.AllDirectories);
            foreach (var dir in dir2Directories)
            {
                string relativePath = dir.Substring(dir2Path.Length + 1);
                string newPath = Path.Combine(dir1Path, relativePath);
                //Console.WriteLine("RELATIVE FOLDERS: " + relativePath);
                if (!Directory.Exists(newPath))
                {
                    try
                    {
                        Directory.Delete(dir, true);
                    }
                    catch (IOException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
        }

        private static void SyncFiles(List<FileInfo> filesDir1, List<FileInfo> filesDir2)
        {
            // copy files from dir1 to dir2 if not exist
            foreach (var file in filesDir1)
            {
                string fullDirectoryPath = new DirectoryInfo(dir1Path).FullName;
                string relativePath = file.FullName.Substring(fullDirectoryPath.Length + 1);
                string newPath = Path.Combine(dir2Path, relativePath);
                //Console.WriteLine("Relative path: {0}", relativePath);
                if (!File.Exists(newPath))
                {
                    string folderName = Path.GetDirectoryName(relativePath);
                    Directory.CreateDirectory(Path.Combine(dir2Path, folderName));
                    Console.WriteLine("file {0} exist in dir1 but not in dir2", file.Name);
                    file.CopyTo(newPath);
                }
            }

            // Delete files from dir2 if not exist in dir1
            foreach (var file in filesDir2)
            {
                string fullDirectoryPath = new DirectoryInfo(dir2Path).FullName;
                string relativePath = file.FullName.Substring(fullDirectoryPath.Length + 1);
                string newPath = Path.Combine(dir1Path, relativePath);
                //Console.WriteLine("Relative path: {0}", relativePath);
                if (!File.Exists(newPath))
                {
                    string relativeFoldersPath = Path.GetDirectoryName(relativePath);
                    Console.WriteLine("file {0} exist in dir2 but not in dir1", file.Name);
                    file.Delete();
                }
            }
        }
    }
}