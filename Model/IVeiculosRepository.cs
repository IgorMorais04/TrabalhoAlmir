namespace TrabalhoAlmir.Model {
    public interface IVeiculosRepository {
        void Add(Veiculos veiculo);
        List<Veiculos> Get();
        Veiculos GetById(int id);
        void Update(Veiculos veiculo);
        void Delete(Veiculos veiculo);
    }
}
