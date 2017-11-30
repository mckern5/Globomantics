using System.Collections.Generic;
using System.Threading.Tasks;
using Shared.Models;

namespace Globomantics.WebApi.Service
{
    public interface IProposalRepository
    {
        Task<ProposalModel> Add(ProposalModel model);

        Task<IEnumerable<ProposalModel>> GetAll(int conferenceId);

        Task<ProposalModel> Approve(int proposalId);
    }
}
