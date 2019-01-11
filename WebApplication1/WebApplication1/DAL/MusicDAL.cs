namespace WebApplication1.DAL
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using WebApplication1.Models;

    public class MusicDAL : DbContext
    {

        public virtual DbSet<Music>Musics { get; set; }



    }


}