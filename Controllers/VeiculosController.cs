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
        public IActionResult Add([FromBody] VeiculosViewModel veiculosView) {
            var veiculo = new Veiculos(0, veiculosView.placa, veiculosView.modelo, veiculosView.marca, veiculosView.ano, veiculosView.cor);
            _veiculosRepository.Add(veiculo);
            return Ok(veiculo);
        }

        [HttpGet]
        public IActionResult Get() {
            var veiculos = _veiculosRepository.Get();
            return Ok(veiculos);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] VeiculosViewModel veiculosView) {
            var veiculo = _veiculosRepository.GetById(id);
            if (veiculo == null)
                return NotFound();

            veiculo.placa = veiculosView.placa;
            veiculo.modelo = veiculosView.modelo;
            veiculo.marca = veiculosView.marca;
            veiculo.ano = veiculosView.ano;
            veiculo.cor = veiculosView.cor;

            _veiculosRepository.Update(veiculo);
            return Ok(veiculo);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id) {
            var veiculo = _veiculosRepository.GetById(id);
            if (veiculo == null)
                return NotFound();

            _veiculosRepository.Delete(veiculo);
            return NoContent();
        }
    }
}
