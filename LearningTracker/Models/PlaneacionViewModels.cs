using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LearningTracker.Models
{
    public class PlaneacionViewModels
    {
        public int? IdPlaneacion { get; set; }
        public int? Id { get; set; }
        [DisplayName("Inicio")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? DateEstimatedInicio { get; set; }
        [DisplayName("Fin")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? DateEstimatedFin { get; set; }
        [DisplayName("Duracion")]
        public Decimal? DurationEstimated { get; set; }
        public int? AssignedCourseId { get; set; }
        public AssignedCourseViewModels AssignedCourse { get; set; }

    }
}