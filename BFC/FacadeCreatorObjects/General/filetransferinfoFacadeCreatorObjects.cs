

using BFO.Core.BusinessFacadeObjects.General;
using IBFO.Core.IBusinessFacadeObjects.General;
using Microsoft.AspNetCore.Http;

namespace BFC.Core.FacadeCreatorObjects.General
{
    public class filetransferinfoFCC
    { 
	
		public filetransferinfoFCC()
        {
		
        }
		
		public static IfiletransferinfoFacadeObjects GetFacadeCreate(IHttpContextAccessor httpContextAccessor)
        {
            IfiletransferinfoFacadeObjects facade = null;
            var context = httpContextAccessor.HttpContext;			
            
            if (context != null)
            {
                facade = context.Items["IfiletransferinfoFacadeObjects"] as IfiletransferinfoFacadeObjects;
    
                if (facade == null)
                {
                    facade = new filetransferinfoFacadeObjects();
                    context.Items["IfiletransferinfoFacadeObjects"] = facade;
                }
            }
            else
            {
                facade = new filetransferinfoFacadeObjects();
                return facade;
            }
            return facade;
        }
		
		
	}
}