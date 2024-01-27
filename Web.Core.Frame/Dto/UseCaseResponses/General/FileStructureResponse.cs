using BDO.Core.DataAccessObjects.ExtendedEntities;
using BDO.Core.DataAccessObjects.Models;
using BDO.Core.DataAccessObjects.SecurityModels;
using System.Collections.Generic;
using Web.Core.Frame.Dto;
using Web.Core.Frame.Interfaces;

namespace Web.Core.Frame.RequestResponse.UseCaseResponses
{
    public partial class FileStructureResponse : UseCaseResponseMessage
    {
        public filestructureEntity _filestructure_ { get; }

        public IEnumerable<filestructureEntity> _filestructure_List { get; }

        public Error Errors { get; }
        
        public AjaxResponse _ajaxresponse { get; }
        
        
        
        public FileStructureResponse(bool success = false, string message = null, Error errors = null) : base(success, message)
        {
            Errors = errors;
        }

        public FileStructureResponse(IEnumerable<filestructureEntity> filestructure_List, bool success = false, string message = null) : base(success, message)
        {
            _filestructure_List = filestructure_List;
        }
        
        public FileStructureResponse(filestructureEntity filestructure_, bool success = false, string message = null) : base(success, message)
        {
            _filestructure_ = filestructure_;
        }

        public FileStructureResponse(AjaxResponse ajaxresponse, bool success = false, string message = null) : base(success, message)
        {
            _ajaxresponse = ajaxresponse;
        }




    }
}
