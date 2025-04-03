using TrabalhoAlmir.Model;

namespace TrabalhoAlmir.Model {
    public interface IVeiculosRepository {

        void Add(Veiculos veiculos);

        List<Veiculos> Get();
    }
}
