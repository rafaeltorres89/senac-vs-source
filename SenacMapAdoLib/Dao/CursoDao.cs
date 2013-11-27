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
    public class CursoDao: AbstractDao
    {
        public CursoDao(String connectionString) : base(connectionString) { }

        protected override void InsertRow(System.Data.SqlClient.SqlConnection sqlCon, BaseVo vo)
        {
            SqlCommand sqlCmd = base.GetStoredProc(sqlCon, this.GetSqlInsert(vo));
            this.AddParametersForInsert(sqlCmd, vo);
            
            SqlDataReader dr = sqlCmd.ExecuteReader();
            if (dr.Read()) ((CursoVo) vo).id = ReadInt( dr["id"].ToString() );
            dr.Close();
        }

        protected override void AddParametersForInsert(SqlCommand sqlCmd, BaseVo vo)
        {
            CursoVo cursoVo = (CursoVo)vo;
            this.AddParameter(sqlCmd, "@dscCurso", cursoVo.dscCurso);
            this.AddParameter(sqlCmd, "@dscAbreviatura", cursoVo.dscAbreviatura);
            this.AddParameter(sqlCmd, "@datInicio", cursoVo.datInicio);
            this.AddParameter(sqlCmd, "@idCoordenador", cursoVo.idCoordenador);
            this.AddParameter(sqlCmd, "@datInativo", cursoVo.datInativo);
        }

        protected override void AddParametersForUpdate(SqlCommand sqlCmd, BaseVo vo)
        {
            CursoVo cursoVo = (CursoVo)vo;
            this.AddParameter(sqlCmd, "@id", cursoVo.id);

            this.AddParametersForInsert(sqlCmd, vo);
        }

        protected override void AddParametersByCriteria(SqlCommand sqlCmd, BaseVo vo)
        {
            CursoVo cursoVo = (CursoVo)vo;
            if (!"".Equals(cursoVo.dscCurso))
                this.AddParameter(sqlCmd, "@dscCurso", cursoVo.dscCurso);
        }

        protected override void AddParametersByPk(SqlCommand sqlCmd, BaseVo vo)
        {
            this.AddParameter(sqlCmd, "@id", ((CursoVo)vo).id);
        }

        protected override BaseVo PopulateVo(SqlDataReader dr)
        {
            CursoVo cursoVo = new CursoVo();

            cursoVo.id = ReadInt( dr["id"] );
            cursoVo.dscCurso = dr["dscCurso"].ToString();
            cursoVo.dscAbreviatura = dr["dscAbreviatura"].ToString();
            cursoVo.datInicio = dr["datInicio"].ToString();
            cursoVo.idCoordenador = ReadInt( dr["idCoordenador"] );
            cursoVo.datInativo = dr["datInativo"].ToString();

            cursoVo.Coordenador = new MembroVo();
            cursoVo.Coordenador.id = ReadInt(dr["idCoordenador"]);
            cursoVo.Coordenador.dscNome = dr["dscNome"].ToString();

            return cursoVo;
        }

        protected override string GetSqlInsert(BaseVo vo)
        {
            return "spInCurso";
        }

        protected override string GetSqlUpdate(BaseVo vo)
        {
            return "spUpCurso";
        }

        protected override string GetSqlDelete(BaseVo vo)
        {
            return "spDeCurso";
        }

        protected override string GetSqlSelectByPrimaryKey(BaseVo vo)
        {
            return "spSeCurso";
        }

        protected override string GetSqlSelectByCriteria(BaseVo vo)
        {
            return "spSeAllCurso";
        }

    }
}
