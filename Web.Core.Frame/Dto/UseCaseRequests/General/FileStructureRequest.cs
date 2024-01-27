using BDO.Core.DataAccessObjects.Models;
using BDO.Core.DataAccessObjects.SecurityModels;
using Web.Core.Frame.Interfaces;
using Web.Core.Frame.RequestResponse.UseCaseResponses;

namespace Web.Core.Frame.RequestResponse.UseCaseRequests
{
    public partial class FileStructureRequest : IUseCaseRequest<FileStructureResponse>
    {
        public filestructureEntity Objfilestructure { get; }
        
        public FileStructureRequest(filestructureEntity objfilestructure)
        {
            Objfilestructure = objfilestructure;
        }
    }
}
