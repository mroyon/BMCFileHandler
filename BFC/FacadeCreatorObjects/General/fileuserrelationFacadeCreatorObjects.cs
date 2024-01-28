

using BFO.Core.BusinessFacadeObjects.General;
using IBFO.Core.IBusinessFacadeObjects.General;
using Microsoft.AspNetCore.Http;

namespace BFC.Core.FacadeCreatorObjects.General
{
    public class fileuserrelationFCC
    { 
	
		public fileuserrelationFCC()
        {
		
        }
		
		public static IfileuserrelationFacadeObjects GetFacadeCreate(IHttpContextAccessor httpContextAccessor)
        {
            IfileuserrelationFacadeObjects facade = null;
            var context = httpContextAccessor?.HttpContext;

            if (context != null)
            {
                facade = context.Items["IfileuserrelationFacadeObjects"] as IfileuserrelationFacadeObjects;
    
                if (facade == null)
                {
                    facade = new fileuserrelationFacadeObjects();
                    context.Items["IfileuserrelationFacadeObjects"] = facade;
                }
            }
            else
            {
                facade = new fileuserrelationFacadeObjects();
                return facade;
            }
            return facade;
        }
		
		
	}
}