using Core.Exceptions.Types;
using Core.Rules;
using Repositories.Abstracts;

namespace Business.Rules
{
    public class ApplicationBusinessRules : BaseBusinessRules
    {
        private readonly IApplicationRepository _applicationRepository;
        private readonly IBlacklistRepository _blacklistRepository;
        private readonly IBootcampRepository _bootcampRepository;

        public ApplicationBusinessRules(
            IApplicationRepository applicationRepository,
            IBlacklistRepository blacklistRepository,
            IBootcampRepository bootcampRepository)
        {
            _applicationRepository = applicationRepository;
            _blacklistRepository = blacklistRepository;
            _bootcampRepository = bootcampRepository;
        }

        public void CheckIfDuplicateApplication(int applicantId, int bootcampId)
        {
            var existingApplication = _applicationRepository.Get(a => a.ApplicantId == applicantId && a.BootcampId == bootcampId);
            if (existingApplication != null)
                throw new BusinessException("Aynı kişi aynı bootcamp’e birden fazla başvuru yapamaz.");
        }

        public void CheckIfBootcampIsActive(int bootcampId)
        {
            var bootcamp = _bootcampRepository.Get(b => b.Id == bootcampId);
            if (bootcamp == null || bootcamp.Status != "ACTIVE")
                throw new BusinessException("Başvuru yapılan bootcamp aktif olmalıdır.");
        }

        public void CheckIfApplicantIsBlacklisted(int applicantId)
        {
            var blacklisted = _blacklistRepository.Get(b => b.ApplicantId == applicantId && b.IsActive);
            if (blacklisted != null)
                throw new BusinessException("Kara listeye alınmış bir aday başvuru yapamaz.");
        }

        public void CheckApplicationStatusTransition(string currentStatus, string newStatus)
        {
            if (currentStatus == "CANCELLED" && newStatus == "PENDING")
                throw new BusinessException("Başvurunun durumu CANCELLED'den PENDING'e geçirilemez.");

        }
    }
}
