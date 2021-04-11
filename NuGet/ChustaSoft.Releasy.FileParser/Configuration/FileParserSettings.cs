namespace ChustaSoft.Releasy.Configuration
{
    public class FileParserSettings
    {

        public string FileName { get; private set; }


        public FileParserSettings(string fileName)
        {
            FileName = fileName;
        }

    }
}
