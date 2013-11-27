using br.senac.sp.mapaaula.ado;
using br.senac.sp.mapaaula.ado.Vo;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SenacMapTest
{
    class Program
    {
        static void Main(string[] args)
        {


            SalaDao salaDao = new SalaDao("Server=(local);DataBase=MapaAulaSenac;User ID=UsrMapaSenacAula;Pwd=PwdMapaSenacAula");

            ArrayList ret = salaDao.FindAll();
            foreach (SalaVo vo in ret)
            {
                Console.WriteLine(vo.codSala + " - Predio " + vo.numPredio);
            }

            SalaVo salaVo = (SalaVo) salaDao.FindByPrimaryKey(new SalaVo("B230"));

            Console.WriteLine(salaVo.codSala);


            Console.WriteLine("===========");

            DisciplinaDao discDao = new DisciplinaDao("Server=(local);DataBase=MapaAulaSenac;User ID=UsrMapaSenacAula;Pwd=PwdMapaSenacAula");
            ArrayList discs = discDao.FindAll();

            foreach (DisciplinaVo discVo in discs)
            {
                Console.WriteLine(discVo.dscDisciplina);

            }


            /*
            Console.WriteLine("" );
            
            Hashtable pkdata = tipoSalaDao.FindByPrimaryKey("id", "10");
            Console.WriteLine(pkdata["id"].ToString() + ";" + pkdata["dscTipoSala"] + ";" + pkdata["datInativo"]);


            tipoSalaDao.Delete(pkdata);
             * 
             * */

        }
    }
}
