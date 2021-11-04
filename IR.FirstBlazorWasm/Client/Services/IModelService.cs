using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IR.FirstBlazorWasm.Client.Services
{
    public interface IModelService<TModel>
    {
        Task<IEnumerable<TModel>> GetModels();

        Task<TModel> SaveModel(string identifier, TModel model);

        Task DeleteModel(string identifier);
    }
}
