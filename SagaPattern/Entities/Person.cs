using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace SagaPattern.Entities
{
    public class Person : IModel
    {
        [Name("Name")] // This should be the name of the column on the CSV File
        public string Name { get; set; }
        
        [Name("Last Name")]
        public string LastName { get; set; }

        [Name("Email address")]
        public string EmailAddress { get; set; }

        [Name("Phone number")]
        public string PhoneNumber { get; set; }
    }
}
