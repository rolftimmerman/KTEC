using KTEC.Core.Domain;

namespace KTEC.Core.Application.Queries
{
    public static class MapperExtensions
    {
        public static CameraDto CreateMap(this Camera camera)
        {
            return new CameraDto
            {
                Number = camera.Number,
                Name = camera.Name,
                Latitude = camera.Location.Latitude,
                Longitude = camera.Location.Longitude
            };
        }
    }
}
