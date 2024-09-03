var builder = DistributedApplication.CreateBuilder(args);

var cache = builder.AddRedis("cache");

var apiService = builder.AddProject<Projects.AspireAppSock_ApiService>("apiservice");

builder.AddProject<Projects.AspireAppSock_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithReference(cache)
    .WithReference(apiService);

//builder.AddProject<Projects.AspireopensearchAppSock_ApiService>("aspireopensearchappsock-apiservice");

builder.AddProject<Projects.OpenSearchSock>("opensearchsock");

//builder.AddProject<Projects.AspireopensearchAppSock_ApiService>("aspireopensearchappsock-apiservice");

builder.Build().Run();
