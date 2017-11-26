using System.Collections.Generic;
using System.Threading.Tasks;
using Shared.Models;

namespace Globomantics.Services
{
    public interface IProposalService
    {
        Task Add(ProposalModel model);

        Task<IEnumerable<ProposalModel>> GetAll(int conferenceId);

        Task<ProposalModel> Approve(int proposalId);
    }
}
