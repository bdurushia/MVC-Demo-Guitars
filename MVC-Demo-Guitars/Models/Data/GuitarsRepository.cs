
using Dapper;
using System.Data;

namespace MVC_Demo_Guitars.Models.Data
{
    public class GuitarsRepository : IGuitarsRepository
    {
        private readonly IDbConnection _conn;
        public GuitarsRepository(IDbConnection conn) 
        {
            _conn = conn;
        }
        public IEnumerable<Guitars> GetAllGuitars()
        {
            return _conn.Query<Guitars>("SELECT * FROM guitars;");
        }

        public Guitars GetGuitar(int id)
        {
            return _conn.QuerySingle<Guitars>("SELECT * FROM guitars WHERE id = @id", new { id = id });
        }


        public void UpdateGuitars(Guitars guitar)
        {
            _conn.Execute("UPDATE guitars SET Brand = @brand, Model = @model, Price = @price, IsNew = @isNew WHERE id = @id", 
                new { brand = guitar.Brand, model = guitar.Model, price = guitar.Price, isNew = guitar.IsNew, id = guitar.Id });
        }
        public void InsertGuitars(Guitars guitarToInsert)
        {
            _conn.Execute("INSERT INTO guitars (Brand, Model, Color, Price, Year, IsNew) VALUES (@brand, @model, @color, @price, @year, @isNew);", 
                new { brand = guitarToInsert.Brand, model = guitarToInsert.Model, color = guitarToInsert.Color, price = guitarToInsert.Price, year = guitarToInsert.Year, isNew = guitarToInsert.IsNew });
        }
    }
}
