using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace wallet_stellar_api.Web.Endpoints
{
    public class Quests : EndpointGroupBase
    {
        public override void Map(WebApplication app)
        {
            app.MapGroup(this);
        }

//         public async Task<IResult> quest1(ISender sender,string id){
// // if (id != command.Id) return Results.BadRequest();
//         await sender.Send();
//         return Results.NoContent();
//         }
    }
}
