using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.BusinessLogicLayer
{
    public class ApplicantSkillLogic : BaseLogic<ApplicantSkillPoco>
    {
        public ApplicantSkillLogic(IDataRepository<ApplicantSkillPoco> repository) : base(repository)
        {

        }

        public override void Add(ApplicantSkillPoco[] pocos)
        {
            Verify(pocos);
            base.Add(pocos);
        }

        public override void Update(ApplicantSkillPoco[] pocos)
        {
            Verify(pocos);
            base.Update(pocos);
        }


        protected override void Verify(ApplicantSkillPoco[] pocos)
        {

            List<ValidationException> exceptions = new List<ValidationException>();

            foreach (ApplicantSkillPoco poco in pocos)
            {
                if (poco.StartMonth > 12)
                {
                    exceptions.Add(new ValidationException(101, $"Applicant Skill ID {poco.Id} has an invalid Start Month {poco.StartMonth}"));
                }
                if (poco.EndMonth > 12)
                {
                    exceptions.Add(new ValidationException(102, $"Applicant Skill ID {poco.Id} has an invalid End Month {poco.EndMonth}"));
                }
                if (poco.StartYear < 1900 || poco.StartYear > DateTime.Now.Year)
                {
                    exceptions.Add(new ValidationException(103, $"Applicant Skill ID {poco.Id} has an invalid Start Year {poco.StartYear}"));
                }
                if (poco.EndYear < poco.StartYear)
                {
                    exceptions.Add(new ValidationException(104, $"Applicant Skill ID {poco.Id} has an invalid End Year {poco.EndYear}"));
                }
            }

            if (exceptions.Count > 0)
            {
                throw new AggregateException(exceptions);
            }
        }
    }
}
