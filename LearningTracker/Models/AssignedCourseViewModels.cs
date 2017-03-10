using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LearningTracker.Models
{
    public class AssignedCourseViewModels
    {
        public int? Id { get; set; }
        public DateTime? AssignmentDate { get; set; }
        public bool? IsCompleted { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? FinishDate { get; set; }
        public Decimal? TotalHours { get; set; }
        public CourseViewModel Course { get; set; }
        public IndividualViewModel Individual { get; set; }
    }

    public class NewAssignedCourseViewModels
    {
        [Required]
        [DisplayName("Fecha de asignación")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? AssignmentDate { get; set; }
        public SelectList IndividualList { get; set; }
        public SelectList CoursesList { get; set; }
        [DisplayName("Persona")]
        [Required]
        public int? IndividualId { get; set; }
        [DisplayName("Curso")]
        [Required]
        public int? CourseId { get; set; }
    }

    public class EditAssignedCourseViewModels
    {
        public int? Id { get; set; }
        public DateTime? AssignmentDate { get; set; }
        [DisplayName("Completado")]
        public bool IsCompleted { get; set; }
        [DisplayName("Inicio")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? StartDate { get; set; }
        [DisplayName("Fin")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? FinishDate { get; set; }
        [DisplayName("Horas totales")]
        public decimal? TotalHours { get; set; }

        //relaciones no editables
        public int? CourseId { get; set; }
        public CourseViewModel Course { get; set; }
        public int? IndividualId { get; set; }
        public IndividualViewModel Individual { get; set; }
    }
}