using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class UserSetting : IEntityBase
    {
        public int Id { get; set; }
        // 0 Small, Medium, Large
        public int ColumnSize { get; set; }
        // 0 Day, Night
        public int Theme { get; set; }
        public bool Controls { get; set; }
    }
}
