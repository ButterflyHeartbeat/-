using Inte_InpatientCare.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Inte_InpatientCare.ViewModels
{
    public class InPatCreatViewModel
    {
        public int ID { get; set; }
        [Required]
        [Display(Name = "姓名")]
        public string Name { get; set; }
        //[Required(ErrorMessage = "不可以爲空"), MinLength(0)]
        //[Display(Name = "性别")]
        //public SexEnum? Sex { get; set; }
        [Required(ErrorMessage = "不可謂空")]
        [Display(Name = "住院号")]
        /// <summary>
        /// 住院号
        /// </summary>
        public string InPatCard { get; set; }
        [Display(Name = "陪护人员")]
        /// <summary>
        /// 陪护人员
        /// </summary>
        public string Chaperone { get; set; }

        public IFormFile Photo { get; set; }
    }
}
