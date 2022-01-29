namespace BlazeAstro.Infrastructure.Mapping
{
    using AutoMapper;

    public interface ICustomMapping
    {
        void CreateMappings(Profile mapper);
    }
}