

using BFO.Core.BusinessFacadeObjects.General;
using IBFO.Core.IBusinessFacadeObjects.General;
using Microsoft.AspNetCore.Http;

namespace BFC.Core.FacadeCreatorObjects.General
{
    public class filestructurehistFCC
    { 
	
		public filestructurehistFCC()
        {
		
        }
		
		public static IfilestructurehistFacadeObjects GetFacadeCreate(IHttpContextAccessor httpContextAccessor)
        {
            IfilestructurehistFacadeObjects facade = null;
            var context = httpContextAccessor.HttpContext;			
            
            if (context != null)
            {
                facade = context.Items["IfilestructurehistFacadeObjects"] as IfilestructurehistFacadeObjects;
    
                if (facade == null)
                {
                    facade = new filestructurehistFacadeObjects();
                    context.Items["IfilestructurehistFacadeObjects"] = facade;
                }
            }
            else
            {
                facade = new filestructurehistFacadeObjects();
                return facade;
            }
            return facade;
        }
		
		
	}
}