using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace wallet_stellar_api.Web.Endpoints
{
    public class Transactions : EndpointGroupBase
    {
        public override void Map(WebApplication app)
        {
            app.MapGroup(this);
        }
    }
}
