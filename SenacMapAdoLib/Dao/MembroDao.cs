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
    public class MembroDao : AbstractDao
    {
        public MembroDao(String connectionString) : base(connectionString) { }

        public MembroVo ValidatePassword(String dscEmail, String dscSenha)
        {

            SqlConnection sqlCon = null;

            try
            {
                sqlCon = GetConnection();
                SqlCommand sqlCmd = this.GetStoredProc(sqlCon, "spSeValidaUsuarioSenha");
                this.AddParameter(sqlCmd, "@dscEmail", dscEmail);
                this.AddParameter(sqlCmd, "@dscSenha", dscSenha);

                SqlDataReader dr=sqlCmd.ExecuteReader();
                if (dr.Read())
                {
                    return (MembroVo) this.PopulateVo(dr);
                }

                return null;

            }
            catch (Exception e)
            {
                throw new SenacMapAdoException("Um erro ocorreu ao atualizar os dados: " + e.Message, e);
            }
            finally
            {
                this.CloseConnection(sqlCon);
            }
        }

        public void UpdatePassword(MembroVo membroVo, String dscSenha)
        {
            SqlConnection sqlCon = null;

            try
            {
                sqlCon = GetConnection();
                SqlCommand sqlCmd = this.GetStoredProc(sqlCon, "spUpMembroSenha");
                this.AddParameter(sqlCmd, "@id", membroVo.id);
                this.AddParameter(sqlCmd, "@dscSenha", dscSenha);

                sqlCmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new SenacMapAdoException("Um erro ocorreu ao atualizar os dados: " + e.Message, e);
            }
            finally
            {
                this.CloseConnection(sqlCon);
            }
        }

        protected override void AddParametersForInsert(SqlCommand sqlCmd, BaseVo vo)
        {
            MembroVo membroVo = (MembroVo)vo;

            this.AddParameter(sqlCmd, "@dscNome", membroVo.dscNome);
            this.AddParameter(sqlCmd, "@dscEmail", membroVo.dscEmail);
            this.AddParameter(sqlCmd, "@dscMatricula", membroVo.dscMatricula);
            this.AddParameter(sqlCmd, "@indStatus", membroVo.indStatus);
            this.AddParameter(sqlCmd, "@indTipo", membroVo.indTipo);
            this.AddParameter(sqlCmd, "@datCriacao", membroVo.datCriacao);
            this.AddParameter(sqlCmd, "@datInativo", membroVo.datInativo);
            this.AddParameter(sqlCmd, "@datNascimento", membroVo.datNascimento);
        }

        protected override void AddParametersForUpdate(SqlCommand sqlCmd, BaseVo vo)
        {
            this.AddParameter(sqlCmd, "@id", ((MembroVo)vo).id);
            this.AddParametersForInsert(sqlCmd, vo);
        }

        protected override void AddParametersByCriteria(SqlCommand sqlCmd, BaseVo vo)
        {
            MembroVo membroVo = (MembroVo)vo;
            if (!"".Equals(membroVo.dscNome))
                this.AddParameter(sqlCmd, "@dscNome", membroVo.dscNome);
        }

        protected override void AddParametersByPk(SqlCommand sqlCmd, BaseVo vo)
        {
            this.AddParameter(sqlCmd, "@id", ((MembroVo) vo).id);
        }


        protected override BaseVo PopulateVo(SqlDataReader dr)
        {
            MembroVo membroVo = new MembroVo();


            membroVo.id = ReadInt(dr["id"]);
            membroVo.dscNome = dr["dscNome"].ToString();
            membroVo.dscEmail = dr["dscEmail"].ToString();
            membroVo.dscMatricula = dr["dscMatricula"].ToString();
            membroVo.indStatus = dr["indStatus"].ToString();
            membroVo.indTipo = dr["indTipo"].ToString();
            membroVo.datCriacao = dr["datCriacao"].ToString();
            membroVo.datSenha = dr["datSenha"].ToString();
            membroVo.datInativo = dr["datInativo"].ToString();
            membroVo.datNascimento = dr["datNascimento"].ToString();

            return membroVo;
        }

        protected override string GetSqlInsert(BaseVo vo)
        {
            return "spInMembro";
        }

        protected override string GetSqlUpdate(BaseVo vo)
        {
            return "spUpMembro";
        }

        protected override string GetSqlDelete(BaseVo vo)
        {
            return "spDeMembro";
        }

        protected override string GetSqlSelectByPrimaryKey(BaseVo vo)
        {
            return "spSeMembro";
        }

        protected override string GetSqlSelectByCriteria(BaseVo vo)
        {
            return "spSeAllMembro";
        }

    }
}
