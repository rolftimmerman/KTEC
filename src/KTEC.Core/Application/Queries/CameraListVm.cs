using System.Collections.Generic;

namespace KTEC.Core.Application.Queries
{
    public class CameraListVm
    {
        public IList<CameraDto> Cameras { get; set; }

        public int Count { get; set; }
    }
}
