using System.Reactive.Linq;

public class StockTick
{
    public string Symbol { get; set; }

    public double Price { get; set; }

    public DateTime Timestamp { get; set; }
}

public static class StockMarketSimulator
{
    private static readonly Random rand = new Random();
    private static readonly string[] symbols = new[] {
      "AAPL",
      "MSFT",
      "GOOGL",
      "AMZN",
      "FB" };

    public static IObservable<StockTick> GetStockStream()
    {
        return Observable.Interval(TimeSpan.FromSeconds(1))
            .Select(_ => new StockTick
            {
                Symbol = symbols[rand.Next(symbols.Length)],
                Price = Math.Round(100 + (rand.NextDouble() * 1000), 2),
                Timestamp = DateTime.Now
            });
    }
}