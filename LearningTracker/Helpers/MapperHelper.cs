using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LTraker.Data.Entities;
using LearningTracker.Models;
using AutoMapper;

namespace LearningTracker.Helpers
{
    public class MapperHelper
    {
        internal static IMapper mapper;

        static MapperHelper()
        {
            var config = new MapperConfiguration(x =>
            {
                x.CreateMap<Individual, IndividualViewModel>().ReverseMap();
                x.CreateMap<Course, CourseViewModel>().ReverseMap();
                x.CreateMap<Topic, TopicCourseViewModel>().ReverseMap();
                x.CreateMap<Topic, TopicViewModel>().ReverseMap();
                x.CreateMap<Course, DetailsTopicCourseViewModel>().ReverseMap();
                x.CreateMap<NewAssignedCourseViewModels, AssignedCourse>();
                x.CreateMap<AssignedCourse, AssignedCourseViewModels>().ReverseMap();
                x.CreateMap<EditAssignedCourseViewModels, AssignedCourse>().ReverseMap();
                x.CreateMap<Planeacion, PlaneacionViewModels>().ReverseMap();
            }
            );
            mapper = config.CreateMapper();
        }

        public static T Map<T>(object source)
        {
            return mapper.Map<T>(source);
        }
    }
}