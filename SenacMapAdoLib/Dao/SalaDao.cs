using br.senac.sp.mapaaula.ado.Vo;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace br.senac.sp.mapaaula.ado
{
    public class SalaDao: AbstractDao
    {
        public SalaDao(String connectionString) : base(connectionString) { }

        protected override void AddParametersForInsert(SqlCommand sqlCmd, BaseVo vo)
        {
            this.AddParametersForUpdate(sqlCmd, vo);
        }

        protected override void AddParametersForUpdate(SqlCommand sqlCmd, BaseVo vo)
        {
            SalaVo salaVo = (SalaVo)vo;

            this.AddParameter(sqlCmd, "@codSala", salaVo.codSala);
            this.AddParameter(sqlCmd, "@numPredio", salaVo.numPredio);
            this.AddParameter(sqlCmd, "@numAndar", salaVo.numAndar);
            this.AddParameter(sqlCmd, "@datInativo", salaVo.datInativo);
            this.AddParameter(sqlCmd, "@dscObs", salaVo.dscObs);
            this.AddParameter(sqlCmd, "@numComputadores", salaVo.numComputadores);
            this.AddParameter(sqlCmd, "@numProjetores", salaVo.numProjetores);
            this.AddParameter(sqlCmd, "@numCadeiras", salaVo.numCadeiras);
            this.AddParameter(sqlCmd, "@idTipoSala", salaVo.idTipoSala);
            
        }

        protected override void AddParametersByCriteria(SqlCommand sqlCmd, BaseVo vo)
        {
            SalaVo salaVo = (SalaVo)vo;
            if (!"".Equals(salaVo.codSala))
                this.AddParameter(sqlCmd, "@codSala", salaVo.codSala);
        }

        protected override void AddParametersByPk(SqlCommand sqlCmd, BaseVo vo)
        {
            this.AddParameter(sqlCmd, "@codSala", ((SalaVo)vo).codSala);
        }


        protected override BaseVo PopulateVo(SqlDataReader dr)
        {
            SalaVo salaVo = new SalaVo();

            salaVo.codSala = dr["codSala"].ToString();
            salaVo.numPredio = ReadInt(dr["numPredio"]);
            salaVo.numAndar = ReadInt(dr["numAndar"]);
            salaVo.datInativo = dr["datInativo"].ToString();
            salaVo.dscObs = dr["dscObs"].ToString();
            salaVo.numComputadores = ReadInt(dr["numComputadores"]);
            salaVo.numProjetores = ReadInt(dr["numProjetores"]);
            salaVo.numCadeiras = ReadInt(dr["numCadeiras"]);
            salaVo.idTipoSala = ReadInt(dr["idTipoSala"]);
            
            return salaVo;
        }

        protected override string GetSqlInsert(BaseVo vo)
        {
            return "spInSala";
        }

        protected override string GetSqlUpdate(BaseVo vo)
        {
            return "spUpSala";
        }

        protected override string GetSqlDelete(BaseVo vo)
        {
            return "spDeSala";
        }

        protected override string GetSqlSelectByPrimaryKey(BaseVo vo)
        {
            return "spSeSala";
        }

        protected override string GetSqlSelectByCriteria(BaseVo vo)
        {
            return "spSeAllSala";
        }

    }
}
