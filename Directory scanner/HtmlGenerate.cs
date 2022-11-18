namespace Directory_scanner
{
    public class HtmlGenerate
    {
        public void Generate(Dictionary<string, string> replase)
        {
            string body = File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), "dist", "template.html"));
            foreach (var str in replase)
            {
                body = body.Replace(str.Key, str.Value);
            } 
            //body = "<!DOCTYPE html>\r\n<html lang=\"ru\">\r\n<head>\r\n\t<meta charset=\"UTF-8\">\r\n\t<title>jstree basic demos</title>\r\n\t<style>\r\n\thtml { margin:0; padding:0; font-size:62.5%; }\r\n\tbody { max-width:800px; min-width:300px; margin:0 auto; padding:20px 10px; font-size:14px; font-size:1.4em; }\r\n\th1 { font-size:1.8em; }\r\n\t.demo { overflow:auto; border:1px solid silver; min-height:100px; }\r\n\t</style>\r\n\t<link rel=\"stylesheet\" href=\"./themes/default/style.min.css\" />\r\n</head>\r\n<body>\r\n\t<h1>Data format demo</h1>\r\n\t<div id=\"frmt\" class=\"demo\"></div>\r\n\r\n\r\n\t<script src=\"https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js\"></script>\r\n\t<script src=\"./jstree.min.js\"></script>\r\n\t\r\n\t<script>\r\n\r\n\t$('#frmt').jstree({ 'core' : { 'data' : [{ \"id\" : \"1\", \"parent\" : \"#\", \"text\": \"net6.0 - 942,49kb)\" },{ \"id\" : \"54267293\", \"parent\" : \"#\", \"text\": \"38.deps.json - (1,36kb) - application/json\", \"icon\" : \"jstree-file\" },{ \"id\" : \"18643596\", \"parent\" : \"#\", \"text\": \"38.dll - (6kb) - application/octet-stream\", \"icon\" : \"jstree-file\" },{ \"id\" : \"33574638\", \"parent\" : \"#\", \"text\": \"38.exe - (144,5kb) - application/octet-stream\", \"icon\" : \"jstree-file\" },{ \"id\" : \"33736294\", \"parent\" : \"#\", \"text\": \"38.pdb - (10,79kb) - application/vnd.palm\", \"icon\" : \"jstree-file\" },{ \"id\" : \"35191196\", \"parent\" : \"#\", \"text\": \"38.runtimeconfig.json - (0,14kb) - application/json\", \"icon\" : \"jstree-file\" },{ \"id\" : \"48285313\", \"parent\" : \"#\", \"text\": \"Directory scanner.dll - (86,5kb) - application/octet-stream\", \"icon\" : \"jstree-file\" },{ \"id\" : \"31914638\", \"parent\" : \"#\", \"text\": \"Directory scanner.pdb - (14,15kb) - application/vnd.palm\", \"icon\" : \"jstree-file\" },{ \"id\" : \"18796293\", \"parent\" : \"#\", \"text\": \"Newtonsoft.Json.dll - (679,04kb) - application/octet-stream\", \"icon\" : \"jstree-file\" },{ \"id\" : \"2\", \"parent\" : \"1\", \"text\": \"каталог 1 - 0kb)\" },{ \"id\" : \"34948909\", \"parent\" : \"1\", \"text\": \"Новый текстовый документ.txt - (0kb) - text/plain\", \"icon\" : \"jstree-file\" },{ \"id\" : \"46104728\", \"parent\" : \"1\", \"text\": \"Новый точечный рисунок.bmp - (0kb) - image/bmp\", \"icon\" : \"jstree-file\" },{ \"id\" : \"3\", \"parent\" : \"1\", \"text\": \"каталог 2 - 170,13kb)\" },{ \"id\" : \"12289376\", \"parent\" : \"1\", \"text\": \"Документ-2022-09-12-213920.pdf - (170,13kb) - application/pdf\", \"icon\" : \"jstree-file\" },{ \"id\" : \"4\", \"parent\" : \"3\", \"text\": \"Новая папка - 0kb)\" },{ \"id\" : \"5\", \"parent\" : \"2\", \"text\": \"каталог 1-1 - 0kb)\" },{ \"id\" : \"6\", \"parent\" : \"2\", \"text\": \"каталог 1-2 - 0kb)\" },]} });\r\n\t\r\n\t\t\r\n\t</script>\r\n</body>\r\n</html>\r\n";
            
            File.WriteAllText(".\\output.html", body);
        }

    }

    
}
