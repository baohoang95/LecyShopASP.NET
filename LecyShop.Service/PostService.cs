using System;
using System.Collections.Generic;
using LecyShop.Data.Infrastructure;
using LecyShop.Data.Repositories;
using LecyShop.Model.Models;
using System.Linq;

namespace LecyShop.Service
{
    public interface IPostService
    {
        void Add(Post post);

        void Update(Post post);

        // int id -> Post id
        void Delete(int id);

        IEnumerable<Post> GetAll();

        IEnumerable<Post> GetAllPaging(int page, int pageSize, out int totalRow);
        /// <summary>
        /// Lay tat ca post theo category
        /// </summary>
        /// <param name="categoryId"></param>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <param name="totalRow"></param>
        /// <returns></returns>
        IEnumerable<Post> GetAllByCategoryPaging( int categoryId, int page, int pageSize, out int totalRow);
        Post GetById(int id);

        IEnumerable<Post> GetAllByTagPaging(string tag, int page, int pageSize, out int totalRow);

        void SaveChanges();
    }

    /// <summary>
    /// Các nghiệp vụ liên quan đến Post
    /// </summary>
    public class PostService : IPostService
    {
        IPostRepository _postRepository;
        IUnitOfWork _unitOfWork;

        /// <summary>
        /// Hàm tạo 
        /// </summary>
        /// <param name="postRepository"></param>
        /// <param name="unitOfWork"></param>
        public PostService(IPostRepository postRepository, IUnitOfWork unitOfWork)
        {
            this._postRepository = postRepository;
            this._unitOfWork = unitOfWork;
        }

        public void Add(Post post)
        {
            _postRepository.Add(post);
        }

        public void Delete(int id)
        {
            _postRepository.Delete(id);
        }

        /// <summary>
        /// Lấy thông tin và Danh mục tương ứng của bài viết (post)
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Post> GetAll()
        {
            return _postRepository.GetAll(new string[] { "PostCategory" });
        }

        public IEnumerable<Post> GetAllByCategoryPaging(int categoryId, int page, int pageSize, out int totalRow)
        {
            return _postRepository.GetMultiPaging(x => x.Status && x.CategoryID == categoryId, out totalRow, page, pageSize , new string[] { "PostCategory" });
        }

        public IEnumerable<Post> GetAllByTagPaging(string tag, int page, int pageSize, out int totalRow)
        {
            //TODO: Select all post by tag
            //Hỗ trợ phân trang , get all tag
            //15/09/2020
            return _postRepository.GetAllByTag(tag, page, pageSize ,out totalRow);

        }

        /// <summary>
        /// Lấy tất cả trang có status  = true
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <param name="totalRow"></param>
        /// <returns></returns>
        public IEnumerable<Post> GetAllPaging(int page, int pageSize, out int totalRow)
        {
            return _postRepository.GetMultiPaging(x => x.Status, out totalRow, page, pageSize);
        }

        /// <summary>
        /// Lấy bài viết qua id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Post GetById(int id)
        {
            return _postRepository.GetSingleById(id);
        }

        /// <summary>
        /// Commit rồi mới gọi đến DB  
        /// </summary>
        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public void Update(Post post)
        {
            _postRepository.Update(post);
        }
    }
}