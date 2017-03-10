using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LearningTracker.Models
{
    public class CourseViewModel
    {
        public int? Id { get; set; }
        [Required]
        [MaxLength(200)]
        [DisplayName("Nombre")]
        public string Name { get; set; }
        
        [DisplayName("Hora Promedio")]
        public decimal DurationAVG { get; set; }

        [MaxLength(500)]
        [DisplayName("Descripción")]
        public string Description { get; set; }

        public ICollection<TopicCourseViewModel> AvailableTopics { get; set; }

        public int[] SelectTopics { get; set; }
    }

    public class DetailsTopicCourseViewModel
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public decimal DurationAVG { get; set; }
        public string Description { get; set; }
        public ICollection<TopicViewModel> Topics { get; set; }
    }

    public class TopicCourseViewModel
    {
        public int? Id { get; set; }
        public string Name { get; set; }
    }

}