using BPS.HiltonDirect.Model;
using BPS.HiltonDirect.Model.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPS.HiltonDirect.Services
{
    [LoggingInterception(LoggingCategory.Services)]
    public interface IFileReadingService
    {
        string ReadAndConcatinateFiles(string outputFileName, IEnumerable<ClientFile> files);
        byte[] ReadBytes(string pathToFile);
        byte[] ReadBytes(string rootPath, string relativePathToFile);
        IEnumerable<ClientFile> ReadFolder(string sourceStartRootPath, string currentRootPath, bool recursive, bool includeFileContent, List<ClientFile> retval = null);
        IEnumerable<ClientFile> ReadFolder(string sourceStartRootPath, string currentRootPath, bool recursive, string extension, bool includeFileContent, List<ClientFile> retval = null);
        string GetFileNameFromPath(string path);
    }
    public class FileReadingService : IFileReadingService
    {
        public IEnumerable<ClientFile> ReadFolder(string sourceStartRootPath, string currentRootPath, bool recursive, bool includeFileContent, List<ClientFile> retval = null)
        {
            return ReadFolderWithExtension(sourceStartRootPath, currentRootPath, recursive, string.Empty, includeFileContent, retval);
        }

        public IEnumerable<ClientFile> ReadFolder(string sourceStartRootPath, string currentRootPath, bool recursive, string extension, bool includeFileContent, List<ClientFile> retval = null)
        {
            return ReadFolderWithExtension(sourceStartRootPath, currentRootPath, recursive, extension, includeFileContent, retval);
        }

        private IEnumerable<ClientFile> ReadFolderWithExtension(string sourceStartRootPath, string currentRootPath, bool recursive, string extension, bool includeFileContent, List<ClientFile> retval = null)
        {
            if (retval == null)
                retval = new List<ClientFile>();

            string[] files = Directory.GetFiles(currentRootPath);
            if (string.IsNullOrEmpty(extension))
            {
                retval.AddRange(files.Select(s => MapToClientFile(s, sourceStartRootPath, includeFileContent)));
            }
            else
            {
                var filters = files.Where(f => f.ToLower().Contains(extension)).Select(s => MapToClientFile(s, sourceStartRootPath, includeFileContent));
                retval.AddRange(filters);
            }
            string[] folders = System.IO.Directory.GetDirectories(currentRootPath);
            if (recursive && folders.Length > 0)
            {
                foreach (string d in folders)
                {
                    ReadFolder(sourceStartRootPath, d, recursive, extension, includeFileContent, retval);
                }
            }

            return retval;
        }


        private string GetTargetFolderPath(string s)
        {
            string retval = s;
            //Check if file
            if (File.Exists(s))
            {
                List<String> pathSplit = s.Split(Path.DirectorySeparatorChar).ToList();
                pathSplit.RemoveAt(pathSplit.Count - 2);
                retval = Path.Combine(pathSplit.ToArray());
            }
            return retval;
        }

        public byte[] ReadBytes(string rootPath, string relativePathToFile)
        {
            string fullPath = Path.Combine(rootPath, relativePathToFile);
            return ReadBytes(fullPath);
        }

        public byte[] ReadBytes(string pathToFile)
        {
            return File.ReadAllBytes(pathToFile);
        }

        public string ReadAndConcatinateFiles(string outputFileName, IEnumerable<ClientFile> files)
        {
            const int chunkSize = 4 * 1024; // 4KB  
            var folder = Path.GetDirectoryName(outputFileName);

            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }

            using (var output = System.IO.File.Create(outputFileName))
            {
                foreach (var file in files)
                {
                    using (var input = System.IO.File.OpenRead(file.SourceAbsolutePath))
                    {
                        var buffer = new byte[chunkSize];
                        int bytesRead;
                        while ((bytesRead = input.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            output.Write(buffer, 0, bytesRead);
                        }
                    }
                }
            }
            return System.IO.File.Exists(outputFileName) ? outputFileName : "";
        }

        private ClientFile MapToClientFile(string pathToFile, string sourceRootPath, bool includeFileContent)
        {
            sourceRootPath = sourceRootPath.Replace("\\\\", "\\");
            pathToFile = pathToFile.Replace("\\\\", "\\");

            var t = new ClientFile();
            t.SourceAbsolutePath = pathToFile;
            t.FileName = pathToFile.Split('\\').Last();

            t.ServerRelativeUrl = pathToFile.Replace(sourceRootPath, "")
                .Replace(t.FileName, "")
                .Replace("\\", "/");

            if (includeFileContent)
                t.FileContent = File.ReadAllText(pathToFile);

            return t;
        }

        public string GetFileNameFromPath(string path)
        {
            return Path.GetFileName(path);
        }
    }
}
