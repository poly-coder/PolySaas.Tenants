namespace Services.TenantAccounts

open Domain.TenantAccounts

type GetTenantAccountListRequest = {
    continuationToken: string
    displayName: string
    identifier: string
}

type GetTenantAccountListResponse = {
    continuationToken: string option
    tenantAccounts: TenantAccountItem list
}
