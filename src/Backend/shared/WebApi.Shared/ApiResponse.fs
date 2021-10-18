namespace WebApi.Shared

open Services.Shared

exception ServerException of exn

exception NotFoundException

exception ValidationException

module ApiResponse =
    let fromServiceResponse (response: ServiceResponse<'t>) : 't =
        match response with
        | SuccessResponse response -> response
        | ErrorResponse exn -> raise (ServerException exn)
        | NotFoundResponse -> raise NotFoundException
        | ValidationErrorResponse -> raise ValidationException
