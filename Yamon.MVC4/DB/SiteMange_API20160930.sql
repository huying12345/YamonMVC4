  --�����Ƿ�Ҫ��¼�ֶ�
  alter table SiteManage_API add  NeedUserLogin int 
  GO
  update SiteManage_API set NeedUserLogin=0
  
    --���Ӵ���������
  alter table SiteManage_API add  ErrorCodeParam int 
  GO
  update SiteManage_API set ErrorCodeParam=''