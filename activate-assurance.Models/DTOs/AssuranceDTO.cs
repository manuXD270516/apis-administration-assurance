using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using static activate_assurance.Utils.UtilsModel;

namespace activate_assurance.Models.DTOs
{
    public class AssuranceDTO
    {

        public int assuranceId { get; set; }
        public string clientDni { get; set; }
        public string clientFullName { get; set; }
        public string productCode { get; set; }
        public string productName { get; set; }
        public string assuranceState { get; set; }
        public string assuranceDateState { get; set; }
        public int expirationDays { get; set; }



        public static explicit operator AssuranceDTO(Assurance assuranceModel)
        {
            AssuranceDTO assuranceDto = new AssuranceDTO();
            if (!isNull(assuranceModel))
            {
                assuranceDto.assuranceId = assuranceModel.assuranceId;
                if (!isNull(assuranceModel.client))
                {
                    assuranceDto.clientDni = assuranceModel.client.dni;
                    assuranceDto.clientFullName = $"{assuranceModel.client.names} {assuranceModel.client.lastnames}";
                }
                if (!isNull(assuranceModel.product))
                {
                    assuranceDto.productCode = assuranceModel.product.codeArticle;
                    assuranceDto.productName = assuranceModel.product.name;
                    assuranceDto.expirationDays = assuranceModel.product.expirationDays;
                }
                if (isNull(assuranceModel.usersCommerceClaimId))
                {
                    assuranceDto.assuranceState = "GARANTIA ACTIVADA";
                    assuranceDto.assuranceDateState = assuranceModel.activationDate.ToString("dd-MM-yyyy hh:mm");
                }
                else
                {
                    assuranceDto.assuranceState = "GARANTIA EJECTUDA";
                    assuranceDto.assuranceDateState = assuranceModel.claimDate?.ToString("dd-MM-yyyy hh:mm");
                }
            }
            return assuranceDto;
        }
    }
}
