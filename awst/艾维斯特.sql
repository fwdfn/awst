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
insert into tb_menu values('关于我们',0,0,1,'','','',GETDATE())
insert into tb_menu(title,pid,sort) values('公司荣誉',1,1)
insert into tb_menu(title,pid,sort) values('公司简介',1,2)
insert into tb_menu(title,pid,sort) values('企业文化',1,3)
insert into tb_menu(title,pid,sort) values('公司新闻',5,2)
insert into tb_menu(title,pid,sort) values('最新促销',5,3)
update tb_menu set isHide=1 where id=4
update tb_menu set pid=5 where title='行业新闻'
select * from tb_menu where pid=5

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
 linkurl nvarchar(30),
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
insert into tb_backgroundMenu values('信息管理',6,2,'News.aspx?id=5',getdate())
insert into tb_backgroundMenu(title,pid,sort) values('行业新闻',6,3)
--产品中心
insert into tb_backgroundMenu(title,pid,sort) values('产品中心',0,3)
insert into tb_backgroundMenu values('类别管理',10,1,'ProductFile/ProductList.aspx',getdate())
select * from tb_backgroundMenu
update tb_backgroundMenu set linkurl='ProductFile/ProductList.aspx' where id=11


select * from tb_menu where pid=5 order by sort
select * from tb_backgroundMenu


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


select * from tb_newsInfo where isverify=1 and pid=6 order by id
select * from tb_newsInfo
select * from tb_menu
--6:行业新闻   20公司新闻  21：最新促销
select * from tb_newsInfo where isverify=0 and pid=20 and title like '%4%' order by id
update tb_newsInfo set picpath='../Upload/a.jpg' where id=10
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
insert into tb_productColumn(title,pid) values('酶标仪和洗板机系列',0)
insert into tb_productColumn(title,pid) values('超微量分光光度计系列',0)
insert into tb_productColumn(title,pid) values('酶标仪系列',1)
insert into tb_productColumn(title,pid) values('洗板机系列',1)
insert into tb_productColumn(title,pid) values('超微量分光光度计',2)
insert into tb_productColumn(title,pid) values('超微量核酸分析仪',2)
