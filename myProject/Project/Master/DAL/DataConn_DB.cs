using DAL.Classes;
using System.Data.Entity;


namespace DAL
{
    public class DataConn_DB : DbContext
    {
        public DbSet<Client> clients { get; set; }
    }
}
