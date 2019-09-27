namespace WebApplication1.Mapping
{
    public class InitializeMappings
    {
        public void Initialize()
        {
            DapperExtensions.DapperExtensions.SqlDialect = new DapperExtensions.Sql.PostgreSqlDialect();
            DapperExtensions.DapperExtensions.SetMappingAssemblies(new[]
            {
                typeof(ResultMap).Assembly,
                typeof(TraksMap).Assembly,
                typeof(SetsMap).Assembly,
                typeof(ItemsMap).Assembly
            });
        }
    }
}
