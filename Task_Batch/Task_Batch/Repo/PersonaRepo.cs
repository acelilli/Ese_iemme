﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_Batch.Models;

namespace Task_Batch.Repo
{
    internal class PersonaRepo : IRepoLettura<Persona>
    {
        private static PersonaRepo instance;
        public static PersonaRepo GetInstance()
        {
            if (instance == null)
                instance = new PersonaRepo();
            
            return instance;
        }
        private PersonaRepo() { }


        public List<Persona> GetAll()
            {
                List<Persona> elenco = new List<Persona>();
                using(var ctx = new TaskBatchContext())
                    elenco = ctx.Personas.ToList();

                return elenco;
            }
    }
}
