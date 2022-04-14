﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Provider
    {
        public int Id { get; set; }
        public string Name { get; private set; }
        public string Address { get; private set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; private set; }
        public string City { get; private set; }

        public Provider(int id, string name, string emailAddress)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException("El nombre no puede ser vacio.");

            if (string.IsNullOrEmpty(emailAddress))
                throw new ArgumentNullException("El correo no puede ser vacio.");


            try
            {
                var email = new System.Net.Mail.MailAddress(emailAddress);
                EmailAddress = email.Address;
            }
            catch(FormatException )
            {
                throw new ArgumentNullException("El correo no es valido");
            }

            Id = id;
            Name = name;
        }
        public void AddAddress(string address, string city)
        {
            if (string.IsNullOrEmpty(address))
                throw new ArgumentNullException("El domicilio no puede ser vacio.");

            if (string.IsNullOrEmpty(city))
                throw new ArgumentNullException("El nombre de la ciudad no puede ser vacio.");

            Address = address;
            City = city;
        }

        public void AddPhoneNumber(string phoneNumber)
        {
            if (string.IsNullOrEmpty(phoneNumber))
                throw new ArgumentNullException("El número de teléfono no puede ser vacio.");

            if (phoneNumber.Length < 10)
                throw new FormatException("El teléfono tiene que tener al menos 10 caracteres");

            PhoneNumber = phoneNumber;
        }
    }

    

}
