using Autofac;

namespace DDD.Infra.IoC
{
    public class ModuleIoC : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            ConfigurationIoC.Load(builder);
        }
    }
}
