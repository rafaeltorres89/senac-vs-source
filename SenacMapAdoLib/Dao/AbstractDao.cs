using br.senac.sp.mapaaula.ado.Vo;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace br.senac.sp.mapaaula.ado
{
    public abstract class AbstractDao
    {
        private String connectionString = null;
 
        public AbstractDao(String connectionString)
        {
            this.connectionString = connectionString;
            
        }

        protected SqlCommand GetStoredProc(SqlConnection sqlCon, String sql)
        {
            return this.GetCommand(sqlCon, sql, CommandType.StoredProcedure);
        }

        protected SqlCommand GetCommand(SqlConnection sqlCon, String sql, System.Data.CommandType cmdType)
        {
            SqlCommand sqlCmd = new SqlCommand(sql, sqlCon);
            sqlCmd.CommandType = cmdType;

            return sqlCmd;
        }

        protected SqlConnection GetConnection()
        {
            SqlConnection dataConnection = new SqlConnection();
            dataConnection.ConnectionString = this.connectionString;
            dataConnection.Open();

            return dataConnection;
        }

        protected void CloseConnection(SqlConnection conn)
        {
            try {
                if (conn != null) conn.Close();
            } catch (Exception) { }
        }

        public ArrayList FindAll()
        {
            return this.FindByCriteria(null);
        }

        public ArrayList FindByCriteria(BaseVo vo)
        {
            SqlConnection sqlCon = null;

            try {
                sqlCon = GetConnection();
                return this.SelectByCriteria(sqlCon, vo);
            } catch (Exception e) {
                throw new SenacMapAdoException("Um erro ocorreu na busca das informações: " + e.Message, e);
            } finally {
                this.CloseConnection(sqlCon);
            }
        }

        public BaseVo FindByPrimaryKey(BaseVo vo)
        {
            SqlConnection sqlCon = null;

            try
            {
                sqlCon = GetConnection();
                return this.LoadRow(sqlCon, vo);
            }
            catch (Exception e)
            {
                throw new SenacMapAdoException("Um erro ocorreu na busca das informações: " + e.Message, e);
            }
            finally
            {
                this.CloseConnection(sqlCon);
            }
        }

        public void Create(BaseVo vo)
        {
            SqlConnection sqlCon = null;

            try
            {
                sqlCon = GetConnection();
                this.InsertRow(sqlCon, vo);
            }
            catch (Exception e)
            {
                throw new SenacMapAdoException("Um erro ocorreu ao inserir os dados: " + e.Message, e);
            }
            finally
            {
                this.CloseConnection(sqlCon);
            }
        }

        public void Update(BaseVo vo)
        {
            SqlConnection sqlCon = null;

            try
            {
                sqlCon = GetConnection();
                this.UpdateRow(sqlCon, vo);
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

        public void Delete(BaseVo vo)
        {
            SqlConnection sqlCon = null;

            try
            {
                sqlCon = GetConnection();
                this.DeleteRow(sqlCon, vo);
            }
            catch (Exception e)
            {
                throw new SenacMapAdoException("Um erro ocorreu ao excluir os dados: " + e.Message, e);
            }
            finally
            {
                this.CloseConnection(sqlCon);
            }
        }

        protected void AddParameter(SqlCommand sqlCmd, String parameterName, Object value)
        {
            SqlParameter sqlP = new SqlParameter();
            sqlP.ParameterName = parameterName;
            sqlP.Value = value;
            sqlP.Direction = ParameterDirection.Input;

            sqlCmd.Parameters.Add(sqlP);
        }

        protected virtual void InsertRow(SqlConnection sqlCon, BaseVo vo)
        {
            SqlCommand sqlCmd = this.GetStoredProc(sqlCon, this.GetSqlInsert(vo));
            this.AddParametersForInsert(sqlCmd, vo);
            sqlCmd.ExecuteNonQuery();
        }

        protected virtual void UpdateRow(SqlConnection sqlCon, BaseVo vo)
        {
            SqlCommand sqlCmd = this.GetStoredProc(sqlCon, this.GetSqlUpdate(vo));
            this.AddParametersForUpdate(sqlCmd, vo);
            sqlCmd.ExecuteNonQuery();
        }

        protected virtual void DeleteRow(SqlConnection sqlCon, BaseVo vo)
        {
            SqlCommand sqlCmd = this.GetStoredProc(sqlCon, this.GetSqlDelete(vo));
            this.AddParametersByPk(sqlCmd, vo);

            sqlCmd.ExecuteNonQuery();
        }

        protected virtual BaseVo LoadRow(SqlConnection sqlCon, BaseVo vo)
        {
            SqlCommand sqlCmd = this.GetStoredProc(sqlCon, this.GetSqlSelectByPrimaryKey(vo));
            this.AddParametersByPk(sqlCmd, vo);

            SqlDataReader dr = sqlCmd.ExecuteReader();

            if (dr.Read())
                return this.PopulateVo(dr);
            else
                return null;

        }

        protected ArrayList SelectByCriteria(SqlConnection sqlCon, BaseVo vo)
        {
            SqlCommand sqlCmd = this.GetStoredProc(sqlCon, this.GetSqlSelectByCriteria(vo));
            if (vo != null)
            {
                this.AddParametersByCriteria(sqlCmd, vo);
            }

            SqlDataReader dr = sqlCmd.ExecuteReader();
            System.Collections.ArrayList results = new System.Collections.ArrayList();
            while (dr.Read())
            {
                results.Add(this.PopulateVo(dr));
            }

            return results;

        }


        protected abstract BaseVo PopulateVo(SqlDataReader dr);

        protected abstract void AddParametersForInsert(SqlCommand sqlCmd, BaseVo vo);

        protected abstract void AddParametersForUpdate(SqlCommand sqlCmd, BaseVo vo);
        
        protected abstract void AddParametersByCriteria(SqlCommand sqlCmd, BaseVo vo);

        protected abstract void AddParametersByPk(SqlCommand sqlCmd, BaseVo vo);

        protected abstract String GetSqlInsert(BaseVo vo);

        protected abstract String GetSqlUpdate(BaseVo vo);

        protected abstract String GetSqlDelete(BaseVo vo);

        protected abstract String GetSqlSelectByPrimaryKey(BaseVo vo);

        protected abstract String GetSqlSelectByCriteria(BaseVo vo);

        protected int ReadInt(object o)
        {
            if (o.ToString().Equals(String.Empty)) return 0;
            return Convert.ToInt32(o.ToString());
        }

        
    }
}
