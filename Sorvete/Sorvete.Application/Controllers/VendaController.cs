using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sorvete.Application.ViewModel;
using Sorvete.Domain.Domain;
using Sorvete.Service.Interface;

namespace Sorvete.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendaController : ControllerBase
    {
        protected readonly IVendaService _service;
        protected readonly IMapper _mapper;

        public VendaController(IVendaService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _service.GetAll();
            var viewmodel = _mapper.Map<IEnumerable<VendaViewModel>>(result);

            return Ok(viewmodel);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var result = _service.GetById(id);
            var viwmodel = _mapper.Map<VendaViewModel>(result);

            return Ok(viwmodel);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Insert([FromBody] VendaViewModel obj)
        {
            var viewmodel = _mapper.Map<VendaDomain>(obj);
            _service.Insert(viewmodel);

            return Ok();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] VendaViewModel obj)
        {
            var viewmodel = _mapper.Map<VendaDomain>(obj);
            _service.Update(viewmodel);

            return Ok();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete([FromBody] VendaViewModel obj)
        {
            var viewmodel = _mapper.Map<VendaDomain>(obj);
            _service.Update(viewmodel);

            return Ok();
        }
    }
}
