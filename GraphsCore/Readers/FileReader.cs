namespace GraphsCore.Readers
{
    public class FileReader
    {
        string _path;

        public FileReader(string path)
        {
            _path = path;
        }

        public string ReadToTheEnd() => SafeFileStreamUse((stream, reader) => reader.ReadToEnd());

        public string? ReadLine() => SafeFileStreamUse((stream, reader) => reader.ReadLine());

        public int GetLinesCount() => SafeFileStreamUse((stream, reader) =>
        {
            var counter = 0;
            while (reader.ReadLine() != null) counter++;
            return counter;
        });

        T SafeFileStreamUse<T>(Func<FileStream, StreamReader, T> func)
        {
            FileStream fileStream = null;
            StreamReader streamReader = null;
            try
            {
                fileStream = new FileStream(_path, FileMode.Open);
                streamReader = new StreamReader(fileStream);
                return func.Invoke(fileStream, streamReader);
            }
            finally
            {
                streamReader?.Close();
            }
        }
    }
}