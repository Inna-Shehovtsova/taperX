using System;
using System.Collections.Generic;
using System.Text;


namespace taperX.Models
{
    
    //[Table("ToDoEvents")]
    public class ToDoEvent
    {
       // [PrimaryKey, AutoIncrement, Column("_id")]
        public string id { get; set; }
        public string title { get; set; }
        public string startIs { get; set; }
        public string endIs { get; set; }
        public string description { get; set; }
    }
}
