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
            return PlanData.GetAll();
        }
        public Business.Entities.Plan GetOne(int _id)
        {
            return PlanData.GetOne(_id);
        }
        public void Save(Business.Entities.Plan _plan)
        {
            PlanData.Save(_plan);
        }
        public void Delete(int _id)
        {
            PlanData.Delete(_id);
        }
    }
}