using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Rick.DataAccess.Abstraction
{
    public interface IMultipleReader : IDisposable
    {
        Task<List<T>> ExecuteEntityListAsync<T>();

        Task<List<T>> ExecuteEntityListAsync<T>(CancellationToken cancellationToken, dynamic paramter = null);

        Task<T> ExecuteEntityAsync<T>();

        Task<T> ExecuteEntityAsync<T>(CancellationToken cancellationToken);

        Task<T> ExecuteScalarAsync<T>();

        Task<T> ExecuteScalarAsync<T>(CancellationToken cancellationToken);

        List<T> ExecuteEntityList<T>();

        T ExecuteEntity<T>();

        T ExecuteScalar<T>();
    }
}