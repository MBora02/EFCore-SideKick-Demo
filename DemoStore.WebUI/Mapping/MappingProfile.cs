using AutoMapper;

namespace DemoStore.WebUI.Mapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Employee, ResultEmployeeDTO>();
            CreateMap<ResultEmployeeDTO, Employee>();

            CreateMap<Employee, ResultEmployeeDTO>().ReverseMap();
        }
    }
}
