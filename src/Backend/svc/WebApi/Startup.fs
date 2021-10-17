namespace WebApi

open System
open System.Collections.Generic
open System.Linq
open System.Threading.Tasks
open Microsoft.AspNetCore.Builder
open Microsoft.AspNetCore.Hosting
open Microsoft.AspNetCore.HttpsPolicy;
open Microsoft.AspNetCore.Mvc
open Microsoft.Extensions.Configuration
open Microsoft.Extensions.DependencyInjection
open Microsoft.Extensions.Hosting
open Microsoft.OpenApi.Models

type Startup(configuration: IConfiguration) =
    [<Literal>]
    let APITitle = "Poly-SaaS Tenants Web API"

    [<Literal>]
    let APIVersion = "v1"

    member _.Configuration = configuration

    // This method gets called by the runtime. Use this method to add services to the container.
    member _.ConfigureServices(services: IServiceCollection) =
        // Add framework services.
        services.AddControllers() |> ignore

        services.AddSwaggerGen(fun c ->
            let info = OpenApiInfo()
            info.Title <- APITitle
            info.Version <- APIVersion
            c.SwaggerDoc(APIVersion, info)
        ) |> ignore

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    member _.Configure(app: IApplicationBuilder, env: IWebHostEnvironment) =
        if (env.IsDevelopment()) then
            app.UseDeveloperExceptionPage() |> ignore

        app.UseSwagger()
           .UseSwaggerUI(fun c ->
                c.SwaggerEndpoint($"/swagger/{APIVersion}/swagger.json", APITitle)
                c.RoutePrefix <- ""
           ) |> ignore

        app.UseRouting()
           .UseAuthorization()
           .UseEndpoints(fun endpoints ->
                endpoints.MapControllers() |> ignore
            ) |> ignore
