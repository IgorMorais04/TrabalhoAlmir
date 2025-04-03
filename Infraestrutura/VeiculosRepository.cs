using TrabalhoAlmir.Model;

namespace TrabalhoAlmir.Infraestrutura {
    public class VeiculosRepository : IVeiculosRepository {

        private readonly ConnectionContext _context = new ConnectionContext();
        public void Add(Veiculos veiculos) {

            _context.Veiculos.Add(veiculos);
            _context.SaveChanges();
        }

        public List<Veiculos> Get() {

            return _context.Veiculos.ToList();
        }
    }
}
