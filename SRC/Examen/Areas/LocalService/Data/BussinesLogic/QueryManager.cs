namespace Examen.Areas.LocalService.Data.BussinesLogic
{
    using Examen.Models.Datas;
    using Examen.Models.Entities;
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;

    public class QueryManager : Connection
    {
        private string messageError = String.Empty;

        public string MessageError
        {
            get { return this.messageError; }
        }

        public QueryManager()
        {

        }

        #region Users

        public User Login(string email, string password)
        {
            try
            {
                User user = new User();
                string newQuery = "SELECT Name,LastName,MiddleName FROM USERS WHERE email =\'" + email + "\' AND password=\'" + password + "\'";
                SqlDataReader result = ObtainedResult(newQuery, this.ConnectionString);
                if (result != null)
                {
                    while (result.Read())
                    {
                        user.Id = result["Id"] == DBNull.Value ? new Guid() : new Guid(result["Name"].ToString());
                        user.Name = result["Name"] == DBNull.Value ? string.Empty : result["Name"].ToString();
                        user.LastName = result["LastName"] == DBNull.Value ? string.Empty : result["LastName"].ToString();
                        user.MiddleName = result["MiddleName"] == DBNull.Value ? string.Empty : result["MiddleName"].ToString();
                        user.Date = DateTime.Now.ToString("yyyy-MM-dd");
                    }
                    result.Close();
                }
                this.CloseConection();
                return user;
            }
            catch (Exception ex)
            {
                messageError = ex.Message;
                return null;
            }
        }

        #endregion

        #region Products

        public List<Products> GetProducts()
        {
            try
            {
                List<Products> listProducts = new List<Products>();
                string newQuery = "SELECT Id,Description,Price,Existence FROM Products";
                SqlDataReader result = ObtainedResult(newQuery, this.ConnectionString);
                if (result != null)
                {
                    while (result.Read())
                    {
                        Products newProduct = new Products();
                        object[] objects = new object[result.FieldCount];
                        result.GetValues(objects);
                        newProduct.Id = result["Id"] == DBNull.Value ? 0 : Convert.ToInt32(result["Id"].ToString());
                        newProduct.Description = result["Description"] == DBNull.Value ? string.Empty : result["Description"].ToString();
                        newProduct.Price = result["Price"] == DBNull.Value ? 0.0d : Convert.ToDouble(result["Price"].ToString());
                        newProduct.Existence = result["Existence"] == DBNull.Value ? 0 : Convert.ToInt32(result["Existence"].ToString());
                        listProducts.Add(newProduct);
                    }
                    result.Close();
                }
                this.CloseConection();
                listProducts.Add(new Products
                {
                    Id = 1,
                    Description = "Prueba",
                    Existence = 5,
                    Price = 32
                });
                return listProducts;
            }
            catch (Exception ex)
            {
                messageError = ex.Message;
                return null;
            }
        }

        #endregion
    }
}