using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace br.senac.sp.mapaaula.ado.Vo
{
    public class TurmaVo: BaseVo
    {
        public TurmaVo() { }
        public TurmaVo(string indTurno, string numPeriodo)
        {
            this.indTurno = indTurno;
            this.numPeriodo = numPeriodo;
        }
        
        public string indTurno { get; set; }
        public string numPeriodo { get; set; }

        public CursoVo Curso { get; set; }

        public List<DisciplinaVo> Disciplinas { get; set; }


    }
}
