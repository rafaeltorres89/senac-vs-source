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
    public class TipoSalaDao: AbstractDao
    {
        public TipoSalaDao(String connectionString) : base(connectionString) { }

        protected override void InsertRow(System.Data.SqlClient.SqlConnection sqlCon, BaseVo vo)
        {
            SqlCommand sqlCmd = base.GetStoredProc(sqlCon, this.GetSqlInsert(vo));
            this.AddParametersForInsert(sqlCmd, vo);
            
            SqlDataReader dr = sqlCmd.ExecuteReader();
            if (dr.Read()) ((TipoSalaVo) vo).id = ReadInt( dr["id"].ToString() );
            dr.Close();
        }

        protected override void AddParametersForInsert(SqlCommand sqlCmd, BaseVo vo)
        {
            TipoSalaVo tipoSalaVo = (TipoSalaVo)vo;
            this.AddParameter(sqlCmd, "@dscTipoSala", tipoSalaVo.dscTipoSala);
            this.AddParameter(sqlCmd, "@datInativo", tipoSalaVo.datInativo);
        }

        protected override void AddParametersForUpdate(SqlCommand sqlCmd, BaseVo vo)
        {
            TipoSalaVo tipoSalaVo = (TipoSalaVo)vo;
            this.AddParameter(sqlCmd, "@id", tipoSalaVo.id);
            this.AddParameter(sqlCmd, "@dscTipoSala", tipoSalaVo.dscTipoSala);
            this.AddParameter(sqlCmd, "@datInativo", tipoSalaVo.datInativo);
        }

        protected override void AddParametersByCriteria(SqlCommand sqlCmd, BaseVo vo)
        {
            TipoSalaVo tipoSalaVo = (TipoSalaVo)vo;
            if (!"".Equals(tipoSalaVo.dscTipoSala))
                this.AddParameter(sqlCmd, "@dscTipoSala", tipoSalaVo.dscTipoSala);
        }

        protected override void AddParametersByPk(SqlCommand sqlCmd, BaseVo vo)
        {
            this.AddParameter(sqlCmd, "@id", ((TipoSalaVo)vo).id);
        }

        protected override BaseVo PopulateVo(SqlDataReader dr)
        {
            TipoSalaVo tipoSalaVo = new TipoSalaVo();
            tipoSalaVo.id = ReadInt( dr["id"] );
            tipoSalaVo.dscTipoSala = dr["dscTipoSala"].ToString();
            tipoSalaVo.datInativo = dr["datInativo"].ToString();
            tipoSalaVo.inativo = (!tipoSalaVo.datInativo.Equals(""));

            return tipoSalaVo;
        }

        protected override string GetSqlInsert(BaseVo vo)
        {
            return "spInTipoSala";
        }

        protected override string GetSqlUpdate(BaseVo vo)
        {
            return "spUpTipoSala";
        }

        protected override string GetSqlDelete(BaseVo vo)
        {
            return "spDeTipoSala";
        }

        protected override string GetSqlSelectByPrimaryKey(BaseVo vo)
        {
            return "spSeTipoSala";
        }

        protected override string GetSqlSelectByCriteria(BaseVo vo)
        {
            return "spSeTipoSala";
        }

    }
}
