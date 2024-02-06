

using BFO.Core.BusinessFacadeObjects.General;
using IBFO.Core.IBusinessFacadeObjects.General;
using Microsoft.AspNetCore.Http;

namespace BFC.Core.FacadeCreatorObjects.General
{
    public class chartFCC
    { 
	
		public chartFCC()
        {
		
        }
		
		public static IchartFacadeObjects GetFacadeCreate(IHttpContextAccessor httpContextAccessor)
        {
            IchartFacadeObjects facade = null;
            var context = httpContextAccessor?.HttpContext;			
            
            if (context != null)
            {
                facade = context.Items["IchartFacadeObjects"] as IchartFacadeObjects;
    
                if (facade == null)
                {
                    facade = new chartFacadeObjects();
                    context.Items["IchartFacadeObjects"] = facade;
                }
            }
            else
            {
                facade = new chartFacadeObjects();
                return facade;
            }
            return facade;
        }
		
		
	}
}