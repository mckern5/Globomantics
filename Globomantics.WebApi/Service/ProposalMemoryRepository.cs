using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Shared.Models;

namespace Globomantics.WebApi.Service
{
    public class ProposalMemoryRepository : IProposalRepository
    {
        private readonly List<ProposalModel> _proposals;

        public ProposalMemoryRepository()
        {
            this._proposals = new List<ProposalModel>()
            {
                new ProposalModel()
                {
                    Id = 1,
                    ConferenceId = 1,
                    Speaker = "Mr. Rock N. Roller",
                    Title = "Understanding ASP.NET Core"
                },
                new ProposalModel()
                {
                    Id = 2,
                    ConferenceId = 2,
                    Speaker = "Mr. Hip Hopper",
                    Title = "Starting your Web API Developer"
                },
                new ProposalModel()
                {
                    Id = 3,
                    ConferenceId = 2,
                    Speaker = "Ms. Pirouetting Ballet",
                    Title = "ASP.NET MVC Fundamentals"
                }
            };
        }

        public async Task Add(ProposalModel model)
        {
            await Task.Run(() =>
            {
                if (model == null)
                {
                    return;
                }

                model.Id = this._proposals.Count + 1;
                this._proposals.Add(model);

            }).ConfigureAwait(false);
        }

        public async Task<ProposalModel> Approve(int proposalId)
        {
            return await Task.Run(() =>
            {
                if (proposalId <= 0)
                {
                    return null;
                }

                ProposalModel proposalModel = this._proposals.Find(proposal => proposal.Id.Equals(proposalId));

                if (proposalModel == null)
                {
                    return null;
                }

                proposalModel.Approved = true;
                return proposalModel;
            }).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets all proposals for a partuclar conference.
        /// </summary>
        /// <param name="conferenceId">The conference id for which the proposals are required.</param>
        /// <returns>Enumerale of all proposals in a particular conference.</returns>
        public async Task<IEnumerable<ProposalModel>> GetAll(int conferenceId)
        {
            return await Task.Run(() =>
            {
                if (conferenceId <= 0)
                {
                    return null;
                }

                return this._proposals.Where(proposal => proposal.ConferenceId.Equals(conferenceId));
            }).ConfigureAwait(false);
        }
    }
}
