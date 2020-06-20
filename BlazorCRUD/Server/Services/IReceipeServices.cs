using BlazorCRUD.Shared.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorCRUD.Server.Services
{
    public interface IReceipeServices
    {
        Task<Receipe> Add(Receipe receipe);
        Task<List<Receipe>> GetAllReceipes();
        Task<Receipe> GetReceipeById(string receipeId);
        Task<bool> Remove(Receipe receipe);
        Task<bool> Update(Receipe receipe);
    }
}