using System;
using System.Collections.Generic;
using System.Linq;

namespace UnitTestingExamples
{
    public class FileStorage
    {
        private readonly int capacity;
        private readonly Dictionary<string, File> files;

        public FileStorage(int capacity)
        {
            
            if (capacity <= 0)
                throw new ArgumentException("Capacity must be positive");

            this.capacity = capacity;
            this.files = new Dictionary<string, File>();
        }

        public bool AddFile(File file)
        {
            
            if (file == null)
                throw new ArgumentNullException(nameof(file));

            if (files.ContainsKey(file.GetFilename()))
                return false;

            if (GetAvailableSize() < file.GetSize())
                return false;

            files[file.GetFilename()] = file;
            return true;
        }

        public bool RemoveFile(string filename)
        {
            return files.Remove(filename);
        }

        public File FindFile(string filename)
        {
            files.TryGetValue(filename, out File file);
            return file;
        }

        public List<File> GetFiles()
        {
            return files.Values.ToList();
        }

        public int GetAvailableSize()
        {
            int usedSize = files.Values.Sum(file => file.GetSize());
            return capacity - usedSize;
        }
    }
}
