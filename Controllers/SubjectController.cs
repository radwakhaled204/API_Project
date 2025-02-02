using API_PRO.Data;
using API_PRO.Data.Models;
using API_PRO.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API_PRO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectController : Controller
    {
        private readonly IDataRepository<Subject> _subjectRepository;
        private readonly IMapper _mapper;

        public SubjectController(IDataRepository<Subject> subjectRepository, IMapper mapper)
        {
            _subjectRepository = subjectRepository;
            _mapper = mapper;
        }

        // استرجاع جميع المواد كـ DTO
        [HttpGet]
        public async Task<IActionResult> GetAllSubjects()
        {
            var subjects = await _subjectRepository.GetAllFun();

            // تحويل الكيانات إلى DTO
            var subjectDtos = _mapper.Map<IEnumerable<SubjectDto>>(subjects);

            return Ok(subjectDtos);
        }

        // استرجاع مادة معينة كـ DTO
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSubjectById(int id)
        {
            var subject = await _subjectRepository.GetByIdFun(id);
            if (subject == null)
            {
                return NotFound();
            }

            // تحويل الكائن Entity إلى DTO
            var subjectDto = _mapper.Map<SubjectDto>(subject);
            return Ok(subjectDto);
        }

        // إضافة مادة جديدة
        [HttpPost]
        public async Task<IActionResult> AddSubject(SubjectDto subjectDto)
        {
            var subject = _mapper.Map<Subject>(subjectDto); // تحويل DTO إلى Entity

            await _subjectRepository.AddFun(subject);
            return CreatedAtAction(nameof(GetSubjectById), new { id = subject.SubjectId }, subjectDto);
        }

        // تعديل اسم المادة
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSubject(int id, SubjectDto subjectDto)
        {
            var subject = await _subjectRepository.GetByIdFun(id);
            if (subject == null)
            {
                return NotFound();
            }

            // تحويل الـ DTO إلى Entity
            _mapper.Map(subjectDto, subject);

            await _subjectRepository.UpdateFun(subject);
            return NoContent();
        }

        // حذف مادة
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubject(int id)
        {
            var subject = await _subjectRepository.GetByIdFun(id);
            if (subject == null)
            {
                return NotFound();
            }

            await _subjectRepository.DeleteFun(id);
            return NoContent();
        }
    }
}

