namespace FormularioJorge.Models
{
    public class OrdenCompra
    {
        public int IdComprador { get; set; }
        public int IdVendedor { get; set; }
        public double Cantidad { get; set; }
        public int Idproducto { get; set; }
        public int IdCheckout {  get; set; }
    }
}
