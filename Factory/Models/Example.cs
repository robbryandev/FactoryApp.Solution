using System.ComponentModel.DataAnnotations;

namespace Factory.Models {
    public class Example {
        [Key]
        public int example_id {get; set;}
        public string name {get; set;}
    }
}