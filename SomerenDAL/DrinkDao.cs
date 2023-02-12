using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using SomerenModel;

namespace SomerenDAL
{
    public class DrinkDao : BaseDao
    {
        public List<Drink> GetAllDrinks()
        {
            string query = "SELECT drinkId, drinkName , drinkType, drinkPrice,  drinkStock FROM [Drinks]";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }

        private List<Drink> ReadTables(DataTable dataTable)
        {
            List<Drink> drinks = new List<Drink>();

            foreach (DataRow dr in dataTable.Rows)
            {
                Drink drink = new Drink()
                {
                    Id = (int)dr["drinkId"],
                    Name = (string)dr["drinkName"],
                    Type = (bool)dr["drinkType"],
                    Price = (decimal)dr["drinkPrice"],
                    Stock = (int)dr["drinkStock"],
                };
                drinks.Add(drink);
            }
            return drinks;
        }

        public void Add(Drink drink)
        {
            string query = 
                "INSERT INTO [Drinks] (drinkName, drinkType, drinkPrice, drinkStock)" +
                "VALUES (@drinkName, @drinkType,  @drinkPrice, @drinkStock) SELECT SCOPE_IDENTITY()";

            SqlParameter[] sqlParameters =
            {
                new SqlParameter("@drinkName", drink.Name),
                new SqlParameter("@drinkType", drink.Type),
                new SqlParameter("@drinkPrice", drink.Price),
                new SqlParameter("@drinkStock", drink.Stock)
            };

            ExecuteEditQuery(query, sqlParameters);
        }

        public void Delete(Drink drink)
        {
            string query = "DELETE FROM Drinks WHERE drinkId = @drinkId";
            SqlParameter[] sqlParameters = { new SqlParameter("@drinkId", drink.Id) };

            ExecuteEditQuery(query, sqlParameters);
        }

        public void Update(Drink drink)     
        {
            string query = "UPDATE [Drinks] SET drinkName = @drinkName, drinkType = @drinkType," +
                "drinkPrice = @drinkPrice, drinkStock = @drinkStock WHERE drinkId = @drinkId";

            SqlParameter[] sqlParameters =
            {
                new SqlParameter("@drinkId", drink.Id),
                new SqlParameter("@drinkName", drink.Name),
                new SqlParameter("@drinkType", drink.Type),
                new SqlParameter("@drinkPrice", drink.Price),
                new SqlParameter("@drinkStock", drink.Stock)
            };

            ExecuteEditQuery(query, sqlParameters);
        }
    }
}

