using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace br.senac.sp.mapaaula.ado.Vo
{
    public class DisciplinaVo: BaseVo
    {
        public DisciplinaVo() { }
        public DisciplinaVo(int id)
        {
            this.id = id;
        }
        
        public int id { get; set; }
        public string dscDisciplina { get; set; }

        public string datInativo { get; set; }
        public bool isInativo()
        {
            return (datInativo != null && !String.Empty.Equals(datInativo));
        }
    }
}
