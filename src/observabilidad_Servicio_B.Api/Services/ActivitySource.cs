private static readonly ActivitySource
Source = new("orders-service");

using var activity =
Source.StartActivity("query-orders");