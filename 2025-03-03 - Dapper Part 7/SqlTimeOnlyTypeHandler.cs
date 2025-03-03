using System.Data;
using Dapper;

public sealed class SqlTimeOnlyTypeHandler : SqlMapper.TypeHandler<TimeOnly>
{
    public override void SetValue(IDbDataParameter parameter, TimeOnly time) => parameter.Value = time.ToString();
    public override TimeOnly Parse(object value) => TimeOnly.FromTimeSpan(((DateTime)value).TimeOfDay);
}