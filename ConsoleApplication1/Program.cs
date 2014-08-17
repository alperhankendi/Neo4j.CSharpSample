// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Program.cs" company="">
//   
// </copyright>
// <summary>
//   Defines the Program type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Neo4jClient.Sample
{
    using System;
    using System.Linq;

    using Neo4j.CSharpSample.BootStrapper;
    using Neo4j.CSharpSample.Domain;

    /// <summary>
    /// The program.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// The main.
        /// </summary>
        /// <param name="args">
        /// The args.
        /// </param>
        public static void Main(string[] args)
        {
            var bs = new BootStrapper();

            bs.Register();

            var dealerService = bs.Container.Resolve<DealerService>();

            var dealer = dealerService.NewDealer(100, "test deaer");

            dealerService.DelelteDealerbyId(100);

            dealerService.NewDealerWithRelationWithExistDealer(101, "another dealer", dealer);

            var relatedDealer = dealerService.NewDealer(102, "related dealer");

            dealerService.CreateRelation(dealer,relatedDealer,"RELATED");

        }
    }
}
