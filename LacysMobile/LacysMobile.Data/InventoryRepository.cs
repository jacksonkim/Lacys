﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using LacysMobile.Models;

namespace LacysMobile.Data
{
    public class InventoryRepository : BaseRepository<Inventory>
    {
        public InventoryRepository(DbContext context)
            : base(context)
        {
        }
    }
}