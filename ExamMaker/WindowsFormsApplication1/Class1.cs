using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public class TestObj
    {
        public List<string> ListaPytan = new List<string>();
        public List<List<string>> ListaOdpowiedzi = new List<List<string>>();
        public List<List<bool>> ListaPoprawnych = new List<List<bool>>();
        public List<bool> JednaOdpowiedz = new List<bool>();
        public List<bool> Obraz = new List<bool>();
        public List<string> PathList = new List<string>();
        public bool isQuestionMixed = false;
        public TestObj()
        {

        }
        public TestObj(List<string> listapytan, List<List<string>> listaodpowiedzi, List<List<bool>> listapoprawnych, List<bool> jednaodpowiedz, List<bool> obraz, List<string> path,bool mixed)
        {
            ListaPytan = listapytan;
            ListaOdpowiedzi = listaodpowiedzi;
            ListaPoprawnych = listapoprawnych;
            JednaOdpowiedz = jednaodpowiedz;
            Obraz = obraz;
            PathList = path;
            isQuestionMixed = mixed;
        }
    }
}
