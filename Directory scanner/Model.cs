namespace Directory_scanner
{
    public class DirectoryProperty : List<DirectoryProperty>
    {
        public int Id { get; set; }
        public int ParentId { get; set; }
        public string? Name { get; set; }
        public double Size { get; set; }
        public FileInfo[]? FileInfos { get; set; }
        public DirectoryInfo? DirectoryInfos { get; set; }
        public DirectoryInfo? Parent { get; set; }
    }


    public class  FileProperty : List<FileProperty>
    {
        public int DirectId { get; set; }
        public string? Name { get; set; }
        public double Size { get; set; }
        public string? MimeType { get; set; }
    }

    public class CountMimeType
    {
        public string? Name { get; set; }
        public double Count { get; set; }
    }

}
    