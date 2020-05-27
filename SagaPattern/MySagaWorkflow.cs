using SagaPattern.Steps;
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
                    .StartWith<SpanishTask>()
                    .Input(t => t.Greet, data => data.boo)
                    .Input(t => t.foo)
                    .Input(t => t.foo, data => data.boo)
                    .Output(data => data.boo, step => step.Output)
                    .CompensateWith<SpanishTask>()

                    .Then<EnglishTask>()
                    .Input(t => t.foo, data => data.boo)
                    .Input(t => t.foo, data => data.boo)
                    .Output(data => data.boo, step => step.Output)
                    .CompensateWith<EnglishCompensationTask>()

                    .Then<FrenchTask>()
                    .Input(t => t.foo, data => data.boo)
                    .Input(t => t.foo, data => data.boo)
                    .Output(data => data.boo, step => step.Output)
                    .CompensateWith<FrenchCompensationTask>()

                    .Then<GermanTask>()
                    .Input(t => t.foo, data => data.boo)
                    .Input(t => t.foo, data => data.boo)
                    .Output(data => data.boo, step => step.Output)
                    .CompensateWith<GermanCompensationTask>()

                    .Then<RussianTask>()
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
