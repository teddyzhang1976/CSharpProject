using System;
using System.Linq;
using System.Data.Services;

namespace Wrox.ProCSharp.DataServices
{
    public class MenuCardDataModel : IUpdatable
    {
        public IQueryable<Menu> Menus
        {
            get
            {
                return MenuCard.Instance.Menus.AsQueryable();
            }
        }

        public IQueryable<Category> Categories
        {
            get
            {
                return MenuCard.Instance.Categories.AsQueryable();
            }
        }



        #region IUpdatable Members

        public void AddReferenceToCollection(object targetResource, string propertyName, object resourceToBeAdded)
        {
            throw new NotImplementedException();
        }

        public void ClearChanges()
        {
            throw new NotImplementedException();
        }

        public object CreateResource(string containerName, string fullTypeName)
        {
            Type t = Type.GetType(fullTypeName);
            return Activator.CreateInstance(t);
        }

        public void DeleteResource(object targetResource)
        {
            throw new NotImplementedException();
        }

        public object GetResource(IQueryable query, string fullTypeName)
        {
            return null;
        }

        public object GetValue(object targetResource, string propertyName)
        {
            throw new NotImplementedException();
        }

        public void RemoveReferenceFromCollection(object targetResource, string propertyName, object resourceToBeRemoved)
        {
            throw new NotImplementedException();
        }

        public object ResetResource(object resource)
        {
            throw new NotImplementedException();
        }

        public object ResolveResource(object resource)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void SetReference(object targetResource, string propertyName, object propertyValue)
        {
            throw new NotImplementedException();
        }

        public void SetValue(object targetResource, string propertyName, object propertyValue)
        {


        }

        #endregion
    }
}
