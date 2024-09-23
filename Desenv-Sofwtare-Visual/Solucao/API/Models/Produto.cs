namespace API.Models;

public class Produto {

    // declarar getter e setter junto com a variavel
    public double Preco {get;set;}  
    public DateTime CriadoEm { get; set;}
    public string? Nome {get;set;}    // ? para suprimir aviso
    public string? Id {get;set;}
    public int Quantidade {get; set;}

    // construtor da classe - nao tem tipo pois não tem retorno
    public Produto() {
        CriadoEm = DateTime.Now;
        Id = Guid.NewGuid().ToString();
    }

    /*
    private double preco;

    public double getPreco() {
        return preco;
    }
 

    public void setPreco(double preco) {
        this.preco = preco*3;
    }*/
}
