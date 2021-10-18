module WebApi.TenantAccounts.Mappers

open Services.TenantAccounts

let toGetTenantAccountListRequest (query: GetTenantAccountListQuery) : GetTenantAccountListRequest =
    {
        continuationToken = query.continuationToken
        displayName = query.displayName
        identifier = query.identifier
    }

