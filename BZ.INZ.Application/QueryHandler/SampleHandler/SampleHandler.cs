using BZ.INZ.Application.Core.Query;
using System.Linq;
using System.Threading.Tasks;

namespace BZ.INZ.Application.QueryHandler.SampleHandler {
    public class SampleHandler : IQueryHandlerAsync<string, string> {
        public async Task<IQueryable<string>> QueryAsync(string request) {
            return await Task.Run(() => {
                return new string[] { request }.AsQueryable();
            });
        }
    }
}
