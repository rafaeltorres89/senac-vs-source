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
    public class TurmaDao : AbstractDao
    {
        public TurmaDao(String connectionString) : base(connectionString) { }

        protected override void AddParametersForInsert(SqlCommand sqlCmd, BaseVo vo)
        {
            
        }

        protected override void AddParametersForUpdate(SqlCommand sqlCmd, BaseVo vo)
        {
            
        }

        protected override void AddParametersByCriteria(SqlCommand sqlCmd, BaseVo vo)
        {
            
        }

        protected override void AddParametersByPk(SqlCommand sqlCmd, BaseVo vo)
        {
            
        }


        protected override BaseVo PopulateVo(SqlDataReader dr)
        {
            TurmaVo turmaVo = new TurmaVo();

            turmaVo.Curso = new CursoVo();
            turmaVo.Curso.id = ReadInt(dr["idCurso"]);
            turmaVo.Curso.dscCurso = dr["dscCurso"].ToString();
            turmaVo.Curso.dscAbreviatura = dr["dscAbreviatura"].ToString();

            turmaVo.indTurno = dr["indTurno"].ToString();
            turmaVo.numPeriodo = dr["numPeriodo"].ToString();

            return turmaVo;
        }

        protected override string GetSqlInsert(BaseVo vo)
        {
            return "";
        }

        protected override string GetSqlUpdate(BaseVo vo)
        {
            return "";
        }

        protected override string GetSqlDelete(BaseVo vo)
        {
            return "";
        }

        protected override string GetSqlSelectByPrimaryKey(BaseVo vo)
        {
            return "";
        }

        protected override string GetSqlSelectByCriteria(BaseVo vo)
        {
            return "spSeAllTurmas";
        }

    }
}
