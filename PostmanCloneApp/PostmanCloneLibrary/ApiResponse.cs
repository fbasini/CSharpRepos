using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostmanCloneLibrary;

public class ApiResponse
{
    public string Body { get; set; } = string.Empty;
    public Dictionary<string, IEnumerable<string>> Headers { get; set; } = new();
}
