

using BFO.Core.BusinessFacadeObjects.General;
using IBFO.Core.IBusinessFacadeObjects.General;
using Microsoft.AspNetCore.Http;

namespace BFC.Core.FacadeCreatorObjects.General
{
    public class trantinyurldataFCC
    { 
	
		public trantinyurldataFCC()
        {
		
        }
		
		public static ItrantinyurldataFacadeObjects GetFacadeCreate(IHttpContextAccessor httpContextAccessor)
        {
            ItrantinyurldataFacadeObjects facade = null;
            var context = httpContextAccessor.HttpContext;			
            
            if (context != null)
            {
                facade = context.Items["ItrantinyurldataFacadeObjects"] as ItrantinyurldataFacadeObjects;
    
                if (facade == null)
                {
                    facade = new trantinyurldataFacadeObjects();
                    context.Items["ItrantinyurldataFacadeObjects"] = facade;
                }
            }
            else
            {
                facade = new trantinyurldataFacadeObjects();
                return facade;
            }
            return facade;
        }
		
		
	}
}