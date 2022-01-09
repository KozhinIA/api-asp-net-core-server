using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ApiAspNetCoreServer.DataModel.Entities
{
    public class BookDto
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
                
        /// <summary>
        /// ISBN
        /// </summary>  
        [Required]
        public string Isbn { get; set; }

        /// <summary>
        /// Год издания книги
        /// </summary>  
        public int Year { get; set; }

        /// <summary>
        /// Стоимость
        /// </summary>  
        public decimal Cost { get; set; }

        /// <summary>
        /// Тип валюты
        /// </summary> 
        public string CurrencyType { get; set; }
               
        /// <summary>
        /// Дата создания записи
        /// </summary> 
        public DateTime? CreateAt { get; set; }

        /// <summary>
        /// Жанр
        /// </summary> 
        public string Genre { get; set; }
                                    
        /// <summary>
        /// Архивная запись
        /// </summary>  
        public bool IsArchive { get; set; }

        /// <summary>
        /// Описание
        /// </summary>    
        [Required]
        public string Annotation { get; set; }

        /// <summary>
        /// Авторы
        /// </summary> 
        public List<AuthorDto> Authors { get; set; }

        /// <summary>
        /// Языки
        /// </summary> 
        public List<LanguageDto> Languages { get; set; }      

        
    }
}