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
            throw new NotImplementedException();
        }

        public void DeletewS(Feature t)
        {
            throw new NotImplementedException();
        }

        public Feature GetByIDwS(int ID)
        {
            throw new NotImplementedException();
        }

        public List<Feature> GetListAllwS()
        {
            throw new NotImplementedException();
        }

        public void UpdatewS(Feature t)
        {
            throw new NotImplementedException();
        }
    }
}

