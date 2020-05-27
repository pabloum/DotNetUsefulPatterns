using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using SagaPattern.Entities;
using CsvHelper;
using System.Linq;

namespace SagaPattern.FileCsvReader
{
    public class FileCsvReader<TModel> : IFileCsvReader where TModel : IModel
    {
        public IEnumerable Read(string awsStream)
        {
            using (var reader = new StringReader(awsStream))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Configuration.MissingFieldFound = null;
                csv.Configuration.CultureInfo = CultureInfo.InvariantCulture;
                var records = csv.GetRecords<TModel>();
                return records.ToList();
            }
        }
    }
}
