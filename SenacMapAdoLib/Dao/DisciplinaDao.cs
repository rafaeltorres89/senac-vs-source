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
    public class DisciplinaDao: AbstractDao
    {
        public DisciplinaDao(String connectionString) : base(connectionString) { }

        protected override void InsertRow(System.Data.SqlClient.SqlConnection sqlCon, BaseVo vo)
        {
            SqlCommand sqlCmd = base.GetStoredProc(sqlCon, this.GetSqlInsert(vo));
            this.AddParametersForInsert(sqlCmd, vo);

            SqlDataReader dr = sqlCmd.ExecuteReader();
            if (dr.Read()) ((DisciplinaVo) vo).id = ReadInt(dr["id"]);
            dr.Close();            
        }


        protected override void AddParametersForInsert(SqlCommand sqlCmd, BaseVo vo)
        {
            DisciplinaVo disciplinaVo = (DisciplinaVo)vo;
            this.AddParameter(sqlCmd, "@dscDisciplina", disciplinaVo.dscDisciplina);
            this.AddParameter(sqlCmd, "@datInativo", disciplinaVo.datInativo);
        }

        protected override void AddParametersForUpdate(SqlCommand sqlCmd, BaseVo vo)
        {
            DisciplinaVo disciplinaVo = (DisciplinaVo)vo;
            this.AddParameter(sqlCmd, "@id", disciplinaVo.id);
            this.AddParameter(sqlCmd, "@dscDisciplina", disciplinaVo.dscDisciplina);
            this.AddParameter(sqlCmd, "@datInativo", disciplinaVo.datInativo);
        }

        protected override void AddParametersByCriteria(SqlCommand sqlCmd, BaseVo vo)
        {
            DisciplinaVo disciplinaVo = (DisciplinaVo)vo;
            if (!"".Equals(disciplinaVo.dscDisciplina))
                this.AddParameter(sqlCmd, "@dscDisciplina", disciplinaVo.dscDisciplina);
        }

        protected override void AddParametersByPk(SqlCommand sqlCmd, BaseVo vo)
        {
            this.AddParameter(sqlCmd, "@id", ((DisciplinaVo)vo).id);
        }


        protected override BaseVo PopulateVo(SqlDataReader dr)
        {
            DisciplinaVo disciplinaVo = new DisciplinaVo();
            disciplinaVo.id = ReadInt(dr["id"]);
            disciplinaVo.dscDisciplina = dr["dscDisciplina"].ToString();
            disciplinaVo.datInativo = dr["datInativo"].ToString();

            return disciplinaVo;
        }

        protected override string GetSqlInsert(BaseVo vo)
        {
            return "spInDisciplina";
        }

        protected override string GetSqlUpdate(BaseVo vo)
        {
            return "spUpDisciplina";
        }

        protected override string GetSqlDelete(BaseVo vo)
        {
            return "spDeDisciplina";
        }

        protected override string GetSqlSelectByPrimaryKey(BaseVo vo)
        {
            return "spSeDisciplina";
        }

        protected override string GetSqlSelectByCriteria(BaseVo vo)
        {
            return "spSeAllDisciplina";
        }

    }
}
