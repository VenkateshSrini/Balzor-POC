using AutoMapper;
using BlazorCRUD.Server.DomainModel;
using BlazorCRUD.Server.Repository;
using BlazorCRUD.Shared.Model;
using DnsClient.Internal;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorCRUD.Server.Services
{
    public class ReceipeServices : IReceipeServices
    {
        readonly ILogger<ReceipeServices> logger;
        readonly IServiceRepo serviceRepo;
        readonly IMapper mapper;
        public ReceipeServices(ILogger<ReceipeServices> logger, IServiceRepo serviceRepo,
            IMapper mapper)
        {
            this.logger = logger;
            this.serviceRepo = serviceRepo;
            this.mapper = mapper;
        }
        public async Task<List<Receipe>> GetAllReceipes()
        {
            var models = await serviceRepo.GetAllRecipes();
            var results = mapper.Map<List<Receipe>>(models);
            return results;
        }
        public async Task<Receipe> GetReceipeById(string receipeId)
        {

            var model = await serviceRepo.GetRecipesById(receipeId);
            var result = mapper.Map<Receipe>(model);
            return result;
        }
        public async Task<Receipe> Add(Receipe receipe)
        {
            var model = mapper.Map<ReceipeModel>(receipe);
            var dbModel = await serviceRepo.CreateReceipeAsync(model);
            var result = mapper.Map<Receipe>(dbModel);
            return result;
        }
        public async Task<bool> Update(Receipe receipe)
        {
            var mappedModel = mapper.Map<ReceipeModel>(receipe);
            return await serviceRepo.UpdateRecipe(mappedModel);
        }
        public async Task<bool> Remove(Receipe receipe)
        {
            var mappedModel = mapper.Map<ReceipeModel>(receipe);
            return await serviceRepo.RemoveReceipe(mappedModel);
        }
    }
}
