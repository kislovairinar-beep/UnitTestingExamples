using System;

namespace UnitTestingExamples
{
    public class File
    {
        public string Filename { get; }
        public int Size { get; }
        public string Content { get; }

        public File(string filename, int size, string content)
        {
            // ДОБАВИТЬ валидацию:
            if (string.IsNullOrEmpty(filename))
                throw new ArgumentException("Filename cannot be null or empty");
            
            if (size <= 0)
                throw new ArgumentException("Size must be positive");
            
            if (content == null)
                throw new ArgumentNullException(nameof(content));

            Filename = filename;
            Size = size;
            Content = content;
        }

        public string GetFilename() => Filename;
        public int GetSize() => Size;
        public string GetContent() => Content;

        // ДОБАВИТЬ методы Equals и GetHashCode:
        public override bool Equals(object obj)
        {
            return obj is File file &&
                   Filename == file.Filename &&
                   Size == file.Size &&
                   Content == file.Content;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Filename, Size, Content);
        }
    }
}
