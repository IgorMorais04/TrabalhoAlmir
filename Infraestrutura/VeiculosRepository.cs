using TrabalhoAlmir.Model;

namespace TrabalhoAlmir.Infraestrutura {
    public class VeiculosRepository : IVeiculosRepository {
        private readonly ConnectionContext _context = new ConnectionContext();

        public void Add(Veiculos veiculo) {
            var existe = _context.Veiculos.Any(v => v.placa == veiculo.placa);
            if (existe)
                throw new Exception("Já existe um veículo com essa placa.");

            _context.Veiculos.Add(veiculo);
            _context.SaveChanges();
        }


        public List<Veiculos> Get() {
            return _context.Veiculos.ToList();
        }

        public Veiculos GetById(int id) {
            return _context.Veiculos.Find(id);
        }

        public void Update(Veiculos veiculo) {
            _context.Veiculos.Update(veiculo);
            _context.SaveChanges();
        }

        public void Delete(Veiculos veiculo) {
            _context.Veiculos.Remove(veiculo);
            _context.SaveChanges();
        }
    }
}
