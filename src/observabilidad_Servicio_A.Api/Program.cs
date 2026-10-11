builder.Services

.AddOpenTelemetry()

.WithTracing(tracing =>
{
     tracing

     .AddAspNetCoreInstrumentation()

     .AddHttpClientInstrumentation()

     .AddOtlpExporter();
})

.WithMetrics(metrics =>
{
     metrics

     .AddAspNetCoreInstrumentation()

     .AddRuntimeInstrumentation()

     .AddHttpClientInstrumentation();
});

builder.Host.UseSerilog(
 (ctx, log) =>
 {
     log
      .WriteTo.Console();
 });