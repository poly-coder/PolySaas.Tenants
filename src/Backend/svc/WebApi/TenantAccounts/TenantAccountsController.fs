namespace WebApi.TenantAccounts

open System
open System.Collections.Generic
open System.Linq
open System.Threading.Tasks
open Microsoft.AspNetCore.Mvc
open Microsoft.Extensions.Logging
open Swashbuckle.AspNetCore.Annotations
open PolyCoder

[<ApiController>]
[<Route("[controller]")>]
type TenantAccountsController() =

    [<HttpGet("", Name = "GetTenantAccountsList")>]
    [<SwaggerResponse(200, "Tenant Accounts list")>]
    [<SwaggerResponse(400, "Bad request", typeof<ValidationProblemDetails>)>]
    [<SwaggerResponse(500, "Server error")>]
    member _.GetTenantAccountsList([<FromQuery>] query: GetTenantAccountsListQuery) =
        async {
            let accounts = [
                ({
                    tenantAccountId = "1234"
                    identifier = "test"
                    displayName = "Test"
                } : TenantAccountItemModel)
            ]

            let responseBody : GetTenantAccountsListResponseBody = {
                tenantAccounts = accounts |> List.toArray
                continuationToken = null
            }

            return responseBody
        }
        |> Async.StartAsTask

    [<HttpGet("{tenantAccountId}", Name = "GetTenantAccountSummary")>]
    [<SwaggerResponse(200, "Tenant Account")>]
    [<SwaggerResponse(400, "Bad request", typeof<ValidationProblemDetails>)>]
    [<SwaggerResponse(404, "Not found", typeof<ProblemDetails>)>]
    [<SwaggerResponse(500, "Server error")>]
    member _.GetTenantAccountSummary([<FromRoute>] route: GetTenantAccountRoute) =
        async {
            return [1;2;3;4]
        }
        |> Async.StartAsTask
