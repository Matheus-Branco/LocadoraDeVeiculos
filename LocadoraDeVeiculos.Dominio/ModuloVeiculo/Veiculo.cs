using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloGrupoVeiculos;

namespace LocadoraDeVeiculos.Dominio.ModuloVeiculo;

public class Veiculo : EntidadeBase
{
    public string Modelo { get; set; }
    public string Marca { get; set; }
    public TipoCombustivel TipoCombustivel { get; set; }
    public int CapacidadeTanque {  get; set; }
    public byte[] Foto { get; set; }
    public bool Disponivel { get; set; }

    public int GrupoVeiculosId {  get; set; }
    public GrupoVeiculos? GrupoVeiculos { get; set; }
    

    protected Veiculo() { }

    public Veiculo(string modelo, string marca, TipoCombustivel tipoCombustivel, int capacidadeTanque, bool disponivel,int grupoVeiculosId)
    {
        Modelo = modelo;
        Marca = marca;
        TipoCombustivel = tipoCombustivel;
        CapacidadeTanque = capacidadeTanque;
        Disponivel = disponivel;
        GrupoVeiculosId = grupoVeiculosId;
    }

    public override List<string> Validar()
    {
        List<string> erros = [];

        if (string.IsNullOrEmpty(Modelo))
            erros.Add("O modelo é obrigatório");

        if (string.IsNullOrEmpty(Marca))
            erros.Add("A marca é obrigatória");

        if (CapacidadeTanque == 0)
            erros.Add("A capacidade do tanque precisa ser informada");

        if (GrupoVeiculosId == 0)
            erros.Add("O grupo de veiculos é obrigatório");

        if (Disponivel is false)
            erros.Add("O veículo não está disponível");

        return erros;
    }
}
