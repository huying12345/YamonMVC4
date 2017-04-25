  alter table SiteManage_Config add Module nvarchar(50)
  GO
  Update SiteManage_Config set Module='SiteManage'
  GO
  alter table SiteManage_APILogs add IP nvarchar(50)
  GO
  alter table SiteManage_Applications add AllowDomain nvarchar(500)