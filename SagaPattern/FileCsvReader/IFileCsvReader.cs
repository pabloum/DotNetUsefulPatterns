using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace SagaPattern.FileCsvReader
{
    public interface IFileCsvReader
    {
        IEnumerable Read(String awsStream);
    }
}
