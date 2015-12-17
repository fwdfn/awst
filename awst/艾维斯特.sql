if exists(select * from sysdatabases where name='awst')
begin
drop database awst
end

create database awst
on primary
(
  name='awst.mdf',
  filename='D:\DataBases\awst.mdf',
  size=50Mb,
  maxsize=unlimited,
  filegrowth=10%
)
log on
(
  name='awst.ldf',
  filename='D:\DataBases\awst.ldf',
  size=20Mb,
  maxsize=unlimited,
  filegrowth=10% 
)
go

--管理员表
if exists(select * from sysobjects where name='tb_admin')
begin
drop table tb_admin
end

create table tb_admin
(
 id int identity,
 name nvarchar(10) not null,  --姓名
 pwd nvarchar(10) not null,   --密码
 loginTime datetime default getdate(),   --datetime时间数据类型   登陆时间
 loginCount int default 0,    --登陆次数
 note nvarchar(100)           --备注 
)
select * from tb_admin
insert into tb_admin(name,pwd,loginTime) values('aaa','123',GETDATE())

--栏目表
--字段：父编号,是否隐藏,序号,图片路径,内容,栏目地址,创建时间
if exists(select * from sysobjects where name='tb_menu')
begin
drop table tb_menu
end
create table tb_menu
(
 id int identity primary key,   --编号
 title nvarchar(10) not null,   --标题
 pid int not null,              --父编号  
 isHide bit default 0,          --是否隐藏       0为显示，1为隐藏
 sort int not null,             --序号
 picPath nvarchar(100),         --图片路径 
 content nvarchar(max),         --内容
 linkUrl nvarchar(100),         --栏目地址
 cdate datetime default getdate() --创建时间
)
go
select * from tb_menu
select * from tb_backgroundMenu
select * from tb_menu

insert into tb_menu values('关于我们',0,0,1,'','','AboutUS.aspx?id=1&pid=0',GETDATE())
insert into tb_menu values('公司荣誉',1,0,1,'','','AboutUS.aspx?id=2&pid=1',GETDATE())
insert into tb_menu values('公司简介',1,0,2,'','','AboutUS.aspx?id=3&pid=1',GETDATE())
insert into tb_menu values('企业文化',1,0,3,'','','AboutUS.aspx?id=4&pid=1',GETDATE())
select * from tb_menu
insert into tb_menu values('新闻中心',0,0,2,'','','News.aspx?id=5&pid=0',GETDATE())
insert into tb_menu values('行业新闻',5,0,1,'','','News.aspx?id=6&pid=5',GETDATE())
insert into tb_menu values('公司新闻',5,0,2,'','','News.aspx?id=7&pid=5',GETDATE())
insert into tb_menu values('最新促销',5,0,3,'','','News.aspx?id=8&pid=5',GETDATE())

insert into tb_menu values('产品中心',0,0,3,'','','Product.aspx?id=9&pid=0',GETDATE())
insert into tb_menu values('售后与服务',0,0,4,'','','AboutUS.aspx?id=10&pid=0',GETDATE())
insert into tb_menu values('人才招聘',0,0,5,'','','AboutUS.aspx?id=11&pid=0',GETDATE())
insert into tb_menu values('留言板',0,0,6,'','','Message.aspx?id=12&pid=0',GETDATE())
insert into tb_menu values('联系我们',0,0,7,'','','AboutUS.aspx?id=13&pid=0',GETDATE())
insert into tb_menu values('',0,0,1,'','','',GETDATE())
update tb_menu set linkUrl='AboutUS.aspx?node=service' where id=10
select * from tb_menu where pid=5
TRUNCATE TABLE tb_menu

--后台栏目表
if exists(select * from sysobjects where name='tb_backgroundMenu')
begin 
drop table tb_backgroundMenu
end 
create table tb_backgroundMenu
(
 id int identity primary key,
 title nvarchar(20) not null,
 pid int not null,
 sort int not null,
 linkurl nvarchar(50),
 cdate datetime default getdate()
)
go
select * from tb_backgroundMenu
select * from tb_menu
--关于我们
insert into tb_backgroundMenu(title,pid,sort) values('关于我们',0,1)
insert into tb_backgroundMenu values('类别管理',1,1,'column.aspx?id=1',getdate())
insert into tb_backgroundMenu(title,pid,sort) values('公司荣誉',1,2)
insert into tb_backgroundMenu(title,pid,sort) values('公司简介',1,3)
insert into tb_backgroundMenu(title,pid,sort) values('企业文化',1,4)
--新闻中心
insert into tb_backgroundMenu(title,pid,sort) values('新闻中心',0,2)
insert into tb_backgroundMenu values('类别管理',6,1,'column.aspx?id=5',getdate())
insert into tb_backgroundMenu values('信息管理',6,2,'NewsFile/News.aspx?id=5',getdate())
insert into tb_backgroundMenu(title,pid,sort) values('行业新闻',6,3)
--产品中心
insert into tb_backgroundMenu(title,pid,sort) values('产品中心',0,3)
insert into tb_backgroundMenu values('类别管理',10,1,'ProductFile/ProductType.aspx',getdate())
insert into tb_backgroundMenu values('信息管理',10,2,'ProductFile/Product.aspx',getdate())
select * from tb_backgroundMenu
--广告位管理
insert into tb_backgroundMenu values('广告位管理',0,4,'',getdate())
insert into tb_backgroundMenu values('首页广告位',13,1,'AdvertisingFile/Advertising.aspx',getdate())
insert into tb_backgroundMenu values('子页广告位',13,2,'AdvertisingFile/Advertising.aspx',getdate())
--版本信息
insert into tb_backgroundMenu values('基本信息管理',0,5,'',getdate())
insert into tb_backgroundMenu values('网站配置',16,1,'CopyRight.aspx',getdate())
insert into tb_backgroundMenu values('首页栏目',0,6,'',getdate())
insert into tb_backgroundMenu values('首页栏目管理',18,1,'column.aspx',getdate())
select * from tb_backgroundMenu
update tb_backgroundMenu set pid=18 where id =19


select * from tb_product
select * from tb_backgroundMenu

select * from tb_menu where pid=5 order by sort
select * from tb_backgroundMenu
select * from tb_menu

if exists(select * from sysobjects where name='tb_newsInfo')
begin
drop table tb_newsInfo
end
create table tb_newsInfo
(
 id int identity primary key,    --编号
 title nvarchar(200) not null,   --标题
 pid int constraint FK_ID foreign key references tb_menu(id),  --父id
 ishide bit default 0,      --是否隐藏    
 isrecommand bit default 0,  --是否推荐
 ishot bit default 0,   --是否热点
 isverify bit default 0,  --是否审核
 isindex bit default 0,   --是否首页
 sort int default 1,    --排序
 content nvarchar(max) null,  --内容
 titlecolor nvarchar(20),  --标题颜色
 picpath nvarchar(200),  --图片路径               
 source nvarchar(30),   --新闻来源
 clicks int default 0,   --点击数
 cdate datetime default getdate() --创建时间
)
select * from tb_backgroundMenu
select * from tb_newsInfo
select * from tb_menu where pid=5
insert into tb_newsInfo(title,pid,sort,content) values('立足产业结构1',6,1,'asdfas')
insert into tb_newsInfo(title,pid,sort,content) values('立足产业结构2',6,1,'asdfas')
insert into tb_newsInfo(title,pid,sort,content) values('立足产业结构3',21,1,'asdfas')
insert into tb_newsInfo(title,pid,sort,content) values('产业结构4',20,1,'asdfas')
update tb_newsInfo set isrecommand=1 where id=1
update tb_newsInfo set source='外部新闻' where id=3
delete tb_newsInfo where id in(3)
update tb_backgroundMenu set linkurl='News.aspx?id=5' where title='信息管理'
update tb_backgroundMenu set linkurl='ProductFile/ProductType.aspx' where id=11
select * from tb_backgroundMenu


select * from tb_newsInfo where isverify=1 and pid=6 order by id
select * from tb_newsInfo
select * from tb_menu
--6:行业新闻   20公司新闻  21：最新促销
select * from tb_newsInfo where isverify=0 and pid=20 and title like '%4%' order by id
update tb_newsInfo set picpath='../../Upload/a.jpg' where id=10
update tb_newsInfo set picpath='' where id=2

if exists(select * from sysobjects where name='tb_productColumn')
begin
drop table tb_productColumn
end
create table tb_productColumn
(
 id int identity primary key,
 title nvarchar(30) not null,
 pid int not null,
 sort int default 0,
 ishide bit default 0,
 cdate datetime default getdate(),
 note nvarchar(100)
)
go
select * from tb_backgroundMenu
select * from tb_productColumn
insert into tb_productColumn(title,pid,sort) values('酶标仪和洗板机系列',0,1)
insert into tb_productColumn(title,pid,sort) values('超微量分光光度计系列',0,2)
insert into tb_productColumn(title,pid,sort) values('酶标仪系列',1,1)
insert into tb_productColumn(title,pid,sort) values('洗板机系列',1,2)
insert into tb_productColumn(title,pid,sort) values('超微量分光光度计',2,1)
insert into tb_productColumn(title,pid,sort) values('超微量核酸分析仪',2,2)
insert into tb_productColumn(title,pid,sort) values('超微量核酸分析仪2',2,3)
insert into tb_productColumn(title,pid,sort) values('超微量核酸分析仪3',2,4)


if exists(select * from sysobjects where name='tb_product')
begin 
drop table tb_product
end
create table tb_product
(
 id int identity primary key,
 name nvarchar(50) not null,
 pid int constraint FK_PRODUCT_ID foreign key references tb_productColumn(id),
 sort int,
 hots int default 0,         --要不要添加热点
 picpath nvarchar(100),       --如何上传多张图
 cdate datetime default getdate(),
 remark nvarchar(100)        --产品表要不要添加备注
)
go
select * from tb_productColumn
select * from tb_product
insert into tb_product values('产品1',3,1,0,'',GETDATE(),'')
insert into tb_product values('产品2',3,2,0,'',GETDATE(),'')
insert into tb_product values('产品3',3,3,0,'',GETDATE(),'')
insert into tb_product values('产品3',4,1,0,'',GETDATE(),'')
insert into tb_product values('产品3',4,2,0,'',GETDATE(),'')
insert into tb_product values('产品3',5,1,0,'',GETDATE(),'')
insert into tb_product values('产品3',6,1,0,'',GETDATE(),'')
insert into tb_product values('产品3',6,2,0,'',GETDATE(),'')
insert into tb_product values('产品3',6,3,0,'',GETDATE(),'')
insert into tb_product values('产品3',6,4,0,'',GETDATE(),'')
insert into tb_product values('产品3',6,5,0,'',GETDATE(),'')
insert into tb_product values('产品3',6,6,0,'',GETDATE(),'')
insert into tb_product values('产品3',6,7,0,'',GETDATE(),'')
select * from tb_product where pid in(select id from tb_productColumn where pid=2)
select * from tb_product where pid in(3,4)
select * from tb_product where  name  like '%1%'
--公司基本信息表
if exists(select * from sysobjects where name='tb_companyInfo')
begin 
drop table tb_companyInfo
end
create table tb_companyInfo
( 
 id int identity not null,
 name nvarchar(20) not null,
 title nvarchar(20) not null,
 website nvarchar(50),
 address nvarchar(40),
 cellphone nvarchar(20),
 phone nvarchar(20), 
 fax varchar(20),
 qq varchar(20),
 email nvarchar(20),
 support nvarchar(15),
 copyright nvarchar(20),
 keywords nvarchar(100),
 webdescription nvarchar(300)
)
go
select * from tb_companyInfo
insert into tb_companyInfo values('武汉艾维斯特科技有限公司','武汉艾维斯特科技有限公司','http://www.avist.com.cn/','武汉市洪山区雄楚大街450号','137-07128722','027-87166527','027-87530722','1740864522','avist_wh@163.com','仙桃赵斌','武汉艾维斯特科技有限公司','艾维斯特、武汉艾维斯特科、分析仪器、实验设备、环保仪器、教学设备','武汉艾维斯特科技有限公司是经营分析仪器、实验设备、环保仪器、教学设备、各种检测仪器设备以及相应的配件和耗材的专业公司。我公司是杭州奥盛仪器有限公司华中办事处、...')

--首页图片表
if exists(select * from sysobjects where name='tb_img')
begin 
drop table tb_img
end
create table tb_img
(
 id int identity primary key,
 title nvarchar(20),
 pid int,    
 sort int,
 ishide bit default 0,
 picpath nvarchar(100),
 cdate datetime default getdate() ,
)
go
--pid为0时为首页图片,pid为1时为子页图片
select * from tb_img
insert into tb_img values('Upload/1.jpg',0,1,0,'../../Upload/1.jpg',GETDATE())
insert into tb_img values('Upload/2.jpg',0,2,0,'../../Upload/2.jpg',GETDATE())
insert into tb_img values('Upload/3.jpg',0,3,0,'../../Upload/3.jpg',GETDATE())
insert into tb_img values('Upload/4.jpg',0,4,0,'../../Upload/4.jpg',GETDATE())
insert into tb_img values('Upload/5.jpg',0,5,0,'../../Upload/5.jpg',GETDATE())

delete tb_img where id in(1,2)
select * from tb_img where pid=0 and ishide=0

if exists(select * from sysobjects where name='tb_message')
begin 
drop table tb_message
end
create table tb_message
(
 id int identity,
 title nvarchar(30),
 username nvarchar(10),
 companyName nvarchar(20),
 phone nvarchar(20),
 email nvarchar(20),
 content nvarchar(100)
)
insert into tb_message values('标题1','张三','艾维斯特','110','abc@qq.com','田园')
select * from tb_message

