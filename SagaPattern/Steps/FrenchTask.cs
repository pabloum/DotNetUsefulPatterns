using System;
using System.Collections.Generic;
using System.Text;
using WorkflowCore.Interface;
using WorkflowCore.Models;

namespace SagaPattern.Steps
{
    public class FrenchTask : StepBody
    {
        public string foo { get; set; }
        public string Greet { get; set; }
        public string Output { get; set; }

        public override ExecutionResult Run(IStepExecutionContext context)
        {
            Console.WriteLine("French task:");
            Console.WriteLine("Greet: " + Greet);

            return ExecutionResult.Next();
        }
    }
}
