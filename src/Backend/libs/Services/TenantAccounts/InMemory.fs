module Services.TenantAccounts.InMemory

open Domain.TenantAccounts
open Services.Shared

type Command =
| GetTenantAccountList of GetTenantAccountListRequest * AsyncReplyChannel<ServiceResponse<GetTenantAccountListResponse>>

type State = { items: TenantAccountSummary ResizeArray }

let summaryToItem (summary: TenantAccountSummary) : TenantAccountItem =
    {
        tenantAccountId = summary.tenantAccountId
        identifier = summary.identifier
        displayName = summary.displayName
    }

let createSnapshootedWith (items: TenantAccountSummary seq) : ITenantAccountsService =
    let mailbox = MailboxProcessor.Start(fun mailbox ->
        let rec loop (state: State) = async {
            match! mailbox.Receive() with
            | GetTenantAccountList(request, reply) ->
                let items = state.items |> Seq.map summaryToItem |> Seq.toList
                reply.Reply(SuccessResponse {
                    tenantAccounts = items
                    continuationToken = None
                })
                return! loop state
        }

        loop { items = ResizeArray(items) }
    )

    { new ITenantAccountsService with
        member _.GetTenantAccountList request =
            mailbox.PostAndAsyncReply(fun reply -> GetTenantAccountList(request, reply))
    }

let createSnapshooted () = createSnapshootedWith []
