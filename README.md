# 封装了工作中常用命令

```csharp
USAGE:
    Custom.CLI.dll [OPTIONS] <COMMAND>

OPTIONS:
    -h, --help       Prints help information
    -v, --version    Prints version information

COMMANDS:
    gen    生成测试数据(手机号、雪花ID、身份证、时间戳等)
    len    字符串长度
    reg    正则匹配
    imp    励志短句
    dc     日期转换时间戳
    tc     时间戳转换日期
    joc    剪贴板中JSON转换C#对象
    jv     剪贴板中JSON格式化
    sv     剪贴板中换行使用逗号拼接
```

* `jv`命令将刚复制的json字符串（可以含转义），去除转义并格式化
* `sv`命令将复制的多行数据用英文逗号','拼接，主要用于SQL查询in语法