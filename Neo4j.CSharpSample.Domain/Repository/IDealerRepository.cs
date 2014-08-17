namespace Neo4j.CSharpSample.Domain.Repository
{
    /// <summary>
    /// The DealerRepository interface.
    /// </summary>
    public interface IDealerRepository
    {
        void AddDealer(Dealer dealer);

        Dealer Get(long nodeRefId);

        Dealer GetbyId(long id);

        void AddDealerWithRelation(Dealer childDealer, long dealerId, string relationName);

        void CreateRelation(Dealer d1, Dealer d2, string relationType);

        void DeletebyNodeId(long id);

        void DeletebyId(long id);
    }
}