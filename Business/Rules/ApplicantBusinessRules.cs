using System.Linq.Expressions;  
using Core.Exceptions.Types;
using Core.Rules;
using Repositories.Abstracts;

namespace Business.Rules
{
    public class ApplicantBusinessRules : BaseBusinessRules
    {
        private readonly IApplicantRepository _applicantRepository;
        private readonly IBlacklistRepository _blacklistRepository;

        public ApplicantBusinessRules(IApplicantRepository applicantRepository, IBlacklistRepository blacklistRepository)
        {
            _applicantRepository = applicantRepository;
            _blacklistRepository = blacklistRepository;
        }

        public void CheckIfApplicantExistsByIdentityNumber(string identityNumber)
        {
            var existingApplicant = _applicantRepository.Get(a => a.IdentityNumber == identityNumber);
            if (existingApplicant != null)
                throw new BusinessException("Aynı TC Kimlik No ile birden fazla başvuru yapılamaz.");
        }

        public void CheckIfApplicantIsBlacklisted(int applicantId)
        {
            var blacklisted = _blacklistRepository.Get(b => b.ApplicantId == applicantId && b.IsActive);
            if (blacklisted != null)
                throw new BusinessException("Kara listeye alınan bir başvuru sahibi yeni başvuru yapamaz.");
        }

        public void CheckIfApplicantExists(int applicantId)
        {
            var applicant = _applicantRepository.Get(a => a.Id == applicantId);
            if (applicant == null)
                throw new BusinessException("Sistemde kayıtlı olmayan bir başvuru sahibi ile işlem yapılamaz.");
        }
    }
}
