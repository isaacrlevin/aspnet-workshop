var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.BackEnd>("backend");

builder.AddProject<Projects.FrontEnd>("frontend");

builder.Build().Run();
