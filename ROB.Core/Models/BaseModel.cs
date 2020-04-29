using System;
using System.Collections.Generic;
using System.Text;

namespace ROB.Core.Models
{
    public abstract class BaseModel
    {
        /// <summary>
        /// Primary key of all models
        /// </summary>
        public int Id { get; set; }
    }
}
