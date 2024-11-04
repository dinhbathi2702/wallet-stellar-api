using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace wallet_stellar_api.Web.Endpoints
{
    public class Wallets : EndpointGroupBase
    {
        public override void Map(WebApplication app)
        {
            app.MapGroup(this);
        }
    }
}
