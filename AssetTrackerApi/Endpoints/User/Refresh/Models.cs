using FastEndpoints;

namespace AssetTrackerApi.Endpoints.User.Refresh;

public class Request
{

}

public class Validator : Validator<Request>
{
    public Validator()
    {

    }
}

public class Response
{
    public string Message => "This endpoint hasn't been implemented yet!";
}