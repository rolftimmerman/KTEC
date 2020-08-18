using System.Collections.Generic;
using System.Linq;
using KTEC.Core.Domain;
using KTEC.Core.Domain.Interfaces;
using KTEC.Core.Infrastructure;

namespace KTEC.Core.Persistence
{
    public class CameraRepository : ICameraRepository
    {
        public Camera FindBy(int number)
        {
            return CsvFileLoader.LoadFile().FirstOrDefault(n => n.Number == number);
        }

        public IEnumerable<Camera> FindByPartOfName(string partOfName)
        {
            return CsvFileLoader.LoadFile().Where(n => n.Name.Contains(partOfName));
        }

        public IEnumerable<Camera> GetAll()
        {
            return CsvFileLoader.LoadFile();
        }
    }
}
