namespace Quiik.ABS.Common.Repositories.Interface
{
    public interface ITransactionAble
    {
        void BeginTransaction();
        void CommitTransaction();
        void RollbackTransaction();
        void DisposeTransaction();
    }
}