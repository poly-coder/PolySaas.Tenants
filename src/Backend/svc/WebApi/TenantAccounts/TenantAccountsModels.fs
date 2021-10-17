namespace WebApi.TenantAccounts

[<CLIMutable>]
type TenantAccountItemModel = {
    tenantAccountId: string
    identifier: string
    displayName: string
}

[<CLIMutable>]
type TenantAccountSummaryModel = {
    tenantAccountId: string
    identifier: string
    displayName: string
}

[<CLIMutable>]
type GetTenantAccountsListQuery = {
    name: string
    identifier: string
}

[<CLIMutable>]
type GetTenantAccountsListResponseBody = {
    continuationToken: string
    tenantAccounts: TenantAccountItemModel array
}

[<CLIMutable>]
type GetTenantAccountRoute = { tenantAccountId: string }

[<CLIMutable>]
type GetTenantAccountSummaryResponseBody = { tenantAccount: TenantAccountSummaryModel }
