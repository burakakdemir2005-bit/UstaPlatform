﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UstaPlatform.Domain.Models
{
    public class Vatandas
    {
        public Guid Id { get; init; } = Guid.NewGuid();
        public string AdSoyad { get; init; } = string.Empty;
        public string Adres { get; init; } = string.Empty;
    }
}
