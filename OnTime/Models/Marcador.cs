using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnTime.Models
{
    public class Marcador
    {
        private string txtCI;
        [Required]
        [Display(Name = "User name")]
        public string TxtCI
        {
            get { return txtCI; }
            set { txtCI = value; }
        }
    }
}