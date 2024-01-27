using BDO.Core.DataAccessObjects.ExtendedEntities;
using BDO.Core.DataAccessObjects.Models;
using BDO.Core.DataAccessObjects.SecurityModels;
using System.Collections.Generic;
using Web.Core.Frame.Dto;
using Web.Core.Frame.Interfaces;

namespace Web.Core.Frame.RequestResponse.UseCaseResponses
{
    public partial class FolderStructureResponse : UseCaseResponseMessage
    {
        public folderstructureEntity _folderstructure_ { get; }

        public IEnumerable<folderstructureEntity> _folderstructure_List { get; }

        public Error Errors { get; }
        
        public AjaxResponse _ajaxresponse { get; }
        
        
        
        public FolderStructureResponse(bool success = false, string message = null, Error errors = null) : base(success, message)
        {
            Errors = errors;
        }

        public FolderStructureResponse(IEnumerable<folderstructureEntity> folderstructure_List, bool success = false, string message = null) : base(success, message)
        {
            _folderstructure_List = folderstructure_List;
        }
        
        public FolderStructureResponse(folderstructureEntity folderstructure_, bool success = false, string message = null) : base(success, message)
        {
            _folderstructure_ = folderstructure_;
        }

        public FolderStructureResponse(AjaxResponse ajaxresponse, bool success = false, string message = null) : base(success, message)
        {
            _ajaxresponse = ajaxresponse;
        }




    }
}
