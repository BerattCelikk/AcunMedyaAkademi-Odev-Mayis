using Core.Exceptions.Types;
using Core.Rules;
using Repositories.Abstracts;
using System;

namespace Business.Rules
{
    public class BootcampBusinessRules : BaseBusinessRules
    {
        private readonly IBootcampRepository _bootcampRepository;
        private readonly IInstructorRepository _instructorRepository;

        public BootcampBusinessRules(IBootcampRepository bootcampRepository, IInstructorRepository instructorRepository)
        {
            _bootcampRepository = bootcampRepository;
            _instructorRepository = instructorRepository;
        }

        public void CheckDates(DateTime startDate, DateTime endDate)
        {
            if (startDate >= endDate)
                throw new BusinessException("Başlangıç tarihi, bitiş tarihinden önce olmalıdır.");
        }

        public void CheckIfBootcampNameUnique(string name)
        {
            var existingBootcamp = _bootcampRepository.Get(b => b.Name == name);
            if (existingBootcamp != null)
                throw new BusinessException("Aynı isimde bir bootcamp daha önce açılmıştır.");
        }

        public void CheckIfInstructorExists(int instructorId)
        {
            var instructor = _instructorRepository.Get(i => i.Id == instructorId);
            if (instructor == null)
                throw new BusinessException("Eğitmen sistemde kayıtlı olmalıdır.");
        }

        public void CheckIfBootcampIsClosed(string status)
        {
            if (status == "CLOSED")
                throw new BusinessException("Başvuru durumu 'CLOSED' olan bootcamp’e başvuru alınamaz.");
        }
    }
}
