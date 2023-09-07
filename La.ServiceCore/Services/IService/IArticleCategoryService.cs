using System.Collections.Generic;
using La.Model;
using La.Model.Dto;
using La.Model.System;

namespace La.Service.System.IService
{
    public interface IArticleCategoryService : IBaseService<ArticleCategory>
    {
        PagedInfo<ArticleCategory> GetList(ArticleCategoryQueryDto parm);
        List<ArticleCategory> GetTreeList(ArticleCategoryQueryDto parm);
        int AddArticleCategory(ArticleCategory parm);
    }
}
