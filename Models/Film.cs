namespace Models
{
    using System;
    using System.Collections.Generic;

    public class Film
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public DateTime ReleaseDate { get; set; }

        public string Synopsis { get; set; }

        public string Language { get; set; }

        public int Budget { get; set; }

        public string Website { get; set; }

        public int RunTime { get; set; }
        
        public Director Director { get; set; }
        
        public IEnumerable<CastMember> Cast { get; set; }

        public int DirectorId { get; set; }
    }
}