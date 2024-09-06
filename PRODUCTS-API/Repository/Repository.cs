using PRODUCTS_API.Data;
using PRODUCTS_API.Models;
using System.Data;
using System.Xml.Linq;
namespace PRODUCTS_API.Repository
{
    public class Repository: IRepository
    {
        public IEnumerable<Products> GetById(int ProductId) {            
            List<Products> list = new List<Products>();
            Products oproducto = new Products();
            DataLayer? DL = new DataLayer();
            DataTable rAlum = DL.FNFillTableRep("SP_CONS_PRODUCTS", "@ProductId", ProductId.ToString());
            foreach (DataRow row in rAlum.Rows)
                list.Add(new Products
                {
                    ProductId = Convert.ToInt16(row["ProductId"].ToString()),
                    Name = (string)row["Names"],
                    StatusName = row["StatusName"].ToString(),
                    Stock = row["Stock"].ToString(),
                    Description = row["Description"].ToString(),
                    Price = row["Price"].ToString(),
                    Discount = row["Discount"].ToString(),
                    FinalPrice = row["FinalPrice"].ToString()
                });
            #pragma warning disable CS8600 // Se va a convertir un literal nulo o un posible valor nulo en un tipo que no acepta valores NULL                
            oproducto = list.FirstOrDefault();
            yield return oproducto;
        }
        public bool Insert(int ProductId, string Name, string StatusName, string Stock, string Description, string Price, string Discount, string FinalPrice)
        {
            DataLayer DL = new DataLayer();
            var oSave = DL.SPExeCmd("SP_INS_PRODUCTS", 1, "@ProductId|@Name|@StatusName |@Stock|@Description|@Price|@Discount|@FinalPrice",
            ProductId.ToString(), Name, StatusName, Stock, Description, Price, Discount, FinalPrice);
            return true;
        }
        public bool Update(int ProductId, string Name, string StatusName, string Stock, string Description, string Price, string Discount, string FinalPrice)
        {
            DataLayer DL = new DataLayer();
            var oSave = DL.SPExeCmd("SP_UPD_PRODUCTS", 1, "@ProductId|@Name|@StatusName |@Stock|@Description|@Price|@Discount|@FinalPrice",
            ProductId.ToString(), Name, StatusName, Stock, Description, Price, Discount, FinalPrice);
            return true;
        }
    }
}
