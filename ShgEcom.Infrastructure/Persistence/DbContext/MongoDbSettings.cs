using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShgEcom.Infrastructure.Persistence.DbContext
{
    public class MongoDbSettings
    {
        public static readonly string SectionName = "MongoDbSettings";
        public string ConnectionString { get; set; } = null!;
        public string Database { get; set; } = null!;
        public string ProductCollectionName { get; set; } = null!;
    }
}
