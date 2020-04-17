namespace worksheet_eight_behavioural_design_patterns
{
    /// <summary>
    /// This is just a dummy class rather than using a real class - a mock.
    /// </summary>
    public class File
    {
        public File(string fileName, string type, string location)
        {
            FileName = fileName;
            Type = type;
            Location = location;
        }  

        public string FileName { get; set; }
        public string Type { get; set; }

        public string Location { get; set; }
    }
}