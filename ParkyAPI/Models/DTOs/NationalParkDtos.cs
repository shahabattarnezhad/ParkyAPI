﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkyAPI.Models.DTOs
{
    public class NationalParkDtos
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string State { get; set; }
        public DateTime Created { get; set; }
        public DateTime Established { get; set; }
    }
}