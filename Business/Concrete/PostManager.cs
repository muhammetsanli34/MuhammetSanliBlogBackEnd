using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class PostManager : IPostService
    {
        IPostDal _postDal;
        public PostManager(IPostDal postDal)
        {
            _postDal = postDal;
        }

        [SecuredOperation("author")]
        [ValidationAspect(typeof(PostValidator))]
        public IResult Add(Post post)
        {
            _postDal.Add(post);
            return new SuccessResult();
        }

        [SecuredOperation("author")]
        public IResult Delete(Post post)
        {
            _postDal.Delete(post);
            return new SuccessResult();
        }

        public IDataResult<List<Post>> GetAll()
        {
            
            return new SuccessDataResult<List<Post>>(_postDal.GetAll());
        }

        public IDataResult<Post> GetById(int id)
        {
            return new SuccessDataResult<Post>(_postDal.Get(p => p.Id == id));
        }

        [SecuredOperation("author")]
        public IResult Update(Post post)
        {
            _postDal.Update(post);
            return new SuccessResult();
        }        
    }
}
