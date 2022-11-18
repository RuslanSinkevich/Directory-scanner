Сканирование директории и вывод статистической информации в HTML файл

dll библиотека

Доступные классы и методы

Главный класс проекта ScanDirectory создаём его экземляр.
В конструкторе активируються метод сканирования директории из которой запускаем сканер.
ScanDirectory scanDirectory = new ScanDirectory();

Далее используя класс моделй DirectoryProperty и FileProperty
получаем списки всех директорий с иказателем на родителя в виде id int
и получаем список всех файлов всех директорий с id int на директорию
DirectoryProperty arrDirect = scanDirectory.ListDirectory;
FileProperty fileProperty = scanDirectory.ListFile;

После, создаём экземпляр класса GetData отвечаюшего за создание данных для скриптов,
которые будут использованны для html выходного файла.
GetData getData = new GetData();

 var jsTreeData = getData.JsTreeData(arrDirect, fileProperty);
 var jsChart = getData.JsChart(fileProperty);
 var jsDataTable = getData.JsDataTable(fileProperty);

После генерируем html
                HtmlGenerate htmlGenerate = new HtmlGenerate();
                Dictionary<string, string> replase = new Dictionary<string, string>();
                replase.Add("(DATA_JSTREE)", jsTreeData);
                replase.Add("(DATA_CHART)", jsChart);
                replase.Add("(DATA_DATATABLE)", jsDataTable);
                
После генерируем html
HtmlGenerate htmlGenerate = new HtmlGenerate();
 htmlGenerate.Generate(replase);
