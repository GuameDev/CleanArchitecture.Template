﻿namespace CleanArchitecture.Template.Domain.Entities
{
    public class BaseEntity<Tkey>
    {
        public Tkey Id { get; set; }
    }
}
