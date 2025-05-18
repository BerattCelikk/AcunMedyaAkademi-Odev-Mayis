using Core.Exceptions.Types;
using Core.Rules;
using Repositories.Abstracts;

namespace Business.Rules
{
    public class BlacklistBusinessRules : BaseBusinessRules
    {
        private readonly IBlacklistRepository _blacklistRepository;

        public BlacklistBusinessRules(IBlacklistRepository blacklistRepository)
        {
            _blacklistRepository = blacklistRepository;
        }

        public void CheckIfActiveBlacklistExists(int applicantId)
        {
            var activeBlacklist = _blacklistRepository.Get(b => b.ApplicantId == applicantId && b.IsActive);
            if (activeBlacklist != null)
                throw new BusinessException("Aynı aday için birden fazla aktif kara liste kaydı olamaz.");
        }

        public void CheckIfReasonIsProvided(string reason)
        {
            if (string.IsNullOrWhiteSpace(reason))
                throw new BusinessException("Sebep (reason) boş bırakılamaz.");
        }
    }
}
