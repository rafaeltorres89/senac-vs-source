using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace br.senac.sp.mapaaula.ado.Vo
{
    public class MembroVo: BaseVo
    {
        public MembroVo() { }
        public MembroVo(int id)
        {
            this.id = id;
        }
        
        public int id { get; set; }
        public string dscNome { get; set; }
        public string dscEmail { get; set; }
        public string dscMatricula { get; set; }
        public string indStatus { get; set; }
        public string indTipo { get; set; }
        public string datCriacao { get; set; }
        public string datSenha { get; set; }
        public string datInativo { get; set; }
        public string datNascimento { get; set; }

        public bool isInativo()
        {
            return (datInativo != null && !String.Empty.Equals(datInativo));
        }
    }
}
