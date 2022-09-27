using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_API_Json
{
    public class PostModel
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public string Title { get; set; }

        public string Body { get; set; }

        //public bool IsCorrectInfo(int userId, int id, string tittle, string body)
        //{
        //    if (id == 0)
        //    {
        //        return UserId == userId && Id != 0 && Title == tittle && Body == body;
        //    }
        //    else
        //    {
        //        return UserId == userId && Id == id && Title == tittle && Body == body;
        //    }

        //}
        public override bool Equals(object obj)
        {
            if (obj == null)
            { return false; }
            PostModel post = obj as PostModel;
            if (post == null)
            { return false; }

            return UserId == post.UserId && (Id == post.Id || Id!=0) && Title == post.Title && Body == post.Body;          
        }
        public bool IsResponseBodyEmpty()
        {
            return Id == 0 && UserId == 0 && Title == null && Body == null;
        }
    }
}
