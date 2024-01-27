

using BFO.Core.BusinessFacadeObjects.General;
using IBFO.Core.IBusinessFacadeObjects.General;
using Microsoft.AspNetCore.Http;

namespace BFC.Core.FacadeCreatorObjects.General
{
    public class filestructureFCC
    { 
	
		public filestructureFCC()
        {
		
        }
		
		public static IfilestructureFacadeObjects GetFacadeCreate(IHttpContextAccessor httpContextAccessor)
        {
            IfilestructureFacadeObjects facade = null;
            var context = httpContextAccessor.HttpContext;			
            
            if (context != null)
            {
                facade = context.Items["IfilestructureFacadeObjects"] as IfilestructureFacadeObjects;
    
                if (facade == null)
                {
                    facade = new filestructureFacadeObjects();
                    context.Items["IfilestructureFacadeObjects"] = facade;
                }
            }
            else
            {
                facade = new filestructureFacadeObjects();
                return facade;
            }
            return facade;
        }
		
		
	}
}