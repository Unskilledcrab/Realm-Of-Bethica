﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ROB.Web.ViewModels
{
    public class PregenAssignedChildSkillsData
    {
        public int ChildSkillId { get; set; }
        public string ChildSkillName { get; set; }
        public bool IsAssigned { get; set; }
    }
}