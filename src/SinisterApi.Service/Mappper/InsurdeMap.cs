﻿using SinisterApi.Domain.Models.Insured;
using SinisterApi.Service.Schemas;
using System.Reflection.Metadata;
using System.Xml.Linq;

namespace SinisterApi.Service.Mappper
{
    internal class InsurdeMap
    {
        public static List<InsuredModel> Map(List<InsuredResponse> response)
        {
            var result = new List<InsuredModel>();
            foreach (var insured in response)
            {
                result.Add(new InsuredModel()
                {
                    PersonId = insured.PersonId,
                    Name = insured.Name,
                    DocumentNumber = insured.DocumentNumber,
                });                
            }
            return result;
        }
        public static InsuredModel Map(InsuredResponse response)
        {
            var result = new InsuredModel()
            {
                PersonId = response.PersonId,
                Name = response.Name,
                DocumentNumber = response.DocumentNumber,
            };

            return result;
        }
    }
}
