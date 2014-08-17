namespace Neo4j.CSharpSample.Domain.Repository
{
    using System.Linq;

    using Neo4jClient;

    /// <summary>
    /// The dealer repository.
    /// </summary>
    public class DealerRepository : IDealerRepository
    {
        private readonly IGraphClient graphClient;

        public DealerRepository(IGraphClient graphClient)
        {
            this.graphClient = graphClient;
        }

        public void AddDealer(Dealer newdealer)
        {
            graphClient.Cypher
                .Create("(dealer:Dealer {newDealer})")
                .WithParam("newDealer", newdealer)
                .ExecuteWithoutResults();
        }

        public Dealer Get(long nodeRefId)
        {
            return graphClient.Get<Dealer>((NodeReference)nodeRefId).Data;
        }
        public Dealer GetbyId(long id)
        {
            var result = graphClient.Cypher.Match("(dealer:Dealer)")
               .Where((Dealer dealer) => dealer.Id == id)
               .Return(dealer => dealer.As<Dealer>())
               .Results.ToList().First();

            return result;
        }

        public void AddDealerWithRelation(Dealer childDealer, long dealerId, string relationName)
        {
            graphClient.Cypher
                      .Match("(dealer:Dealer)")
                      .Where((Dealer dealer) => dealer.Id == dealerId)
                      .Create("dealer-[:" + relationName + "]->(childDealer:Dealer {childDealer})")
                      .WithParam("childDealer", childDealer)
                      .ExecuteWithoutResults();
        }

        public void CreateRelation(Dealer d1, Dealer d2, string relationType)
        {
            graphClient.Cypher.Match("(dealer1:Dealer)", "(dealer2:Dealer)")
                .Where((Dealer dealer1) => dealer1.Id == d1.Id)
                .AndWhere((Dealer dealer2) => dealer2.Id == d2.Id)
                .CreateUnique("dealer1-[:" + relationType + "]->dealer2")
                .ExecuteWithoutResults();
        }

        public void DeletebyNodeId(long id)
        {
            graphClient.Delete(id,DeleteMode.NodeOnly);
        }

        public void DeletebyId(long id)
        {
            graphClient.Cypher
            .Match("(dealer:Dealer)")
            .Where((Dealer dealer) => dealer.Id == id)
            .Delete("dealer")
            .ExecuteWithoutResults();
        }


        #region Get all Labes for a selected dealer

        //var result = graphClient.Cypher
        //    .Match("(d1:Dealer)")
        //    .Where((Dealer d1) => d1.Id==2)
        //    .Return(d1 => d1.Labels())
        //    .Results;

        #endregion

        #region Get all labels for selected dealer and dealer too

        //var result = graphClient.Cypher.Match("(d1:Dealer)").Where((Dealer d1) => d1.Id == 3)
        //    .Return(d1 => new
        //    {
        //        Dealer = d1.As<Dealer>(),
        //        Labels = d1.Labels()
        //    }).Results;

        #endregion

    }

}