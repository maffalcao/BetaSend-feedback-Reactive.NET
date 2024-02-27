using Akka.Actor;

// Akka.NET Actor for dashboard updates
public class DashboardActor : ReceiveActor
{
    public DashboardActor()
    {
        Receive<SignificantMovement>(movement =>
        {
            // Logic to update the dashboard with the significant movement
            Console.WriteLine($"Dashboard updated for {movement.Symbol}: {movement.PriceChange * 100:F2}% change, from {movement.StartPrice} to {movement.EndPrice}");
        });
    }
}