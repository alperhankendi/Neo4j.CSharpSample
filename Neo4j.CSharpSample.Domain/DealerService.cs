// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DealerService.cs" company="">
//   
// </copyright>
// <summary>
//   The dealer service.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Neo4j.CSharpSample.Domain
{
    using System.Threading;

    using Neo4j.CSharpSample.Domain.Repository;

    /// <summary>
    /// The dealer service.
    /// </summary>
    public class DealerService
    {
        private readonly IDealerRepository dealerRepository;

        public DealerService(IDealerRepository dealerRepository)
        {
            this.dealerRepository = dealerRepository;
        }

        public Dealer NewDealer(long id, string name)
        {
            var newDealer = new Dealer { Id = id, Name = "root" };
   
            this.dealerRepository.AddDealer(newDealer);

            return newDealer;
        }

        public Dealer Get(long id)
        {
            return this.dealerRepository.GetbyId(id);
        }

        public void NewDealerWithRelationWithExistDealer(long newId,string newName,Dealer existDealer)
        {
            var childDealer = new Dealer { Id = newId, Name = newName };

            this.dealerRepository.AddDealerWithRelation(childDealer, existDealer.Id, "RELATED");
        }

        /// <summary>
        /// related two existing dealers, if they are not related with each other.
        /// </summary>
        /// <param name="d1"></param>
        /// <param name="d2"></param>
        public void CreateRelation(Dealer d1, Dealer d2,string relationType)
        {
            this.dealerRepository.CreateRelation(d1, d2, relationType);
        }

        public void DeleteDealerbyNodeId(long id)
        {
            this.dealerRepository.DeletebyNodeId(id);
        }

        public void DelelteDealerbyId(long id)
        {
            this.dealerRepository.DeletebyId(id);

        }



    }
}
