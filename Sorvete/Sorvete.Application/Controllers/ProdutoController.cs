using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Sorvete.Application.ViewModel;
using Sorvete.Domain.Domain;
using Sorvete.Service.Interface;

namespace Sorvete.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        protected readonly IProdutoService _service;
        protected readonly IMapper _mapper;

        public ProdutoController(IProdutoService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _service.GetAll();
            var viewmodel = _mapper.Map<IEnumerable<ProdutoViewModel>>(result);

            viewmodel = AjustaIdProduto(viewmodel.ToList());

            return Ok(viewmodel);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            //var nomeProduto = "Picole";
            //var idProduto = nomeProduto.Substring(0,1) + id;

            var result = _service.GetById(id);

            var viwmodel = _mapper.Map<ProdutoViewModel>(result);

            viwmodel.id = viwmodel.DescricaoProduto.Substring(0, 1) + viwmodel.id;            

            return Ok(viwmodel);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Insert([FromBody] ProdutoViewModel obj)
        {
            var viewmodel = _mapper.Map<ProdutoDomain>(obj);
            _service.Insert(viewmodel);

            return Ok();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] ProdutoViewModel obj)
        {
            var viewmodel = _mapper.Map<ProdutoDomain>(obj);
            _service.Update(viewmodel);

            return Ok();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete([FromBody] ProdutoViewModel obj)
        {
            var viewmodel = _mapper.Map<ProdutoDomain>(obj);
            _service.Update(viewmodel);

            return Ok();
        }


        private List<ProdutoViewModel> AjustaIdProduto(List<ProdutoViewModel> obj)
        {
            foreach(var item in obj)
            {
                item.id = item.DescricaoProduto.Substring(0, 1) + item.id;
            }

            return obj;
        }
    }
}
