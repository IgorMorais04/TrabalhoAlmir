using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TrabalhoAlmir.ViewModel;
using TrabalhoAlmir.Model;

namespace TrabalhoAlmir.Controllers {

    [ApiController]
    [Route("api/v1/veiculos")]
    public class VeiculosController : ControllerBase {

        private readonly IVeiculosRepository _veiculosRepository;

        public VeiculosController(IVeiculosRepository veiculosRepository) {
            _veiculosRepository = veiculosRepository ?? throw new ArgumentNullException(nameof(veiculosRepository));
        }

        [HttpPost]
        public IActionResult Add([FromForm] VeiculosViewModel veiculosView) {

            var veiculos = new Veiculos(veiculosView.id, veiculosView.placa, veiculosView.modelo, veiculosView.marca, veiculosView.ano, veiculosView.cor);

            _veiculosRepository.Add(veiculos);

            return Ok();
        }

        [HttpGet]
        public IActionResult Get() {

            var veiculos = _veiculosRepository.Get();
            return Ok(veiculos);
        }
    }
}
