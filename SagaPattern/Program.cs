using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading;
using WorkflowCore.Interface;
using WorkflowCore.Models;

namespace SagaPattern
{
    class Program
    {
        // In this project the SAGA pattern was implemented. 

        public static IPersistenceProvider PersistenceProvider { get; set; }

        private static IServiceProvider ConfigureServices()
        {
            IServiceCollection services = new ServiceCollection();
            services.AddLogging();
            services.AddWorkflow();

            var serviceProvider = services.BuildServiceProvider();

            return serviceProvider;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var serviceProvider = ConfigureServices();
            PersistenceProvider = serviceProvider.GetRequiredService<IPersistenceProvider>();

            IWorkflowHost host = serviceProvider.GetService<IWorkflowHost>();
            host.RegisterWorkflow<MySagaWorkflow, MySagaData>();
            //host.RegisterWorkflow<MySagaWorkflow>(); // To do withput the MySagaData class

            host.Start();

            var data = new MySagaData { boo = "boo", 
                                        SpanishGreet = "¡Hola, mundo!",
                                        EnglishGreet = "Hello, World!",
                                        FrenchGreet  = "Salut, monde!",
                                        GermanGreet  = "Hallo, Welt!",
                                        RussianGreet = ".____.",
                                      };

            var workflowId = host.StartWorkflow<MySagaData>("PablosSagaPattern", data).Result;

            // Console.ReadKey(); // This wait the user to press enter.
            var remainingTime = TimeSpan.FromSeconds(5);
            WaitForWorkflowToComplete(workflowId, remainingTime);

            host.Stop();

        }

        private static WorkflowStatus GetStatus(string workflowId)
        {
            var instance = PersistenceProvider.GetWorkflowInstance(workflowId).Result;
            return instance.Status;
        }

        private static void WaitForWorkflowToComplete(string workflowId, TimeSpan timeOut)
        {
            // Waits until the process is over or until the timer is ends. The first to occur
            
            var status = GetStatus(workflowId);
            var counter = 0;
            while ((status == WorkflowStatus.Runnable) && (counter < (timeOut.TotalMilliseconds / 100)))
            {
                Thread.Sleep(100);
                counter++;
                status = GetStatus(workflowId);
            }
        }
    }
}
