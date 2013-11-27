using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace br.senac.sp.mapaaula.ado.Vo
{
    public class TipoSalaVo: BaseVo
    {
        public TipoSalaVo() { }
        public TipoSalaVo(int id)
        {
            this.id = id;
        }
        
        public int id { get; set; }
        public string dscTipoSala { get; set; }
        public string datInativo { get; set; }
        public bool inativo { get; set; }
    }
}
