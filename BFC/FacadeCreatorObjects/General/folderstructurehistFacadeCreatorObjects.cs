

using BFO.Core.BusinessFacadeObjects.General;
using IBFO.Core.IBusinessFacadeObjects.General;
using Microsoft.AspNetCore.Http;

namespace BFC.Core.FacadeCreatorObjects.General
{
    public class folderstructurehistFCC
    { 
	
		public folderstructurehistFCC()
        {
		
        }
		
		public static IfolderstructurehistFacadeObjects GetFacadeCreate(IHttpContextAccessor httpContextAccessor)
        {
            IfolderstructurehistFacadeObjects facade = null;
            var context = httpContextAccessor?.HttpContext;

            if (context != null)
            {
                facade = context.Items["IfolderstructurehistFacadeObjects"] as IfolderstructurehistFacadeObjects;
    
                if (facade == null)
                {
                    facade = new folderstructurehistFacadeObjects();
                    context.Items["IfolderstructurehistFacadeObjects"] = facade;
                }
            }
            else
            {
                facade = new folderstructurehistFacadeObjects();
                return facade;
            }
            return facade;
        }
		
		
	}
}