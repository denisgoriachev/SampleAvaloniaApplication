using DynamicData;
using SampleAvaloniaApplication.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SampleAvaloniaApplication.Client.Core.Services
{
    public interface IDataService<TModel, TKey>
    {
        IObservable<IChangeSet<TModel, TKey>> Connect();

        Task<ServiceResult<TModel>> AddAsync(TModel model);

        Task<ServiceResult<TModel>> UpdateAsync(TModel model);

        Task DeleteAsync(TModel model);
    }
}
