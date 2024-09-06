using PRODUCTS_API.Models;
using System.IO;
using System.Text;
namespace PRODUCTS_API.Tools
{
    public class FileManager : IFileManager
    {
        public bool Writelog(DateTime TimeOne, DateTime TimeTwo, string  sModulo) {
            string sComent = "";
            string sPath = cServer._hostingEnvironment.ContentRootPath + "\\LOG\\LOG.txt";
            StreamWriter sw = new StreamWriter(sPath, true, Encoding.ASCII);
            var timeResul = TimeTwo - TimeOne;
            sComent = "Tiempo Inicial = " + TimeOne.ToString() + " -- Tiempo Final = " + TimeTwo.ToString() + " -- Tiempo Total = " + timeResul.ToString() + " -- Metodo = " + sModulo;
            sw.WriteLine(sComent);
            sw.Close();
            sw.Dispose(); sw = null;
            return true;
        }
    }
}
