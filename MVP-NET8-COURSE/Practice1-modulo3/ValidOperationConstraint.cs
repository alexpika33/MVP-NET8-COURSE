public class ValidOperationConstraint : IRouteConstraint
{
    public bool Match(HttpContext httpContext, IRouter route, string routeKey, RouteValueDictionary values, RouteDirection routeDirection)
    {
        
        var operation = values[routeKey]?.ToString().ToLower();
        if(operation=="div" && int.Parse(values["b"].ToString())==0){
            return false;
        }
        
        return operation == "add" || operation == "sub" || operation == "mul" || operation == "div";
    }
}
