using Asa.ApartmentManagement.Core.Common;
using System.ComponentModel.DataAnnotations;

namespace Asa.ApartmentSystem.API.Areas.BaseInfo.Models.Requests
{
    public class AddExpenseCategoryRequest
    {
        [Required]
        public string ExpensCategoryName { get; set; }
        [Required]
        public int? FormulaType { get; set; }
    }
}