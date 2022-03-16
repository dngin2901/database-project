using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace UI
{
    class Cars
    {
        // function to add a column to the database
        public int AddCar(int id, string make, string model, int mileage)
        {
            string query = string.Format("INSERT INTO CARS(CarID, make, model, mileage) " +
            "VALUES('{0}','{1}','{2}','{3}')",id, make, model, mileage);
            return DataAccess.ExecuteNonQuery(query);
        }

        // function to update database
        public int Update(int id, string make, string model, int mileage)
        {
            string query = string.Format("UPDATE CARS SET make = '{0}'," +
            "model = '{1}'," + "mileage = '{2}'" + " WHERE CarID = {3}", make, model, mileage,id);
            return DataAccess.ExecuteNonQuery(query);
        }

        // function to select from entire database in database
        public DataTable getAllCars()
        {
            string query = "SELECT * FROM cars";
            return DataAccess.ExecuteQuery(query);
        }

        // select car from database by model
        public DataTable getCarByModel(string model)
        {
            string query = string.Format("SELECT * FROM cars WHERE model = '{0}'", model);
            return DataAccess.ExecuteQuery(query);
        }

        // select car from database by car id
        public DataTable getCarId(int id)
        {
            string query = string.Format("SELECT * FROM cars WHERE CarID = '{0}'",+ id);
            return DataAccess.ExecuteQuery(query);
        }

        //select car from database by make
        public DataTable getCarByMake(string make)
        {
            string query = string.Format("SELECT * FROM cars WHERE make = '{0}'", make);
            return DataAccess.ExecuteQuery(query);
        }

        // delete from the database by car id
        public int Delete(int id)
        {
            string query = "DELETE FROM cars WHERE CarID ="+ id;
            return DataAccess.ExecuteNonQuery(query);
        }
    }
}
