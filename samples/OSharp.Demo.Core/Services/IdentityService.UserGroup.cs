// -----------------------------------------------------------------------
//  <copyright file="IdentityService.User.cs" company="OSharp开源团队">
//      Copyright (c) 2014-2015 OSharp. All rights reserved.
//  </copyright>
//  <last-editor>郭明锋</last-editor>
//  <last-date>2015-03-24 17:25</last-date>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

using Microsoft.AspNet.Identity;

using OSharp.Core.Identity;
using OSharp.Core.Mapping;
using OSharp.Demo.Dtos.Identity;
using OSharp.Demo.Models.Identity;
using OSharp.Utility.Data;
using OSharp.Utility.Extensions;


namespace OSharp.Demo.Services
{
    public partial class IdentityService
    {
        #region Implementation of IIdentityContract

        /// <summary>
        /// 获取 用户信息查询数据集
        /// </summary>
        public IQueryable<UserGroup> UserGroup
        {
            get { return UserGroupRepository.Entities; }
        }

        /// <summary>
        /// 添加用户信息信息
        /// </summary>
        /// <param name="dtos">要添加的用户信息DTO信息</param>
        /// <returns>业务操作结果</returns>
        public OperationResult AddUserGroups(params UserGroupInputDto[] dtos)
        {
            return UserGroupRepository.Insert(dtos,
               dto =>
               {
                   if (!string.IsNullOrEmpty(dto.GroupCode))
                   {
                       if (UserGroupRepository.CheckExists(m => m.GroupCode == dto.GroupCode))
                       {
                           throw new Exception("用户组中名称为“{0}”的用户组编码已存在，不能重复添加。".FormatWith(dto.GroupCode));
                       }
                   }
               },
               (dto, entity) =>
               {
                   return entity;
               });
        }

        /// <summary>
        /// 更新用户信息信息
        /// </summary>
        /// <param name="dtos">包含更新信息的用户信息DTO信息</param>
        /// <returns>业务操作结果</returns>
        public OperationResult EditUserGroups(params UserGroupInputDto[] dtos)
        {
            return UserGroupRepository.Update(dtos,
               (dto, entity) =>
               {
                   if (!string.IsNullOrEmpty(dto.GroupCode))
                   {
                       if (UserGroupRepository.CheckExists(m => m.GroupCode == dto.GroupCode))
                       {
                           throw new Exception("用户组中名称为“{0}”的用户组编码已存在，不能重复添加。".FormatWith(dto.GroupCode));
                       }
                   }
               },
               (dto, entity) =>
               {
                   return entity;
               });
        }

        /// <summary>
        /// 删除用户信息信息
        /// </summary>
        /// <param name="ids">要删除的用户信息编号</param>
        /// <returns>业务操作结果</returns>
        public async Task<OperationResult> DeleteUserGroups(params int[] ids)
        {
            OperationResult result = UserGroupRepository.Delete(ids, null,
                entity =>
                {
                    //先删除所有用户相关信息
                    return entity;
                });
            return await Task.FromResult(result);
        }
        #endregion
    }
}