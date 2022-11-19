using System.Text;

namespace Directory_scanner
{
    public class GetData
    {
        /// <summary> Данные для скрипта "data" JavaScript jsTree.  </summary>
        /// <param name="directoryList">Массив категорий .</param>
        /// <param name="fileList">Массив файлов.</param>
        public string JsTreeData(DirectoryProperty directoryList, FileProperty fileList)
        {
            var sb = new StringBuilder();
            bool root = true;
            foreach (var parent in directoryList)
            {
                string parId = parent.ParentId.ToString();
                if (root)
                    parId = "#";
                root = false;

                sb.Append("{");
                sb.AppendFormat(" \"id\" : \"{0}\", \"parent\" : \"{1}\", \"text\": \"{2}\" ",
                    parent.Id, parId, parent.Name + " - " + Math.Round(parent.Size / 1024, 2) + " kb)");
                sb.Append("},");
                foreach (var file in fileList.FindAll(x => x.DirectId == parent.Id))
                {
                    sb.Append("{");
                    sb.AppendFormat(
                        " \"id\" : \"{0}\", \"parent\" : \"{1}\", \"text\": \"{2}\", \"icon\" : \"jstree-file\" ",
                        file.GetHashCode(), parId, file.Name + " - (" + Math.Round((decimal)(file.Size / 1024), 2) + " kb) - " + file.MimeType);
                    sb.Append("},");
                }
            }

            return sb.ToString();

        }


        /// <summary> Данные для скрипта JavaScript Chart</summary>
        /// <param name="fileList">Массив файлов.</param>
        public string JsChart(FileProperty fileList)
        {
            IEnumerable<CountMimeType> fileQuery = GetCountMimeType(fileList);
            string data = "labels: [LABELS, ],  datasets: [{label: 'MimeType',data: [ DATA ], backgroundColor: randomRGB, borderWidth: 1}]";
            string labeleChart = "";
            string dataChart = "";
            foreach (var files in fileQuery)
            {
                labeleChart += "\"" + files.Name + "\", ";
                dataChart += Math.Round((files.Count * 100) / fileList.Count()) +  ", ";
            }
            data = data.Replace("LABELS", labeleChart);
            data = data.Replace("DATA", dataChart);
            return data;
        }

        /// <summary> Данные для скрипта JavaScript DataTable.  </summary>
        /// <param name="fileList">Массив файлов.</param>
        public string JsDataTable(FileProperty fileList)
        {
            IEnumerable<CountMimeType> fileQuery = GetAverageSizeMimeType(fileList);
            string tableData = "";
            foreach (var files in fileQuery)
            {
                tableData += "[\"" + files.Name + "\", " + "\"" + Math.Round((files.Count / 1024), 2) + "\"" + "], ";
            }
            return tableData;
        }


        /// <summary> Количество сгруппированных файлов с одинаковым MimeType </summary>
        /// <param name="fileList">Массив файлов.</param>
        private IEnumerable<CountMimeType> GetCountMimeType(FileProperty fileList)
        {
            IEnumerable<CountMimeType> fileQuery =
                from file in fileList
                group file by file.MimeType
                into result
                select new
                    CountMimeType()
                    {
                        Name = result.Key,
                        Count = result.Count() 
                    };
             return fileQuery;
        }

        /// <summary> Средний размер файлов с одинаковым MimeType </summary>
        /// <param name="fileList">Массив файлов.</param>
        private IEnumerable<CountMimeType> GetAverageSizeMimeType(FileProperty fileList)
        {
            IEnumerable<CountMimeType> fileQuery =
                from file in fileList
                group file by file.MimeType
                into result
                select new
                    CountMimeType()
                    {
                        Name = result.Key,
                        Count = result.Select(x => x.Size).Sum()  / result.Count()
                };
            return fileQuery;
        }


    }
}
