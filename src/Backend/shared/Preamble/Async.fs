[<RequireQualifiedAccess>]
module Async

let result a = async.Return a

let bind fn ma =
    async {
        let! a = ma
        return! fn a
    }

let map fn ma =
    async {
        let! a = ma
        return fn a
    }

let startWithCancellationToken cancellationToken computation =
    Async.StartAsTask(computation, cancellationToken = cancellationToken)
