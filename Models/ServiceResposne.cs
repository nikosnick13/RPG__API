using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


//ΑΥΤΟ ΕΙΝΑΙ ΕΝΑ SERVCES ΠΟΥ ΕΙΝΙΑ

namespace RPG__API.Models
{
    public class ServiceResposne<T>
    {
        public T? Data { get; set; }
        public bool Success  { get; set; }
        public string Massage { get; set; } =  string.Empty;

        //public List<string>? Errors { get; set;}
    }
}