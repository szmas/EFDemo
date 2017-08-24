using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace OneToOne
{
    class MasContext : DbContext
    {

        public MasContext()
            : base("name=MasContext")
        {

        }

        public DbSet<Student> Student { get; set; }
        public DbSet<Person> Person { get; set; }

        public DbSet<DemoAttribute> DemoAttr { get; set; }


        /// <summary>
        /// 通过反射一次性将表进行映射
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var typesRegister = Assembly.GetExecutingAssembly().GetTypes()
                .Where(type => !(string.IsNullOrEmpty(type.Namespace))).Where(type => type.BaseType != null && type.BaseType.IsGenericType && type.BaseType.GetGenericTypeDefinition() == typeof(EntityTypeConfiguration<>));
            foreach (var type in typesRegister)
            {
                dynamic configurationInstance = Activator.CreateInstance(type);
                modelBuilder.Configurations.Add(configurationInstance);
            }
        }

    }
}
