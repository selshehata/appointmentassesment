﻿using System.ComponentModel.DataAnnotations;

namespace Core.Domain.Entities
{
    public abstract class EntityBase
    {
        [Key]
        public int Id { get; set; }

    }
}
