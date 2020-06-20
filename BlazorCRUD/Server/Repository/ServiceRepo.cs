using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorCRUD.Server.AppConfigOptions;
using BlazorCRUD.Server.DomainModel;
using DnsClient.Internal;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;

namespace BlazorCRUD.Server.Repository
{
    public class ServiceRepo : IServiceRepo
    {
        private readonly IMongoCollection<ReceipeModel> receipeCollection;
        private readonly ILogger<ServiceRepo> logger;
        public ServiceRepo(IOptions<MongoDBSettings> conectionOptions,
            ILogger<ServiceRepo> logger)
        {
            var client = new MongoClient(conectionOptions.Value?.ConnectionString);
            var db = client.GetDatabase(conectionOptions.Value?.DatabaseName);

            var collectionName = conectionOptions.Value?.CollectionName;
            var filter = new BsonDocument("name", collectionName);
            var isCollectionExist = db.ListCollections(new ListCollectionsOptions { Filter = filter })
                                      .Any();
            if (!isCollectionExist)
                db.CreateCollection(collectionName);

            receipeCollection = db.GetCollection<ReceipeModel>(collectionName);
            this.logger = logger;

        }
        public async Task<List<ReceipeModel>> GetAllRecipes()
        {
            return (await receipeCollection.FindAsync(receipe => true)).ToList();
        }
        public async Task<List<ReceipeModel>> GetRecipesById(string receipeId)
        {
            return (await receipeCollection.FindAsync(receipe => receipe.ReceipeID == receipeId)).ToList();
        }
        public async Task<ReceipeModel> CreateReceipeAsync(ReceipeModel receipeModel)
        {
            await receipeCollection.InsertOneAsync(receipeModel);
            return receipeModel;

        }
        public async Task<bool> UpdateRecipe(ReceipeModel receipeModel)
        {
            var result = await receipeCollection.ReplaceOneAsync<ReceipeModel>(receipe => receipe.ReceipeID == receipeModel.ReceipeID,
                 receipeModel);
            return result.IsAcknowledged;
        }
        public async Task<bool> RemoveReceipe(ReceipeModel receipeModel)
        {
            var result = await receipeCollection.DeleteOneAsync<ReceipeModel>(receipe => receipe.ReceipeID == receipeModel.ReceipeID);
            return result.IsAcknowledged;
        }
    }
}
