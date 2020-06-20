using BlazorCRUD.Server.DomainModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorCRUD.Server.Repository
{
    public interface IServiceRepo
    {
        Task<ReceipeModel> CreateReceipeAsync(ReceipeModel receipeModel);
        Task<List<ReceipeModel>> GetAllRecipes();
        Task<List<ReceipeModel>> GetRecipesById(string receipeId);
        Task<bool> RemoveReceipe(ReceipeModel receipeModel);
        Task<bool> UpdateRecipe(ReceipeModel receipeModel);
    }
}