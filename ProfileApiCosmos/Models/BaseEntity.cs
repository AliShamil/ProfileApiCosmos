﻿namespace ProfileApiCosmos.Models
{
    public class BaseEntity
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
    }
}
