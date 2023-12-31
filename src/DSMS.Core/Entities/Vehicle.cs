﻿using DSMS.Core.Common;
using DSMS.Core.Entities.Identity;
using DSMS.Core.Enums;

namespace DSMS.Core.Entities
{
    public class Vehicle : BaseEntity
    {
        public ApplicationUser Instructor { get; set; }

        public Category Category { get; set; }

        public string Description { get; set; }

        public byte[] Photo { get; set; }
    }
}
