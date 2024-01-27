using BDO.Core.DataAccessObjects.ExtendedEntities;
using BDO.Core.DataAccessObjects.Models;
using BDO.Core.DataAccessObjects.SecurityModels;
using System.Collections.Generic;
using Web.Core.Frame.Dto;
using Web.Core.Frame.Interfaces;

namespace Web.Core.Frame.RequestResponse.UseCaseResponses
{
    public partial class TranTinyURLAccessInfoResponse : UseCaseResponseMessage
    {
        public trantinyurlaccessinfoEntity _trantinyurlaccessinfo_ { get; }

        public IEnumerable<trantinyurlaccessinfoEntity> _trantinyurlaccessinfo_List { get; }

        public Error Errors { get; }
        
        public AjaxResponse _ajaxresponse { get; }
        
        
        
        public TranTinyURLAccessInfoResponse(bool success = false, string message = null, Error errors = null) : base(success, message)
        {
            Errors = errors;
        }

        public TranTinyURLAccessInfoResponse(IEnumerable<trantinyurlaccessinfoEntity> trantinyurlaccessinfo_List, bool success = false, string message = null) : base(success, message)
        {
            _trantinyurlaccessinfo_List = trantinyurlaccessinfo_List;
        }
        
        public TranTinyURLAccessInfoResponse(trantinyurlaccessinfoEntity trantinyurlaccessinfo_, bool success = false, string message = null) : base(success, message)
        {
            _trantinyurlaccessinfo_ = trantinyurlaccessinfo_;
        }

        public TranTinyURLAccessInfoResponse(AjaxResponse ajaxresponse, bool success = false, string message = null) : base(success, message)
        {
            _ajaxresponse = ajaxresponse;
        }




    }
}
