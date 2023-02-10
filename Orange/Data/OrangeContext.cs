using Microsoft.EntityFrameworkCore;

namespace Orange.Data
{
    public class OrangeContext : DbContext
    {


        public OrangeContext(DbContextOptions<OrangeContext> options) : base(options)
        {

        }


    }
}
