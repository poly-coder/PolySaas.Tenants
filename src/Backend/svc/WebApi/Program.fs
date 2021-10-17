namespace WebApi

open System
open System.Collections.Generic
open System.IO
open System.Linq
open System.Threading.Tasks
open Microsoft.AspNetCore
open Microsoft.AspNetCore.Hosting
open Microsoft.Extensions.Configuration
open Microsoft.Extensions.Hosting
open Microsoft.Extensions.Logging
open System.Collections
open Serilog

module Program =
    let printEnv () =
        Environment.GetEnvironmentVariables().Cast<DictionaryEntry>()
            |> Seq.map (fun entry -> string entry.Key, string entry.Value)
            |> Seq.sortBy (fst >> (fun s -> s.ToLowerInvariant()))
            |> Seq.map (fun (k, v) -> k, (if String.length v > 100 then v.Substring(0, 100) + "..." else v))
            |> Seq.iter (fun (k, v) -> printfn "%s ==> %s" k v)

    let exitCode = 0

    let CreateHostBuilder args =
        // printEnv()

        Host.CreateDefaultBuilder(args)
            .UseSerilog(fun hostingContext loggerConfiguration ->
                loggerConfiguration
                    .ReadFrom.Configuration(hostingContext.Configuration)
                |> ignore)
            .ConfigureWebHostDefaults(fun webBuilder ->
                webBuilder.UseStartup<Startup>() |> ignore
            )

    [<EntryPoint>]
    let main args =
        CreateHostBuilder(args).Build().Run()

        exitCode
