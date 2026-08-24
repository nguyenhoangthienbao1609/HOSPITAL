using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace THUCTAP.ViewModels
{
    public class MenuCreateRequest
    {
        [Required(ErrorMessage = "Tên menu cha không được để trống")]
        public string parentMenuName { get; set; } = string.Empty;
        public List<string>?childMenuName { get; set; } = new List<string>();
    }
}