using FilterValidation.Data;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;

namespace FilterValidation.Filters;
public class CheckFilterUser:ActionFilterAttribute
{
    private readonly AppDbContext _appDbContext;
    public CheckFilterUser(AppDbContext appDbContext) => _appDbContext = appDbContext;

    public override async Task OnActionExecutionAsync(ActionExecutingContext context , ActionExecutionDelegate actionExecutionDelegate)
    {
        if (!context.ActionArguments.ContainsKey("id"))
        {
            await actionExecutionDelegate();
            return;
        }
        var getid = (int)context.ActionArguments["id"];
        if (! await _appDbContext.Users.AnyAsync(x => x.Id == getid))
        {
            await actionExecutionDelegate();
            return;
        }
        await actionExecutionDelegate();
        if (!context.ActionArguments.ContainsKey("name"))
        {
            await actionExecutionDelegate();
            return;
        }
        var name = context.ActionArguments["name"];
        if (!await _appDbContext.Users.AnyAsync(x => x.Name == name))
        {
            _ = await actionExecutionDelegate();
            return;
        }
        await actionExecutionDelegate();
    }


}
