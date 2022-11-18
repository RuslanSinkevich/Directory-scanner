
namespace Directory_scanner
{
    public class ScanDirectory
    {
        private static readonly string CurDir = Directory.GetCurrentDirectory();
        public DirectoryProperty ListDirectory = new DirectoryProperty();
        public FileProperty ListFile = new FileProperty();

        public ScanDirectory()
        {
            WalkDirectories();
            GetIdDirectory();
            GetFileInfoList();
        }

        /// <summary> Список всех категорий </summary>
        public List<DirectoryProperty> WalkDirectories()
        {
            int id = 1;
            DirectoryInfo root = new DirectoryInfo(CurDir);
            var stack = new Stack<DirectoryInfo>();
            stack.Push(root);

            DirectoryProperty arrDir = new DirectoryProperty
            {
                Parent = null,
                DirectoryInfos = root,
                FileInfos = root.GetFiles(),
                Id = id,
                Name = root.Name,
                Size = root.GetFiles().Select(x => x.Length).Sum()
            };

            ListDirectory.Add(arrDir);

            // Рекурсия 
            while (stack.Count > 0)
            { 
                DirectoryInfo dir = stack.Pop();
                try
                {
                    foreach (var directory in dir.GetDirectories())
                    {
                        id++;
                        arrDir = new DirectoryProperty
                        {
                            DirectoryInfos = directory,
                            Parent = dir,
                            FileInfos = directory.GetFiles(),
                            Id = id,
                            Name = directory.Name,
                            Size = directory.GetFiles().Select(x => x.Length).Sum()
                        };
                        ListDirectory.Add(arrDir);
                        stack.Push(directory);
                    }
                }
                catch (UnauthorizedAccessException)
                {
                    // ignore it
                }
            }
            return ListDirectory;
        }

        /// <summary> Добавляем id родителя </summary>
        private void GetIdDirectory()
        {
            // Для связи присваиваем каждой категории ParentId
            foreach (var direct in ListDirectory)
            {
                var res = ListDirectory.Find(x => x.DirectoryInfos?.FullName == direct.DirectoryInfos?.Parent?.FullName);
                {
                    if (res != null) 
                        direct.ParentId = res.Id;
                }
            }
        }

        /// <summary> Список всех файлов </summary>
        public List<FileProperty> GetFileInfoList()
        {
            // Для связи присваиваем каждой категории ParentId
            foreach (var direct in ListDirectory)
            {
                if (direct.FileInfos != null)
                    foreach (var file in direct.FileInfos)
                    {
                        FileProperty item = new FileProperty
                        {
                            DirectId = direct.Id,
                            Name = file.Name,
                            Size = file.Length,
                            MimeType = MimeTypes.GetMimeType(file.Name)
                        };
                        ListFile.Add(item);
                    }
            }

            return ListFile;
        }





 
    }
}