using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SunRise.HOSP.MONITOR.Util;

namespace SunRise.HOSP.MONITOR.Entity.SystemManage
{
    [Table("SysMenuAuthorize")]
    public class MenuAuthorizeEntity : BaseCreateEntity
    {
        [JsonConverter(typeof(StringJsonConverter))]
        public long? MenuId { get; set; }

        [JsonConverter(typeof(StringJsonConverter))]
        public long? AuthorizeId { get; set; }

        public int? AuthorizeType { get; set; }

        [NotMapped]
        public string AuthorizeIds { get; set; }
    }
}
