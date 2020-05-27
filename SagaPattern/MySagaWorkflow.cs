using System;
using System.Collections.Generic;
using System.Text;
using WorkflowCore.Interface;
using WorkflowCore.Models;

namespace SagaPattern
{
    public class MySagaWorkflow : IWorkflow<MySagaData>
    {
        public string Id => "PablosSagaPattern";

        public int Version => 1;

        public void Build(IWorkflowBuilder<MySagaData> builder)
        {
            // Structure
            // builder.StartWith().Saga().Then().OnError();

            builder.
                StartWith(context => Console.WriteLine("Begin Saga"))
                .Saga(saga => saga
                    .StartWith<>()
                    .Input(t => t.foo, data => data.boo)
                    .Input(t => t.foo, data => data.boo)
                    .Output(data => data.boo, step => step.Output)
                    .CompensateWith<>()

                    .Then<>()
                    .Input(t => t.foo, data => data.boo)
                    .Input(t => t.foo, data => data.boo)
                    .Output(data => data.boo, step => step.Output)
                    .CompensateWith<>()

                    .Then<>()
                    .Input(t => t.foo, data => data.boo)
                    .Input(t => t.foo, data => data.boo)
                    .Output(data => data.boo, step => step.Output)
                    .CompensateWith<>()

                    .Then<>()
                    .Input(t => t.foo, data => data.boo)
                    .Input(t => t.foo, data => data.boo)
                )
                .Then(context =>
                    {
                        Console.WriteLine("Workflow complete");
                        return ExecutionResult.Next();
                    })
                .OnError(WorkflowErrorHandling.Terminate);
        }
    }
}
