using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICommentService
    {
        IResult Add(Comment comment);
        IResult Delete(Comment comment);
        IResult Update(Comment comment);
        SuccessDataResult<List<Comment>> GetByPostId(int postId);
        SuccessDataResult<Comment> GetById(int id);
        SuccessDataResult<List<Comment>> GetAll();
    }
    
}
