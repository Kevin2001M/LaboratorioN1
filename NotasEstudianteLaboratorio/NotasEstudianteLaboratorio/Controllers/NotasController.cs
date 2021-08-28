using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NotasEstudianteLaboratorio.Models;

namespace NotasEstudianteLaboratorio.Controllers
{
    public class NotasController : Controller
    {
        // GET: Notas
        public ActionResult index()
        {
           
            return View();
        }

        public ActionResult Resultado()
        {
            using (NotasEstudianteEntities2 nota = new NotasEstudianteEntities2())
            {
                var listadoEstudiante = nota.TblEstudiante.ToList();

                return View(listadoEstudiante);
            }

        }

       

        [HttpPost]
        public ActionResult Estudiante(String nombre, String Lab1, String Lab2, String Lab3, String Par1, String Par2, String Par3)
        {
            using (NotasEstudianteEntities2 estu = new NotasEstudianteEntities2())
            {
                TblEstudiante estudiante = new TblEstudiante();
               
                    estudiante.Nombre = nombre;
                    estudiante.Lab1 = Lab1;
                    estudiante.Lab2 = Lab2;
                    estudiante.Lab3 = Lab3;
                    estudiante.Par1 = Par1;
                    estudiante.Par2 = Par2;
                    estudiante.Par3 = Par3;

                    estu.TblEstudiante.Add(estudiante);
                    estu.SaveChanges();
               
            }
            double Laboratorio1 = Convert.ToDouble(Lab1);
            double Laboratorio2 = Convert.ToDouble(Lab2);
            double Laboratorio3 = Convert.ToDouble(Lab3);
            double Parcial1 = Convert.ToDouble(Par1);
            double Parcial2 = Convert.ToDouble(Par2);
            double Parcial3 = Convert.ToDouble(Par3);

            Double prom1 = (((Laboratorio1 * 0.40) + (Parcial1 * 0.60)) / 3);
            Double prom2 = (((Laboratorio2 * 0.40) + (Parcial2 * 0.60)) / 3);
            Double prom3= (((Laboratorio3 * 0.40) + (Parcial3 * 0.60)) / 3);
            double ProFinal = (prom1) + (prom2) + (prom3);
            ViewBag.nombre = nombre;
            ViewBag.promedio1 = prom1;
            ViewBag.promedio2 = prom2;
            ViewBag.promedio3 = prom3;
            ViewBag.promFinal = ProFinal;
            return View();
        }


    }
}