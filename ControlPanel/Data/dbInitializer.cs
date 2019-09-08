using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControlPanel.Models;

namespace ControlPanel.Data
{
    public class dbInitializer
    {
        public static void Initialize(ControlPanelContext context)
        {
            context.Database.EnsureCreated();
            //Busqueda de registro en la tabla Juegos
            if (context.Juego.Any())
            {
                return;
            }
            //si aun no se ha cargado ningu registro 
            //genera la carga inicial en la db
            var listaJuego = new Juego[] {
                new Juego { Nombre = "MemoTest", Categoria = "Ejercitacion", Descripcion = "Ejercitacion de la memoria a corto plazo", Estado = true },
                new Juego { Nombre = "Virtualidad Real", Categoria = "Ejercitacion", Descripcion = "Ejercitacion de la memoria a largo plazo", Estado = true }
            };

            foreach (var j in listaJuego)
            {
                context.Juego.Add(j);
            }
            context.SaveChanges();
        }

    }
}
