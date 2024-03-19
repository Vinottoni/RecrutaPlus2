using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Safety.Application.ViewModels
{
    public class AppLoggerViewModel
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public string Template { get; set; }
        public string Level { get; set; }
        public DateTime TimeStamp { get; set; }
        public string Exception { get; set; }
        public string Properties { get; set; }
    }
}
