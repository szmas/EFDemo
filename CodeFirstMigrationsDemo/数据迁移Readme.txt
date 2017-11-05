

--------------------生成和运行迁移-----------

#启用迁移

Enable-Migrations

Configuration.cs（配置类） : 此类允许您配置迁移对您的上下文的行为
InitialCreate(初始创建迁移)：这种迁移是因为在启用迁移之前，已经有Code First为我们创建了一个数据库。
此支架迁移中的代码表示已在数据库中创建的对象。

#添加迁移

Add-Migration

Name:AddBlogUrl 

#更新数据库

Update-Database




------------自定义迁移-------------




#添加迁移

Add-Migration  AddPostClass


#修改AddPostClass迁移类的默认内容


#更新数据库  –Verbose 可以看到迁移生成的SQL语句

Update-Database –Verbose #以便您可以看到运行代码第一次迁移的SQL




------------------------数据运动/自定义SQL----------------

#添加迁移
Add-Migration AddPostAbstract


#在AddPostAbstract迁移类里面添加SQl语句


#更新数据库  –Verbose 可以看到迁移生成的SQL语句
Update-Database -Verbose





---------------------迁移到特定版本（包括降级）----------------------


#假设我们希望将数据库迁移到运行我们的AddBlogUrl迁移之后的状态。我们可以使用-TargetMigration开关降级到此迁移。

Update-Database –TargetMigration: AddBlogUrl #这个命令将会运行 AddBlogAbstract and AddPostClass 的 Down 命令

#如果你想回滚一切至空数据库
Update-Database -TargetMigration:$InitialDatabase





-------------------------获取SQL脚本-------------------

#例如我们希望产生的脚本是从一个空数据库（$InitialDatabase）到最新的版本（AddPostAbstract 迁移）;
#（注意：如果你没有指定目标迁移，那么迁移将始终更新至最新版本；如果你没有指定源迁移，那么迁移将以数据库目前状态为初始）

Update-Database -Script -SourceMigration: $InitialDatabase -TargetMigration: AddPostAbstract（指定的数据迁移名称）



-----------------------产生幂等脚本（EF6+）------------------------

从 EF6 开始，如果你使用 –SourceMigration $InitialDatabase， 产生的脚本将是幂等的，幂等脚本意味着无论数据库当前处于什么版本/状态，都能升级至最新版本或指定版本（指定 –TargetMigration），生成的脚本包括检查表 __MigrationsHistory 的逻辑以及只更新之前从未更新的



-----------------------在应用程序启动时自动升级----------------------

　当我们创建一个初始化器的实例时，需要指定 context type（BlogContext）以及 migrations configuration （Configuration）- 这个迁移配置类是在我们启用迁移时生成的 Migrations 目录下增加的


#当我们创建这个初始化器的一个实例时，我们需要指定上下文类型（BlogContext ）和迁移配置（配置） - 
迁移配置是当我们启用Migrations时添加到Migrations文件夹中的类。

Database.SetInitializer(new MigrateDatabaseToLatestVersion<BlogContext, Configuration>());





原文：http://msdn.microsoft.com/en-us/data/jj591621