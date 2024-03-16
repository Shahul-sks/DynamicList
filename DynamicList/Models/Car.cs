using System.ComponentModel.DataAnnotations;

namespace DynamicList.Models
{
    public class Car
    {
        [Key]
        public int carno { get; set; }
        public string carname { get; set; }
        public int caryear { get; set; }
        public byte[] carpic { get; set; }

    }
}
