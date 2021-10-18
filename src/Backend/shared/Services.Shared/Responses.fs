namespace Services.Shared

type ServiceResponse<'response> =
    | SuccessResponse of 'response
    | ValidationErrorResponse
    | NotFoundResponse
    | ErrorResponse of exn
