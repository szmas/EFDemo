EntityFramework6中有缓存实现吗？

就目前而言，EntityFramework的缓存只是维护其内部的DbContext，也就是常说的一级缓存。
如果要对EntityFramework的查询结果对象进行缓存，我们就需要使用二级缓存来进行。
常用的一些分布式应用缓存，如memcached或Redis都可以实现。

CodePlex上也提供了一些二级缓存的实例，我们给以通过Nuget直接下载使用，比如下面的这俩个缓存组件： 
EntityFramework.Cache  https://efcache.codeplex.com/