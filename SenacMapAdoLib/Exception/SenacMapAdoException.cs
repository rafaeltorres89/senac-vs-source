using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace br.senac.sp.mapaaula.ado
{
    [Serializable]
    class SenacMapAdoException: ApplicationException
    {
        private Object source;

        public SenacMapAdoException(String message): base(message) { }

        public SenacMapAdoException(String message, Exception inner):base(message, inner) { }
        
        protected SenacMapAdoException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context): base(info, context) { }

        public void setSource(Object source) {
            this.source = source;
        }

        public Object getSource()
        {
            return this.source;
        }
    }
}
