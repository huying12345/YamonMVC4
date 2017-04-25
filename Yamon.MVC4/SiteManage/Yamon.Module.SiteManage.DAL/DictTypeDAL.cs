
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
using Yamon.Module.SiteManage.Entity;

namespace Yamon.Module.SiteManage.DAL
{
    /// <summary>
    /// SiteManage_DictType实体类
    ///</summary>
    public partial class DictTypeDAL : _DictTypeDAL
    {

        /// <summary>
        /// 获取数据字典
        /// </summary>
        /// <param name="dictTypeId"></param>
        /// <returns></returns>
        public static MyNameValueCollection GetNameValueCollectionByID(string dictTypeId)
        {
            DictTypeDAL dictTypeDal=new DictTypeDAL();
            string cacheKey = dictTypeDal.CacheKeyPrefix + "GetNameValueCollectionByID_" + dictTypeId;
            object obj = CacheHelper.Get(cacheKey);
            if ( obj== null)
            {
                MyNameValueCollection nv = new MyNameValueCollection();
                DictType dictType = dictTypeDal.GetCacheEntityModelByID(dictTypeId);
                if (dictType != null)
                {
                    DictDataDAL dictDataDal = new DictDataDAL();
                    RequestHelper.NameValue.Set("DictTypeID", dictTypeId);
                    List<DictData> dataList = dictDataDal.GetAllEntityList_DictTypeID();
                    foreach (DictData data in dataList)
                    {
                        if (dictType.IsSingleValue != null && dictType.IsSingleValue.Value==1)
                        {
                            nv.Add(data.Name, data.Name);
                        }
                        else
                        {
                            nv.Add(data.Value, data.Name);
                        }
                    }
                }
                CacheHelper.Insert(cacheKey,nv);
                return nv;
            }
            return obj as MyNameValueCollection;
        }
    }
}
