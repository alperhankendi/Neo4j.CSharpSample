// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BootStrapper.cs" company="">
//   
// </copyright>
// <summary>
//   The boot strapper.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Neo4j.CSharpSample.BootStrapper
{
    using System;

    using Castle.MicroKernel.Registration;
    using Castle.Windsor;

    using Neo4j.CSharpSample.Domain;
    using Neo4j.CSharpSample.Domain.Repository;

    using Neo4jClient;

    /// <summary>
    /// The boot strapper.
    /// </summary>
    public class BootStrapper
    {
        public IWindsorContainer Container { get; private set; }
        /// <summary>
        /// The register.
        /// </summary>
        public void Register()
        {
            Container = new WindsorContainer();

            var graphClient = new GraphClient(new Uri("http://localhost:7474/db/data"));
            graphClient.Connect();

            Container.Register(
                Component.For<IGraphClient>().Instance(graphClient).LifestyleSingleton(),
                Component.For<IDealerRepository>().ImplementedBy<DealerRepository>(),
                Component.For<DealerService>()
            );
        }
    }
}