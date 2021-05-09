using Lamar;

namespace Sportradar.Service.Recruitment.Api.DependencyResolution
{
    public class Registry : ServiceRegistry
    {
        public Registry()
        {
            Scan();
        }

        private void Scan()
        {
            Scan(scan =>
            {
                scan.TheCallingAssembly();
                scan.WithDefaultConventions();
                scan.AssembliesFromApplicationBaseDirectory(assembly =>
                    assembly.FullName.StartsWith("Sportradar.Service.Recruitment"));
            });
        }

        private void Setup()
        {

        }
    }
}