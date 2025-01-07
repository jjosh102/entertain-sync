var builder = DistributedApplication.CreateBuilder(args);

var api = builder.AddProject<Projects.EntertainSync_Api>("api")
    .WithExternalHttpEndpoints();

builder.Build().Run();
