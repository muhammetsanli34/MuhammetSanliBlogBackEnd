using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IPostService
    {
        IResult Add(Post post);
        IResult Delete(Post post);
        IResult Update(Post post);
        IDataResult<List<Post>> GetAll();
        IDataResult<Post> GetById(int id);

    }
}
