using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TesteEntity.Models {
    public class Endereco {
        public int Id { get; set; }
        public string NomeRua { get; set; }

        [ForeignKey(nameof(PessoaId))]
        public Pessoa Pessoa { get; set; }
        public int PessoaId { get; set; }

    }
}
