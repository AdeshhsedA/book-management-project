using Book__Management_Final.BusinessLogic.DTO.Subject;
using Book__Management_Final.BusinessLogic.Services.IServices;
using Book__Management_Final.BusinessLogic.Services.Services;
using Book__Management_Final.DataAccess.Models;
using Book__Management_Final.DataAccess.Repository.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Book__Management_Final.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectsController : ControllerBase
    {
        private readonly ISubjectServices _subjectServices;
        public SubjectsController(ISubjectServices subjectServices)
        {
            _subjectServices = subjectServices;
        }

        [HttpGet]
		[Authorize(Roles ="Admin")]
        public IActionResult GetAllSubjectList()
        {
            var result = _subjectServices.GetAllSubjects();
            return Ok(result);
		}

		[HttpGet("ByName/{subjectName}")]
		[Authorize(Roles = "Admin")]
		public IActionResult GetSubjectByName(string subjectName)
		{
			var result = _subjectServices.GetSubjectByName(subjectName);
			return Ok(result);
		}

		[HttpGet("{subjectId}")]
		[Authorize(Roles = "Admin")]
		public IActionResult GetSubjectById(int subjectId)
		{
			var res = _subjectServices.GetSubjectById(subjectId);
			if (res == null)
			{
				return BadRequest("No Subject");
			}
			return Ok(res);
		}


		[HttpPost("addSubject")]
		[Authorize(Roles = "Admin")]
		public IActionResult AddSubject(SubjectRequestDTO subjectReq)
		{
			var result = _subjectServices.AddSubject(subjectReq);
			if (result == "Success")
			{
				return StatusCode(StatusCodes.Status201Created, result);
			}
			return BadRequest(result);
		}
	}
}
