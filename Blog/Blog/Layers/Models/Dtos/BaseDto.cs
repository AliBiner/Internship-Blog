using System;

namespace Blog.Layers.Models.Dtos
{
    public class BaseDto
    {
        
        public Guid Id { get; set; }
        public DateTime CreateDate { get; set; }
    }
}