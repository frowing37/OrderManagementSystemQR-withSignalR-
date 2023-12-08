using System;
namespace SignalR_Business.Abstract
{
	public interface IGenericService<T> where T : class
	{
		void AddwS(T t);

		void UpdatewS(T t);

		void DeletewS(T t);

		T GetByIDwS(int ID);

		List<T> GetListAllwS();
	}
}

