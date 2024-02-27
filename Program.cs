using Akka.Actor;
using System;

class Program
{
    static void Main(string[] args)
    {
        var system = ActorSystem.Create("StockMonitorSystem");
        var dashboardActor = system.ActorOf<DashboardActor>("dashboardActor");

        var significantMovements = StockAnalysis.AnalyzeStockTicks();
        var props = Props.Create(() => new SignificantMovementActor(dashboardActor, significantMovements));
        system.ActorOf(props, "significantMovementActor");

        Console.WriteLine("System is running. Press any key to exit...");
        Console.ReadLine();
        system.Terminate().Wait();
    }
}