namespace GraphsCore.Writers;

public class FileWriter
{
    string _path;

    public FileWriter(string path)
    {
        _path = path;
    }

    public void Write(string content)
    {
        SafeFileStreamUse((stream, writer) => writer.Write(content));
    }

    void SafeFileStreamUse(Action<FileStream, StreamWriter> func)
    {
        FileStream fileStream = null;
        StreamWriter streamWriter = null;
        try
        {
            fileStream = new FileStream(_path, FileMode.OpenOrCreate);
            fileStream.SetLength(0);
            streamWriter = new StreamWriter(fileStream, leaveOpen:true);
            func.Invoke(fileStream, streamWriter);
        }
        finally
        {
            streamWriter?.Close();
        }
    }
}