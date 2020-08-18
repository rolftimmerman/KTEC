using System.Collections.Generic;

namespace KTEC.Core.Domain.Interfaces
{
    public interface ICameraRepository
    {
        Camera FindBy(int number);
        IEnumerable<Camera> GetAll();
        IEnumerable<Camera> FindByPartOfName(string partOfName);
    }
}
