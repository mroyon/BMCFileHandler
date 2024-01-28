

using BFO.Core.BusinessFacadeObjects.General;
using IBFO.Core.IBusinessFacadeObjects.General;
using Microsoft.AspNetCore.Http;

namespace BFC.Core.FacadeCreatorObjects.General
{
    public class folderstructureFCC
    { 
	
		public folderstructureFCC()
        {
		
        }
		
		public static IfolderstructureFacadeObjects GetFacadeCreate(IHttpContextAccessor httpContextAccessor)
        {
            IfolderstructureFacadeObjects facade = null;
            var context = httpContextAccessor?.HttpContext;

            if (context != null)
            {
                facade = context.Items["IfolderstructureFacadeObjects"] as IfolderstructureFacadeObjects;
    
                if (facade == null)
                {
                    facade = new folderstructureFacadeObjects();
                    context.Items["IfolderstructureFacadeObjects"] = facade;
                }
            }
            else
            {
                facade = new folderstructureFacadeObjects();
                return facade;
            }
            return facade;
        }
		
		
	}
}