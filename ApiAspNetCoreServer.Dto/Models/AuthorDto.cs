using ApiAspNetCoreServer.DataModel.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ApiAspNetCoreServer.DataModel.Entities
{
    public class AuthorDto
    {

        /// <summary>
        /// Id
        /// </summary>    
        public int? Id { get; set; }

        /// <summary>
        /// Имя
        /// </summary>    
        [Required]
        public string FirstName { get; set; }

        /// <summary>
        /// Фамилия
        /// </summary>    
        [Required]
        public string LastName { get; set; }

        /// <summary>
        /// День рождения
        /// </summary> 
        public DateTime? Birthday { get; set; }

        /// <summary>
        /// Пол
        /// </summary> 
        public Gender Gender { get; set; }


    }
}