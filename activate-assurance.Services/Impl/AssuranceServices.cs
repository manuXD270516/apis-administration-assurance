using activate_assurance.DataAccess.Data.Repository;
using activate_assurance.Models;
using activate_assurance.Models.DTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static activate_assurance.Utils.UtilsModel;

namespace activate_assurance.Services.Impl
{
    public class AssuranceServices : IAssuranceServices
    {
        private readonly IAssuranceRepository assuranceRepository;
        public AssuranceServices(IAssuranceRepository assuranceRepository)
        {
            this.assuranceRepository = assuranceRepository;
        }

        public async Task<Assurance> addAsync(Assurance entity)
        {
            return await assuranceRepository.addAsync(entity);
        }

        public async Task<ActionResult<Assurance>> claimAssurance(ClaimAssuranceDTO claimAssurance)
        {
            var assuranceFind = await assuranceRepository.getByIdAsync(claimAssurance.assuranceId);
            if (!isNull(assuranceFind))
            {
                assuranceFind.claimDate = DateTime.Now;
                assuranceFind.reason = claimAssurance.reason;
                assuranceFind.usersCommerceClaimId = claimAssurance.usersCommerceClaimId;

                assuranceFind = await assuranceRepository.updateAsync(assuranceFind.assuranceId, assuranceFind);

            }
            return assuranceFind;
        }

        public List<Assurance> findAll()
        {
            throw new NotImplementedException();
        }

        public async Task<ActionResult<List<AssuranceDTO>>> findAllAssurancesByClientId(int clientId)
        {
            string[] relations = { "product", "client", "usersCommerceActivate", "usersCommerceClaim" };
            List<Assurance> assurances = await assuranceRepository.getAllAsync(filter: assurance => assurance.clientId == clientId, includeProperties: relations,
                orderBy: sort => sort.OrderByDescending(a => a.createdAt));
            return assurances.ConvertAll(ass => (AssuranceDTO)ass)
                .ToList();
        }

        public async Task<ActionResult<List<AssuranceDTO>>> findAllAssurancesCustom()
        {
            string[] relations = { "product", "client", "usersCommerceActivate", "usersCommerceClaim" };
            List<Assurance> assurances = await assuranceRepository.getAllAsync(includeProperties: relations,
                orderBy: sort => sort.OrderByDescending(a => a.createdAt));
            return assurances.ConvertAll(ass => (AssuranceDTO)ass)
                .ToList();
            //return assurances.ConvertAll(ass => (AssuranceDTO)ass);

        }

        public async Task<List<Assurance>> findAllAsync()
        {
            string[] relations = { "product", "client", "usersCommerceActivate", "usersCommerceClaim" };
            return await assuranceRepository.getAllAsync(includeProperties: relations);
        }

        public Assurance findById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Assurance> findByIdAsync(int id)
        {
            return await assuranceRepository.getByIdAsync(id);
        }

        public async Task<Assurance> updateAsync(int id, Assurance entity)
        {
            return await assuranceRepository.updateAsync(id, entity);
        }
    }
}
