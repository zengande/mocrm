using System.Threading.Tasks;

namespace YunStorm.MoCRM.Data
{
    public interface IMoCRMDbSchemaMigrator
    {
        Task MigrateAsync();
    }
}
