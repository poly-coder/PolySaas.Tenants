namespace WebApi.TenantAccounts

open System
open System.Collections.Generic
open System.Linq
open System.Threading.Tasks
open Microsoft.AspNetCore.Mvc
open Microsoft.Extensions.Logging
open PolyCoder
open Services.TenantAccounts
open Swashbuckle.AspNetCore.Annotations
open System.Threading
open WebApi.Shared

[<ApiController>]
[<Route("[controller]")>]
type TenantAccountsController(service: ITenantAccountsService) =

    [<HttpGet("", Name = "GetTenantAccountList")>]
    [<SwaggerResponse(200, "Tenant Accounts list")>]
    [<SwaggerResponse(400, "Bad request", typeof<ValidationProblemDetails>)>]
    [<SwaggerResponse(500, "Server error")>]
    member _.GetTenantAccountList
        (
            [<FromQuery>] query: GetTenantAccountListQuery,
            cancellationToken: CancellationToken
        ) =
        Mappers.toGetTenantAccountListRequest query
        |> service.GetTenantAccountList
        |> Async.map ApiResponse.fromServiceResponse
        |> Async.startWithCancellationToken cancellationToken

    [<HttpGet("{tenantAccountId}", Name = "GetTenantAccountSummary")>]
    [<SwaggerResponse(200, "Tenant Account")>]
    [<SwaggerResponse(400, "Bad request", typeof<ValidationProblemDetails>)>]
    [<SwaggerResponse(404, "Not found", typeof<ProblemDetails>)>]
    [<SwaggerResponse(500, "Server error")>]
    member _.GetTenantAccountSummary([<FromRoute>] route: GetTenantAccountRoute) =
        async { return [ 1; 2; 3; 4 ] }
        |> Async.StartAsTask
