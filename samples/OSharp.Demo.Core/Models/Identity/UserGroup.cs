using OSharp.Core.Data;
using OSharp.Core.Identity.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSharp.Demo.Models.Identity
{
    /// <summary>
    /// 实体类——角色信息
    /// </summary>
    [Description("认证-角色信息")]
    public class UserGroup : EntityBase<int>, IAudited
    {
        [Required, StringLength(100)]
        public string GroupName { get; set; }

        /// </summary>
        [Required, StringLength(100)]
        public string GroupCode { get; set; }

        public int status { get; set; }

        #region Implementation of ICreatedTime

        /// <summary>
        /// 获取设置 信息创建时间
        /// </summary>
        public DateTime CreatedTime { get; set; }

        #endregion

        #region Implementation of ICreatedAudited

        /// <summary>
        /// 获取或设置 创建者编号
        /// </summary>
        [StringLength(50)]
        public string CreatorUserId { get; set; }

        #endregion

        #region Implementation of IUpdateAutited

        /// <summary>
        /// 获取或设置 最后更新时间
        /// </summary>
        public DateTime? LastUpdatedTime { get; set; }

        /// <summary>
        /// 获取或设置 最后更新者编号
        /// </summary>
        [StringLength(50)]
        public string LastUpdatorUserId { get; set; }

        #endregion
    }
}
