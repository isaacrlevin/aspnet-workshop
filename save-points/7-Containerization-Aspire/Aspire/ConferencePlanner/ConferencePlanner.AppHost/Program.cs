
var builder = DistributedApplication.CreateBuilder(args);


var redis = builder.AddRedis("cache");

var backend = builder.AddProject<Projects.BackEnd>("backend");

builder.AddProject<Projects.FrontEnd>("frontend")
    .WithReference(redis)
    .WithReference(backend);

builder.Build().Run();
