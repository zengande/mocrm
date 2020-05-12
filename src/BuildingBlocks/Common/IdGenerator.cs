using System;
using System.Collections.Generic;
using System.Text;

namespace BuildingBlocks.Common
{
    public class IdGenerator
    {
        public string GenerateTimeId(string prefix = null)
        {
            var id = new StringBuilder(prefix);
            var now = DateTime.UtcNow;
            
            id.Append(now.ToString("yyyyMMddHHmmssffff"));
            id.Append("");

            return id.ToString();
        }
    }
}
