

using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Threading;
using System.Threading.Tasks;
using BDO.Core.DataAccessObjects.ExtendedEntities;
using BDO.Core.DataAccessObjects.Models;

namespace IBFO.Core.IBusinessFacadeObjects.General
{
    public partial interface IfiletransferinfoFacadeObjects 
    {


        [OperationContract]
        Task<long> UpdatePopUpData(filetransferinfoEntity filetransferinfo, CancellationToken cancellationToken);

        [OperationContract]
        Task<IList<filetransferinfoEntity>> GetAllMyNotificaiton(filetransferinfoEntity filetransferinfo, CancellationToken cancellationToken);

        [OperationContract]
        Task<IList<filetransferinfoEntity>> GetAllByPagesInBoxView(filetransferinfoEntity filetransferinfo, CancellationToken cancellationToken);

        [OperationContract]
        Task<IList<filetransferinfoEntity>> GetAllByPagesOutBoxView(filetransferinfoEntity filetransferinfo, CancellationToken cancellationToken);



        [OperationContract]
        Task<long> UpdateOpenData(filetransferinfoEntity filetransferinfo, CancellationToken cancellationToken);


        [OperationContract]
        Task<long> UpdateOpenDataNPopUpData(filetransferinfoEntity filetransferinfo, CancellationToken cancellationToken);



        [OperationContract]
        Task<filetransferinfoEntity> GetSingleNewPopTopView(filetransferinfoEntity filetransferinfo, CancellationToken cancellationToken);


    }
}
