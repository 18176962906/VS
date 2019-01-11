using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using WebApplication1.DAL;

namespace WebApplication1.Models
{
    public class MusicBusiness
    {
        public List<Music> GetMusicList()
        {
            //实例化上下文
            using (MusicDAL m = new MusicDAL())
            {

                var list = m.Musics.ToList();
                return list;
            }
        }
        public void Addm(Music m)
        {
            using (var db = new MusicDAL())
            {
                db.Musics.Add(m);
                db.SaveChanges();
            }
        }

        public Music Query(int id)
        {
            using (var db = new MusicDAL())
            {
                Music m = db.Musics.Find(id);
                return m;
            }
        }
    }
}