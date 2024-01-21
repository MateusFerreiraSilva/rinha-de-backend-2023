using Medallion.Threading.Postgres;
using rinha_de_backend_2023.Data;
using Constants = rinha_de_backend_2023.Models.Constants;

namespace rinha_de_backend_2023.Utils;

public class DatabaseUtils
{

    public static async Task CreateDataseWithRetry(RinhaDbContext context, string connectionString, int retryCount = 0)
    {
        try
        {
            await CreateDatase(context, connectionString);
        }
        catch
        {
            if (retryCount >= Constants.DATABASE_CREATION_MAX_RETRIES)
            {
                throw;
            }

            Thread.Sleep(TimeSpan.FromSeconds(Constants.DATABASE_CREATION_FAIL_SLEEP_TIME_IN_SECONDS));
            
            await CreateDataseWithRetry(context, connectionString, ++retryCount);
        }
    }

    private static async Task CreateDatase(RinhaDbContext context, string connectionString)
    {
        var @lock = new PostgresDistributedLock(new PostgresAdvisoryLockKey("MyLock", allowHashing: true), connectionString);
        
        await using (await @lock.AcquireAsync())
        {
            var hasDatabaseBeenCreated = await context.Database.EnsureCreatedAsync();
        
            Console.WriteLine($"Database has been created by this application: {hasDatabaseBeenCreated}");
        }
    }
}