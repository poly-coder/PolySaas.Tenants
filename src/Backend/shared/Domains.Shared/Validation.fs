namespace Domains

type ValidationItem =
    { code: string
      message: string
      path: string }

type ValidationState = ValidationItem seq

type ValidationResult = Result<unit, ValidationItem list>

[<RequireQualifiedAccess>]
module Validation =
    let fine: ValidationState = Seq.empty

    let result (state: ValidationState) : ValidationResult =
        state
        |> List.ofSeq
        |> function
            | [] -> Result.Ok()
            | items -> Result.Error(items)

    // Prepend/Append to paths

    let prependToPath (propertyName: string) =
        function
        | "" -> propertyName
        | path -> $"{propertyName}.{path}"

    let appendToPath (propertyName: string) =
        function
        | "" -> propertyName
        | path -> $"{path}.{propertyName}"

    let prependIndexToPath index =
        function
        | "" -> $"[{index}]"
        | path -> $"[{index}]{path}"

    let appendIndexToPath index =
        function
        | "" -> $"[{index}]"
        | path -> $"{path}[{index}]"

    let applyPathFnToItem fn (item: ValidationItem) = { item with path = fn item.path }

    let prependToItem propertyName = applyPathFnToItem (prependToPath propertyName)
    let appendToItem propertyName = applyPathFnToItem (appendToPath propertyName)
    let prependIndexToItem index = applyPathFnToItem (prependIndexToPath index)
    let appendIndexToItem index = applyPathFnToItem (appendIndexToPath index)

    let applyPathFnToState fn (state: ValidationState) : ValidationState =
        state
        |> Seq.map (applyPathFnToItem fn)

    let prepend propertyName = applyPathFnToState (prependToPath propertyName)
    let append propertyName = applyPathFnToState (appendToPath propertyName)
    let prependIndex index = applyPathFnToState (prependIndexToPath index)
    let appendIndex index = applyPathFnToState (appendIndexToPath index)


    let message message = { code = ""; path = ""; message = message }
    let withCode code item = { item with code = code }
    let withProperty path item = { item with path = path }

    let item code path message = { code = code; path = path; message = message }
    let coded code message = { code = code; path = ""; message = message }
