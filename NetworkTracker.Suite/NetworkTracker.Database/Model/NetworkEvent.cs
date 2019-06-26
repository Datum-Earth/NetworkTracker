using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkTracker.Database.Model
{
    public class NetworkEvent
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long NetworkEventId { get; set; }
        public virtual EventType EventType { get; set; }
        public string Value { get; set; }
        public DateTimeOffset CreateTime { get; set; }
    }
}
