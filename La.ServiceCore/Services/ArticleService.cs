﻿using La.Infra.Attribute;
using SqlSugar;
using System;
using La.Model;
using La.Model.System;
using La.Model.System.Dto;
using La.Repository;
using La.Service.System.IService;

namespace La.Service.System
{
    /// <summary>
    /// 
    /// </summary>
    [AppService(ServiceType = typeof(IArticleService), ServiceLifetime = LifeTime.Transient)]
    public class ArticleService : BaseService<Article>, IArticleService
    {
        /// <summary>
        /// 查询文章管理列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<ArticleDto> GetList(ArticleQueryDto parm)
        {
            var predicate = Expressionable.Create<Article>();

            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Title), m => m.Title.Contains(parm.Title));
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.IsStatus), m => m.IsStatus == parm.IsStatus);

            //搜索条件查询语法参考Sqlsugar
            var response = Queryable()
                .Includes(x => x.ArticleCategoryNav) //填充子对象
                .Where(predicate.ToExpression())
                .OrderBy(x => x.CreateTime, OrderByType.Desc)
                .ToPage<Article, ArticleDto>(parm);

            return response;
        }

        /// <summary>
        /// 查询我的文章列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<ArticleDto> GetMyList(ArticleQueryDto parm)
        {
            var predicate = Expressionable.Create<Article>();

            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Title), m => m.Title.Contains(parm.Title));
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.IsStatus), m => m.IsStatus == parm.IsStatus);
            predicate = predicate.AndIF(parm.BeginTime != null, m => m.CreateTime >= parm.BeginTime);
            predicate = predicate.AndIF(parm.EndTime != null, m => m.CreateTime <= parm.EndTime);
            predicate = predicate.And(m => m.UserId == parm.UserId);

            var response = Queryable()
                .Includes(x => x.ArticleCategoryNav)
                .Where(predicate.ToExpression())
                .ToPage<Article, ArticleDto>(parm);

            return response;
        }

        /// <summary>
        /// 修改文章管理
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateArticle(Article model)
        {
            var response = Update(w => w.Cid == model.Cid, it => new Article()
            {
                Title = model.Title,
                Content = model.Content,
                IsStatus = model.IsStatus,
                Tags = model.Tags,
                UpdateTime = DateTime.Now,
                CoverUrl = model.CoverUrl,
                CategoryId = model.CategoryId,
                FmtType = model.FmtType,
                IsPublic = model.IsPublic,
            });
            return response;
        }
    }
}