using System.Data.Common;
using Dapper;
using Microsoft.Data.SqlClient;

namespace TransactionWork.v1
{
    public class TransactionProcessor
    {
        public async Task<DateTime> DoThisThing(SqlConnection cn, DbTransaction trans)
        {
            var result = await cn.QuerySingleAsync<DateTime>("SELECT GETDATE()", transaction: trans);
            return result;
        }

        public async Task<DateTime> DoTheOtherThing(SqlConnection cn, DbTransaction trans)
        {
            var result = await cn.QuerySingleAsync<DateTime>("SELECT GETDATE()", transaction: trans);
            return result;
        }
    }
}

namespace TransactionWork.v2
{
    public class TransactionProcessor
    {
        public async Task<DateTime> DoThisThing(DbTransaction trans)
        {
            var result = await trans.Connection!.QuerySingleAsync<DateTime>("SELECT GETDATE()", transaction: trans);
            return result;
        }

        public async Task<DateTime> DoTheOtherThing(DbTransaction trans)
        {
            var result = await trans.Connection!.QuerySingleAsync<DateTime>("SELECT GETDATE()", transaction: trans);
            return result;
        }
    }
}