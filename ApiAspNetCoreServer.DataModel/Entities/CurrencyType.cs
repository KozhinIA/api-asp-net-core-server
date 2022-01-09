using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ApiAspNetCoreServer.DataModel.Entities
{
    public class CurrencyType
    {
        /// <summary>
        /// Id
        /// </summary> 
        public int Id { get; set; }

        /// <summary>
        /// Название
        /// </summary>    
        [Required]
        public string Name { get; set; }

        [Required]
        public string LetterCode { get; set; }

        [Required]
        public string NumericCode { get; set; }


        /// <summary>
        /// Список книг
        /// </summary> 
        public virtual ICollection<Book> Books { get; set; }
    }
}