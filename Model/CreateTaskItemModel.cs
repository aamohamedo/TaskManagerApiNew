using System.ComponentModel.DataAnnotations;

namespace TaskManager.Model
{
    public class CreateTaskItemModel
    {
        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        [Required]
        public string Status { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime? DueDate { get; set; }
    }
}
