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
type GetTenantAccountListQuery = {
    continuationToken: string
    displayName: string
    identifier: string
}

[<CLIMutable>]
type GetTenantAccountListResponseBody = {
    continuationToken: string
    tenantAccounts: TenantAccountItemModel array
}

[<CLIMutable>]
type GetTenantAccountRoute = { tenantAccountId: string }

[<CLIMutable>]
type GetTenantAccountSummaryResponseBody = { tenantAccount: TenantAccountSummaryModel }
