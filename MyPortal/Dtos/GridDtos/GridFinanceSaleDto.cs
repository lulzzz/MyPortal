﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyPortal.Interfaces;

namespace MyPortal.Dtos.GridDtos
{
    public class GridFinanceSaleDto : IGridDto
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string StudentName { get; set; }
        public string ProductDescription { get; set; }
        public decimal AmountPaid { get; set; }
        public bool Refunded { get; set; }
        public bool Processed { get; set; }
    }
}