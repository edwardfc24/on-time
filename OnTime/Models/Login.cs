using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnTime.Models
{
    public class Login
    {
        
        private string txtNombre;
        [Required]
        [Display(Name = "User name")]
        public string TxtNombre
        {
            get { return txtNombre; }
            set { txtNombre = value; }
        }
       
        private string txtPassword;
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string TxtPassword
        {
            get { return txtPassword; }
            set { txtPassword = value; }
        }

        private int intTipo;

        public int IntTipo
        {
            get { return intTipo; }
            set { intTipo = value; }
        }
        
 

        /// <summary>
        /// Checks if user with given password exists in the database
        /// </summary>
        /// <param name="_username">User name</param>
        /// <param name="_password">User password</param>
        /// <returns>True if user exist and password is correct</returns>
        
    }
}