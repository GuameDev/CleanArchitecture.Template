namespace CleanArchitecture.Template.Application.Base.UnitOfWork
{
    /// <summary>
    /// Represents the Unit of Work pattern interface for managing transactions and committing changes.
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Saves all changes made within the current transaction context to the database.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous operation. The task result contains the number of state entries written to the database.
        /// </returns>
        Task<int> CommitAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Begins a new database transaction.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous operation of starting a transaction.
        /// </returns>
        Task BeginTransactionAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Commits the current database transaction, saving all changes made within the transaction context.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous operation of committing the transaction.
        /// </returns>
        Task CommitTransactionAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Rolls back the current transaction, discarding all changes made within the transaction context.
        /// </summary>
        void Rollback();
    }
}
