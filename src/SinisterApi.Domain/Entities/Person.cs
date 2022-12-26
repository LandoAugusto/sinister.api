﻿using SinisterApi.Domain.Entities.Interfaces;

namespace SinisterApi.Domain.Entities
{
    public class Person : IIdentityEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int DocumentType { get; set; }
        public string Document { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public PersonEmail PersonEmail { get; set; }
        public PersonPhone PersonPhone { get; set; }
        public PersonAddress PersonAddress { get; set; }
        public List<Communicant> Communicant { get; set; }
    }
}
