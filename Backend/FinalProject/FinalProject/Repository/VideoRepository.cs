using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProject.Repository
{
    public class VideoRepository : Repository<Video>, IVideoRepository
    {
        public List<Video> GetVideoBySubject(int id)
        {
            return this.context.Videos.Where(x => x.SubjectId == id).ToList();
        }
    }
}