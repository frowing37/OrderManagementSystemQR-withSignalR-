using System;
using SignalR_Business.Abstract;
using SignalR_DataAccess.Abstract;
using SignalR_Entities.Concrete;

namespace SignalR_Business.Concrete
{
    public class FeatureManager : IFeatureService
    {
        protected readonly IFeatureDAL _featureDAL;

        public FeatureManager(IFeatureDAL featureDAL)
        {
            _featureDAL = featureDAL;
        }

        public void AddwS(Feature t)
        {
            _featureDAL.Insert(t);
        }

        public void DeletewS(Feature t)
        {
            _featureDAL.Delete(t);
        }

        public Feature GetByIDwS(int ID)
        {
            return _featureDAL.GetByID(ID);
        }

        public List<Feature> GetListAllwS()
        {
            return _featureDAL.GetListAll();
        }

        public void UpdatewS(Feature t)
        {
            _featureDAL.Update(t);
        }
    }
}

