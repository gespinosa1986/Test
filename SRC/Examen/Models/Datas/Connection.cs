using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Web;

namespace Examen.Models.Datas
{
    public class Connection
    {
        #region Members Privates

        private string mensaje = string.Empty;

        private SqlConnection conectionSql;

        private readonly string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        #endregion

        #region Public Methods

        public void CloseConection()
        {
            if (this.conectionSql != null && this.conectionSql.State == ConnectionState.Open)
            {
                this.conectionSql.Close();
            }
        }

        public SqlDataReader ObtainedResult(string consult, string connectingChain)
        {
            return this.GetResult(consult, connectingChain);
        }

        public int ObtainedCommand(string consult, string connectingChain)
        {
            return this.GetCommand(consult, connectingChain);
        }

        public bool TestConnection(string connectionChain)
        {
            return this.TestConectionSql(connectionChain);
        }

        #endregion

        #region Private Methods

        private SqlDataReader GetResult(string consult, string connectionChain)
        {
            this.conectionSql = new SqlConnection();
            SqlDataReader reader = null;
            int count = 0;
            try
            {
            OfNew:

                this.conectionSql.ConnectionString = connectionChain;
                SqlCommand command = new SqlCommand();
                command.CommandText = consult;
                command.CommandType = CommandType.Text;
                command.Connection = this.conectionSql;
                if (conectionSql.State == ConnectionState.Open)
                {
                    Thread.Sleep(10);
                    count++;
                    if (count < 10)
                    {
                        goto OfNew;
                    }
                }
                this.conectionSql.Open();
                reader = command.ExecuteReader();
            }
            catch (Exception ex)
            {
                this.mensaje = ex.ToString();
            }

            return reader;
        }

        private int GetCommand(string consult, string connectionChain)
        {
            this.conectionSql = new SqlConnection();
            SqlCommand command = new SqlCommand();
            try
            {
                this.conectionSql.ConnectionString = connectionChain;
                command.CommandText = consult;
                command.Connection = this.conectionSql;
                this.conectionSql.Open();
                return command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                this.mensaje = ex.ToString();
                return -1;
            }
        }

        private bool TestConectionSql(string connectionChain)
        {
            this.conectionSql = new SqlConnection();
            try
            {
                this.conectionSql.ConnectionString = connectionChain;
                this.conectionSql.Open();
                return this.conectionSql.State == ConnectionState.Open ? true : false;
            }
            catch (Exception ex)
            {
                this.mensaje = ex.ToString();
                return false;
            }
        }

        #endregion

        #region Members Publics

        public string Mensaje
        {
            get { return this.mensaje; }
            set { this.mensaje = value; }
        }

        public string ConnectionString
        {
            get { return this.connectionString; }
        }

        #endregion
    }
}