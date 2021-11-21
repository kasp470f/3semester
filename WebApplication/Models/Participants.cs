﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models
{
    public class Participants
    {
        public int Id { get; set; }
        public float Distance { get; set; }
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:H:mm}", ApplyFormatInEditMode = true)]
        public DateTime Time { get; set; }


    }
}
