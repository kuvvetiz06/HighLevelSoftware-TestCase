using System.ComponentModel.DataAnnotations;

namespace MulakatProjesi.Models
{
    public class ProductsVM
    {
        public int id { get; set; }
        public string name { get; set; }
        public string imageUrl { get; set; }		
		public decimal price { get; set; }
    }
}
