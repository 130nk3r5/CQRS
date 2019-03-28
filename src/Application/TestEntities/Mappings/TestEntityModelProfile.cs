using Application.TestEntities.Models;
using AutoMapper;
using Domain.Entities;

namespace Application.TestEntities.Mappings
{
    public class TestEntityModelProfile : Profile
    {
        public TestEntityModelProfile()
        {
            CreateMap<TestEntity, TestEntityModel>().ReverseMap();
        }
    }
}
