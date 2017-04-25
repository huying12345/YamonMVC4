  --增加是否要登录字段
  alter table SiteManage_API add  NeedUserLogin int 
  GO
  update SiteManage_API set NeedUserLogin=0
  
    --增加错误码配置
  alter table SiteManage_API add  ErrorCodeParam int 
  GO
  update SiteManage_API set ErrorCodeParam=''