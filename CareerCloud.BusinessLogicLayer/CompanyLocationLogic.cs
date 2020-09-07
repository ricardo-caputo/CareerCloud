using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.BusinessLogicLayer
{
    public class CompanyLocationLogic : BaseLogic<CompanyLocationPoco>
    {
        public CompanyLocationLogic(IDataRepository<CompanyLocationPoco> repository) : base(repository)
        {

        }

        public override void Add(CompanyLocationPoco[] pocos)
        {
            Verify(pocos);
            base.Add(pocos);
        }

        public override void Update(CompanyLocationPoco[] pocos)
        {
            Verify(pocos);
            base.Update(pocos);
        }

        protected override void Verify(CompanyLocationPoco[] pocos)
        {
            List<ValidationException> exceptions = new List<ValidationException>();
            foreach (var poco in pocos)
            {
                if (string.IsNullOrEmpty(poco.CountryCode))
                {
                    exceptions.Add(new ValidationException(500, $"Country Code for Company Location ID {poco.Id} is empty"));
                }
                if (string.IsNullOrEmpty(poco.Province))
                {
                    exceptions.Add(new ValidationException(501, $"Province for Company Location ID {poco.Id} is empty"));
                }
                if (string.IsNullOrEmpty(poco.Street))
                {
                    exceptions.Add(new ValidationException(502, $"Street for Company Location {poco.Id} is empty"));
                }
                if (string.IsNullOrEmpty(poco.City))
                {
                    exceptions.Add(new ValidationException(503, $"City for Company Location {poco.Id} is empty"));
                }
                if (string.IsNullOrEmpty(poco.PostalCode))
                {
                    exceptions.Add(new ValidationException(504, $"Postal Code for Company Location ID {poco.Id} is empty"));
                }
            }

            if (exceptions.Count > 0)
            {
                throw new AggregateException(exceptions);
            }
        }
    }
}
