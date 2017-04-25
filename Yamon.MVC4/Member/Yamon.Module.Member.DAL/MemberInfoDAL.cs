
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Yamon.Framework.DBUtility;
using System.Collections;
using Yamon.Framework.Common.DataBase;
using Yamon.Framework.Common;
using Yamon.Framework.Common.IO;
using System.IO;
using System.Linq.Expressions;
using Yamon.Framework.DAL;
using Yamon.Module.Member.Entity;

namespace Yamon.Module.Member.DAL
{
    /// <summary>
    /// 会员信息实体类
    ///</summary>
    public partial class MemberInfoDAL : _MemberInfoDAL
    {

        /// <summary>
        /// 查询会员信息
        /// </summary>
        /// <returns></returns>
        public DataRow MemberInfoSelect(string id)
        {
            try
            {
                string sql = "select*from [Member_MemberInfo] as info inner join (select MemberGradeId as mgid,GradeName,DiscountPercent from Member_MemberGrade) as grade on info.MemberGradeId=grade.mgid where [MemberNo] =? OR MobileNo=?";
                DataRow dr = DbHelper.GetConn("UCenter").ExecuteDataRowSqlEx(sql, id, id);
                return dr;
            }
            catch
            {
            }
            return null;
        }

        public string MenberLogin(string phone, string password)
        {
            string sql = "select top 1  MemberNo  From [Member_MemberInfo] where MobileNo=? and MemberPassword=?";
            string str = DbHelper.GetConn("UCenter").ExecuteStringSqlEx(sql, phone, password);
            return str;
        }

        public int GetMemberMaxID()
        {
            string sql = "select MAX(MemberInfoId) as MemberInfoId  from [Member_MemberInfo]";
            string str = DbHelper.GetConn("UCenter").ExecuteStringSqlEx(sql);
            return DataConverter.ToInt(str);
        }

        public override MemberInfo GetEditFormDefaultValue(MemberInfo model)
        {

            model.MemberPassword = "**********";
            return base.GetEditFormDefaultValue(model);
        }


    }
}
