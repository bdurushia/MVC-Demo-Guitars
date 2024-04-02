namespace MVC_Demo_Guitars.Models.Data
{
    public interface IGuitarsRepository
    {
        public IEnumerable<Guitars> GetAllGuitars();
        public Guitars GetGuitar(int id);
        public void UpdateGuitars(Guitars guitar);
        public void InsertGuitars(Guitars guitarToinsert);
    }
}
