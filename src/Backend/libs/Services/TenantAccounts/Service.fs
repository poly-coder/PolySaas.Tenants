namespace Services.TenantAccounts

open Services.Shared

type ITenantAccountsService =
    abstract GetTenantAccountList: GetTenantAccountListRequest -> Async<ServiceResponse<GetTenantAccountListResponse>>
