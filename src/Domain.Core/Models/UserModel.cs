﻿namespace Domain.Core.Models
{
    public class UserModel
    {
        public UserModel(int? id, string? name)
        {
            Id = id;
            Name = name;
        }
        public int? Id { get; set; }
        public string? Name { get; set; }
    }
}
