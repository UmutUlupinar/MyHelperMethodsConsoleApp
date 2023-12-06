private List<Model> GetSalesFromExcel(string path)
    {
        var salesList = new List<Model>(); 
        
            string currentDirectory = Environment.CurrentDirectory;
            string filePath = Path.Combine(currentDirectory, "..\\..\\..\\", path); // get file from project root 
            Console.WriteLine($"Current Directory: {currentDirectory}");
            Console.WriteLine($"filePath : {filePath}");
            FileInfo fileInfo = new FileInfo(filePath);

            using (ExcelPackage package = new ExcelPackage(fileInfo))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets[0]; // Assuming data is in the first worksheet

                int rowCount = worksheet.Dimension.Rows;

                for (int row = 2; row <= rowCount; row++) // Assuming the first row is header
                {
                    Model sales = new Model
                    {
                            Property1 =worksheet.Cells[row, 1].Value.ToString()! ,
                            Property2 =worksheet.Cells[row, 2].Value.ToString()! ,     
                            Property3 =worksheet.Cells[row, 3].Value.ToString()!,
                    };
                    salesList.Add(sales);
                }
            }
        return salesList;
    }


    private static void WriteXlsxFile(List<Model> models, string fileName)
    {
        using (ExcelPackage package = new ExcelPackage())
        {
            ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Sheet1");

            string[] titles = {"title1","title2","title3"}
            for (int colNum = 0; colNum < titles.Length; colNum++)
            {
                worksheet.Cells[1, colNum+1].Value = titles[colNum];
            }
            
            for (int row = 2; row <= models.Count + 1; row++)
            {
                int col = 1;

                foreach (var title in titles)
                {
                    var propertyInfo = typeof(Model).GetProperty(title);
                    if (propertyInfo != null)
                    {
                        worksheet.Cells[row, col].Value = propertyInfo.GetValue(models[row - 2]);
                    }
                    col++;
                }
            }

            FileStream excelFile = File.Create(fileName + ".xlsx");
            package.SaveAs(excelFile);
            excelFile.Close();

        }
    }