

using BFO.Core.BusinessFacadeObjects.General;
using IBFO.Core.IBusinessFacadeObjects.General;
using Microsoft.AspNetCore.Http;

namespace BFC.Core.FacadeCreatorObjects.General
{
    public class folderuserrelationFCC
    { 
	
		public folderuserrelationFCC()
        {
		
        }
		
		public static IfolderuserrelationFacadeObjects GetFacadeCreate(IHttpContextAccessor httpContextAccessor)
        {
            IfolderuserrelationFacadeObjects facade = null;
            var context = httpContextAccessor?.HttpContext;

            if (context != null)
            {
                facade = context.Items["IfolderuserrelationFacadeObjects"] as IfolderuserrelationFacadeObjects;
    
                if (facade == null)
                {
                    facade = new folderuserrelationFacadeObjects();
                    context.Items["IfolderuserrelationFacadeObjects"] = facade;
                }
            }
            else
            {
                facade = new folderuserrelationFacadeObjects();
                return facade;
            }
            return facade;
        }
		
		
	}
}