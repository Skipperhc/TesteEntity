using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TesteEntity.Models {
    public class Pessoa {
        public Pessoa() {
            ListaEnderecos = new List<Endereco>();
            ListaTelefones = new List<Telefone>();
        }
        public int Id { get; set; }
        public List<Endereco> ListaEnderecos { get; set; }
        public List<Telefone> ListaTelefones { get; set; }
        [NotMapped]
        public List<int> listaInts { get; set; }
        [NotMapped]
        public Endereco Endereco { get; set; }
        [NotMapped]
        public int EnderecoId { get; set; }
        [NotMapped]
        public Telefone Telefone { get; set; }
        [NotMapped]
        public int TelefoneId { get; set; }
    }
}
