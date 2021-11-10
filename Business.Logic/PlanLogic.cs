using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
    public class PlanLogic : BusinessLogic
    {
        private Data.Database.PlanAdapter _PlanData;
        public PlanLogic()
        {
            PlanData = new PlanAdapter();
        }

        public Data.Database.PlanAdapter PlanData
        {
            get { return _PlanData; }
            set { _PlanData = value; }
        }

        public List<Plan> GetAll()
        {
            List<Plan> planes = new List<Plan>();
            try
            {
                planes = PlanData.GetAll();
            }
            catch (Exception)
            {
                throw;
            }
            return planes;
        }
        public Business.Entities.Plan GetOne(int _id)
        {
            Plan pl = new Plan();
            try
            {
                pl = PlanData.GetOne(_id);
            }
            catch (Exception)
            {
                throw;
            }
            return pl;
        }
        public void Save(Business.Entities.Plan _plan)
        {
            try
            {
                PlanData.Save(_plan);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void Delete(int _id)
        {
            try
            {
                PlanData.Delete(_id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static string DescripcionPlan(int id)
        {
            PlanLogic pl = new PlanLogic();
            Plan pla = pl.GetOne(id);            
            return pla.Descripcion;
        }

        public static int EspecialidadPlan(int id)
        {
            PlanLogic pl = new PlanLogic();
            Plan pla = pl.GetOne(id);
            return pla.IDEspecialidad;
        }
    }
}