using LocadoraDeVeiculos.Dominio.ModuloGrupoVeiculos;
using LocadoraDeVeiculos.Dominio.ModuloVeiculo;

namespace LocadoraDeVeiculos.Testes.Unidade.ModuloVeiculo;

[TestClass]
[TestCategory("Unidade")]
public class VeiculoTests
{
    [TestMethod]
    public void Deve_Criar_Instancia_Valida()
    {
        var grupo = new GrupoVeiculos("SUV");

        var veiculo = new Veiculo("Modelo A", "Marca B", TipoCombustivel.Gasolina, 50, 1);

        var erros = veiculo.Validar();

        Assert.AreEqual(0, erros.Count);
    }

    [TestMethod]
    public void Deve_Criar_Instancia_Com_Erro()
    {
        var veiculo = new Veiculo
            (
            "",
            "",
            TipoCombustivel.Gasolina,
            0,
            0
            );

        var erros = veiculo.Validar();

        List<string> errosEsperado = 
        [
            "O modelo é obrigatório",
            "A marca é obrigatória",
            "A capacidade do tanque precisa ser informada",
            "O grupo de veiculos é obrigatório"
        ];

        Assert.AreEqual(errosEsperado.Count, erros.Count);
        CollectionAssert.AreEqual(erros, errosEsperado);
    }
}
