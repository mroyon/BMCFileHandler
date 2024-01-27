

using BFO.Core.BusinessFacadeObjects.General;
using IBFO.Core.IBusinessFacadeObjects.General;
using Microsoft.AspNetCore.Http;

namespace BFC.Core.FacadeCreatorObjects.General
{
    public class trantinyurlaccessinfoFCC
    { 
	
		public trantinyurlaccessinfoFCC()
        {
		
        }
		
		public static ItrantinyurlaccessinfoFacadeObjects GetFacadeCreate(IHttpContextAccessor httpContextAccessor)
        {
            ItrantinyurlaccessinfoFacadeObjects facade = null;
            var context = httpContextAccessor.HttpContext;			
            
            if (context != null)
            {
                facade = context.Items["ItrantinyurlaccessinfoFacadeObjects"] as ItrantinyurlaccessinfoFacadeObjects;
    
                if (facade == null)
                {
                    facade = new trantinyurlaccessinfoFacadeObjects();
                    context.Items["ItrantinyurlaccessinfoFacadeObjects"] = facade;
                }
            }
            else
            {
                facade = new trantinyurlaccessinfoFacadeObjects();
                return facade;
            }
            return facade;
        }
		
		
	}
}