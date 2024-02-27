using Akka.Actor;
using System.Reactive.Linq;

// Akka.NET Actor to handle significant movements
public class SignificantMovementActor : ReceiveActor
{
    private readonly IActorRef _dashboardActor;

    public SignificantMovementActor(IActorRef dashboardActor, IObservable<dynamic> significantMovements)
    {
        _dashboardActor = dashboardActor;

        significantMovements.Subscribe(movement =>
        {
            var significantMovement = new SignificantMovement
            {
                Symbol = movement.Symbol,
                PriceChange = movement.PriceChange,
                StartPrice = movement.StartPrice,
                EndPrice = movement.EndPrice,
                Timestamp = movement.Timestamp
            };

            _dashboardActor.Tell(significantMovement);
        });
    }
}