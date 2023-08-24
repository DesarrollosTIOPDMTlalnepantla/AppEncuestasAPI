using AutoMapper;
using AppEncuestasAPI.Data;
using AppEncuestasAPI.Models.Encuestas;
using AppEncuestasAPI.Models.EmpleadosEncuesta;
using AppEncuestasAPI.Models.Empleados;


namespace AppEncuestasAPI.Configurations
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<EncuestaCrearDTO, Encuesta>().ReverseMap();         
            CreateMap<EncuestaReadOnlyDTO, Encuesta>().ReverseMap();
            CreateMap<EmpleadoEncuestaCrearDTO, EmpleadoEncuesta>().ReverseMap();
            CreateMap<EmpleadoEncuestaActualizarDTO, EmpleadoEncuesta>().ReverseMap();
            CreateMap<EmpleadoEncuestaReadOnlyDTO, EmpleadoEncuesta>().ReverseMap();
            CreateMap<EmpleadoReadOnlyDTO, Empleado>().ReverseMap();
        }
    }
}