using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace br.senac.sp.mapaaula.ado.Vo
{
    public class SalaVo: BaseVo
    {
        public SalaVo() { }
        public SalaVo(String codSala)
        {
            this.codSala = codSala;
        }
        
        public string codSala { get; set; }
        public int numPredio { get; set; }
        public int numAndar { get; set; }
        public string datInativo { get; set; }
        public int numComputadores { get; set; }
        public int numProjetores { get; set; }
        public int numCadeiras { get; set; }
        public string dscObs { get; set; }
        public int idTipoSala { get; set; }

        public TipoSalaVo TipoSala { get; set; }


        public bool isInativo()
        {
            return (datInativo != null && !String.Empty.Equals(datInativo));
        }
    }
}
