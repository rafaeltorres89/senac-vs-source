using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace br.senac.sp.mapaaula.ado.Vo
{
    public class CursoVo: BaseVo
    {
        public CursoVo() { }
        public CursoVo(int id)
        {
            this.id = id;
        }
        
        public int id { get; set; }
        public string dscCurso { get; set; }
        public string dscAbreviatura { get; set; }
        public string datInicio { get; set; }
        public int idCoordenador { get; set; }

        public string datInativo { get; set; }
        public bool isInativo()
        {
            return (datInativo != null && !String.Empty.Equals(datInativo));
        }

        /*
         * Late bind  
         */
        public MembroVo Coordenador { get; set; }
        public List<TurmaVo> Turmas { get; set; }
    }
}
